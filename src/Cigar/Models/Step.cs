namespace Cigar.Models;

public class Step
{
    public Step() { }
    
    public Step(Request request,string? alias = null)
    {
        Alias = alias;
        Request = request;
    }

    public string? Alias { get; init; }
    public Request Request { get; init; }
}