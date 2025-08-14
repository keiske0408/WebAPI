using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAPI.jwt;
using WebAPI.Models;

namespace WebAPI.db;

public class ApplicationDatabase : IdentityDbContext<JWTIdentity>
{
    public ApplicationDatabase(DbContextOptions<ApplicationDatabase> options) : base (options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
    
    //model registration ...
    public DbSet<TestModel> TestModels { get; set; }
    public DbSet<Category> Categories { get; set; }
}

