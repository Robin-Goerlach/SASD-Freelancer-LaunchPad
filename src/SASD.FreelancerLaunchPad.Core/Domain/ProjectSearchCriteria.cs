namespace SASD.FreelancerLaunchPad.Core.Domain;

/// <summary>
/// Defines filter values used when searching or listing projects.
/// </summary>
public sealed class ProjectSearchCriteria
{
    /// <summary>Gets or sets the optional free-text search term.</summary>
    public string? SearchText { get; set; }

    /// <summary>Gets or sets the optional status filter.</summary>
    public ProjectStatus? Status { get; set; }

    /// <summary>Gets or sets the optional platform identifier filter.</summary>
    public long? PlatformId { get; set; }

    /// <summary>Gets or sets whether archived projects should be included in the result.</summary>
    public bool IncludeArchived { get; set; }
}
