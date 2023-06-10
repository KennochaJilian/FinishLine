using FinishLine.Models;
using FinishLine.Services;
using FinishLine.Services.Auth;
using FinishLine.Services.Models;
using FinishLine.Services.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace FinishLine.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register ([FromBody] RegisterModel model)
        {
            var vm = new ValidationModel<AppUser>();
            if (!ModelState.IsValid)
            {
                vm.Errors.AddRange(new List<string>(){"Invalid registration data"});
                return BadRequest(vm);
            }

            try
            {
                var res = await _authService.Register(model);
                return Ok(res);
            }
            catch (Exception ex)
            {
                vm.Errors.Add(ex.Message);
                return BadRequest(vm);
            }
            
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                var vm = new ValidationModel<AppUser>
                {
                    Errors = new List<string>() { "Invalid registration data" }
                };
                return BadRequest(vm);
            }
            var res = await _authService.Login(model);
            if (!res.Success)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
    }
}
