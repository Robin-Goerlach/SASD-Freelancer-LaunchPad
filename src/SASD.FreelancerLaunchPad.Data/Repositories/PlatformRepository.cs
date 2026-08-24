using Microsoft.Data.Sqlite;
using SASD.FreelancerLaunchPad.Core.Domain;
using SASD.FreelancerLaunchPad.Core.Repositories;
using SASD.FreelancerLaunchPad.Data.Sqlite;

namespace SASD.FreelancerLaunchPad.Data.Repositories;

/// <summary>
/// SQLite implementation of <see cref="IPlatformRepository"/>.
/// </summary>
public sealed class PlatformRepository : IPlatformRepository
{
    private readonly SqliteConnectionFactory _connectionFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="PlatformRepository"/> class.
    /// </summary>
    /// <param name="connectionFactory">Factory used to create database connections.</param>
    public PlatformRepository(SqliteConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
    }

    /// <inheritdoc />
    public IReadOnlyList<Platform> GetActivePlatforms()
    {
        var platforms = new List<Platform>();

        using var connection = _connectionFactory.CreateOpenConnection();
        using var command = connection.CreateCommand();

        command.CommandText = @"
SELECT id, name, base_url, notes, is_active
FROM platforms
WHERE is_active = 1
ORDER BY name;
";

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            platforms.Add(ReadPlatform(reader));
        }

        return platforms;
    }

    private static Platform ReadPlatform(SqliteDataReader reader)
    {
        return new Platform
        {
            Id = reader.GetInt64(0),
            Name = reader.GetString(1),
            BaseUrl = reader.IsDBNull(2) ? null : reader.GetString(2),
            Notes = reader.IsDBNull(3) ? null : reader.GetString(3),
            IsActive = reader.GetInt32(4) == 1
        };
    }
}
