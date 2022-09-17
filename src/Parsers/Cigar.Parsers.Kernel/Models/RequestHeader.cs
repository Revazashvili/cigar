namespace Cigar.Parsers.Kernel.Models;

public class RequestHeader
{
    public RequestHeader() { }
    
    public RequestHeader(string key,object value)
    {
        Key = key;
        Value = value;
    }

    public string Key { get; init; }
    public object Value { get; init; }
}