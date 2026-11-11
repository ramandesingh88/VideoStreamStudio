using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using VideoStream.Infrastructure.Persistence;

public sealed class VideoStreamDbContextFactory : IDesignTimeDbContextFactory<VideoStreamDbContext>
{
    public VideoStreamDbContext CreateDbContext(string[] args)
    {
        var connectionString =
            Environment.GetEnvironmentVariable(
                "ConnectionStrings__VideoStreamDatabase");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                "Connection string is missing. Set the " +
                "ConnectionStrings__VideoStreamDatabase environment variable.");
        }
        
        var optionsBuilder = new DbContextOptionsBuilder<VideoStreamDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new VideoStreamDbContext(optionsBuilder.Options);
    }
}