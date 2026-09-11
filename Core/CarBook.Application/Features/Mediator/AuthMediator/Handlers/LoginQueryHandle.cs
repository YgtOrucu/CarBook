using CarBook.Application.Base;
using CarBook.Application.Features.Mediator.AuthMediator.Queries;
using CarBook.Application.Features.Mediator.AuthMediator.Results;
using CarBook.Application.Interfaces.JwtInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CarBook.Application.Features.Mediator.AuthMediator.Handlers;

public class LoginQueryHandle(UserManager<AppUser> userManager, IJwtService jwtService) : IRequestHandler<LoginQuery, BaseResult<LoginQueryResult>>
{
    public async Task<BaseResult<LoginQueryResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var users = await userManager.FindByEmailAsync(request.Email);

        if (users == null)
        {
            return BaseResult<LoginQueryResult>.Failure("Email or Password is incorrect. Please check your details.");
        }

        var result = await userManager.CheckPasswordAsync(users, request.Password);

        if (!result)
        {
            return BaseResult<LoginQueryResult>.Failure("Email or Password is incorrect. Please check your details.");
        }

        var createdToken = await jwtService.GenerateTokenAsync(users.UserName!);

        return BaseResult<LoginQueryResult>.Success(createdToken);
    }
}
