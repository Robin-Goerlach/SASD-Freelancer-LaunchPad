namespace SASD.FreelancerLaunchPad.Core.Domain;

/// <summary>
/// Represents a source platform or manual source from which a project opportunity originates.
/// </summary>
public sealed class Platform
{
    /// <summary>Gets or sets the database identifier of the platform.</summary>
    public long Id { get; set; }

    /// <summary>Gets or sets the human-readable platform name, e.g. PeoplePerHour.</summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>Gets or sets the optional platform base URL.</summary>
    public string? BaseUrl { get; set; }

    /// <summary>Gets or sets optional notes about the platform.</summary>
    public string? Notes { get; set; }

    /// <summary>Gets or sets whether this platform is active and should be shown in selection lists.</summary>
    public bool IsActive { get; set; } = true;
}
