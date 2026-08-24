namespace SASD.FreelancerLaunchPad.Core.Domain;

/// <summary>
/// Defines the lifecycle status of a tracked freelance project.
/// </summary>
/// <remarks>
/// The enum names are intentionally stable English identifiers because they
/// are stored in the database. The UI may translate them to German labels.
/// </remarks>
public enum ProjectStatus
{
    /// <summary>The project was captured but has not been evaluated yet.</summary>
    New,

    /// <summary>The project looks relevant and may be worth further analysis.</summary>
    Interesting,

    /// <summary>The project should be monitored but is not yet ready for action.</summary>
    Watching,

    /// <summary>A proposal or application was submitted.</summary>
    Applied,

    /// <summary>The project is not worth pursuing or was rejected.</summary>
    Rejected,

    /// <summary>The freelancer won the project.</summary>
    Won,

    /// <summary>The project is no longer active in the normal work list.</summary>
    Archived
}
