using CarBook.Application.Features.CQRS.Commands.ContactCommand;
using CarBook.Application.Features.CQRS.Handlers.ContactHandle.Write;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using ContactBook.Application.Features.CQRS.Handlers.ContactHandle.Read;
using MediatR;

namespace CarBook.WebAPI.Endpoints.ContactEndpoints
{
    public static class ContactEndpoint
    {
        public static void AppContactEndpoint(this IEndpointRouteBuilder builder)
        {
            var Contacts = builder.MapGroup("/contact").WithTags("Contacts");

            Contacts.MapGet("", GetContactAsync).AllowAnonymous();
            Contacts.MapGet("{id}", GetContactByIdAsync).AllowAnonymous();
            Contacts.MapGet("GetOpenAIAnswer", GetOpenAIAnswerAsync).AllowAnonymous();

            var adminContact = Contacts.MapGroup("").RequireAuthorization(policy => policy.RequireRole("Admin"));

            adminContact.MapPost("", CreateContactAsync);
            adminContact.MapPost("SendMessage", SendMessageAsync);
            adminContact.MapPut("", UpdateContactAsync);
            adminContact.MapDelete("{id}", RemoveContactAsync);

        }

        private static async Task<IResult> GetOpenAIAnswerAsync(string Message, string Name, IMediator mediator)
        {
            var response = await mediator.Send(new AnswerOpenAIQuery(Message, Name));
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> SendMessageAsync(IMediator mediator, SendMailCommand command)
        {
            var response = await mediator.Send(command);
            return response != null ? Results.Ok(new { Message = response }) : Results.BadRequest(new { Message = response });
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
