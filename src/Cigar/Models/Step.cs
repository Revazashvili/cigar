namespace Cigar.Models;

public class Step
{
    public string? Alias { get; init; }
    public Request Request { get; init; } = null!;
}