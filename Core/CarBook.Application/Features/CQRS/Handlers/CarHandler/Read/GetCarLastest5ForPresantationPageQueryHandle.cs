using AutoMapper;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResult;
using CarBook.Application.Interfaces.CarInterfaces;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandler.Read;

public class GetCarLastest5ForPresantationPageQueryHandle(ICarRepository repository, IMapper mapper)
    : IRequestHandler<GetCarLastest5ForPresantationPageQuery, List<GetCarLastest5ForPresantationPageResult>>
{
    public async Task<List<GetCarLastest5ForPresantationPageResult>> Handle(GetCarLastest5ForPresantationPageQuery request, CancellationToken cancellationToken)
    {
        var values = mapper.Map<List<GetCarLastest5ForPresantationPageResult>>(await repository.GetCarLastest5ForPresantationPageAsync());
        return values;
    }
}
