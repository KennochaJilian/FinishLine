using FinishLine.Models.Interfaces;

namespace FinishLine.Models;

public class Competition : Entity, IIncludeObject
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public string Address { get; set; }
    public List<Event> Events { get; set; }
    public AppUser Organizer { get; set; }
    public Sport Sport { get; set; }

    public List<string> IncludesNeeded()
    {
       return new List<string>();
    }
}