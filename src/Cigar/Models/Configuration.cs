namespace Cigar.Models;

public class Configuration
{
    public Configuration() { }
    public Configuration(string baseUrl,int iterations,Execution execution)
    {
        BaseUrl = baseUrl;
        Iterations = iterations;
        Execution = execution;
    }

    public string BaseUrl { get; init; }
    public int Iterations { get; init; }
    public Execution Execution { get; init; }
}