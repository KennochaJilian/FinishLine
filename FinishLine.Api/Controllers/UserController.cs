using FinishLine.Models;
using FinishLine.Services.Generics;
using Microsoft.AspNetCore.Mvc;

namespace FinishLine.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : FinishLineController<AppUser>
    {
        public UserController(IServiceGeneric<AppUser> service) : base(service)
        {
        }
    }
}
