using FinishLine.Models.Interfaces;

namespace FinishLine.Models;

public class Event : Entity, IIncludeObject
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public Competition Competition { get; set; }
    public List<Constraint> Constraints { get; set; }
    public List<string> IncludesNeeded()
    {
        return new List<string>();
    }
}