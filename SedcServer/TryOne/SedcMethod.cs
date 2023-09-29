public readonly record struct SedcMethod //: IEquatable<Method>
{
    public string Value { get; init; } = string.Empty;

    public SedcMethod(string value)
    {
        Value = value.ToUpper();
    }

    public readonly static SedcMethod Get = new("GET");
    public readonly static SedcMethod Post = new("POST");
    public readonly static SedcMethod Put = new("PUT");
    public readonly static SedcMethod Delete = new("DELETE");
    public readonly static SedcMethod Head = new("HEAD");
    public readonly static SedcMethod Options = new("OPTIONS");
    public readonly static SedcMethod Trace = new("TRACE");
    public readonly static SedcMethod Connect = new("CONNECT");
    public readonly static SedcMethod Patch = new("PATCH");
    public readonly static SedcMethod Invalid = new("INVALID");

    public override string ToString()
    {
        return Value;
    }
}
