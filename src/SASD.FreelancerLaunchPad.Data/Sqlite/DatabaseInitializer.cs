using Microsoft.Data.Sqlite;

namespace SASD.FreelancerLaunchPad.Data.Sqlite;

/// <summary>
/// Creates and initializes the local SQLite database.
/// </summary>
/// <remarks>
/// The initializer currently uses embedded SQL strings so the application can
/// start without relying on external files being copied to the output folder.
/// The repository still contains SQL files under /database for documentation,
/// review and future migration tooling.
/// </remarks>
public sealed class DatabaseInitializer
{
    private readonly SqliteConnectionFactory _connectionFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="DatabaseInitializer"/> class.
    /// </summary>
    /// <param name="connectionFactory">Factory used to create SQLite connections.</param>
    public DatabaseInitializer(SqliteConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
    }

    /// <summary>
    /// Ensures that the database schema and seed data exist.
    /// </summary>
    public void Initialize()
    {
        using var connection = _connectionFactory.CreateOpenConnection();

        ExecuteScript(connection, SchemaSql);
        ExecuteScript(connection, SeedSql);
    }

    private static void ExecuteScript(SqliteConnection connection, string script)
    {
        using var command = connection.CreateCommand();
        command.CommandText = script;
        command.ExecuteNonQuery();
    }

    private const string SchemaSql = @"
PRAGMA foreign_keys = ON;

CREATE TABLE IF NOT EXISTS schema_migrations (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    migration_name TEXT NOT NULL UNIQUE,
    applied_at TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS platforms (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL UNIQUE,
    base_url TEXT NULL,
    notes TEXT NULL,
    is_active INTEGER NOT NULL DEFAULT 1,
    created_at TEXT NOT NULL,
    updated_at TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS projects (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    platform_id INTEGER NOT NULL,
    title TEXT NOT NULL,
    url TEXT NULL,
    description TEXT NULL,
    budget_amount REAL NULL,
    hourly_rate REAL NULL,
    currency TEXT NULL,
    published_at TEXT NULL,
    current_status TEXT NOT NULL DEFAULT 'new',
    external_reference TEXT NULL,
    source_text TEXT NULL,
    is_archived INTEGER NOT NULL DEFAULT 0,
    created_at TEXT NOT NULL,
    updated_at TEXT NOT NULL,
    archived_at TEXT NULL,
    FOREIGN KEY (platform_id) REFERENCES platforms(id)
);

CREATE TABLE IF NOT EXISTS skills (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    normalized_name TEXT NOT NULL UNIQUE,
    notes TEXT NULL,
    is_active INTEGER NOT NULL DEFAULT 1,
    created_at TEXT NOT NULL,
    updated_at TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS project_skills (
    project_id INTEGER NOT NULL,
    skill_id INTEGER NOT NULL,
    created_at TEXT NOT NULL,
    PRIMARY KEY (project_id, skill_id),
    FOREIGN KEY (project_id) REFERENCES projects(id) ON DELETE CASCADE,
    FOREIGN KEY (skill_id) REFERENCES skills(id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS project_notes (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    project_id INTEGER NOT NULL,
    note_text TEXT NOT NULL,
    created_at TEXT NOT NULL,
    updated_at TEXT NOT NULL,
    FOREIGN KEY (project_id) REFERENCES projects(id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS project_status_history (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    project_id INTEGER NOT NULL,
    old_status TEXT NULL,
    new_status TEXT NOT NULL,
    comment TEXT NULL,
    changed_at TEXT NOT NULL,
    FOREIGN KEY (project_id) REFERENCES projects(id) ON DELETE CASCADE
);

CREATE INDEX IF NOT EXISTS idx_projects_platform_id ON projects(platform_id);
CREATE INDEX IF NOT EXISTS idx_projects_current_status ON projects(current_status);
CREATE INDEX IF NOT EXISTS idx_projects_is_archived ON projects(is_archived);
CREATE INDEX IF NOT EXISTS idx_projects_published_at ON projects(published_at);
CREATE INDEX IF NOT EXISTS idx_project_notes_project_id ON project_notes(project_id);
CREATE INDEX IF NOT EXISTS idx_project_status_history_project_id ON project_status_history(project_id);
CREATE INDEX IF NOT EXISTS idx_project_skills_skill_id ON project_skills(skill_id);
";

    private const string SeedSql = @"
INSERT OR IGNORE INTO platforms (name, base_url, notes, is_active, created_at, updated_at)
VALUES
('PeoplePerHour', 'https://www.peopleperhour.com', 'Primary platform for early project tracking.', 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
('Freelancermap', 'https://www.freelancermap.de', 'Possible later platform.', 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
('Manual', NULL, 'Manually entered project source.', 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);

INSERT OR IGNORE INTO skills (name, normalized_name, notes, is_active, created_at, updated_at)
VALUES
('Linux', 'linux', NULL, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
('PHP', 'php', NULL, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
('MariaDB', 'mariadb', NULL, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
('MySQL', 'mysql', NULL, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
('SQLite', 'sqlite', NULL, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
('C#', 'c#', NULL, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
('Windows Forms', 'windows forms', NULL, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
('REST API', 'rest api', NULL, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
('Server Migration', 'server migration', NULL, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
";
}
