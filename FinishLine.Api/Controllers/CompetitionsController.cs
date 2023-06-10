using FinishLine.Models;
using FinishLine.Services.Generics;
using Microsoft.AspNetCore.Mvc;

namespace FinishLine.Api.Controllers;

[Route("api/[controller]")]
public class CompetitionsController: FinishLineController<Competition>
{
    public CompetitionsController(IServiceGeneric<Competition> service) : base(service)
    {
    }
    [NonAction]
    public override List<Competition> GetAll()
    {
        return base.GetAll();
    }

    [HttpGet]
    public List<Competition> GetAll(string? userId)
    {
        return userId != null ? service.GetAll(x => x.Organizer.Id == Guid.Parse(userId)) : service.GetAll();
    }
}