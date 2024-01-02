
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;

namespace HttpDocLib;

public static class OpenApiDocumentExtensions {

    public static IList<OpenApiExample> GetAllExamples(this OpenApiMediaType mediaType) {
        var examples = mediaType.Examples.Select(x => x.Value).ToList();
        if (mediaType.Example == null) {
            examples.Add( new OpenApiExample() { Value = mediaType.Example });
        }
        if (mediaType.Schema != null) {
            examples.Add(new OpenApiExample() { Value = mediaType.Schema.Example });
        } 
        return examples;
    }
    public static string ConvertToString(this OpenApiExample example) {
        return SerializeOpenApiElement(w => w.WriteAny(example.Value));
    }

    public static IList<OpenApiParameter> GetAllParameters(this OpenApiPathItem pathItem, OpenApiOperation operation) {
                    return pathItem.Parameters
                            .Union<OpenApiParameter>(operation.Parameters)
                            .DistinctBy(static x => x.Name + "/" + x.In.ToString())
                            .ToList();
    }

    public static string ConvertToExample(this OpenApiSchema schema) {
        switch(schema.Type) {
            case "string":
                return "\"a string\"";
            case "integer":
                return "123";
            case "boolean":
                return "true";
            case "array":
                return "["+ schema.Items.ConvertToExample() +"]";
            case "object":
                var sb = new StringBuilder();
                sb.Append("{");
                foreach(var property in schema.Properties) {
                    sb.Append($"\"{property.Key}\": {property.Value.ConvertToExample()},");
                }
                sb.Append("}");
                return sb.ToString();
            default:
                return "Unknown type";
        }
    }
    static string SerializeOpenApiElement(Action<OpenApiJsonWriter> content) {
        var sb = new StringBuilder();
        var openApiWriter = new OpenApiJsonWriter(new StringWriter(sb), new OpenApiJsonWriterSettings() { InlineLocalReferences = true });
        content(openApiWriter);
        openApiWriter.Flush();
        return sb.ToString();
    }
} 
