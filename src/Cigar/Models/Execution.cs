namespace Cigar.Models;

public class Execution
{
    public Execution() { }
    
    public Execution(IEnumerable<Step> steps)
    {
        Steps = steps;
    }

    public IEnumerable<Step> Steps { get; init; }
}