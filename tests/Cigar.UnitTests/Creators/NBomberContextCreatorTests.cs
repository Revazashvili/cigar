using Cigar.Creators;
using Cigar.Models;

namespace Cigar.UnitTests.Creators;

public class NBomberContextCreatorTests
{
    [Fact]
    public void Should_Create_Context()
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
                        Request = new Request
                        {
                            Url = "/customers"
                        }
                    }
                }
            }
        };

        var nBomberContext = NBomberContextCreator.Create("sample", configuration);
        Assert.NotNull(nBomberContext);
        Assert.Equal("sample", nBomberContext.TestName);
    }
}