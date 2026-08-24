using SASD.FreelancerLaunchPad.App.UI;
using SASD.FreelancerLaunchPad.Data.Repositories;
using SASD.FreelancerLaunchPad.Data.Sqlite;

namespace SASD.FreelancerLaunchPad.App;

/// <summary>
/// Application entry point.
/// </summary>
internal static class Program
{
    /// <summary>
    /// Starts the Windows Forms application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        var databasePath = DatabasePathProvider.GetDefaultDatabasePath();

        var connectionFactory = new SqliteConnectionFactory(databasePath);
        var initializer = new DatabaseInitializer(connectionFactory);

        try
        {
            initializer.Initialize();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"The local database could not be initialized.\n\nDatabase path:\n{databasePath}\n\nError:\n{ex.Message}",
                "SASD Freelancer LaunchPad - Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        var projectRepository = new ProjectRepository(connectionFactory);
        var platformRepository = new PlatformRepository(connectionFactory);

        Application.Run(new MainForm(projectRepository, platformRepository, databasePath));
    }
}
