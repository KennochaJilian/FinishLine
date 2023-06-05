using FinishLine.Models;
using FinishLine.Services.Models;
using FinishLine.Services.Models.Auth;

namespace FinishLine.Services.Auth;

public interface IAuthService
{
    Task<ValidationModel<TokenModel>> Register(RegisterModel model);
    Task<ValidationModel<TokenModel>> Login(LoginModel model);
}