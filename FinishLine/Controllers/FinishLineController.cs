using FinishLine.Services.Generics;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace FinishLine.Api.Controllers;
public class FinishLineController<T> : ControllerBase where T : class
 {
    protected IServiceGeneric<T> service;
    public FinishLineController(IServiceGeneric<T> service)
    {
        this.service = service;
    }
    [HttpGet]
    public virtual List<T> GetAll()
    {
        return service.GetAll();
    }

    [HttpGet("{id}")]
    public virtual T Get(Guid id)
    {
        PropertyInfo idProperty = typeof(T).GetProperty("Id");
        return service.Get(x => (Guid)idProperty.GetValue(x) == id);
    }

    [HttpPost]
    public virtual IActionResult Add([FromBody] T obj)
    {
        if (obj == null) return BadRequest("Invalid form");
        T objTmp = service.Add(obj);
        if (objTmp != null)
        {
            return Ok(objTmp);
        }

        return BadRequest($"{typeof(T)} already exist !");
    }

    [HttpDelete("{id}")]
    public virtual IActionResult Delete(Guid id)
    {
        PropertyInfo idProperty = typeof(T).GetProperty("Id");
        var obj = service.Get(x => (Guid)idProperty.GetValue(x) == id);
        if (obj != null)
        {
            service.Delete(obj);
        }
        else
        {
            return BadRequest("Invalid id");
        }
        return NoContent();
    }

    [HttpPatch("{id}")]
    public virtual T Patch(Guid id, [FromBody] JsonPatchDocument<T> tPatch)
    {
        return service.Patch(tPatch, id);
    }
}

