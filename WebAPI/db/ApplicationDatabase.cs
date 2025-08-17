using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAPI.jwt;
using WebAPI.Models;
using WebAPI.Models.Internal;

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
    public DbSet<Users> Users { get; set; }
    public DbSet<UsersCredentials> UsersCredentials { get; set; }
    public DbSet<UsersInformation> UsersInformation { get; set; }
}

