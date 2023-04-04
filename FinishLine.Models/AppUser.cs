using FinishLine.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FinishLine.Models;

    public class AppUser : IIncludeObject
{
        public string FirstName { get; set; }
        public string LastName { get; set; }

    public List<string> IncludesNeeded()
    {
        return new List<string>();
    }
}

