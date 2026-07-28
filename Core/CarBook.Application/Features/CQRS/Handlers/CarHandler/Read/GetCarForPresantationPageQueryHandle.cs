using AutoMapper;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResult;
using CarBook.Application.Interfaces.CarInterfaces;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandler.Read;

public class GetCarForPresantationPageQueryHandle(ICarRepository repository, IMapper mapper)
    : IRequestHandler<GetCarForPresantationPageQuery, List<GetCarForPresantationPageResult>>
{
    public async Task<List<GetCarForPresantationPageResult>> Handle(GetCarForPresantationPageQuery request, CancellationToken cancellationToken)
    {
        var values = mapper.Map<List<GetCarForPresantationPageResult>>(await repository.GetCarForPresantationPageAsync());
        return values;
    }
}
