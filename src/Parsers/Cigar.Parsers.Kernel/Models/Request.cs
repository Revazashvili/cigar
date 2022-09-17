namespace Cigar.Parsers.Kernel.Models;

public class Request
{
    public Request() { }
    
    public Request(string url, RequestMethod? method = null, RequestHeaders? headers = null, string? body= null)
    {
        Url = url;
        Method = method;
        Headers = headers;
        Body = body;
    }

    public string Url { get; init; }
    public RequestMethod? Method { get; init; }
    public RequestHeaders? Headers { get; init; }
    public string? Body { get; init; }
}