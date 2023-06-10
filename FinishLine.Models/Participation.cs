using FinishLine.Models.Interfaces;

namespace FinishLine.Models;

public class Participation : Entity, IIncludeObject
{
    public int? Chrono { get; set; }
    public string? Score { get; set; }
    public int? Ranking { get; set; }
    public Event Event { get; set; }
    public AppUser Competitor { get; set; }
    public List<string> IncludesNeeded()
    {
        return new List<string>();
    }
}