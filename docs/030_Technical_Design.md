# SASD Freelancer LaunchPad – Technical Design

Version: 0.1  
Status: MVP-Architekturentwurf  
Projekt: SASD Freelancer LaunchPad  
Organisation: SASD GmbH  
Dokumenttyp: Technical Design  
Sprache: Deutsch  

---

# 1. Zweck des Dokuments

Dieses Dokument beschreibt das technische Design der MVP-Version von **SASD Freelancer LaunchPad**.

Es übersetzt die fachlichen Anforderungen aus Lastenheft und Pflichtenheft in eine konkrete technische Struktur. Ziel ist eine kleine, stabile, wartbare Windows-Desktop-Anwendung, die schnell nutzbar ist und später kontrolliert erweitert werden kann.

Der Schwerpunkt liegt nicht auf maximaler Architekturkomplexität, sondern auf einem klaren, verständlichen und produktiv umsetzbaren Aufbau.

---

# 2. Architekturziel

## 2.1 Leitidee

Die Anwendung soll als lokale Desktop-Anwendung entwickelt werden, die Freelancer-Projekte strukturiert erfasst, verwaltet und später auswertbar macht.

Das zentrale Architekturziel lautet:

> Eine einfache, robuste und verständliche MVP-Architektur, die sofort Nutzen liefert und spätere Erweiterungen nicht blockiert.

## 2.2 Nicht-Ziel der Architektur

Die MVP-Architektur soll ausdrücklich NICHT versuchen, bereits alle später denkbaren Ausbaustufen vollständig abzubilden.

Nicht Ziel des MVP-Designs sind:

- komplexe Plugin-Architektur
- Enterprise-Framework-Overhead
- Cloud-Synchronisation
- Multi-User-Betrieb
- automatische Scraping-Pipeline
- mandantenfähige Plattform
- übermäßig abstrakte Repository-/Service-Schichten

Die Architektur soll klein bleiben, aber nicht schlampig werden.

---

# 3. Technologiestack

| Bereich | Entscheidung |
|---|---|
| Programmiersprache | C# |
| Runtime / Framework | .NET 10 |
| Benutzeroberfläche | Windows Forms |
| Datenbank | SQLite |
| Datenzugriff | Microsoft.Data.Sqlite |
| Tests | xUnit oder MSTest, später festzulegen |
| IDE | Visual Studio |
| Versionsverwaltung | Git |
| Repository | GitHub |

---

# 4. Solution-Struktur

Die Solution soll nicht aus nur einem einzigen Projekt bestehen. Auch für den MVP ist eine kleine Trennung sinnvoll, damit die Anwendung später nicht unwartbar wird.

```text
SASD.FreelancerLaunchPad/
  src/
    SASD.FreelancerLaunchPad.App/
    SASD.FreelancerLaunchPad.Core/
    SASD.FreelancerLaunchPad.Data/
    SASD.FreelancerLaunchPad.Import/
  tests/
    SASD.FreelancerLaunchPad.Tests/
  database/
    001_create_initial_schema.sql
    002_insert_seed_data.sql
  docs/
    010_Lastenheft.md
    020_Pflichtenheft_MVP.md
    030_Technical_Design.md
    040_Database_Design.md
```

---

# 5. Projektverantwortung pro Assembly

## 5.1 SASD.FreelancerLaunchPad.App

Dieses Projekt enthält die Windows-Forms-Oberfläche.

Aufgaben:

- Start der Anwendung
- Hauptfenster
- Projektliste
- Projekteditor
- Such- und Filteroberfläche
- Benutzerinteraktion
- Anzeige von Statusmeldungen

Dieses Projekt darf UI-spezifische Logik enthalten, aber keine SQL-Details und keine direkte Datenbanklogik.

## 5.2 SASD.FreelancerLaunchPad.Core

Dieses Projekt enthält die fachlichen Modelle und Geschäftslogik.

Aufgaben:

- Domänenmodelle
- Enums
- Validierungslogik
- fachliche Services
- einfache Such-/Filtermodelle
- zentrale Geschäftsregeln

Beispiele:

- `Project`
- `Platform`
- `Skill`
- `ProjectNote`
- `ProjectStatus`
- `ProjectSearchCriteria`

## 5.3 SASD.FreelancerLaunchPad.Data

Dieses Projekt enthält die Datenzugriffsschicht.

Aufgaben:

- SQLite-Verbindung
- Repository-Klassen
- Datenbankinitialisierung
- einfache Migrationen
- Mapping zwischen SQLite und Core-Modellen

Beispiele:

- `DatabaseInitializer`
- `ProjectRepository`
- `PlatformRepository`
- `SkillRepository`
- `SqliteConnectionFactory`

## 5.4 SASD.FreelancerLaunchPad.Import

Dieses Projekt ist für spätere Importfunktionen reserviert.

Im MVP bleibt es entweder leer oder enthält nur Platzhalter/Interfaces.

Mögliche spätere Aufgaben:

- CSV-Import
- JSON-Import
- manuelle Textanalyse
- Feed-Import
- externe Plattform-Importe

Automatisiertes Scraping gehört NICHT zur MVP-Version.

## 5.5 SASD.FreelancerLaunchPad.Tests

Dieses Projekt enthält automatisierte Tests.

Im MVP reichen einfache Tests für:

- Validierungen
- Statuslogik
- Repository-Funktionen
- Datenbankinitialisierung

---

# 6. Schichtenmodell

Die Anwendung folgt einem einfachen Schichtenmodell:

```text
Windows Forms UI
      ↓
Application Services / Core Services
      ↓
Repositories
      ↓
SQLite
```

## 6.1 UI-Schicht

Die UI-Schicht zeigt Daten an und nimmt Benutzereingaben entgegen.

Sie soll:

- keine SQL-Statements enthalten
- keine Datenbankverbindungen direkt öffnen
- keine komplexe Geschäftslogik enthalten

## 6.2 Core-Schicht

Die Core-Schicht enthält die fachliche Bedeutung der Anwendung.

Sie soll:

- unabhängig von Windows Forms bleiben
- unabhängig von SQLite bleiben
- später auch für andere UIs verwendbar sein

## 6.3 Data-Schicht

Die Data-Schicht kapselt den Zugriff auf SQLite.

Sie soll:

- SQL zentral halten
- Datenbankdetails von UI und Core fernhalten
- einfache Austauschbarkeit ermöglichen

---

# 7. Zentrale Domänenobjekte

## 7.1 Project

Ein Projektangebot, das aus einer Freelancer-Plattform oder einer anderen Quelle stammt.

Wichtige Eigenschaften:

- Id
- PlatformId
- Title
- Url
- Description
- BudgetAmount
- HourlyRate
- Currency
- PublishedAt
- CurrentStatus
- CreatedAt
- UpdatedAt
- ArchivedAt

## 7.2 Platform

Beschreibt die Quelle eines Projektangebots.

Beispiele:

- PeoplePerHour
- Freelancermap
- Manuelle Quelle
- Sonstige Plattform

Wichtige Eigenschaften:

- Id
- Name
- BaseUrl
- Notes
- IsActive

## 7.3 Skill

Ein Skill oder Keyword, das einem Projekt zugeordnet werden kann.

Beispiele:

- Linux
- PHP
- MariaDB
- MySQL
- REST API
- Windows Forms
- Server Migration

## 7.4 ProjectNote

Freie Notiz zu einem Projekt.

Wichtige Eigenschaften:

- Id
- ProjectId
- NoteText
- CreatedAt
- UpdatedAt

## 7.5 ProjectStatusHistory

Historisiert Statusänderungen.

Wichtige Eigenschaften:

- Id
- ProjectId
- OldStatus
- NewStatus
- ChangedAt
- Comment

---

# 8. Statusmodell

Für den MVP werden folgende Projektstatus definiert:

| Status | Bedeutung |
|---|---|
| Neu | Projekt wurde erfasst, aber noch nicht bewertet |
| Interessant | Projekt wirkt grundsätzlich passend |
| Beobachten | Projekt soll weiter verfolgt werden |
| Beworben | Eine Bewerbung wurde gesendet |
| Abgelehnt | Projekt wird nicht weiter verfolgt |
| Zuschlag erhalten | Der Auftrag wurde gewonnen |
| Archiviert | Projekt ist erledigt oder nicht mehr relevant |

Statusänderungen sollen in der Tabelle `project_status_history` dokumentiert werden.

---

# 9. Datenbankstrategie

## 9.1 SQLite als lokale Datenbank

SQLite ist für den MVP geeignet, weil:

- keine Serverinstallation erforderlich ist
- die Datenbank als Datei vorliegt
- Backups einfach sind
- lokale Desktop-Anwendungen gut unterstützt werden

## 9.2 Speicherort der Datenbank

Für die Entwicklung kann die Datenbank zunächst im lokalen Projekt- oder App-Verzeichnis liegen.

Später sollte sie unterhalb eines Benutzerverzeichnisses abgelegt werden, z. B.:

```text
%APPDATA%\SASD\FreelancerLaunchPad\freelancer_launchpad.db
```

Für den MVP ist wichtig, dass der Speicherort klar dokumentiert ist.

## 9.3 Migrationen

Für den MVP wird eine einfache SQL-Datei verwendet:

```text
database/001_create_initial_schema.sql
```

Spätere Migrationen können nummeriert ergänzt werden:

```text
database/002_add_project_rating.sql
database/003_add_import_runs.sql
```

---

# 10. Datenzugriff

## 10.1 Repository Pattern

Der Zugriff auf Daten erfolgt über Repository-Klassen.

Beispiele:

- `IProjectRepository`
- `ProjectRepository`
- `IPlatformRepository`
- `PlatformRepository`
- `ISkillRepository`
- `SkillRepository`

Das Interface liegt in `Core`, die SQLite-Implementierung in `Data`.

## 10.2 Connection Factory

Eine zentrale Connection Factory stellt SQLite-Verbindungen bereit.

Beispiel:

```text
SqliteConnectionFactory
```

Aufgaben:

- Connection String verwalten
- neue Verbindungen erzeugen
- Speicherort der Datenbank kapseln

## 10.3 Kein direkter SQL-Code in der UI

SQL wird ausschließlich in der Data-Schicht verwendet.

---

# 11. Benutzeroberfläche

## 11.1 Hauptfenster

Das Hauptfenster ist der zentrale Arbeitsbereich.

Es enthält:

- Projektliste
- Suchfeld
- Statusfilter
- Plattformfilter
- Schaltflächen für Neu/Bearbeiten/Löschen/Archivieren
- Statusleiste

## 11.2 Projektliste

Die Projektliste wird als `DataGridView` umgesetzt.

Geplante Spalten:

- Status
- Plattform
- Titel
- Budget
- Stundensatz
- Währung
- Veröffentlichungsdatum
- Aktualisiert am

## 11.3 Projekteditor

Der Projekteditor wird als separates Formular umgesetzt.

Felder:

- Plattform
- Titel
- URL
- Beschreibung
- Budget
- Stundensatz
- Währung
- Veröffentlichungsdatum
- Status
- Skills
- Notizen

Für den MVP kann die Skill-Eingabe zunächst als kommaseparierter Text erfolgen. Eine komfortable Mehrfachauswahl kann später ergänzt werden.

---

# 12. Validierungsregeln

## 12.1 Mindestvalidierung

Für den MVP gelten folgende Regeln:

- Titel darf nicht leer sein
- URL darf leer sein, muss aber bei Eingabe grundsätzlich plausibel sein
- Budget darf nicht negativ sein
- Stundensatz darf nicht negativ sein
- Plattform muss gesetzt sein
- Status muss gesetzt sein

## 12.2 Fehleranzeige

Validierungsfehler werden dem Benutzer im Formular angezeigt.

Für den MVP reicht eine einfache MessageBox oder ein Fehlerlabel.

---

# 13. Fehlerbehandlung

## 13.1 Grundprinzip

Fehler sollen verständlich und kontrolliert behandelt werden.

Die Anwendung soll nicht kommentarlos abstürzen.

## 13.2 MVP-Fehlerfälle

Zu behandeln sind mindestens:

- Datenbankdatei nicht erreichbar
- Datenbankinitialisierung schlägt fehl
- Speichern eines Projekts schlägt fehl
- ungültige Benutzereingaben
- unerwartete Datenbankfehler

## 13.3 Logging

Für den MVP reicht zunächst eine einfache Debug-Ausgabe oder spätere lokale Logdatei.

Ein vollständiges Logging-Framework ist für den MVP nicht notwendig.

---

# 14. Konfiguration

## 14.1 MVP-Konfiguration

Für den MVP sollen nur sehr wenige Konfigurationen notwendig sein.

Mögliche Einstellungen:

- Datenbankpfad
- Standardplattform
- Standardwährung

Diese Einstellungen können zunächst fest im Code oder in einer einfachen Konfigurationsdatei verwaltet werden.

## 14.2 Spätere Konfiguration

Spätere Versionen können eine Benutzeroberfläche für Einstellungen erhalten.

---

# 15. Sicherheit

## 15.1 Lokale Anwendung

Da die Anwendung lokal arbeitet, ist der Angriffsraum im MVP begrenzt.

Trotzdem gelten folgende Grundsätze:

- keine unnötige Speicherung sensibler Daten
- keine Passwörter speichern
- keine Login-Daten für Plattformen speichern
- keine automatische Anmeldung an externen Plattformen

## 15.2 Externe Plattformen

Im MVP gibt es keine automatische Kommunikation mit PeoplePerHour oder anderen Plattformen.

Damit werden rechtliche und technische Risiken reduziert.

---

# 16. Datenschutz

## 16.1 Personenbezogene Daten

Die Anwendung soll im MVP keine personenbezogenen Kundendaten erfassen müssen.

Falls Projekttexte personenbezogene Daten enthalten, liegt die Verantwortung beim Benutzer, diese Daten bewusst zu speichern.

## 16.2 Lokale Kontrolle

Alle Daten bleiben lokal auf dem Rechner des Benutzers.

---

# 17. Testkonzept

## 17.1 Manuelle Tests

Mindesttests:

- Anwendung startet
- Datenbank wird erstellt
- Projekt kann angelegt werden
- Projekt kann bearbeitet werden
- Projekt kann gelöscht oder archiviert werden
- Suche funktioniert
- Filter funktionieren
- Daten bleiben nach Neustart erhalten

## 17.2 Automatisierte Tests

Frühe automatisierte Tests sollten prüfen:

- Validierung von Projektdaten
- Statuswechsel
- Repository-Speichern
- Repository-Laden
- Datenbankinitialisierung

---

# 18. Entwicklungsmeilensteine

## 18.1 Meilenstein 1 – Solution und Datenbankbasis

Ergebnis:

- Solution existiert
- Projekte sind angelegt
- Datenbankinitialisierung funktioniert
- Tabellen werden erstellt

## 18.2 Meilenstein 2 – Projektliste

Ergebnis:

- App startet
- Projektliste wird angezeigt
- vorhandene Projekte werden geladen

## 18.3 Meilenstein 3 – Projekteditor

Ergebnis:

- neues Projekt anlegen
- Projekt bearbeiten
- Projekt speichern

## 18.4 Meilenstein 4 – Suche, Filter, Notizen

Ergebnis:

- Suchfeld funktioniert
- Statusfilter funktioniert
- Notizen können gepflegt werden

## 18.5 Meilenstein 5 – Erste nutzbare V0.1

Ergebnis:

- App ist für echte Projektbeobachtung nutzbar
- Daten bleiben erhalten
- Grundbedienung ist stabil

---

# 19. Erweiterungspunkte

Spätere Erweiterungspunkte:

- CSV-Import
- JSON-Import
- Feed-Import
- Budgetanalyse
- Skill-Häufigkeiten
- Proposal-Verwaltung
- Vorlagenverwaltung
- einfache Diagramme
- Exportfunktionen
- Backup/Restore-Dialog
- Installer

Diese Erweiterungen dürfen die MVP-Entwicklung nicht verzögern.

---

# 20. Architekturentscheidungen

## 20.1 Windows Forms statt WPF

Windows Forms wird gewählt, weil:

- schnelle Umsetzung möglich ist
- der Benutzer konkrete schnelle Nutzbarkeit wünscht
- Visual Studio gute Designer-Unterstützung bietet
- die UI-Anforderungen im MVP überschaubar sind

## 20.2 SQLite statt SQL Server

SQLite wird gewählt, weil:

- keine Installation eines Datenbankservers notwendig ist
- lokale Speicherung genügt
- die Datenbank einfach kopierbar ist
- der MVP dadurch schneller umsetzbar ist

## 20.3 Manuelle Erfassung statt Scraping

Manuelle Erfassung wird gewählt, weil:

- sie sofort nutzbar ist
- sie rechtlich risikoärmer ist
- sie technisch stabiler ist
- sie die MVP-Entwicklung stark beschleunigt

## 20.4 Kleine Architektur statt Großsystem

Die Anwendung soll bewusst keine überladene Enterprise-Architektur erhalten.

Die Struktur soll helfen, nicht bremsen.

---

# 21. Offene Punkte

Vor der Implementierung oder während der ersten Iteration zu klären:

- exakte .NET-10-Projektvorlagen in Visual Studio
- Wahl von xUnit oder MSTest
- finaler Speicherort der SQLite-Datenbank
- genaue Benennung der Statuswerte im UI
- erste Standardplattformen
- Standardwährung
- Umgang mit archivierten Projekten in der Liste

Diese Punkte blockieren den MVP nicht.

---

# 22. Zusammenfassung

Das Technical Design beschreibt eine kleine, robuste und verständliche Windows-Desktop-Anwendung auf Basis von C#, .NET 10, Windows Forms und SQLite.

Die Architektur ist bewusst einfach gehalten, trennt aber UI, Fachlogik und Datenzugriff sauber genug, um spätere Erweiterungen zu ermöglichen.

Das wichtigste Ziel bleibt:

> Eine App, die schnell echten Nutzen bringt, statt eine perfekte Anwendung, die zu spät fertig wird.
