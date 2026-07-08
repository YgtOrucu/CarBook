using CarBook.Application.Features.CQRS.Commands.CategoryCommand;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandles.Read;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandles.Write;
using CarBook.Application.Features.CQRS.Queries.CategoryQueries;

namespace CarBook.WebAPI.Endpoints.CategoryEndpoints
{
    public static class CategoryEndpoint
    {
        public static void AppCategoryEndpoint(this IEndpointRouteBuilder builder)
        {
            var Categorys = builder.MapGroup("/Category").WithTags("Categorys");

            Categorys.MapGet(string.Empty, GetCategoryAsync);
            Categorys.MapGet("{id}", GetCategoryByIdAsync);
            Categorys.MapPost(string.Empty, CreateCategoryAsync);
            Categorys.MapPut(string.Empty, UpdateCategoryAsync);
            Categorys.MapDelete("{id}", RemoveCategoryAsync);

        }

        private static async Task<IResult> GetCategoryAsync(GetCategoryCommandHandle getCategoryQueryHandle)
        {
            var result = await getCategoryQueryHandle.Handle();
            return result != null ? Results.Ok(result) : Results.BadRequest("The Category listing process failed.");
        }

        private static async Task<IResult> GetCategoryByIdAsync(int id, GetCategoryByIdCommandHandle getCategoryByIdQueryHandle)
        {
            var result = await getCategoryByIdQueryHandle.Handle(new GetCategoryByIdQuery(id));
            return result != null ? Results.Ok(result) : Results.NotFound();
        }

        private static async Task<IResult> CreateCategoryAsync(CreateCategoryCommandHandle createCategoryCommandHandle, CreateCategoryCommand command)
        {
            await createCategoryCommandHandle.Handle(command);
            return Results.Ok("The Category has been successfully created.");
        }

        private static async Task<IResult> UpdateCategoryAsync(UpdateCategoryCommandHandle updateCategoryCommandHandle, UpdateCategoryCommand command)
        {
            await updateCategoryCommandHandle.Handle(command);
            return Results.Ok("The Category has been successfully updated.");
        }

        private static async Task<IResult> RemoveCategoryAsync(int id, RemoveCategoryCommandHandle removeCategoryCommandHandle)
        {
            await removeCategoryCommandHandle.Handle(new RemoveCategoryCommand(id));
            return Results.Ok("The Category has been successfully deleted.");
        }

    }
}
