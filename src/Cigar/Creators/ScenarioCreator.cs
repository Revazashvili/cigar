using Cigar.Models;
using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Plugins.Http.CSharp;

namespace Cigar.Creators;

public static class ScenarioCreator
{
    public static Scenario Create(string fileName, Configuration configuration)
    {
        var httpFactory = HttpClientFactory.Create();
        var steps = new List<IStep>();
        foreach (var executionStep in configuration.Execution.Steps)
        {
            steps.AddRange(Enumerable.Range(1, configuration.Iterations)
                .Select(_ => StepCreator.Create(httpFactory, executionStep, configuration.BaseUrl)));
        }
        
        return ScenarioBuilder
            .CreateScenario(fileName, steps.ToArray())
            .WithLoadSimulations(Simulation.InjectPerSec(100, TimeSpan.FromSeconds(30)));
    }
}