using System.ComponentModel.DataAnnotations.Schema;
using FinishLine.Models.Interfaces;

namespace FinishLine.Models;

public class Profile : Entity, IIncludeObject
{
    public DateTime ? BirthDate { get; set; }
    public Sex Sex { get; set; }
    public List<string> IncludesNeeded()
    {
        return new List<string>();
    }
}