using CarBook.Application.Features.Mediator.AuthMediator.Results;
using CarBook.Application.Interfaces.JwtInterfaces;
using CarBook.Domain.Entities;
using CarBook.Infrastructure.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarBook.Infrastructure.Repositories.JwtRepository;

public class JwtRepository(IOptions<JwtTokenOption> options, UserManager<AppUser> userManager) : IJwtService
{
    private readonly JwtTokenOption _jwtToken = options.Value;

    public async Task<LoginQueryResult> GenerateTokenAsync(string UserName)
    {
        var user = await userManager.FindByNameAsync(UserName);
        if (user == null)
            throw new Exception("User not found");

        var roles = await userManager.GetRolesAsync(user);

        SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(_jwtToken.Key));
        var now = DateTime.UtcNow;
        var expiration = now.AddMinutes(_jwtToken.ExpireInMinutes);

        List<Claim> claims = new()
        {
            new(JwtRegisteredClaimNames.UniqueName,user.UserName!),
            new(JwtRegisteredClaimNames.Sub,user.Id.ToString()!),
            new(JwtRegisteredClaimNames.Email, user.Email!),
            new("FullName",string.Join(" ",user.Name,user.Surname)),
            new("FirstAndLastLetter",string.Join("",user.Name.Substring(0,1),user.Surname.Substring(0,1))),
            new("security_stamp", user.SecurityStamp!),
        };

        foreach (var role in roles)
        {
            claims.Add(new("role", role));
        }


        JwtSecurityToken jwtSecurityToken = new
        (
            issuer: _jwtToken.Issuer,
            audience: _jwtToken.Audience,
            claims: claims,
            notBefore: now,
            expires: expiration,
            signingCredentials: new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
        );

        LoginQueryResult reponse = new LoginQueryResult()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            ExpirationTime = expiration
        };

        return reponse;
    }
}
