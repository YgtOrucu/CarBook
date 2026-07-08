using CarBook.Application.Features.CQRS.Commands.ContactCommand;
using CarBook.Application.Features.CQRS.Handlers.ContactHandle.Write;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using ContactBook.Application.Features.CQRS.Handlers.ContactHandle.Read;

namespace CarBook.WebAPI.Endpoints.ContactEndpoints
{
    public static class ContactEndpoint
    {
        public static void AppContactEndpoint(this IEndpointRouteBuilder builder)
        {
            var Contacts = builder.MapGroup("/contact").WithTags("Contacts");

            Contacts.MapGet(string.Empty, GetContactAsync);
            Contacts.MapGet("{id}", GetContactByIdAsync);
            Contacts.MapPost(string.Empty, CreateContactAsync);
            Contacts.MapPut(string.Empty, UpdateContactAsync);
            Contacts.MapDelete("{id}", RemoveContactAsync);

        }

        private static async Task<IResult> GetContactAsync(GetContactQueryHandle getContactQueryHandle)
        {
            var result = await getContactQueryHandle.Handle();
            return result != null ? Results.Ok(result) : Results.BadRequest("The Contact listing process failed.");
        }

        private static async Task<IResult> GetContactByIdAsync(int id, GetContactByIdQueryHandle getContactByIdQueryHandle)
        {
            var result = await getContactByIdQueryHandle.Handle(new GetContactByIdQuery(id));
            return result != null ? Results.Ok(result) : Results.NotFound();
        }

        private static async Task<IResult> CreateContactAsync(CreateContactCommandHandle createContactCommandHandle, CreateContactCommand command)
        {
            await createContactCommandHandle.Handle(command);
            return Results.Ok("The Contact has been successfully created.");
        }

        private static async Task<IResult> UpdateContactAsync(UpdateContactCommandHandle updateContactCommandHandle, UpdateContactCommand command)
        {
            await updateContactCommandHandle.Handle(command);
            return Results.Ok("The Contact has been successfully updated.");
        }

        private static async Task<IResult> RemoveContactAsync(int id, RemoveContactCommandHandle removeContactCommandHandle)
        {
            await removeContactCommandHandle.Handle(new RemoveContactCommand(id));
            return Results.Ok("The Contact has been successfully deleted.");
        }

    }
}
