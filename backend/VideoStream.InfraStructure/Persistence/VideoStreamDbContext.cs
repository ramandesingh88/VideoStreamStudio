using Microsoft.EntityFrameworkCore;

namespace VideoStream.Infrastructure.Persistence;

public  sealed class VideoStreamDbContext : DbContext
{
    public VideoStreamDbContext(DbContextOptions<VideoStreamDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Entity configurations will be added here.
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(VideoStreamDbContext).Assembly);
    }

}