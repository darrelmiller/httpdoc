using System.Linq;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;

namespace HttpDocLib;

public class OpenApiDocWriter
{
    private readonly HttpHtmlWriter writer;
    private readonly OpenApiDocument hostDocument;

    public OpenApiDocWriter(TextWriter wr, OpenApiDocument hostDocument)
    {
        this.writer = new HttpHtmlWriter(wr);
        this.hostDocument = hostDocument;
    }

    public void CreateHttpDoc(string path, OpenApiPathItem pathItem, OperationType operationType, OpenApiOperation operation)
    {
        writer.WriteHtml(() =>
        {
            writer.WriteHead(operation.Summary);
            writer.WriteBody(() =>
            {
                writer.WriteArticle(() =>
                {
                    BuildRequestOverview(operation);
                    BuildHttpRequest(path, pathItem, operationType, operation);
                    BuildParameters(pathItem, operation);
                    if (operation.RequestBody != null)
                    {
                        BuildRequestBody(operation);
                    }
    ;
                    BuildResponses(operation);
                });
            });
        });
    }

    /// <summary>
    /// This section provides a human readable description of the behavior of the HTTP request.
    /// </summary>
    /// <param name="operation"></param>
    private void BuildRequestOverview(OpenApiOperation operation)
    {
        writer.WriteSection("requestOverview", () =>
        {
            writer.WriteRequestSummary(operation.Summary ?? operation.OperationId ?? "");
            writer.WriteRequestDescription(operation.Description);
        });
    }

    /// <summary>
    /// This section provides a complete HTTP request example that can be copy/pasted into a tool like REST Client
    /// </summary>
    /// <param name="path"></param>
    /// <param name="pathItem"></param>
    /// <param name="operationType"></param>
    /// <param name="operation"></param>
    private void BuildHttpRequest(string path, OpenApiPathItem pathItem, OperationType operationType, OpenApiOperation operation)
    {
        writer.WriteSection("http", () =>
            {
                writer.WriteTag("h3", "HTTP Request");

                writer.WriteBlock("pre", HttpHtmlWriter.CSS.HttpExample, (wr) =>
                {
                    WriteHttpMessage(path, pathItem, operationType, operation);
                });
            });
    }

    private void WriteHttpMessage(string path, OpenApiPathItem pathItem, OperationType operationType, OpenApiOperation operation)
    {
        var uriTemplate = CreateUriTemplate(path, pathItem, operation);
        writer.WriteRequestLine(operationType.ToString().ToUpperInvariant(), uriTemplate, "HTTP/1.1");
        if (hostDocument != null && hostDocument.Servers.Any())
        {
            var server = hostDocument.Servers.First();
            var url = new Uri(server.Url);
            writer.WriteHeaderLine("host", url.Host + ":" + url.Port);
        }
        // Get list of media types from operation responses
        var mediaTypes = operation.Responses
                            .SelectMany(static x => x.Value.Content.Keys)
                            .Distinct()
                            .ToArray();
        if (mediaTypes.Any())
        {
            writer.WriteHeaderLine("accept", mediaTypes.Aggregate((x, y) => $"{x},{y}"));
        }
        if (operation.RequestBody != null)
        {
            var selectedContent = operation.RequestBody.Content.First();
            writer.WriteHeaderLine("content-type", selectedContent.Key);
            WriteBody(selectedContent.Value);
        }
    }

    private void WriteBody(OpenApiMediaType mediaType)
    {
        var allExamples = mediaType.GetAllExamples();
        if (allExamples.Any())
        {
            var example = allExamples.First().ConvertToString();
            writer.WriteRequestBody(example);
        }
        else
        {
            if (mediaType.Schema != null)
            {
                var example = mediaType.Schema.ConvertToExample();
                writer.WriteRequestBody(example);
            }
            else
            {
                writer.WriteRequestBody("{ \"example\": \"Example goes here\" }");
            }
        }
    }

    private void BuildParameters(OpenApiPathItem pathItem, OpenApiOperation operation)
    {
        var allParameters =  pathItem.GetAllParameters(operation);
        if (!allParameters.Any())
        {
            return;
        }

        writer.WriteBlock("dl", "parameters", (wr) =>
        {
            writer.WriteTag("h3", "Parameters");
            foreach (var parameter in operation.Parameters.Where<OpenApiParameter>(static x => x.In == ParameterLocation.Path))
            {
                writer.WriteParameter(parameter.Name, "path", parameter.Description ?? "", parameter.Required, parameter.Schema?.Type?.ToString() ?? "");
            }
            foreach (var parameter in operation.Parameters.Where<OpenApiParameter>(static x => x.In == ParameterLocation.Query))
            {
                writer.WriteParameter(parameter.Name, "query", parameter.Description ?? "", parameter.Required, parameter.Schema?.Type?.ToString() ?? "");
            }
            foreach (var parameter in operation.Parameters.Where<OpenApiParameter>(static x => x.In == ParameterLocation.Header))
            {
                writer.WriteParameter(parameter.Name, "header", parameter.Description ?? "", parameter.Required, parameter.Schema?.Type?.ToString() ?? "");
            }
        });
    }

    private void BuildRequestBody(OpenApiOperation operation)
    {
        writer.WriteSection("requestContent", () =>
        {
            writer.WriteTag("h3", "Request Body Schema");
            writer.WriteBlock("pre", "schema", (wr) =>
            {
                var schema = SerializeOpenApiElement((openApiWriter) =>
                        operation.RequestBody.Content.First<KeyValuePair<string, OpenApiMediaType>>().Value.Schema.SerializeAsV3(openApiWriter));
                wr.WriteText(schema);
            });
        });
    }

    private string SerializeOpenApiElement(Action<OpenApiJsonWriter> content)
    {
        var sb = new StringBuilder();
        var openApiWriter = new OpenApiJsonWriter(new StringWriter(sb), new OpenApiJsonWriterSettings() { InlineLocalReferences = true });
        content(openApiWriter);
        openApiWriter.Flush();
        return sb.ToString();
    }
    private void BuildResponses(OpenApiOperation operation)
    {
        writer.WriteSection("responses", () =>
        {
            writer.WriteTag("h2", "Responses");
            writer.WriteBlock("ul", "responses", (wr) =>
            {
                foreach (var response in operation.Responses)
                {
                    BuildResponse(response);
                }
            });
        });
    }

    private void BuildResponse(KeyValuePair<string, OpenApiResponse> response)
    {
        writer.WriteBlock("li", "response", (wr) =>
        {
            writer.WriteBlock("pre", HttpHtmlWriter.CSS.HttpExample, (wr) =>
                {
                    writer.WriteStatusLine(response.Key.ToString(), response.Value.Description);

                    if (response.Value.Content != null)
                    {
                        if (response.Value.Content.Count > 0)
                        {
                            var selectedContent = response.Value.Content.FirstOrDefault();
                            writer.WriteHeaderLine("content-type", selectedContent.Key);
                            WriteBody(selectedContent.Value);
                        }
                    }
                });
        });
    }


    public static string CreateUriTemplate(string path, OpenApiPathItem pathItem, OpenApiOperation operation)
    {
        var queryParameters = pathItem.Parameters
                                        .Where(static x => x.In == ParameterLocation.Query)
                                        .Union(operation.Parameters.Where(static x => x.In == ParameterLocation.Query))
                                        .DistinctBy(static x => x.Name)
                                        .ToArray();
        var queryStringParameters = string.Empty;
        if (queryParameters.Length != 0)
        {
            queryStringParameters = "{?" +
                                    queryParameters.Select(static x =>
                                                        x.Name.SanitizeParameterNameForUrlTemplate() +
                                                        (x.Explode ?
                                                            "*" : string.Empty))
                                            .Aggregate(static (x, y) => $"{x},{y}") +
                                    '}';
        }

        return path + queryStringParameters;
    }
}
