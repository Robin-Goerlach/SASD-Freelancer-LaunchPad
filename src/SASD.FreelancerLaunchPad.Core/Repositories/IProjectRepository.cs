using SASD.FreelancerLaunchPad.Core.Domain;

namespace SASD.FreelancerLaunchPad.Core.Repositories;

/// <summary>
/// Defines persistence operations for freelance projects.
/// </summary>
public interface IProjectRepository
{
    /// <summary>
    /// Searches projects using the supplied criteria.
    /// </summary>
    /// <param name="criteria">Search and filter criteria.</param>
    /// <returns>A read-only list of matching projects.</returns>
    IReadOnlyList<FreelanceProject> Search(ProjectSearchCriteria criteria);
}
