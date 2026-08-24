using SASD.FreelancerLaunchPad.Core.Domain;
using SASD.FreelancerLaunchPad.Core.Repositories;

namespace SASD.FreelancerLaunchPad.App.UI;

/// <summary>
/// Main application window for the MVP.
/// </summary>
/// <remarks>
/// This first version intentionally focuses on startup, database initialization
/// and displaying the basic project list. Create/edit functionality follows in
/// the next milestone.
/// </remarks>
public sealed class MainForm : Form
{
    private readonly IProjectRepository _projectRepository;
    private readonly IPlatformRepository _platformRepository;
    private readonly string _databasePath;

    private readonly TextBox _searchTextBox = new();
    private readonly ComboBox _statusComboBox = new();
    private readonly ComboBox _platformComboBox = new();
    private readonly CheckBox _includeArchivedCheckBox = new();
    private readonly DataGridView _projectGrid = new();
    private readonly StatusStrip _statusStrip = new();
    private readonly ToolStripStatusLabel _statusLabel = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="MainForm"/> class.
    /// </summary>
    /// <param name="projectRepository">Repository used to load projects.</param>
    /// <param name="platformRepository">Repository used to load platforms.</param>
    /// <param name="databasePath">Path to the local SQLite database.</param>
    public MainForm(
        IProjectRepository projectRepository,
        IPlatformRepository platformRepository,
        string databasePath)
    {
        _projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
        _platformRepository = platformRepository ?? throw new ArgumentNullException(nameof(platformRepository));
        _databasePath = databasePath;

        Text = "SASD Freelancer LaunchPad";
        Width = 1200;
        Height = 720;
        StartPosition = FormStartPosition.CenterScreen;

        BuildUserInterface();

        Load += (_, _) =>
        {
            LoadPlatforms();
            ReloadProjects();
        };
    }

    private void BuildUserInterface()
    {
        var root = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 3
        };

        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 72));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 24));

        Controls.Add(root);

        root.Controls.Add(BuildFilterPanel(), 0, 0);

        ConfigureProjectGrid();
        root.Controls.Add(_projectGrid, 0, 1);

        _statusStrip.Items.Add(_statusLabel);
        root.Controls.Add(_statusStrip, 0, 2);
    }

    private Control BuildFilterPanel()
    {
        var panel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(12),
            ColumnCount = 8,
            RowCount = 1
        };

        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70));
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70));
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));

        panel.Controls.Add(new Label { Text = "Suche:", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 0);

        _searchTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        _searchTextBox.PlaceholderText = "Titel, Beschreibung oder URL durchsuchen";
        panel.Controls.Add(_searchTextBox, 1, 0);

        panel.Controls.Add(new Label { Text = "Status:", AutoSize = true, Anchor = AnchorStyles.Left }, 2, 0);

        _statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        _statusComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        panel.Controls.Add(_statusComboBox, 3, 0);

        panel.Controls.Add(new Label { Text = "Plattform:", AutoSize = true, Anchor = AnchorStyles.Left }, 4, 0);

        _platformComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        _platformComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        panel.Controls.Add(_platformComboBox, 5, 0);

        _includeArchivedCheckBox.Text = "Archiv anzeigen";
        _includeArchivedCheckBox.AutoSize = true;
        _includeArchivedCheckBox.Anchor = AnchorStyles.Left;
        panel.Controls.Add(_includeArchivedCheckBox, 6, 0);

        var reloadButton = new Button
        {
            Text = "Aktualisieren",
            Anchor = AnchorStyles.Left | AnchorStyles.Right
        };

        reloadButton.Click += (_, _) => ReloadProjects();
        panel.Controls.Add(reloadButton, 7, 0);

        _searchTextBox.TextChanged += (_, _) => ReloadProjects();
        _statusComboBox.SelectedIndexChanged += (_, _) => ReloadProjects();
        _platformComboBox.SelectedIndexChanged += (_, _) => ReloadProjects();
        _includeArchivedCheckBox.CheckedChanged += (_, _) => ReloadProjects();

        return panel;
    }

    private void ConfigureProjectGrid()
    {
        _projectGrid.Dock = DockStyle.Fill;
        _projectGrid.ReadOnly = true;
        _projectGrid.AllowUserToAddRows = false;
        _projectGrid.AllowUserToDeleteRows = false;
        _projectGrid.AutoGenerateColumns = false;
        _projectGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _projectGrid.MultiSelect = false;
        _projectGrid.RowHeadersVisible = false;

        _projectGrid.Columns.Add(CreateTextColumn(nameof(FreelanceProject.CurrentStatus), "Status", 110));
        _projectGrid.Columns.Add(CreateTextColumn(nameof(FreelanceProject.PlatformName), "Plattform", 130));
        _projectGrid.Columns.Add(CreateTextColumn(nameof(FreelanceProject.Title), "Titel", 360));
        _projectGrid.Columns.Add(CreateTextColumn(nameof(FreelanceProject.BudgetAmount), "Budget", 90));
        _projectGrid.Columns.Add(CreateTextColumn(nameof(FreelanceProject.HourlyRate), "Stundensatz", 100));
        _projectGrid.Columns.Add(CreateTextColumn(nameof(FreelanceProject.Currency), "Währung", 80));
        _projectGrid.Columns.Add(CreateTextColumn(nameof(FreelanceProject.PublishedAt), "Veröffentlicht", 150));
        _projectGrid.Columns.Add(CreateTextColumn(nameof(FreelanceProject.UpdatedAt), "Aktualisiert", 150));
    }

    private static DataGridViewTextBoxColumn CreateTextColumn(string propertyName, string headerText, int width)
    {
        return new DataGridViewTextBoxColumn
        {
            DataPropertyName = propertyName,
            HeaderText = headerText,
            Width = width
        };
    }

    private void LoadPlatforms()
    {
        var platformItems = new List<ComboBoxItem<long?>>
        {
            new("Alle", null)
        };

        foreach (var platform in _platformRepository.GetActivePlatforms())
        {
            platformItems.Add(new ComboBoxItem<long?>(platform.Name, platform.Id));
        }

        _platformComboBox.DataSource = platformItems;
        _platformComboBox.DisplayMember = nameof(ComboBoxItem<long?>.Text);
        _platformComboBox.ValueMember = nameof(ComboBoxItem<long?>.Value);

        var statusItems = new List<ComboBoxItem<ProjectStatus?>>
        {
            new("Alle", null),
            new("Neu", ProjectStatus.New),
            new("Interessant", ProjectStatus.Interesting),
            new("Beobachten", ProjectStatus.Watching),
            new("Beworben", ProjectStatus.Applied),
            new("Abgelehnt", ProjectStatus.Rejected),
            new("Zuschlag erhalten", ProjectStatus.Won),
            new("Archiviert", ProjectStatus.Archived)
        };

        _statusComboBox.DataSource = statusItems;
        _statusComboBox.DisplayMember = nameof(ComboBoxItem<ProjectStatus?>.Text);
        _statusComboBox.ValueMember = nameof(ComboBoxItem<ProjectStatus?>.Value);
    }

    private void ReloadProjects()
    {
        try
        {
            var criteria = new ProjectSearchCriteria
            {
                SearchText = _searchTextBox.Text,
                IncludeArchived = _includeArchivedCheckBox.Checked,
                PlatformId = (_platformComboBox.SelectedItem as ComboBoxItem<long?>)?.Value,
                Status = (_statusComboBox.SelectedItem as ComboBoxItem<ProjectStatus?>)?.Value
            };

            var projects = _projectRepository.Search(criteria);

            _projectGrid.DataSource = projects.ToList();
            _statusLabel.Text = $"{projects.Count} Projekt(e) geladen – Datenbank: {_databasePath}";
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Projects could not be loaded.\n\nError:\n{ex.Message}",
                "SASD Freelancer LaunchPad - Load Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private sealed class ComboBoxItem<T>
    {
        public ComboBoxItem(string text, T value)
        {
            Text = text;
            Value = value;
        }

        public string Text { get; }

        public T Value { get; }
    }
}
