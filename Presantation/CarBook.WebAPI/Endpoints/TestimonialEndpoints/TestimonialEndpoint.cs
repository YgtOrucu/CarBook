using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using MediatR;

namespace CarBook.WebAPI.Endpoints.TestimonialEndpoints
{
    public static class TestimonialEndpoint
    {
        public static void AppTestimonialEndpoint(this IEndpointRouteBuilder app)
        {
            var testimonial = app.MapGroup("/testimonial").WithTags("Testimonial");

            testimonial.MapPost(string.Empty, CreateTestimonialAsync);
            testimonial.MapPut(string.Empty, UpdateTestimonialAsync);
            testimonial.MapGet(string.Empty, GetTestimonialAsync);
            testimonial.MapGet("{id}", GetTestimonialByIdAsync);
            testimonial.MapDelete("{id}", RemoveTestimonialAsync);
        }


        private static async Task<IResult> CreateTestimonialAsync(IMediator mediator, CreateTestimonialCommand command)
        {
            var response = await mediator.Send(command);
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> UpdateTestimonialAsync(IMediator mediator, UpdateTestimonialCommand command)
        {
            var response = await mediator.Send(command);
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetTestimonialAsync(IMediator mediator)
        {
            var response = await mediator.Send(new GetTestimonialQuery());
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetTestimonialByIdAsync(int id, IMediator mediator)
        {
            var response = await mediator.Send(new GetTestimonialByIdQuery(id));
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> RemoveTestimonialAsync(int id, IMediator mediator)
        {
            var response = await mediator.Send(new RemoveTestimonialCommand(id));
            return Results.Ok(response);
        }
    }
}
