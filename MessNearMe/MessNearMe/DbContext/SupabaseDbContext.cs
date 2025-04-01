using Microsoft.EntityFrameworkCore;

public class SupabaseDbContext : DbContext
{
    public SupabaseDbContext(DbContextOptions<SupabaseDbContext> options) : base(options)
    {
    }

    public DbSet<Country> Country { get; set; }
}
