namespace Cigar.Models;

public class Configuration
{
    public string BaseUrl { get; init; } = null!;
    public int Iterations { get; init; } = 1;
    public Execution Execution { get; init; } = null!;
}