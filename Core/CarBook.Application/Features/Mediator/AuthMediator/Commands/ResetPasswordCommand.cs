using CarBook.Application.Base;
using MediatR;

namespace CarBook.Application.Features.Mediator.AuthMediator.Commands;

public class ResetPasswordCommand : IRequest<BaseResult<object>>
{
    public string Email { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string NewPassword { get; set; } = null!;
    public string ConfirmPassword { get; set; } = null!;
}
