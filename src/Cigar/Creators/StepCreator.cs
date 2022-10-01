using Cigar.Models;
using NBomber.Contracts;
using NBomber.Plugins.Http.CSharp;

namespace Cigar.Creators;

public static class StepCreator
{
    public static IStep Create( ClientFactory<HttpClient> httpFactory,Step step,string baseUrl)
    {
        return NBomber.CSharp.Step.Create(step.Alias, httpFactory, context =>
        {
            var request = Http.CreateRequest(step.Request.Method?.ToUpper() ?? "GET", $"{baseUrl}{step.Request.Url}");

            step.Request.Headers?.ToList().ForEach(header => request.WithHeader(header.Key, header.Value.ToString()));

            if (!string.IsNullOrEmpty(step.Request.Body))
                request.WithBody(new StringContent(step.Request.Body!));

            return Http.Send(request, context);
        });
    }
}