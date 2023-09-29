
using System.Collections.Immutable;

internal class SedcUri
{
    public string FullUri { get; }
    public string FullPath { get; }
    public ImmutableArray<string> Paths { get; }

    public string FullQuery { get; }
    public ImmutableDictionary<string, string> Queries { get; }
    public static SedcUri Empty { get; } = new(string.Empty);

    public SedcUri(string fullUri)
    {
        FullUri = fullUri;
        (FullPath, FullQuery) = SplitPathAndQuery(fullUri);
        Paths = GetPaths(FullPath);
        Queries = GetQueries(FullQuery);
    }

    private ImmutableDictionary<string, string> GetQueries(string fullQuery)
    {
        var queries = fullQuery.Split("&").Where(q => !string.IsNullOrEmpty(q));
        var builder = ImmutableDictionary.CreateBuilder<string, string>();
        foreach (var query in queries)
        {
            var parts = query.Split("=");
            var key = parts[0];
            var value = parts[1];
            builder.Add(key, value);
        }

        return builder.ToImmutable();
    }

    private static ImmutableArray<string> GetPaths(string path)
    {
        var paths = path.Split('/').Where(p => !string.IsNullOrEmpty(p)).ToArray();
        return ImmutableArray.Create(paths);
    }

    private (string Path, string Query) SplitPathAndQuery(string fullUri)
    {
        if (fullUri.Contains('?'))
        {
            var parts = fullUri.Split('?');
            return (parts[0], parts[1]);
        } 
        return (fullUri, string.Empty);
    }
}
