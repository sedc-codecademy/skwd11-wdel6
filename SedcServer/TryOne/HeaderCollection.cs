using System.Collections;

public class HeaderCollection: IEnumerable<KeyValuePair<string, string>>
{
    private readonly Dictionary<string, string> _headers = new();

    public string this[string name]
    {
        get
        {
            return _headers[name];
        }
        set
        {
            _headers[name] = value;
        }
    }

    public HeaderCollection(Dictionary<string, string> headers)
    {
        _headers = headers;
    }

    public void AddHeader(string name, string value)
    {
        _headers.Add(name, value);
    }

    public void RemoveHeader(string name)
    {
        _headers.Remove(name);
    }

    public bool HasHeader(string name)
    {
        return _headers.ContainsKey(name);
    }

    public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    {
        return _headers.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _headers.GetEnumerator();
    }


    //public string this[string name]
    //{
    //    get
    //    {
    //        return string.Empty;
    //    }
    //    set
    //    {
    //    }
    //}
}