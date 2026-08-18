using AutoMapper;
using CarBook.Application.Features.CQRS.Commands.ContactCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandle.Write;

public class SendMailCommandHandle(ISendMailRepository mailRepository, IMapper mapper, IRepository<Contact> repository,IUnitOfWork unitOfWork)
    : IRequestHandler<SendMailCommand, string>
{

    public async Task<string> Handle(SendMailCommand request, CancellationToken cancellationToken)
    {
        await mailRepository.SendMailAsync(request.ReceiverEmail, request.ReceiverName, request.ReplySubject!, request.ReplyMessage);

        var findUser = await repository.GetFilterAsync(x => x.Email == request.ReceiverEmail);
        findUser.IsStatus = true;

        repository.Update(findUser);
        await unitOfWork.SaveChangeAsync();

        return "Mesaj başarıyla kullanıcıya iletilmiştir.";
    }
}
