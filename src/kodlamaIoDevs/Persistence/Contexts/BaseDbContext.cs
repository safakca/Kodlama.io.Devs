using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<ProgLangEntity> ProgLangEntities { get; set; }
    public BaseDbContext()
    {

    }
    public BaseDbContext(DbContextOptions dbContextOptions,IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       // base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ProgLangEntity>(x =>
        {
            x.ToTable("ProgLangEntities").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("Id");
            x.Property(p => p.Name).HasColumnName("Name");
        });

        ProgLangEntity[] progLangEntities = { new(1, "C#"), new(2, "Java"), new(3, "Pyhton") };
        modelBuilder.Entity<ProgLangEntity>().HasData(progLangEntities);
    }
}

