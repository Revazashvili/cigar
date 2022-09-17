namespace Cigar.Parsers.Kernel.Models;

public record Request(string Url, RequestMethod Method, RequestHeaders Headers, string Body);