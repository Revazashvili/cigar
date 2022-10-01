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
            steps.AddRange(Enumerable.Range(1, configuration.Iterations)
                .Select(i => StepCreator.Create(httpFactory, executionStep, configuration.BaseUrl,$"{executionStep.Alias}_{i}")));

        return ScenarioBuilder
            .CreateScenario(fileName, steps.ToArray())
            .WithLoadSimulations(Simulation.InjectPerSec(100, TimeSpan.FromSeconds(30)));
    }
}