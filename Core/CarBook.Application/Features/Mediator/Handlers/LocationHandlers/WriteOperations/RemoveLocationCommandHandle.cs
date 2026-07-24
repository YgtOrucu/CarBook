using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers.WriteOperations
{
    public class RemoveLocationCommandHandle(IRepository<Location> repository, IUnitOfWork unitOfWork)
        : IRequestHandler<RemoveLocationCommand, object>
    {
        public async Task<object> Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
        {
            var values = await repository.GetByIdAsync(request.Id);

            if (values == null)
                throw new Exception("Id could not be found");

            repository.Delete(values);
            await unitOfWork.SaveChangeAsync();
            return new
            {
                success = true,
                message = "The deleted was succesfully",
                data = values
            };
        }
    }
}
