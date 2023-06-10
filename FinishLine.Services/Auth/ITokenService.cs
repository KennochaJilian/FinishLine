using FinishLine.Models;
using FinishLine.Services.Models.Auth;

namespace FinishLine.Services.Auth;

public interface ITokenService
{
    TokenModel GenerateJwtTokenFromUser(AppUser user);
}