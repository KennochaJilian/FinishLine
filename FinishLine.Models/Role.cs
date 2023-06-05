using Microsoft.AspNetCore.Identity;

namespace FinishLine.Models;

public class Role : IdentityRole<Guid>
{
    public string Description { get; set; }
}