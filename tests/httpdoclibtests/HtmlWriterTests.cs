using HttpDocLib;
using Xunit;

namespace HttpDocLibTests;

public class HtmlWriterTests
{
    [Fact]
    public void WriteRaw()
    {
        // Arrange
        var writer = new StringWriter();
        using var htmlWriter = new HtmlWriter(writer);
        // Act
        htmlWriter.WriteRaw("<html>");
        // Assert
        Assert.Equal("<html>", writer.ToString());
        // Cleanup
    }

    [Fact]
    public void WriteText()
    {
        // Arrange
        var writer = new StringWriter();
        using var htmlWriter = new HtmlWriter(writer);
        // Act
        htmlWriter.WriteText("<html>");
        // Assert
        Assert.Equal("&lt;html&gt;", writer.ToString());
        // Cleanup
    }

    [Fact]
    public void StartTag()
    {
        // Arrange
        var writer = new StringWriter();
        using var htmlWriter = new HtmlWriter(writer);
        // Act
        htmlWriter.StartTag("html");
        // Assert
        Assert.Equal("<html>", writer.ToString());
        // Cleanup
    }

    [Fact]
    public void StartTagWithAttribute()
    {
        // Arrange
        var writer = new StringWriter();
        using var htmlWriter = new HtmlWriter(writer);
        // Act
        htmlWriter.StartTag("html", () => {
            htmlWriter.WriteAttribute("class", "test");
        });
        // Assert
        Assert.Equal("<html class=\"test\">", writer.ToString());
        // Cleanup
    }

    [Fact]
    public void EndTag()
    {
        // Arrange
        var writer = new StringWriter();
        using var htmlWriter = new HtmlWriter(writer);
        // Act
        htmlWriter.StartTag("html");
        htmlWriter.EndTag();
        // Assert
        Assert.Equal("<html></html>", writer.ToString());
        // Cleanup
    }

    // Test WriteAttributeIf
    [Fact]
    public void WriteAttributeIf()
    {
        // Arrange
        var writer = new StringWriter();
        using var htmlWriter = new HtmlWriter(writer);
        // Act
        htmlWriter.StartTag("html", () => {
            htmlWriter.WriteAttributeIf(true, "class", "test");
        });
        // Assert
        Assert.Equal("<html class=\"test\">", writer.ToString());
        // Cleanup
    }

    // Test WriteAttributeIf with false
    [Fact]
    public void WriteAttributeIfFalse()
    {
        // Arrange
        var writer = new StringWriter();
        using var htmlWriter = new HtmlWriter(writer);
        // Act
        htmlWriter.StartTag("html", () => {
            htmlWriter.WriteAttributeIf(false, "class", "test");
        });
        // Assert
        Assert.Equal("<html>", writer.ToString());
        // Cleanup
    }

    // Test WriteAttributeIsNotNull
    [Fact]
    public void WriteAttributeIfNotNull()
    {
        // Arrange
        var writer = new StringWriter();
        using var htmlWriter = new HtmlWriter(writer);
        // Act
        htmlWriter.StartTag("html", () => {
            htmlWriter.WriteAttributeIfNotNull("class", "test");
        });
        // Assert
        Assert.Equal("<html class=\"test\">", writer.ToString());
        // Cleanup
    }

    // Test WriteAttributeIsNotNull with null
    [Fact]
    public void WriteAttributeIfNotNullNull()
    {
        // Arrange
        var writer = new StringWriter();
        using var htmlWriter = new HtmlWriter(writer);
        // Act
        htmlWriter.StartTag("html", () => {
            htmlWriter.WriteAttributeIfNotNull("class", null);
        });
        // Assert
        Assert.Equal("<html>", writer.ToString());
        // Cleanup
    }
}