using CarBook.Application.Features.CQRS.Commands.BannerCommand;
using CarBook.Application.Features.CQRS.Handlers.BannerHandler.Read;
using CarBook.Application.Features.CQRS.Handlers.BannerHandler.Write;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;

namespace CarBook.WebAPI.Endpoints.BannerEndpoints;

public static class BannerEndpoint
{
    public static void AppBannerEndpoint(this IEndpointRouteBuilder builder)
    {
        var banners = builder.MapGroup("/banner").WithTags("Banners");

        banners.MapGet("", GetBannerAsync).AllowAnonymous();
        banners.MapGet("{id}", GetBannerByIdAsync).AllowAnonymous();
        banners.MapPost("", CreateBannerAsync).RequireAuthorization(policy => policy.RequireRole("Admin"));
        banners.MapPut("", UpdateBannerAsync).RequireAuthorization(policy => policy.RequireRole("Admin"));
        banners.MapDelete("{id}", RemoveBannerAsync).RequireAuthorization(policy => policy.RequireRole("Admin"));

    }

    private static async Task<IResult> GetBannerAsync(GetBannerQueryHandle getBannerQueryHandle)
    {
        var result = await getBannerQueryHandle.Handle();
        return result != null ? Results.Ok(result) : Results.BadRequest("The banner listing process failed.");
    }

    private static async Task<IResult> GetBannerByIdAsync(int id, GetBannerByIdQueryHandle getBannerByIdQueryHandle)
    {
        var result = await getBannerByIdQueryHandle.Handle(new GetBannerByIdQuery(id));
        return result != null ? Results.Ok(result) : Results.NotFound();
    }

    private static async Task<IResult> CreateBannerAsync(CreateBannerCommandHandle createBannerCommandHandle, CreateBannerCommand command)
    {
        await createBannerCommandHandle.Handle(command);
        return Results.Ok("The banner has been successfully created.");
    }

    private static async Task<IResult> UpdateBannerAsync(UpdateBannerCommandHandle updateBannerCommandHandle, UpdateBannerCommand command)
    {
        await updateBannerCommandHandle.Handle(command);
        return Results.Ok("The banner has been successfully updated.");
    }

    private static async Task<IResult> RemoveBannerAsync(int id, RemoveBannerCommandHandle removeBannerCommandHandle)
    {
        await removeBannerCommandHandle.Handle(new RemoveBannerCommand(id));
        return Results.Ok("The banner has been successfully deleted.");
    }

}