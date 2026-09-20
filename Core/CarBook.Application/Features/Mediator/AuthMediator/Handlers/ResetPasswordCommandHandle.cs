using CarBook.Application.Base;
using CarBook.Application.Features.Mediator.AuthMediator.Commands;
using CarBook.Application.Features.Mediator.AuthMediator.Events;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CarBook.Application.Features.Mediator.AuthMediator.Handlers;

public class ResetPasswordCommandHandle(UserManager<AppUser> userManager, ISendMailRepository mailService, IMediator mediator)
: IRequestHandler<ResetPasswordCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        if (request.NewPassword != request.ConfirmPassword)
        {
            return BaseResult<object>.Failure("Şifreler birbiriyle uyuşmuyor.");
        }

        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return BaseResult<object>.Failure("Geçersiz e-posta veya kod.");
        }

        if (string.IsNullOrEmpty(user.PasswordResetCode) ||
            user.PasswordResetCode != request.Code ||
            user.PasswordResetCodeExpiresAt == null ||
            user.PasswordResetCodeExpiresAt < DateTime.UtcNow)
        {
            return BaseResult<object>.Failure("Kod geçersiz veya süresi dolmuş. Lütfen tekrar kod isteyin.");
        }

        var token = await userManager.GeneratePasswordResetTokenAsync(user);
        var resetResult = await userManager.ResetPasswordAsync(user, token, request.NewPassword);

        if (!resetResult.Succeeded)
        {
            return BaseResult<object>.Failure(resetResult.Errors);
        }

        user.PasswordResetCode = null;
        user.PasswordResetCodeExpiresAt = null;

        await userManager.UpdateSecurityStampAsync(user);
        await userManager.UpdateAsync(user);


        await mediator.Publish(new UserSendResetPasswordEvent(user.Name, user.Surname, user.Email!), cancellationToken);
        return BaseResult<object>.Success("Şifreniz başarıyla güncellendi. Yeni şifrenizle giriş yapabilirsiniz.");
    }
}