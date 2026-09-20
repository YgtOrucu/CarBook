using CarBook.Application.Base;
using MediatR;

namespace CarBook.Application.Features.Mediator.AuthMediator.Commands;

public class ForgotPasswordCommand : IRequest<BaseResult<object>>
{
    public string Email { get; set; }
}

