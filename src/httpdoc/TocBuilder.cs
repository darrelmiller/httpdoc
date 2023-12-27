using Microsoft.OpenApi.Services;
using Microsoft.OpenApi.Models;

public class TocBuilder
{
    private readonly OpenApiUrlTreeNode root;
    private readonly string label;
    private readonly StreamWriter writer;
    private readonly Action<string, OpenApiPathItem, OperationType, OpenApiOperation, string> generateHttpDoc;
    public TocBuilder(OpenApiDocument document, Stream stream, Action<string, OpenApiPathItem, OperationType, OpenApiOperation, string> generateHttpDoc)
    {
        this.root = OpenApiUrlTreeNode.Create(document, "default");
        this.label = "default";
        this.generateHttpDoc = generateHttpDoc;
        this.writer = new StreamWriter(stream);
    }

    public void BuildToc()
    {
        foreach (var child in root.Children.Values)
        {
            GenerateTocItem(child);
        }
        writer.Flush();
    }
    private void GenerateTocItem(OpenApiUrlTreeNode node, int level = 0)
    {
        var indent = new string(' ', level * 2);
        var segment = node.Segment.Replace("{", "").Replace("}", "");
        writer.WriteLine($"{indent}- name: {segment}");

        if (node.PathItems.Any())
        {
            writer.WriteLine($"{indent}  items:");
            var ops = node.PathItems[label].Operations;
            foreach (var op in ops)
            {
                var filename = $"{op.Value.OperationId}.md";
                writer.WriteLine($"{indent}  - name: \"{op.Key.ToString().ToUpperInvariant()}\"");
                writer.WriteLine($"{indent}    href: {filename}");
                generateHttpDoc(node.Path, node.PathItems[label], op.Key, op.Value, filename);
            }
        }

        if (node.Children.Any())
        {
            if (!node.PathItems.Any())
            {
                writer.WriteLine($"{indent}  items:");
            }
            foreach (var child in node.Children.Values)
            {
                GenerateTocItem(child, level + 1);
            }
        }
    }

}