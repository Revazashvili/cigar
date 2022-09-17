namespace Cigar.Parsers.Kernel.Models;

public class Step
{
    public Step() { }
    
    public Step(string description,Request request,string? alias = null)
    {
        Description = description;
        Request = request;
        Alias = alias;
    }

    public string Description { get; init; }
    public Request Request { get; init; }
    public string? Alias { get; init; }
}