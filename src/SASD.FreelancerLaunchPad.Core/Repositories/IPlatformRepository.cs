using SASD.FreelancerLaunchPad.Core.Domain;

namespace SASD.FreelancerLaunchPad.Core.Repositories;

/// <summary>
/// Defines persistence operations for project source platforms.
/// </summary>
public interface IPlatformRepository
{
    /// <summary>
    /// Returns all active platforms.
    /// </summary>
    /// <returns>A read-only list of active platforms.</returns>
    IReadOnlyList<Platform> GetActivePlatforms();
}
