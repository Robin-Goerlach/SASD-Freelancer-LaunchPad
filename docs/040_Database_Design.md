# SASD Freelancer LaunchPad – Database Design

Version: 0.1  
Status: MVP-Datenbankentwurf  
Projekt: SASD Freelancer LaunchPad  
Organisation: SASD GmbH  
Dokumenttyp: Database Design  
Sprache: Deutsch  

---

# 1. Zweck des Dokuments

Dieses Dokument beschreibt das Datenbankdesign der MVP-Version von **SASD Freelancer LaunchPad**.

Es ergänzt Lastenheft, Pflichtenheft und Technical Design um die konkrete fachliche und technische Datenstruktur. Ziel ist eine einfache, robuste und erweiterbare SQLite-Datenbank, die den schnellen Start der Anwendung unterstützt und spätere Analysefunktionen nicht unnötig erschwert.

Das Datenbankdesign folgt dem Projektprinzip:

> Praktischer Nutzen vor Perfektion, aber keine bewusst unordentliche Datenhaltung.

---

# 2. Datenbankziel

Die Datenbank soll in der MVP-Version ermöglichen:

- lokale Speicherung von Freelancer-Projekten
- Speicherung der Plattform/Quelle
- Speicherung von Status und Statushistorie
- Speicherung von Skills/Keywords
- Speicherung von Projektnotizen
- spätere Auswertbarkeit von Projekten, Budgets und Skills
- einfache Sicherung durch Kopieren der SQLite-Datei

Die Datenbank soll bewusst klein bleiben. Sie soll aber so angelegt werden, dass spätere Erweiterungen wie Importläufe, Proposal-Verwaltung, Rating, Preisanalysen oder Plattformbeobachtung ergänzt werden können.

---

# 3. Datenbanktechnologie

## 3.1 Entscheidung

Für den MVP wird **SQLite** verwendet.

## 3.2 Begründung

SQLite ist für diese Anwendung geeignet, weil:

- keine Serverinstallation notwendig ist
- die Datenbank lokal als Datei gespeichert wird
- Backups einfach durch Kopieren möglich sind
- die Anwendung offline nutzbar bleibt
- SQLite gut mit C# über `Microsoft.Data.Sqlite` nutzbar ist
- die Komplexität gering bleibt

## 3.3 Abgrenzung

Nicht verwendet werden im MVP:

- SQL Server
- MySQL/MariaDB
- PostgreSQL
- Cloud-Datenbanken
- verteilte Datenhaltung

Diese Systeme wären für den ersten praktischen Nutzen überdimensioniert.

---

# 4. Speicherort der Datenbank

## 4.1 Entwicklungsphase

Während der Entwicklung kann die Datenbank im Projekt- oder Ausführungsverzeichnis liegen, z. B.:

```text
data/freelancer_launchpad.db
```

## 4.2 Spätere Standardablage

Für eine spätere nutzbare Windows-Version wird folgender Speicherort empfohlen:

```text
%APPDATA%\SASD\FreelancerLaunchPad\freelancer_launchpad.db
```

## 4.3 Backup

Die Datenbankdatei soll einfach kopierbar sein.

Ein Backup kann z. B. durch Kopieren folgender Datei erfolgen:

```text
freelancer_launchpad.db
```

Spätere Versionen können zusätzlich einen Backup-/Restore-Dialog erhalten.

---

# 5. Namenskonventionen

## 5.1 Tabellen

Tabellennamen werden in `snake_case` und im Plural geschrieben.

Beispiele:

- `projects`
- `platforms`
- `project_notes`
- `project_status_history`

## 5.2 Spalten

Spaltennamen werden ebenfalls in `snake_case` geschrieben.

Beispiele:

- `created_at`
- `updated_at`
- `platform_id`
- `current_status`

## 5.3 Primärschlüssel

Primärschlüssel heißen grundsätzlich:

```text
id
```

## 5.4 Fremdschlüssel

Fremdschlüssel bestehen aus dem Singularnamen der referenzierten Entität plus `_id`.

Beispiele:

- `project_id`
- `platform_id`
- `skill_id`

## 5.5 Zeitstempel

Zeitstempel werden im ISO-8601-kompatiblen Textformat gespeichert.

Beispiel:

```text
2026-05-12T14:30:00Z
```

Für die Anwendung gilt:

- intern möglichst UTC verwenden
- lokale Darstellung in der UI erlauben
- gespeicherte Werte eindeutig halten

---

# 6. MVP-Tabellenübersicht

Für den MVP werden folgende Tabellen vorgesehen:

| Tabelle | Zweck |
|---|---|
| `platforms` | Quellen/Plattformen wie PeoplePerHour oder manuelle Quellen |
| `projects` | zentrale Projektdaten |
| `skills` | Skills und Keywords |
| `project_skills` | Zuordnung zwischen Projekten und Skills |
| `project_notes` | freie Notizen zu Projekten |
| `project_status_history` | Historie von Statusänderungen |
| `schema_migrations` | einfache Verwaltung angewendeter SQL-Migrationen |

---

# 7. Entity-Relationship-Übersicht

Vereinfachte Beziehung:

```text
platforms 1 ─── n projects
projects  n ─── n skills
projects  1 ─── n project_notes
projects  1 ─── n project_status_history
```

Die n:m-Beziehung zwischen Projekten und Skills wird über `project_skills` abgebildet.

---

# 8. Tabelle `platforms`

## 8.1 Zweck

Die Tabelle `platforms` speichert Plattformen oder Quellen, von denen Projekte stammen.

Beispiele:

- PeoplePerHour
- Freelancermap
- Upwork
- Manuell
- Sonstige Quelle

## 8.2 Spalten

| Spalte | Typ | Pflicht | Beschreibung |
|---|---|---:|---|
| `id` | INTEGER | ja | Primärschlüssel |
| `name` | TEXT | ja | Name der Plattform |
| `base_url` | TEXT | nein | Basis-URL der Plattform |
| `notes` | TEXT | nein | Freie Notizen |
| `is_active` | INTEGER | ja | 1 = aktiv, 0 = inaktiv |
| `created_at` | TEXT | ja | Erstellungszeitpunkt |
| `updated_at` | TEXT | ja | Änderungszeitpunkt |

## 8.3 Fachliche Regeln

- Plattformnamen sollen eindeutig sein.
- Eine Plattform kann deaktiviert, aber nicht zwingend gelöscht werden.
- Für manuelle Einträge kann eine Plattform „Manual“ oder „Manuell“ angelegt werden.

---

# 9. Tabelle `projects`

## 9.1 Zweck

Die Tabelle `projects` ist die zentrale Tabelle der Anwendung.

Sie speichert Freelancer-Projektangebote, unabhängig davon, ob diese manuell erfasst oder später importiert wurden.

## 9.2 Spalten

| Spalte | Typ | Pflicht | Beschreibung |
|---|---|---:|---|
| `id` | INTEGER | ja | Primärschlüssel |
| `platform_id` | INTEGER | ja | Referenz auf `platforms` |
| `title` | TEXT | ja | Projekttitel |
| `url` | TEXT | nein | Projektlink |
| `description` | TEXT | nein | Projektbeschreibung |
| `budget_amount` | REAL | nein | Budgetbetrag |
| `hourly_rate` | REAL | nein | Stundensatz |
| `currency` | TEXT | nein | Währung, z. B. EUR, GBP, USD |
| `published_at` | TEXT | nein | Veröffentlichungsdatum |
| `current_status` | TEXT | ja | aktueller Status |
| `external_reference` | TEXT | nein | spätere externe Projekt-ID oder Referenz |
| `source_text` | TEXT | nein | optionaler Originaltext bei manueller Übernahme |
| `is_archived` | INTEGER | ja | 1 = archiviert |
| `created_at` | TEXT | ja | Erstellungszeitpunkt |
| `updated_at` | TEXT | ja | Änderungszeitpunkt |
| `archived_at` | TEXT | nein | Archivierungszeitpunkt |

## 9.3 Fachliche Regeln

- `title` darf nicht leer sein.
- `platform_id` muss vorhanden sein.
- `current_status` muss einen definierten Status enthalten.
- `budget_amount` darf nicht negativ sein.
- `hourly_rate` darf nicht negativ sein.
- `url` darf leer sein, sollte aber bei Eingabe plausibel sein.
- `is_archived` wird für schnelles Filtern archivierter Projekte verwendet.

## 9.4 Statuswerte

Für den MVP werden folgende Statuswerte empfohlen:

| Wert | Bedeutung |
|---|---|
| `new` | Neu |
| `interesting` | Interessant |
| `watching` | Beobachten |
| `applied` | Beworben |
| `rejected` | Abgelehnt |
| `won` | Zuschlag erhalten |
| `archived` | Archiviert |

Die UI kann diese Werte deutsch anzeigen, intern sollten stabile englische Schlüssel verwendet werden.

---

# 10. Tabelle `skills`

## 10.1 Zweck

Die Tabelle `skills` speichert Skills, Technologien oder Keywords, die Projekten zugeordnet werden können.

Beispiele:

- Linux
- PHP
- MariaDB
- MySQL
- REST API
- Windows Forms
- SQLite
- Server Migration

## 10.2 Spalten

| Spalte | Typ | Pflicht | Beschreibung |
|---|---|---:|---|
| `id` | INTEGER | ja | Primärschlüssel |
| `name` | TEXT | ja | Skillname |
| `normalized_name` | TEXT | ja | normalisierte Schreibweise |
| `notes` | TEXT | nein | freie Notizen |
| `is_active` | INTEGER | ja | 1 = aktiv |
| `created_at` | TEXT | ja | Erstellungszeitpunkt |
| `updated_at` | TEXT | ja | Änderungszeitpunkt |

## 10.3 Fachliche Regeln

- Skillnamen sollen eindeutig normalisiert werden.
- `PHP`, `php` und `Php` sollen nicht mehrfach entstehen.
- Für den MVP genügt eine einfache Normalisierung über Kleinschreibung und Trimmen.

---

# 11. Tabelle `project_skills`

## 11.1 Zweck

Diese Tabelle bildet die n:m-Beziehung zwischen Projekten und Skills ab.

Ein Projekt kann mehrere Skills haben. Ein Skill kann mehreren Projekten zugeordnet sein.

## 11.2 Spalten

| Spalte | Typ | Pflicht | Beschreibung |
|---|---|---:|---|
| `project_id` | INTEGER | ja | Referenz auf `projects` |
| `skill_id` | INTEGER | ja | Referenz auf `skills` |
| `created_at` | TEXT | ja | Zeitpunkt der Zuordnung |

## 11.3 Fachliche Regeln

- Eine Kombination aus `project_id` und `skill_id` darf nur einmal existieren.
- Beim Löschen eines Projekts sollen zugehörige Skill-Zuordnungen entfernt werden.
- Skills selbst sollen beim Löschen eines Projekts erhalten bleiben.

---

# 12. Tabelle `project_notes`

## 12.1 Zweck

Die Tabelle `project_notes` speichert freie Notizen zu Projekten.

Damit kann der Benutzer festhalten:

- warum ein Projekt interessant ist
- welche Risiken bestehen
- welche Bewerbungsidee vorhanden ist
- was später beobachtet werden soll
- wie der Ausgang bewertet wird

## 12.2 Spalten

| Spalte | Typ | Pflicht | Beschreibung |
|---|---|---:|---|
| `id` | INTEGER | ja | Primärschlüssel |
| `project_id` | INTEGER | ja | Referenz auf `projects` |
| `note_text` | TEXT | ja | Notiztext |
| `created_at` | TEXT | ja | Erstellungszeitpunkt |
| `updated_at` | TEXT | ja | Änderungszeitpunkt |

## 12.3 Fachliche Regeln

- Leere Notizen sollen nicht gespeichert werden.
- Notizen bleiben beim Projekt.
- Beim Löschen eines Projekts werden zugehörige Notizen gelöscht.

---

# 13. Tabelle `project_status_history`

## 13.1 Zweck

Diese Tabelle dokumentiert Statusänderungen eines Projekts.

Damit kann später nachvollzogen werden:

- wann ein Projekt bewertet wurde
- wann eine Bewerbung erfolgte
- wann ein Projekt abgelehnt oder archiviert wurde
- wie sich die Bearbeitung entwickelt hat

## 13.2 Spalten

| Spalte | Typ | Pflicht | Beschreibung |
|---|---|---:|---|
| `id` | INTEGER | ja | Primärschlüssel |
| `project_id` | INTEGER | ja | Referenz auf `projects` |
| `old_status` | TEXT | nein | vorheriger Status |
| `new_status` | TEXT | ja | neuer Status |
| `comment` | TEXT | nein | Kommentar zur Änderung |
| `changed_at` | TEXT | ja | Änderungszeitpunkt |

## 13.3 Fachliche Regeln

- Jeder Statuswechsel soll protokolliert werden.
- Beim Anlegen eines Projekts kann ein erster Statushistorieneintrag erzeugt werden.
- Beim Löschen eines Projekts werden zugehörige Statushistorien gelöscht.

---

# 14. Tabelle `schema_migrations`

## 14.1 Zweck

Die Tabelle `schema_migrations` dokumentiert, welche Datenbankmigrationen bereits angewendet wurden.

Für den MVP ist dies optional, aber sehr sinnvoll, weil spätere Änderungen geordnet nachvollzogen werden können.

## 14.2 Spalten

| Spalte | Typ | Pflicht | Beschreibung |
|---|---|---:|---|
| `id` | INTEGER | ja | Primärschlüssel |
| `migration_name` | TEXT | ja | Name der Migration |
| `applied_at` | TEXT | ja | Ausführungszeitpunkt |

## 14.3 Fachliche Regeln

- Jede Migration darf nur einmal eingetragen werden.
- Migrationen werden nach Dateinamen versioniert.

Beispiel:

```text
001_create_initial_schema.sql
```

---

# 15. Initiales SQL-Schema

Das folgende Schema beschreibt den geplanten MVP-Startpunkt.

```sql
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
```

---

# 16. Empfohlene Indizes

Für schnelle Suche und Filterung werden folgende Indizes empfohlen:

```sql
CREATE INDEX IF NOT EXISTS idx_projects_platform_id
ON projects(platform_id);

CREATE INDEX IF NOT EXISTS idx_projects_current_status
ON projects(current_status);

CREATE INDEX IF NOT EXISTS idx_projects_is_archived
ON projects(is_archived);

CREATE INDEX IF NOT EXISTS idx_projects_published_at
ON projects(published_at);

CREATE INDEX IF NOT EXISTS idx_project_notes_project_id
ON project_notes(project_id);

CREATE INDEX IF NOT EXISTS idx_project_status_history_project_id
ON project_status_history(project_id);

CREATE INDEX IF NOT EXISTS idx_project_skills_skill_id
ON project_skills(skill_id);
```

Für Volltextsuche wird im MVP noch keine FTS-Tabelle benötigt. Eine einfache Suche über `LIKE` reicht zunächst aus.

Später kann SQLite FTS5 geprüft werden.

---

# 17. Seed-Daten

Für den ersten Start sollen sinnvolle Standarddaten angelegt werden.

## 17.1 Plattformen

```sql
INSERT OR IGNORE INTO platforms (name, base_url, notes, is_active, created_at, updated_at)
VALUES
('PeoplePerHour', 'https://www.peopleperhour.com', 'Primary platform for early project tracking.', 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
('Freelancermap', 'https://www.freelancermap.de', 'Possible later platform.', 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
('Manual', NULL, 'Manually entered project source.', 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
```

## 17.2 Skills

```sql
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
```

---

# 18. Datenzugriff aus C#

## 18.1 Grundsatz

Die UI greift nicht direkt auf SQLite zu.

Der Datenzugriff erfolgt über Repository-Klassen in der Data-Schicht.

## 18.2 Repository-Kandidaten

Für den MVP werden folgende Repositories empfohlen:

- `IProjectRepository`
- `ProjectRepository`
- `IPlatformRepository`
- `PlatformRepository`
- `ISkillRepository`
- `SkillRepository`

## 18.3 Typische Methoden

Beispielhafte Methoden für `IProjectRepository`:

```csharp
Task<IReadOnlyList<Project>> GetAllAsync(ProjectSearchCriteria criteria);
Task<Project?> GetByIdAsync(long id);
Task<long> CreateAsync(Project project);
Task UpdateAsync(Project project);
Task ArchiveAsync(long projectId);
Task DeleteAsync(long projectId);
```

Für den schnellen MVP können die Methoden zunächst auch synchron implementiert werden. Asynchrone Methoden sind langfristig sauberer, aber bei lokaler SQLite-Nutzung nicht zwingend erforderlich.

---

# 19. Validierung und Integrität

## 19.1 Anwendungsebene

Folgende Validierungen sollen primär in der Anwendung erfolgen:

- Titel ist nicht leer
- Budget ist nicht negativ
- Stundensatz ist nicht negativ
- Plattform ist gewählt
- Status ist gültig
- URL ist plausibel, sofern gesetzt

## 19.2 Datenbankebene

Die Datenbank erzwingt:

- Primärschlüssel
- Fremdschlüssel
- Eindeutigkeit von Plattformnamen
- Eindeutigkeit normalisierter Skillnamen
- eindeutige Projekt-Skill-Zuordnungen

Weitere CHECK-Constraints können später ergänzt werden. Im MVP bleibt das Schema bewusst einfach.

---

# 20. Lösch- und Archivierungsstrategie

## 20.1 Archivieren statt Löschen

Für normale Nutzung soll Archivieren bevorzugt werden.

Archivieren bedeutet:

- `is_archived = 1`
- `archived_at` wird gesetzt
- Projekt bleibt historisch erhalten

## 20.2 Löschen

Löschen soll möglich sein, aber bewusst eingesetzt werden.

Beim Löschen eines Projekts werden automatisch gelöscht:

- zugehörige Notizen
- zugehörige Statushistorie
- zugehörige Skill-Zuordnungen

Die Skills selbst bleiben erhalten.

---

# 21. Erweiterbarkeit

Das MVP-Schema bereitet spätere Erweiterungen vor, ohne sie jetzt vollständig umzusetzen.

## 21.1 Spätere Tabellen

Mögliche spätere Tabellen:

- `proposals`
- `proposal_templates`
- `project_ratings`
- `import_runs`
- `imported_raw_items`
- `rate_analysis_snapshots`
- `competitor_profiles`
- `settings`
- `attachments`

## 21.2 Bewusste Zurückstellung

Diese Tabellen werden nicht im MVP angelegt, weil sie:

- die erste Version verzögern würden
- zusätzliche UI erfordern
- fachlich noch nicht vollständig validiert sind
- das Projekt unnötig komplex machen würden

---

# 22. Migrationsstrategie

## 22.1 Dateibasierte Migrationen

Migrationen sollen im Verzeichnis `database/` abgelegt werden.

Beispiele:

```text
database/
  001_create_initial_schema.sql
  002_insert_seed_data.sql
  003_add_project_rating.sql
```

## 22.2 Reihenfolge

Migrationen werden nach Dateinummer sortiert ausgeführt.

## 22.3 Protokollierung

Ausgeführte Migrationen werden in `schema_migrations` eingetragen.

---

# 23. Beispielabfragen

## 23.1 Alle aktiven Projekte

```sql
SELECT
    p.id,
    p.title,
    pf.name AS platform_name,
    p.current_status,
    p.budget_amount,
    p.hourly_rate,
    p.currency,
    p.published_at,
    p.updated_at
FROM projects p
JOIN platforms pf ON pf.id = p.platform_id
WHERE p.is_archived = 0
ORDER BY p.updated_at DESC;
```

## 23.2 Projekte nach Status

```sql
SELECT *
FROM projects
WHERE current_status = 'interesting'
  AND is_archived = 0
ORDER BY updated_at DESC;
```

## 23.3 Projekte mit bestimmtem Skill

```sql
SELECT p.*
FROM projects p
JOIN project_skills ps ON ps.project_id = p.id
JOIN skills s ON s.id = ps.skill_id
WHERE s.normalized_name = 'linux'
  AND p.is_archived = 0
ORDER BY p.updated_at DESC;
```

## 23.4 Budgetübersicht

```sql
SELECT
    currency,
    COUNT(*) AS project_count,
    AVG(budget_amount) AS average_budget,
    MIN(budget_amount) AS minimum_budget,
    MAX(budget_amount) AS maximum_budget
FROM projects
WHERE budget_amount IS NOT NULL
GROUP BY currency;
```

---

# 24. Qualitätshinweise

## 24.1 Einfachheit

Das Schema soll nicht künstlich verkompliziert werden.

Der MVP benötigt keine vollständige Projektmanagement-Datenbank.

## 24.2 Nachvollziehbarkeit

Felder sollen sprechend benannt sein.

## 24.3 Wartbarkeit

Änderungen am Schema sollen über Migrationen erfolgen.

## 24.4 Datensicherheit

Die Datenbank ist lokal. Trotzdem sollte der Benutzer regelmäßig Backups erstellen.

---

# 25. Offene Entscheidungen

Folgende Punkte können während der Umsetzung konkretisiert werden:

- finaler Speicherort der Datenbank
- Sync- oder Async-Datenzugriff
- xUnit oder MSTest
- genaue UI-Darstellung der Statuswerte
- ob `source_text` im MVP sichtbar bearbeitbar ist
- ob Notizen als eine große Notiz oder mehrere Notizeinträge angezeigt werden
- ob Soft Delete zusätzlich zu Archivierung benötigt wird

Diese Punkte blockieren den MVP nicht.

---

# 26. Zusammenfassung

Das Database Design definiert eine kleine, klare und erweiterbare SQLite-Datenbank für SASD Freelancer LaunchPad.

Die wichtigsten Entitäten sind:

- Plattformen
- Projekte
- Skills
- Projektnotizen
- Statushistorie

Das Schema unterstützt den schnellen MVP und lässt spätere Erweiterungen zu, ohne die erste Version unnötig zu verlangsamen.

Das wichtigste Ziel bleibt:

> Eine einfache Datenbank, die morgen hilft und später nicht im Weg steht.
