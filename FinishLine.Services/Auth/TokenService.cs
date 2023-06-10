using Microsoft.IdentityModel.Tokens;
using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FinishLine.Models;
using FinishLine.Services.Models.Auth;
using Microsoft.Extensions.Configuration;

namespace FinishLine.Services.Auth;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public TokenModel GenerateJwtTokenFromUser(AppUser user)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var secretKey = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);
        var expirationHours = Int64.Parse(jwtSettings["ExpirationHours"]);
        var issuer = jwtSettings["Issuer"];
        var audience = jwtSettings["Audience"];

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
        };
        var securityKey = new SymmetricSecurityKey(secretKey);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(issuer,
            audience,
            claims,
            expires: DateTime.Now.AddHours(expirationHours),
            signingCredentials: credentials);

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return new TokenModel()
        {
            User = user,
            Token = tokenString,
            ExpiredAt = DateTime.UtcNow.AddHours(expirationHours)
        };


    }
}