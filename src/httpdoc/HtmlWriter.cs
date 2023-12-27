/// <summary>
/// Class to manage writing HTML primitives
/// </summary>
public class HtmlWriter : IDisposable
{
    private readonly TextWriter _writer;
    private readonly Stack<string> _tags = new Stack<string>();

    public HtmlWriter(TextWriter writer)
    {
        _writer = writer;
    }

    public void Dispose()
    {
        while (_tags.Count > 0)
        {
            EndTag();
        }
    }

    public void StartTag(string tag, Action configure = null)
    {
        _tags.Push(tag);
        _writer.Write("<");
        _writer.Write(tag);
        if (configure != null)
        {
            _writer.Write(" ");
            configure();
        }
        _writer.Write(">");
    }

    public void EndTag()
    {
        var tag = _tags.Pop();
        _writer.Write("</");
        _writer.Write(tag);
        _writer.Write(">");
    }

    public void WriteRaw(string text)
    {
        _writer.Write(text);
    }

    public void WriteText(string text)
    {
        _writer.Write(text);
    }

    public void WriteText(string format, params object[] args)
    {
        _writer.Write(format, args);
    }

    public void WriteAttribute(string name, string value)
    {
        _writer.Write(" ");
        _writer.Write(name);
        _writer.Write("=\"");
        _writer.Write(value);
        _writer.Write("\"");
    }

    public void WriteAttribute(string name, string format, params object[] args)
    {
        _writer.Write(" ");
        _writer.Write(name);
        _writer.Write("=\"");
        _writer.Write(format, args);
        _writer.Write("\"");
    }

    public void WriteAttributeIf(bool condition, string name, string value)
    {
        if (condition)
        {
            WriteAttribute(name, value);
        }
    }

    public void WriteAttributeIf(bool condition, string name, string format, params object[] args)
    {
        if (condition)
        {
            WriteAttribute(name, format, args);
        }
    }

    public void WriteAttributeIfNotNull(string name, string value)
    {
        if (value != null)
        {
            WriteAttribute(name, value);
        }
    }

    public void WriteAttributeIfNotNull(string name, string format, params object[] args)
    {
        if (args != null)
        {
            WriteAttribute(name, format, args);
        }
    }

    public void WriteAttributeIfNotEmpty(string name, string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            WriteAttribute(name, value);
        }
    }

}

