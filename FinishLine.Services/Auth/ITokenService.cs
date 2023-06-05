using FinishLine.Models;

namespace FinishLine.Services.Auth;

public interface ITokenService
{
    string GenerateJwtTokenFromUser(AppUser user);
}