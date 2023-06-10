using System.ComponentModel.DataAnnotations;
using FinishLine.Models.Interfaces;

namespace FinishLine.Models;

public class Sport : Entity, IIncludeObject
{

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    public List<string> IncludesNeeded()
    {
        return new List<string>();
    }
}