using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DLL.Context;

public class UkraineContext : IdentityDbContext {
    public UkraineContext(DbContextOptions<UkraineContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Entertainment> Entertainments { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<About> Abouts { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<WorkTime> WorkTimes { get; set; }
    public DbSet<Monument> Monuments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);
        builder.Entity<User>(UserConfigure);
        builder.Entity<Entertainment>(EntertainmentConfigure);
        builder.Entity<Monument>(MonumentConfigure);
    }

    private void UserConfigure(EntityTypeBuilder<User> builder) {
        builder.Property(x => x.NickName).HasMaxLength(16).IsRequired();
    }

    private void EntertainmentConfigure(EntityTypeBuilder<Entertainment> builder) {
        builder.HasMany(x => x.Reviews).WithOne(x => x.Entertainment);
    }

    private void MonumentConfigure(EntityTypeBuilder<Monument> builder) {
        builder.HasMany(x => x.Reviews).WithOne(x => x.Monument).OnDelete(DeleteBehavior.NoAction);
    }
}