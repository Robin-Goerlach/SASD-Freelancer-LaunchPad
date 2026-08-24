namespace SASD.FreelancerLaunchPad.Core.Domain;

/// <summary>
/// Represents a freelance project opportunity tracked by the application.
/// </summary>
/// <remarks>
/// This class intentionally contains only straightforward domain data.
/// Database logic belongs to the Data project and UI logic belongs to the App project.
/// </remarks>
public sealed class FreelanceProject
{
    /// <summary>Gets or sets the database identifier of the project.</summary>
    public long Id { get; set; }

    /// <summary>Gets or sets the identifier of the source platform.</summary>
    public long PlatformId { get; set; }

    /// <summary>Gets or sets the platform name for display purposes.</summary>
    public string PlatformName { get; set; } = string.Empty;

    /// <summary>Gets or sets the project title.</summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>Gets or sets the optional source URL of the project.</summary>
    public string? Url { get; set; }

    /// <summary>Gets or sets the optional project description.</summary>
    public string? Description { get; set; }

    /// <summary>Gets or sets the optional fixed project budget.</summary>
    public decimal? BudgetAmount { get; set; }

    /// <summary>Gets or sets the optional hourly rate.</summary>
    public decimal? HourlyRate { get; set; }

    /// <summary>Gets or sets the optional currency code, e.g. EUR, GBP or USD.</summary>
    public string? Currency { get; set; }

    /// <summary>Gets or sets the optional publication timestamp.</summary>
    public DateTimeOffset? PublishedAt { get; set; }

    /// <summary>Gets or sets the current workflow status of the project.</summary>
    public ProjectStatus CurrentStatus { get; set; } = ProjectStatus.New;

    /// <summary>Gets or sets an optional external platform reference for later imports.</summary>
    public string? ExternalReference { get; set; }

    /// <summary>Gets or sets an optional raw source text copied from a platform.</summary>
    public string? SourceText { get; set; }

    /// <summary>Gets or sets whether this project is archived.</summary>
    public bool IsArchived { get; set; }

    /// <summary>Gets or sets the creation timestamp.</summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>Gets or sets the last update timestamp.</summary>
    public DateTimeOffset UpdatedAt { get; set; }

    /// <summary>Gets or sets the optional archive timestamp.</summary>
    public DateTimeOffset? ArchivedAt { get; set; }
}
