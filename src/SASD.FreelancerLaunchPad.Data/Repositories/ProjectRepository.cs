using Microsoft.Data.Sqlite;
using SASD.FreelancerLaunchPad.Core.Domain;
using SASD.FreelancerLaunchPad.Core.Repositories;
using SASD.FreelancerLaunchPad.Data.Sqlite;

namespace SASD.FreelancerLaunchPad.Data.Repositories;

/// <summary>
/// SQLite implementation of <see cref="IProjectRepository"/>.
/// </summary>
/// <remarks>
/// This repository currently implements only the first read operation needed
/// by the MVP start screen. Create/update/delete operations will be added in
/// the next milestone together with the project editor form.
/// </remarks>
public sealed class ProjectRepository : IProjectRepository
{
    private readonly SqliteConnectionFactory _connectionFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectRepository"/> class.
    /// </summary>
    /// <param name="connectionFactory">Factory used to create database connections.</param>
    public ProjectRepository(SqliteConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
    }

    /// <inheritdoc />
    public IReadOnlyList<FreelanceProject> Search(ProjectSearchCriteria criteria)
    {
        criteria ??= new ProjectSearchCriteria();

        var projects = new List<FreelanceProject>();

        using var connection = _connectionFactory.CreateOpenConnection();
        using var command = connection.CreateCommand();

        command.CommandText = @"
SELECT
    p.id,
    p.platform_id,
    pf.name AS platform_name,
    p.title,
    p.url,
    p.description,
    p.budget_amount,
    p.hourly_rate,
    p.currency,
    p.published_at,
    p.current_status,
    p.external_reference,
    p.source_text,
    p.is_archived,
    p.created_at,
    p.updated_at,
    p.archived_at
FROM projects p
JOIN platforms pf ON pf.id = p.platform_id
WHERE
    (@include_archived = 1 OR p.is_archived = 0)
    AND (@status IS NULL OR p.current_status = @status)
    AND (@platform_id IS NULL OR p.platform_id = @platform_id)
    AND (
        @search_text IS NULL
        OR p.title LIKE '%' || @search_text || '%'
        OR p.description LIKE '%' || @search_text || '%'
        OR p.url LIKE '%' || @search_text || '%'
    )
ORDER BY p.updated_at DESC;
";

        command.Parameters.AddWithValue("@include_archived", criteria.IncludeArchived ? 1 : 0);
        command.Parameters.AddWithValue("@status", criteria.Status is null ? DBNull.Value : ToDatabaseStatus(criteria.Status.Value));
        command.Parameters.AddWithValue("@platform_id", criteria.PlatformId is null ? DBNull.Value : criteria.PlatformId.Value);
        command.Parameters.AddWithValue("@search_text", string.IsNullOrWhiteSpace(criteria.SearchText) ? DBNull.Value : criteria.SearchText.Trim());

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            projects.Add(ReadProject(reader));
        }

        return projects;
    }

    private static FreelanceProject ReadProject(SqliteDataReader reader)
    {
        return new FreelanceProject
        {
            Id = reader.GetInt64(0),
            PlatformId = reader.GetInt64(1),
            PlatformName = reader.GetString(2),
            Title = reader.GetString(3),
            Url = reader.IsDBNull(4) ? null : reader.GetString(4),
            Description = reader.IsDBNull(5) ? null : reader.GetString(5),
            BudgetAmount = reader.IsDBNull(6) ? null : Convert.ToDecimal(reader.GetDouble(6)),
            HourlyRate = reader.IsDBNull(7) ? null : Convert.ToDecimal(reader.GetDouble(7)),
            Currency = reader.IsDBNull(8) ? null : reader.GetString(8),
            PublishedAt = reader.IsDBNull(9) ? null : DateTimeOffset.Parse(reader.GetString(9)),
            CurrentStatus = FromDatabaseStatus(reader.GetString(10)),
            ExternalReference = reader.IsDBNull(11) ? null : reader.GetString(11),
            SourceText = reader.IsDBNull(12) ? null : reader.GetString(12),
            IsArchived = reader.GetInt32(13) == 1,
            CreatedAt = DateTimeOffset.Parse(reader.GetString(14)),
            UpdatedAt = DateTimeOffset.Parse(reader.GetString(15)),
            ArchivedAt = reader.IsDBNull(16) ? null : DateTimeOffset.Parse(reader.GetString(16))
        };
    }

    private static string ToDatabaseStatus(ProjectStatus status)
    {
        return status switch
        {
            ProjectStatus.New => "new",
            ProjectStatus.Interesting => "interesting",
            ProjectStatus.Watching => "watching",
            ProjectStatus.Applied => "applied",
            ProjectStatus.Rejected => "rejected",
            ProjectStatus.Won => "won",
            ProjectStatus.Archived => "archived",
            _ => "new"
        };
    }

    private static ProjectStatus FromDatabaseStatus(string value)
    {
        return value switch
        {
            "new" => ProjectStatus.New,
            "interesting" => ProjectStatus.Interesting,
            "watching" => ProjectStatus.Watching,
            "applied" => ProjectStatus.Applied,
            "rejected" => ProjectStatus.Rejected,
            "won" => ProjectStatus.Won,
            "archived" => ProjectStatus.Archived,
            _ => ProjectStatus.New
        };
    }
}
