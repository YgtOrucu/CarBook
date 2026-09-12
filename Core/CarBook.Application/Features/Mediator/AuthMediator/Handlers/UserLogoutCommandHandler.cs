using MediatR;
using Microsoft.AspNetCore.Identity;
using CarBook.Application.Features.Mediator.AuthMediator.Commands;
using CarBook.Domain.Entities;
using CarBook.Application.Interfaces;

namespace CarBook.Application.Features.Mediator.AuthMediator.Handlers;

public class UserLogoutCommandHandler(UserManager<AppUser> userManager, IUnitOfWork unitOfWork)
    : IRequestHandler<LogoutCommand, string>
{
    public async Task<string> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.UserId);
        if (user != null)
        {
            user.SecurityStamp = Guid.NewGuid().ToString();

            await userManager.UpdateAsync(user);
        }

        return "Çıkış başarılı, token geçersiz kılındı.";
    }
}
