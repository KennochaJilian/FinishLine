using FinishLine.Models.Interfaces;

namespace FinishLine.Models;

public class Constraint : Entity, IIncludeObject
{
    public string Name { get; set; }
    public DateTime? MinBirthDate { get; set; }
    public DateTime? MaxBirthDate { get; set; }
    public int? MaximumParticipant { get; set; }
    public Sex Sex { get; set; }
    public List<string> IncludesNeeded()
    {
        return new List<string>();
    }
}