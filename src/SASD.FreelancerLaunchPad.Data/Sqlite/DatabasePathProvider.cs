namespace SASD.FreelancerLaunchPad.Data.Sqlite;

/// <summary>
/// Provides the default local database path for the application.
/// </summary>
public static class DatabasePathProvider
{
    /// <summary>
    /// Returns the default database file path below the current user's AppData folder.
    /// </summary>
    /// <returns>The recommended SQLite database path.</returns>
    public static string GetDefaultDatabasePath()
    {
        var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var directory = Path.Combine(appData, "SASD", "FreelancerLaunchPad");

        Directory.CreateDirectory(directory);

        return Path.Combine(directory, "freelancer_launchpad.db");
    }
}
