using CarBook.Application.Base;
using CarBook.Application.Features.Mediator.AuthMediator.Commands;
using CarBook.Application.Features.Mediator.AuthMediator.Events;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CarBook.Application.Features.Mediator.AuthMediator.Handlers;

public class ForgotPasswordCommandHandle(UserManager<AppUser> userManager, ISendMailRepository mailService, IMediator mediator)
    : IRequestHandler<ForgotPasswordCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
            return BaseResult<object>.Failure("E-posta adresi sistemde bulunamadı");

        string resetCode = new Random().Next(100000, 999999).ToString();

        user.PasswordResetCode = resetCode;
        user.PasswordResetCodeExpiresAt = DateTime.UtcNow.AddMinutes(5);

        var updateResult = await userManager.UpdateAsync(user);
        if (!updateResult.Succeeded)
        {
            return BaseResult<object>.Failure("Kod üretilirken bir hata oluştu.");
        }

        await mediator.Publish(new UserSendForgotPasswordCodeEvent(user.Email!, user.PasswordResetCode), cancellationToken);
        return BaseResult<object>.Success("Doğrulama kodu e-posta adresinize gönderildi.");
    }
}