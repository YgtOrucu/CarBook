using CarBook.Application.Features.CQRS.Commands.AboutCommand;
using CarBook.Application.Features.CQRS.Handlers.AboutHandler;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;

namespace CarBook.WebAPI.Endpoints.AboutEndpoints
{
    public static class AboutEndpoint
    {
        public static void AppAboutEndpoint(this IEndpointRouteBuilder builder)
        {
            var abouts = builder.MapGroup("/about").WithTags("Abouts");

            abouts.MapGet("", async (GetAboutQueryHandle _getAboutQueryHandler) =>
            {
                var response = await _getAboutQueryHandler.Handle();
                return response != null ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous();

            abouts.MapGet("{id}", async (int id, GetAboutByIdQueryHandle _getAboutByIdQueryHandler) =>
            {
                var response = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
                return response != null ? Results.Ok(response) : Results.BadRequest(response);
            }).AllowAnonymous();

            abouts.MapPost("", async (CreateAboutCommandHandle _createAboutCommandHandler, CreateAboutCommand command) =>
            {
                await _createAboutCommandHandler.Handle(command);
                return Results.Ok(new { message = "Ekleme işlemi başarılı." });
            }).RequireAuthorization(policy => policy.RequireRole("Admin"));

            abouts.MapPut("", (UpdateAboutCommandHandle _updateAboutCommandHandler, UpdateAboutCommand command) =>
            {
                _updateAboutCommandHandler?.Handle(command);
                return Results.Ok(new { message = "Güncelleme işlemi başarılı." });
            }).RequireAuthorization(policy => policy.RequireRole("Admin"));

            abouts.MapDelete("{id}", async (int id, RemoveAboutCommandHandle _removeAboutCommandHandler) =>
            {
                await _removeAboutCommandHandler?.Handle(new RemoveAboutCommand(id));
                return Results.Ok(new { message = "Silme işlemi başarılı." });
            }).RequireAuthorization(policy => policy.RequireRole("Admin"));
        }
    }
}
