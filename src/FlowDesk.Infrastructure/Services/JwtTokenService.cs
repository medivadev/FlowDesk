using FlowDesk.Application.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlowDesk.Infrastructure.Services;

public sealed class JwtTokenService(IConfiguration configuration) : IJwtTokenService
{
    public string GenerateToken(Guid userId, string email, string fullName)
    {
        var secretKey = configuration["Jwt:Secret"] ?? "SuperSecretKeyForFlowDeskApplication123!";
        var issuer = configuration["Jwt:Issuer"] ?? "FlowDesk";
        var audience = configuration["Jwt:Audience"] ?? "FlowDeskClient";

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim("name", fullName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
