using CarBook.Application.Features.Mediator.AuthMediator.Results;

namespace CarBook.Application.Interfaces.JwtInterfaces;
public interface IJwtService
{
    Task<LoginQueryResult> GenerateTokenAsync(string UserName);
}
