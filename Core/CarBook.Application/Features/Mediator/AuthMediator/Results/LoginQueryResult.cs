namespace CarBook.Application.Features.Mediator.AuthMediator.Results;

public class LoginQueryResult
{
    public string Token { get; set; }
    public DateTime ExpirationTime { get; set; }
}
