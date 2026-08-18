using CarBook.Application.Features.CQRS.Results.ContactResult;
using MediatR;

namespace CarBook.Application.Features.CQRS.Queries.ContactQueries;

public record AnswerOpenAIQuery(string Message, string Name) : IRequest<AnswerOpenAI>;
