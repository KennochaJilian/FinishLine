using FinishLine.Models;
using FinishLine.Services.Generics;
using Microsoft.AspNetCore.Mvc;

namespace FinishLine.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : FinishLineController<User>
    {
        public UserController(IServiceGeneric<User> service) : base(service)
        {
        }
    }
}
