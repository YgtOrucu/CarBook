using CarBook.Application.Base;
using CarBook.Application.Features.Mediator.AuthMediator.Results;
using MediatR;

namespace CarBook.Application.Features.Mediator.AuthMediator.Queries;

public record LoginQuery(string Email, string Password) : IRequest<BaseResult<LoginQueryResult>>;
