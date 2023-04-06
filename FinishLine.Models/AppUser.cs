using FinishLine.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FinishLine.Models;

public class AppUser : IIncludeObject
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<string> IncludesNeeded()
    {
        return new List<string>();
    }
}

