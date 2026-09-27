using CarBook.Application.Features.Mediator.Commands.AskAssistantCommands;
using MediatR;

namespace CarBook.WebAPI.Endpoints.OpenAıAssistantEndpoints
{
    public static class OpenAıAssistantEndpoints
    {
        public static void AppOpenAIEndpoint(this IEndpointRouteBuilder app)
        {
            var Assistant = app.MapGroup("/assistant").WithTags("Assistant");

            Assistant.MapPost("ask", GenerateAnswerForUser).AllowAnonymous();
        }

        private static async Task<IResult> GenerateAnswerForUser(IMediator mediator, AskAssistantCommand command)
        {
            var response = await mediator.Send(command);
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }
    }
}
