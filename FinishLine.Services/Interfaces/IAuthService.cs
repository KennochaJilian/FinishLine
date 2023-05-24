using FinishLine.Models;
using FinishLine.Services.Models;
using FinishLine.Services.Models.Auth;

namespace FinishLine.Services.Interfaces;

public interface IAuthService
{
    Task<ValidationModel<AppUser>> Register(RegisterModel model);
}