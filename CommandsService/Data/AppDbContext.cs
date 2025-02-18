using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {

    }

    public DbSet<Command> Commands { get; set; }
    public DbSet<Platform> Platforms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
        .Entity<Platform>()
        .HasMany(p => p.Commands)
        .WithOne(p => p.Platform!)
        .HasForeignKey(p => p.PlatformId);

        modelBuilder
        .Entity<Command>()
        .HasOne(c => c.Platform)
        .WithMany(c => c.Commands)
        .HasForeignKey(c => c.PlatformId);


        base.OnModelCreating(modelBuilder);
    }
}