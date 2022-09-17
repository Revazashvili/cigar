namespace Cigar.Parsers.Kernel.Models;

public record Request(string Url, RequestMethod? Method = null, RequestHeaders? Headers= null, string? Body= null);