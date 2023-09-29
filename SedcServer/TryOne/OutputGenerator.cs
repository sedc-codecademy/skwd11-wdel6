
using System.Text;

internal class OutputGenerator
{
    internal static ReadOnlySpan<byte> MakeResponse(HttpResponse response)
    {
        var responseString = GetResponseString(response);
        var bytes = Encoding.UTF8.GetBytes(responseString);
        return bytes;
    }

    private static string GetResponseString(HttpResponse response)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"HTTP/1.1 {response.StatusCode}");
        foreach (var (key, value) in response.Headers)
        {
            sb.AppendLine($"{key}: {value}");
        }
        sb.AppendLine();
        sb.AppendLine(response.Body);
        return sb.ToString();
    }
}