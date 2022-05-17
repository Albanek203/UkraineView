using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DLL.Context;

public class UkraineContext : IdentityDbContext {
    public UkraineContext(DbContextOptions<UkraineContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Entertainment> Entertainments { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<About> Abouts { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<WorkTime> WorkTimes { get; set; }
    public DbSet<Monument> Monuments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);
        builder.Entity<Monument>().HasMany(x => x.Reviews).WithOne(x => x.Monument).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Entertainment>().HasMany(x => x.Reviews).WithOne(x => x.Entertainment);
    }
}