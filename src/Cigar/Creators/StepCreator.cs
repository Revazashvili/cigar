using Cigar.Models;
using NBomber.Contracts;
using NBomber.Plugins.Http.CSharp;
using Step = NBomber.CSharp.Step;

namespace Cigar.Creators;

public static class StepCreator
{
    public static IStep Create(ClientFactory<HttpClient> httpFactory,
        Cigar.Models.Step step,string baseUrl)
    {
        //TODO: Iterations
        return Step.Create(step.Alias, httpFactory, async context =>
        {
            var method = step.Request.Method ?? RequestMethod.Get;
            var request = Http.CreateRequest(method.ToString().ToUpper(), $"{baseUrl}{step.Request.Url}");
            
            step.Request.Headers?.ToList().ForEach(header => request.WithHeader(header.Key, header.Value.ToString()));

            if (!string.IsNullOrEmpty(step.Request.Body))
                request.WithBody(new StringContent(step.Request.Body!));

            return await Http.Send(request, context);
        });
    }
}