using SASD.FreelancerLaunchPad.Data.Repositories;
using SASD.FreelancerLaunchPad.Data.Sqlite;

namespace SASD.FreelancerLaunchPad.Tests;

/// <summary>
/// Tests for the initial SQLite database creation.
/// </summary>
public sealed class DatabaseInitializerTests
{
    /// <summary>
    /// Ensures that the database initializer creates seed platforms.
    /// </summary>
    [Fact]
    public void Initialize_CreatesSeedPlatforms()
    {
        var databasePath = Path.Combine(Path.GetTempPath(), $"sasd_launchpad_test_{Guid.NewGuid():N}.db");

        try
        {
            var factory = new SqliteConnectionFactory(databasePath);
            var initializer = new DatabaseInitializer(factory);

            initializer.Initialize();

            var repository = new PlatformRepository(factory);
            var platforms = repository.GetActivePlatforms();

            Assert.Contains(platforms, p => p.Name == "PeoplePerHour");
            Assert.Contains(platforms, p => p.Name == "Manual");
        }
        finally
        {
            if (File.Exists(databasePath))
            {
                File.Delete(databasePath);
            }
        }
    }
}
