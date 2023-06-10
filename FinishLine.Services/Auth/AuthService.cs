using FinishLine.Models;
using FinishLine.Services.Models;
using FinishLine.Services.Models.Auth;
using Microsoft.AspNetCore.Identity;
using System.Text;

namespace FinishLine.Services.Auth;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;
    public AuthService(UserManager<AppUser> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }


    public async Task<ValidationModel<TokenModel>> Register(RegisterModel model)
    {
        var user = new AppUser { UserName = model.Email, FirstName = model.FirstName, LastName = model.LastName, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description);
            return new ValidationModel<TokenModel>
            {
                Errors = errors.ToList()
            };
        }

        return GetToken(user);
    }

    public async Task<ValidationModel<TokenModel>> Login(LoginModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            return new ValidationModel<TokenModel>
            {
                Errors = new List<string> { "Utilisateur non trouvé." }
            };
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, model.Password);
        if (!isPasswordValid)
        {
            return new ValidationModel<TokenModel>
            {
                Errors = new List<string> { "Mot de passe incorrect." }
            };
        }

        return GetToken(user);
    }
    private ValidationModel<TokenModel> GetToken(AppUser user)
    {
        return new ValidationModel<TokenModel>
        {
            Object = _tokenService.GenerateJwtTokenFromUser(user)

    };
    }
}