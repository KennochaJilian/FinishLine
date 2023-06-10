using FinishLine.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FinishLine.Models;

public class AppUser : IdentityUser<Guid>, IIncludeObject
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Profile? Profile { get; set; }
    public Guid? ProfileId { get; set; }

    public List<string> IncludesNeeded()
    {
        return new List<string>();
    }
}

