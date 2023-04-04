using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinishLine.Models;
public class FinishLineDbContext: DbContext
{
    public FinishLineDbContext(DbContextOptions<FinishLineDbContext> options) : base(options) 
    {}

    public virtual DbSet<AppUser> AppUsers { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

}

