using MediatR;
using Microsoft.AspNetCore.Http;

namespace Mam.Api.Extensions
{
    public static class EndpointExtensions
    {
        public static WebApplication Get<TRequest>(this WebApplication app, string template)
        {
            app.MapGet(template, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
            return app;
        }

        public static WebApplication Post<TRequest>(this WebApplication app, string template)
        {
            app.MapPost(template, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));

            return app;
        }
    }
}
