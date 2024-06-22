using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Sandbox.Data.Entities;

namespace Sandbox.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
        : base(options)
    {}
    
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder m)
    {
        m.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
    }
}
// could also use .net secrets
public class ContextFactory : IDesignTimeDbContextFactory<Context>
{
    public static Context Create(IConfiguration config)
    {
        var optionsBuilder = new DbContextOptionsBuilder<Context>();
        optionsBuilder.UseSqlServer(config["ConnectionStrings:DefaultConnection"]);
        var c = new Context(optionsBuilder.Options);
        return c;
    }
    
    public Context CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        return Create(configuration);
    }
}