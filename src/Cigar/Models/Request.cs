namespace Cigar.Models;

public class Request
{
    public string Url { get; init; } = null!;
    public string? Method { get; init; }
    public IEnumerable<RequestHeader>? Headers { get; init; }
    public string? Body { get; init; }
}