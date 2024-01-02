using System.Text.Encodings.Web;

namespace HttpDocLib;

/// <summary>
/// Class to manage writing HTTP concepts as HTML
/// </summary>
public class HttpHtmlWriter {
    // Create consts for each CSS class used in this file
    // These will be used in the CSS file to style the HTML
    public class CSS {
        public const string RequestLine = "request-line";
        public const string HttpTarget = "http-target";
        public const string HttpVersion = "http-version";
        public const string HttpExample = "http-example";
        public const string HeaderLine = "header-line";
        public const string HeaderValue = "header-value";
        public const string RequestSummary = "request-summary";
        public const string RequestDescription = "request-description";
        public const string Parameter = "parameter";
        public const string ParameterName = "parameter-name";
        public const string ParameterLocation = "parameter-location";
        public const string ParameterType = "parameter-type";
        public const string ParameterDescription = "parameter-description";
        public const string ParameterRequired = "parameter-required";
        public const string StatusLine = "status-line";
        public const string StatusDescription = "status-description";
        public const string Schema = "schema";
    }

    private readonly HtmlWriter wr;

    public HttpHtmlWriter(TextWriter writer)
    {
        wr = new HtmlWriter(writer);
    }

    public void WriteHtml(Action writeContent)
    {
        wr.WriteRaw("<!DOCTYPE html>");
        wr.StartTag("html");
        writeContent();
        wr.EndTag();
    }
   public void WriteHead(string operationSummary)
    {
        wr.StartTag("head");
        wr.StartTag("title");
        wr.WriteText(operationSummary);
        wr.EndTag();
        wr.WriteRaw(@"<link rel=""stylesheet"" href=""./OpenApi.css""/>");
        wr.WriteRaw(@"<meta charset=""utf-8""/>");
        wr.WriteRaw(@"<meta name=""viewport"" content=""width=device-width, initial-scale=1""/>");
        wr.EndTag();
    }
    public void WriteBody(Action writeContent)
    {
        wr.StartTag("body");
        writeContent();
        wr.EndTag();
    }

    public void WriteArticle(Action writeContent)
    {
        wr.StartTag("article");
        writeContent();
        wr.EndTag();
    }


    public void WriteSection(string className,Action writeContent)
    {
        wr.StartTag("section", () =>{
            wr.WriteAttribute("class", className);
        });
        
        writeContent();
        wr.EndTag();
    }

    public void WriteBlock(string tagName, string className,Action<HtmlWriter> writeContent)
    {
        wr.StartTag(tagName, () =>{
            wr.WriteAttribute("class", className);
        });
        writeContent(wr);
        wr.EndTag();
    }

    public void WriteSpan(string className, string content)
    {
        wr.StartTag("span", () =>{
            wr.WriteAttribute("class", className);
        });
        wr.WriteText(content);
        wr.EndTag();
    }

    public void WriteRequestLine(string method, string uriTemplate,  string version)
    {
        wr.StartTag("span", () =>{
            wr.WriteAttribute("class", CSS.RequestLine);
        });
        wr.WriteText(method);
        wr.EndTag();
        wr.WriteText(" ");

        wr.StartTag("span", () =>{
            wr.WriteAttribute("class", CSS.HttpTarget);
        });
        wr.WriteText(uriTemplate);
        wr.EndTag();
        wr.WriteText(" ");

        wr.StartTag("span", () =>{
        wr.WriteAttribute("class", CSS.HttpVersion);
        });
        wr.WriteText(version);
        wr.EndTag();
        wr.WriteText("\n");
    }

    public void WriteRequestBody(string body) {
        if (string.IsNullOrEmpty(body)) {
            return;
        }
        wr.WriteText("\n");
        wr.WriteText(body);
    }

    public void WriteHeaderLine(string headerName, string headerValue)
    {
        wr.StartTag("span", () =>{
            wr.WriteAttribute("class", CSS.HeaderLine);
        });
        wr.WriteText(headerName);
        wr.EndTag();
        wr.WriteText(": ");
        wr.StartTag("span", () =>{
            wr.WriteAttribute("class", CSS.HeaderValue);
        }); 
        wr.WriteText(headerValue);
        wr.EndTag();
        wr.WriteText("\n");

    }


    public void WriteRequestSummary(string? operationSummary)
    {
        if (string.IsNullOrEmpty(operationSummary)) {
            return;
        }
        wr.StartTag("h1", () => {
            wr.WriteAttribute("class", CSS.RequestSummary);
        });
        wr.WriteText(operationSummary);
        wr.EndTag();
    }

    public void WriteRequestDescription(string? operationDescription)
    {
        if (string.IsNullOrEmpty(operationDescription)) {
            return;
        }
        wr.StartTag("p", () => {
            wr.WriteAttribute("class", CSS.RequestDescription);
        }); 
        wr.WriteRaw(operationDescription);
        wr.EndTag();
    }
 
    public void WriteTag(string tag, string content)
    {
        wr.StartTag(tag);
        wr.WriteText(content);
        wr.EndTag();
    }

    internal void WriteParameter(string name, string inLocation, string description, bool required, string dataType)
    {
        WriteBlock("dt", CSS.Parameter, (wr) => {
            WriteBlock("span", CSS.ParameterName, (wr) => {
                wr.WriteText(name);
            });
            
            wr.WriteText(" [ in: ");
            
            WriteBlock("span", CSS.ParameterLocation, (wr) => {
                wr.WriteText(inLocation);
            });

            wr.WriteText(" type: ");

            WriteBlock("span", CSS.ParameterType, (wr) => {
                wr.WriteText(dataType);
            });

            wr.WriteText(" ]");
        });

        WriteBlock("dd", CSS.Parameter, (wr) => {

            WriteBlock("span", CSS.ParameterDescription, (wr) => {
                wr.WriteRaw(description);
            });

            wr.WriteText(" ");

            WriteBlock("span", CSS.ParameterRequired, (wr) => {
                wr.WriteText(required ? "required" : "optional");
            });

        });

    }

    internal void WriteStatusLine(string statusCode, string description)
    {
        wr.StartTag("span", () => {
            wr.WriteAttribute("class", CSS.StatusLine);
        });
        wr.WriteText(statusCode);
        wr.EndTag();
        wr.WriteText(" ");
        wr.StartTag("span", () => {
            wr.WriteAttribute("class", CSS.StatusDescription);
        });
        wr.WriteText(description);
        wr.EndTag();        
        wr.WriteRaw("\n");
    }

    internal void WriteSchema(string schema)
    {
        wr.WriteText(schema);
    }
}