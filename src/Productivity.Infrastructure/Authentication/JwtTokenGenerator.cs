using Microsoft.IdentityModel.Tokens;
using Productivity.Application.Common.Interfaces.Authentication;
using Productivity.Domain.UserAggregate.ValueObjects;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Productivity.Infrastructure.Authentication;
class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateToken(UserId userId, string firstName, string lastName)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("valid-secret-key")),
            SecurityAlgorithms.HmacSha256);



        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.Value.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName ),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var securityToken = new JwtSecurityToken
        (
            issuer: "Productivity",
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
