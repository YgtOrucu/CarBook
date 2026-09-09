using CarBook.Application.Base;
using MediatR;

namespace CarBook.Application.Features.Mediator.AuthMediator.Commands;

public class CreateRegisterCommand : IRequest<BaseResult<object>>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
