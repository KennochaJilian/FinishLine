using FinishLine.Models;
using FinishLine.Services.Interfaces;
using FinishLine.Services.Models;
using FinishLine.Services.Models.Auth;
using Microsoft.AspNetCore.Identity;

namespace FinishLine.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    public AuthService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }


    public async Task<ValidationModel<AppUser>> Register(RegisterModel model)
    {
        var user = new AppUser { UserName = model.Email, FirstName = model.FirstName, LastName = model.LastName, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            return new ValidationModel<AppUser>
            {
                Object = user,

            };
        }
        else
        {
            var errors = result.Errors.Select(e => e.Description);
            return new ValidationModel<AppUser>
            {
                Object = user,
                Errors = errors.ToList()
            };
        }
    }
}