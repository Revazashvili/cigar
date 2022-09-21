using Cigar.Creators;
using Cigar.Models;

namespace Cigar.UnitTests.Creators;

public class ScenarioCreatorTests
{
    [Fact]
    public void Should_Create_Scenario()
    {
        var configuration = new Configuration
        {
            BaseUrl = "http://localhost:80",
            Iterations = 5,
            Execution = new Execution
            {
                Steps = new[]
                {
                    new Step
                    {
                        Alias = "test",
                        Description = "test",
                        Request = new Request
                        {
                            Url = "/customers"
                        }
                    }
                }
            }
        };
        var scenario = ScenarioCreator.Create("sample", configuration);
        Assert.NotNull(scenario);
        Assert.Equal("sample",scenario.ScenarioName);
    }
}