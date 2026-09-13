using CarBook.Application.Features.CQRS.Commands.BrandCommand;
using CarBook.Application.Features.CQRS.Handlers.BrandHandler;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;

namespace CarBook.WebAPI.Endpoints.BrandEndpoints
{
    public static class BrandEndpoint
    {
        public static void AppBrandEndpoint(this IEndpointRouteBuilder builder)
        {
            var Brands = builder.MapGroup("/brand").WithTags("Brands");

            Brands.MapGet("", GetBrandAsync).AllowAnonymous();
            Brands.MapGet("{id}", GetBrandByIdAsync).AllowAnonymous();


            var adminBrand = Brands.MapGroup("").RequireAuthorization(policy => policy.RequireRole("Admin"));

            adminBrand.MapPost("", CreateBrandAsync);
            adminBrand.MapPut("", UpdateBrandAsync);
            adminBrand.MapDelete("{id}", RemoveBrandAsync);

        }

        private static async Task<IResult> GetBrandAsync(GetBrandQueryHandle getBrandQueryHandle)
        {
            var result = await getBrandQueryHandle.Handle();
            return result != null ? Results.Ok(result) : Results.BadRequest("The Brand listing process failed.");
        }

        private static async Task<IResult> GetBrandByIdAsync(int id, GetBrandByIdQueryHandle getBrandByIdQueryHandle)
        {
            var result = await getBrandByIdQueryHandle.Handle(new GetBrandByIdQuery(id));
            return result != null ? Results.Ok(result) : Results.NotFound();
        }

        private static async Task<IResult> CreateBrandAsync(CreateBrandCommandHandle createBrandCommandHandle, CreateBrandCommand command)
        {
            await createBrandCommandHandle.Handle(command);
            return Results.Ok("The Brand has been successfully created.");
        }

        private static async Task<IResult> UpdateBrandAsync(UpdateBrandCommandHandle updateBrandCommandHandle, UpdateBrandCommand command)
        {
            await updateBrandCommandHandle.Handle(command);
            return Results.Ok("The Brand has been successfully updated.");
        }

        private static async Task<IResult> RemoveBrandAsync(int id, RemoveBrandCommandHandle removeBrandCommandHandle)
        {
            await removeBrandCommandHandle.Handle(new RemoveBrandCommand(id));
            return Results.Ok("The Brand has been successfully deleted.");
        }
    }
}
