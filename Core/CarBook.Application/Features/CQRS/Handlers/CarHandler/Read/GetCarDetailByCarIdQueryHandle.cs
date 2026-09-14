using CarBook.Application.Base;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResult;
using CarBook.Application.Interfaces.CarInterfaces;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandler.Read;

public class GetCarDetailByCarIdQueryHandle(ICarDetailRepository carDetailRepository) : IRequestHandler<GetCarDetailByCarIdQuery, BaseResult<GetCarDetailByCarIdResult>>
{
    public async Task<BaseResult<GetCarDetailByCarIdResult>> Handle(GetCarDetailByCarIdQuery request, CancellationToken cancellationToken)
    {
       var value = await carDetailRepository.CarDetailByCarIdResultAsync(request.Id);
       return BaseResult<GetCarDetailByCarIdResult>.Success(value);
    }
}
