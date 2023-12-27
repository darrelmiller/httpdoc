using Kiota.Builder.Extensions;
using Microsoft.OpenApi.Models;

public static class OpenApiDocBuilder
{

    public static void GenerateHttpDoc(TextWriter wr, string path, OpenApiPathItem pathItem, OperationType operationType, OpenApiOperation operation)
    {
        var builder = new HttpHtmlWriter(wr);
        builder.WriteHtml(() =>
        {
            builder.WriteHead(operation.Summary);
            builder.WriteBody(() =>
            {
                builder.WriteArticle(() =>
                {
                    builder.WriteSection("requestOverview", () =>
                    {
                        builder.WriteRequestSummary(operation.Summary ?? operation.OperationId ?? "");
                        builder.WriteRequestDescription(operation.Description);
                    });
                    builder.WriteSection("http", () =>
                    {
                        builder.WriteTag("h3", "HTTP Request");

                        builder.WriteBlock("pre", HttpHtmlWriter.CSS.HttpExample, () =>
                        {
                            var uriTemplate = CreateUriTemplate(path, pathItem, operation);
                            builder.WriteRequestLine(operationType.ToString().ToUpperInvariant(), uriTemplate, "HTTP/1.1");
                            builder.WriteHeaderLine("host", "example.org:443");
                            // Get list of media types from operation responses
                            var mediaTypes = operation.Responses
                                                        .SelectMany(static x => x.Value.Content.Keys)
                                                        .Distinct()
                                                        .ToArray();
                            builder.WriteHeaderLine("accept", mediaTypes.Aggregate((x, y) => $"{x},{y}"));
                            builder.WriteRequestBody("");
                        });
                    });
                    builder.WriteBlock("dl", "parameters", () =>
                    {
                        builder.WriteTag("h3", "Parameters");

                        var allParameters = pathItem.Parameters
                                        .Union(operation.Parameters)
                                        .DistinctBy(static x => x.Name + "/" + x.In.ToString())
                                        .ToArray();
                        foreach (var parameter in operation.Parameters.Where(static x => x.In == ParameterLocation.Path))
                        {
                            builder.WriteParameter(parameter.Name, parameter.In.ToString(), parameter.Description ?? "", parameter.Required, parameter.Schema?.Type?.ToString() ?? "");
                        }
                        foreach (var parameter in operation.Parameters.Where(static x => x.In == ParameterLocation.Query))
                        {
                            builder.WriteParameter(parameter.Name, parameter.In.ToString(), parameter.Description ?? "", parameter.Required, parameter.Schema?.Type?.ToString() ?? "");
                        }
                        foreach (var parameter in operation.Parameters.Where(static x => x.In == ParameterLocation.Header))
                        {
                            builder.WriteParameter(parameter.Name, parameter.In.ToString(), parameter.Description ?? "", parameter.Required, parameter.Schema?.Type?.ToString() ?? "");
                        }
                    });
                    if (operation.RequestBody != null)
                    {
                        builder.WriteSection("requestContent", () =>
                        {
                            builder.WriteTag("h3", "Request Body Schema");
                            builder.WriteBlock("pre", "schema", () =>
                            {
                                //builder.WriteSchema(operation.RequestBody.Content["application/json"].Schema.SerializeAsV3());
                            });
                        });
                    }
    ;
                    builder.WriteSection("responses", () =>
                    {
                        builder.WriteTag("h2", "Responses");
                        builder.WriteBlock("ul", "responses", () =>
                        {
                            foreach (var response in operation.Responses)
                            {
                                builder.WriteBlock("li", "response", () =>
                                {
                                    builder.WriteStatusLine(response.Key.ToString(), response.Value.Description);
                                });
                            }
                        });
                    });
                });
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
        if (queryParameters.Length != 0) {
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
