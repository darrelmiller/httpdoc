// Create tests for all httpHtmlWriterTests methods

using HttpDocLib;
namespace HttpDocLibTests;

public class HttpHtmlWriterTests {

    [Fact]
    public void WriteHtml()
    {
        // Arrange
        var writer = new StringWriter();
        var httpWriter = new HttpHtmlWriter(writer);
        
        // Act
        httpWriter.WriteHtml(() => {});

        // Assert
        Assert.Equal("<!DOCTYPE html><html></html>", writer.ToString());
        // Cleanup
    }

    // Create WriteBody test
    [Fact]
    public void WriteBody()
    {
        // Arrange
        var writer = new StringWriter();
        var httpWriter = new HttpHtmlWriter(writer);
        
        // Act
        httpWriter.WriteBody(() => {});

        // Assert
        Assert.Equal("<body></body>", writer.ToString());
        // Cleanup
    }

    // Create WriteArticle test
    [Fact]
    public void WriteArticle()
    {
        // Arrange
        var writer = new StringWriter();
        var httpWriter = new HttpHtmlWriter(writer);
        
        // Act
        httpWriter.WriteArticle(() => {});

        // Assert
        Assert.Equal("<article></article>", writer.ToString());
        // Cleanup
    }

    // Create WriteSection test
    [Fact]
    public void WriteSection()
    {
        // Arrange
        var writer = new StringWriter();
        var httpWriter = new HttpHtmlWriter(writer);
        
        // Act
        httpWriter.WriteSection("className", () => {});

        // Assert
        Assert.Equal("<section class=\"className\"></section>", writer.ToString());
        // Cleanup
    }

    // Create WriteBlock test
    [Fact]
    public void WriteBlock()
    {
        // Arrange
        var writer = new StringWriter();
        var httpWriter = new HttpHtmlWriter(writer);
        
        // Act
        httpWriter.WriteBlock("tagName", "className", (wr) => {});

        // Assert
        Assert.Equal("<tagName class=\"className\"></tagName>", writer.ToString());
        // Cleanup
    }

    // Create WriteSpan test
    [Fact]
    public void WriteSpan()
    {
        // Arrange
        var writer = new StringWriter();
        var httpWriter = new HttpHtmlWriter(writer);
        
        // Act
        httpWriter.WriteSpan("className", "content");

        // Assert
        Assert.Equal("<span class=\"className\">content</span>", writer.ToString());
        // Cleanup
    }

    // Create WriteRequestLine test
    [Fact]
    public void WriteRequestLine()
    {
        // Arrange
        var writer = new StringWriter();
        var httpWriter = new HttpHtmlWriter(writer);
        
        // Act
        httpWriter.WriteRequestLine("method", "uriTemplate", "version");

        // Assert
        Assert.Equal("<span class=\"request-line\">method</span> <span class=\"http-target\">uriTemplate</span> <span class=\"http-version\">version</span>&#xA;", writer.ToString());
        // Cleanup
    }

    // Create WriteRequestSummary test
    [Fact]
    public void WriteRequestSummary()
    {
        // Arrange
        var writer = new StringWriter();
        var httpWriter = new HttpHtmlWriter(writer);
        
        // Act
        httpWriter.WriteRequestSummary("summary");

        // Assert
        Assert.Equal("<h1 class=\"request-summary\">summary</h1>", writer.ToString());
        // Cleanup
    }

    // Create WriteRequestDescription test
    [Fact]
    public void WriteRequestDescription()
    {
        // Arrange
        var writer = new StringWriter();
        var httpWriter = new HttpHtmlWriter(writer);
        
        // Act
        httpWriter.WriteRequestDescription("description");

        // Assert
        Assert.Equal("<p class=\"request-description\">description</p>", writer.ToString());
        // Cleanup
     }

     // Create WriteRequestDescription with null
    [Fact]
    public void WriteRequestDescriptionWithNull()
    {
        // Arrange
        var writer = new StringWriter();
        var httpWriter = new HttpHtmlWriter(writer);
        
        // Act
        httpWriter.WriteRequestDescription(null);

        // Assert
        Assert.Equal("", writer.ToString());
        // Cleanup
     }


}