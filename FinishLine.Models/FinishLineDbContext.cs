using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinishLine.Models;
public class FinishLineDbContext: DbContext
{
    public FinishLineDbContext(DbContextOptions<FinishLineDbContext> options) : base(options) 
    {}

    public virtual DbSet<AppUser> AppUsers { get; set; }
    public virtual DbSet<Sport> Sports { get; set; }
    public virtual DbSet<Competition> Competitions { get; set; }
    public virtual DbSet<Event> Events { get; set; }
    public virtual DbSet<Constraint> Constraints { get; set; }
    public virtual DbSet<Participation> Participations { get; set; }
    public virtual DbSet<Profile> Profiles { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        
        base.OnModelCreating(builder);
    }

}

