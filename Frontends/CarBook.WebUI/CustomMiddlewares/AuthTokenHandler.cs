using CarBook.Application.Base;
using CarBook.WebUI.Models;
using System.Net;
using System.Net.Http.Headers;

namespace CarBook.WebUI.CustomMiddlewares
{
    public class AuthTokenHandler(IHttpContextAccessor httpContextAccessor) : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = httpContextAccessor.HttpContext?.User.FindFirst("AccessToken")?.Value;
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var error = new BaseResult<GetApıErrors>
                {
                    Errors = [new Error
                    {
                        Code = "401",
                        ErrorMessage = "Bu kaynağa erişim izniniz yok. Devam etmek için lütfen oturum açın."

                    }]
                };
                response.Content = JsonContent.Create(error);
            }

            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                var error = new BaseResult<GetApıErrors>
                {
                    Errors = [new Error
                    {
                        Code = "403",
                        ErrorMessage = "Bu kaynağa sadece yetkili kullanıcılar erişim iznine sahip."

                    }]
                };
                response.Content = JsonContent.Create(error);
            }
            return response;
        }

    }
}
