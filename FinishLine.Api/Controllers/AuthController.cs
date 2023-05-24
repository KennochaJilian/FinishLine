using FinishLine.Api.Models.Auth;
using FinishLine.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace FinishLine.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        public AuthController(UserManager<AppUser> userManager) 
        {
            _userManager = userManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register ([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = model.Email, FirstName = model.FirstName, LastName = model.LastName, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return Ok("Registration successful.");
                }
                else
                {
                    var errors = result.Errors.Select(e => e.Description);
                    return BadRequest(errors);
                }
            }

            return BadRequest("Invalid registration data.");
        }
    }
}
