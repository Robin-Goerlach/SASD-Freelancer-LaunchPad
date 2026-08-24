# SASD Freelancer LaunchPad – Technical Design

**Version:** 0.2  
**Status:** Baseline-Kandidat – an Lastenheft 0.2, Pflichtenheft 0.2 und Architecture 0.1 angepasst  
**Projekt:** SASD Freelancer LaunchPad  
**Organisation:** SASD GmbH  
**Dokumenttyp:** Technical Design  
**Sprache:** Deutsch  
**Stand:** 24.08.2026  
**Führende Grundlagen:** `010_Lastenheft.md`, `020_Pflichtenheft_MVP.md`, `050_Architecture.md`

---

# 0. Dokumentkontrolle

## 0.1 Zweck

Dieses Dokument konkretisiert die technische Umsetzung des **ersten praktisch nutzbaren Produktstands**.

Es beantwortet:

> **Wie wird die beschlossene Architektur mit C#/.NET, Windows Forms und SQLite konkret umgesetzt, ohne spätere Produktziele unnötig zu verbauen?**

Es ist bewusst konkreter als `050_Architecture.md`, darf dessen Abhängigkeitsregeln aber nicht verletzen.

---

## 0.2 Abgrenzung

Dieses Dokument führt:

- konkrete .NET-/UI-/Persistenzentscheidungen,
- Projektstruktur,
- Namespace-Struktur,
- Application Use Cases,
- konkrete technische Ports,
- Fehlerbehandlung,
- Logging,
- Teststruktur,
- Start-/Shutdown-Verhalten,
- Migration des vorhandenen Prototyps.

Nicht führend sind hier:

- Produkt-Scope,
- Release-Reihenfolge,
- exakte SQL-DDL,
- Wettbewerbsanalyse,
- Datenschutz-Retention,
- konkrete Plattformparser.

---

## 0.3 Ausgangslage

Der vorhandene frühe Prototyp verwendet:

```text
SASD.FreelancerLaunchPad.App
SASD.FreelancerLaunchPad.Core
SASD.FreelancerLaunchPad.Data
SASD.FreelancerLaunchPad.Tests
```

mit:

- `.NET 10`,
- Windows Forms,
- `Microsoft.Data.Sqlite`,
- SQLite,
- einem `FreelanceProject`-zentrierten Modell,
- direkter Repository-Nutzung,
- `projects` als zentraler Tabelle.

Diese technische Basis ist grundsätzlich brauchbar.

Fachlich überholt sind jedoch:

- `Project` als Kombination aus realem Projekt und Listing,
- `Applied/Won/Rejected/Archived` als Opportunity-Status,
- `platform_id` direkt am realen Projekt,
- nur ein Preis-/Rate-Modell,
- fehlendes Proposal-Objekt.

Der Prototyp wird deshalb **refaktoriert**, nicht blind fortgeschrieben.

---

# 1. Technologiestack

## 1.1 Festgelegter Stack

| Bereich | Entscheidung |
|---|---|
| Sprache | C# |
| Runtime | .NET 10 |
| Domain/Application Target | `net10.0` |
| Windows UI Target | `net10.0-windows` |
| UI | Windows Forms |
| Persistenz | SQLite |
| Datenzugriff | `Microsoft.Data.Sqlite` |
| DI/Host | `Microsoft.Extensions.Hosting` / DI |
| Logging-Abstraktion | `Microsoft.Extensions.Logging` |
| Tests | xUnit |
| Repository | Git / GitHub |
| IDE | Visual Studio 2022 bzw. kompatible aktuelle Visual-Studio-Version |

---

## 1.2 Warum .NET 10

**TD-001**

Der aktuelle Code arbeitet bereits mit .NET 10.

Die Neuausrichtung soll keinen unnötigen Framework-Downgrade erzeugen.

---

## 1.3 Warum Windows Forms

**TD-002**

Windows Forms bleibt für den frühen Windows-Desktop-Stand gesetzt, weil:

- der vorhandene Prototyp bereits darauf basiert,
- schnelle produktive Desktop-Entwicklung möglich ist,
- kein zusätzlicher UI-Technologiewechsel nötig ist,
- 1280×720 mit sorgfältigem Layout unterstützt werden kann.

Die Architektur verhindert trotzdem, dass Domain/Application von WinForms abhängen.

---

## 1.4 Warum `Microsoft.Data.Sqlite`

**TD-003**

Der direkte SQLite-Zugriff bleibt über `Microsoft.Data.Sqlite`.

Für den MVP wird kein ORM eingeführt.

Begründung:

- kleines Schema,
- volle Kontrolle über Migrationen und SQL,
- geringe Abhängigkeiten,
- bestehender Code nutzt die Bibliothek bereits,
- Datenbankdesign ist wichtiger als ORM-Komfort.

Ein späterer ORM-Wechsel ist keine aktuelle Anforderung.

---

# 2. Solution- und Projektstruktur

## 2.1 Zielstruktur

```text
SASD-Freelancer-LaunchPad/
│
├── src/
│   ├── SASD.FreelancerLaunchPad.Domain/
│   ├── SASD.FreelancerLaunchPad.Application/
│   ├── SASD.FreelancerLaunchPad.Infrastructure/
│   └── SASD.FreelancerLaunchPad.WinForms/
│
├── tests/
│   ├── SASD.FreelancerLaunchPad.Domain.Tests/
│   ├── SASD.FreelancerLaunchPad.Application.Tests/
│   ├── SASD.FreelancerLaunchPad.Infrastructure.Tests/
│   └── SASD.FreelancerLaunchPad.Architecture.Tests/
│
├── database/
│   └── migrations/
│
├── docs/
│   ├── 010_Lastenheft.md
│   ├── 020_Pflichtenheft_MVP.md
│   ├── 030_Technical_Design.md
│   ├── 040_Database_Design.md
│   ├── 045_Competitive_Product_Feature_Inventory.md
│   └── 050_Architecture.md
│
└── SASD.FreelancerLaunchPad.sln
```

---

## 2.2 Keine leeren Zukunftsprojekte

**TD-004**

Für noch nicht implementierte Bereiche wird zunächst **kein leeres `Integrations`-, `Analytics`- oder `Discovery`-Projekt** angelegt.

Wenn der erste reale Plattformadapter entwickelt wird, kann beispielsweise ergänzt werden:

```text
SASD.FreelancerLaunchPad.Integrations
```

Bis dahin existiert keine künstliche Projektleiche.

---

## 2.3 Projektabhängigkeiten

```text
Domain
  ↑
Application
  ↑
WinForms

Application
  ↑
Infrastructure
```

Genauer:

```text
Domain
  keine Projektabhängigkeit

Application
  → Domain

Infrastructure
  → Application
  → Domain

WinForms
  → Application
  → Domain
  → Infrastructure nur am Composition Root
```

---

## 2.4 UI und Infrastructure

**TD-005**

`WinForms` darf die konkrete `Infrastructure`-Assembly ausschließlich für:

- Composition Root,
- DI-Registrierung,
- Host-Aufbau

referenzieren.

Formulare und Presenter dürfen nicht direkt konkrete SQLite-Repositories verwenden.

---

# 3. Namespace-Konvention

## 3.1 Root Namespace

Der bestehende Produktname wird beibehalten:

```text
SASD.FreelancerLaunchPad
```

---

## 3.2 Domain

Beispiele:

```text
SASD.FreelancerLaunchPad.Domain.Opportunities
SASD.FreelancerLaunchPad.Domain.Listings
SASD.FreelancerLaunchPad.Domain.Proposals
SASD.FreelancerLaunchPad.Domain.Skills
SASD.FreelancerLaunchPad.Domain.Common
```

---

## 3.3 Application

Beispiele:

```text
SASD.FreelancerLaunchPad.Application.Opportunities
SASD.FreelancerLaunchPad.Application.Proposals
SASD.FreelancerLaunchPad.Application.Search
SASD.FreelancerLaunchPad.Application.Backup
SASD.FreelancerLaunchPad.Application.Common
```

---

## 3.4 Infrastructure

Beispiele:

```text
SASD.FreelancerLaunchPad.Infrastructure.Sqlite
SASD.FreelancerLaunchPad.Infrastructure.Repositories
SASD.FreelancerLaunchPad.Infrastructure.Migrations
SASD.FreelancerLaunchPad.Infrastructure.Backup
SASD.FreelancerLaunchPad.Infrastructure.Logging
```

---

## 3.5 WinForms

Beispiele:

```text
SASD.FreelancerLaunchPad.WinForms.Views
SASD.FreelancerLaunchPad.WinForms.Presenters
SASD.FreelancerLaunchPad.WinForms.Models
SASD.FreelancerLaunchPad.WinForms.Controls
SASD.FreelancerLaunchPad.WinForms.Startup
```

---

# 4. Build-Konfiguration

## 4.1 Gemeinsame Projektoptionen

Empfohlenes `Directory.Build.props`:

```xml
<Project>
  <PropertyGroup>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    <LangVersion>latest</LangVersion>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
  </PropertyGroup>
</Project>
```

---

## 4.2 Warnungen

**TD-006**

Compiler-Warnungen sollen nicht ignoriert werden.

`TreatWarningsAsErrors` darf zunächst im lokalen Debug-Build deaktiviert bleiben, kann aber in CI schrittweise verschärft werden.

Ziel:

> Keine bekannte Warnung dauerhaft akzeptieren, nur damit der Build grün aussieht.

---

## 4.3 Package-Versionen

Package-Versionen sollen zentral verwaltbar sein.

Ein späteres:

```text
Directory.Packages.props
```

ist sinnvoll, sobald mehrere Projekte dieselben Packages referenzieren.

---

# 5. Domain Design

## 5.1 Leitregel

Der Domain Layer enthält fachliche Bedeutung und Invarianten.

Er enthält keine:

- SQL-Statements,
- Connection Strings,
- Forms,
- Controls,
- MessageBoxes,
- HTTP-Aufrufe,
- Plattformparser.

---

## 5.2 Opportunity

Konzeptionelle C#-Form:

```csharp
public sealed class Opportunity
{
    public long Id { get; private set; }
    public string CanonicalTitle { get; private set; }
    public OpportunityStatus Status { get; private set; }
    public bool IsArchived { get; private set; }
    public DateTimeOffset? ArchivedAtUtc { get; private set; }
    public string? DismissReason { get; private set; }
    public string? EndClientName { get; private set; }
    public DateTimeOffset CreatedAtUtc { get; private set; }
    public DateTimeOffset UpdatedAtUtc { get; private set; }
}
```

Die exakte Implementierung kann davon abweichen.

---

## 5.3 Opportunity Status

```csharp
public enum OpportunityStatus
{
    New,
    Reviewing,
    Interesting,
    Watching,
    Dismissed,
    Closed,
    Cancelled,
    Expired
}
```

**TD-007**

`Archived`, `Applied`, `Rejected` und `Won` gehören nicht in dieses Enum.

---

## 5.4 Listing

Ein Listing enthält source-spezifische Informationen.

Konzeptionell:

```csharp
public sealed class Listing
{
    public long Id { get; private set; }
    public long OpportunityId { get; private set; }
    public long PlatformId { get; private set; }

    public string SourceTitle { get; private set; }
    public string? ExternalId { get; private set; }
    public Uri? SourceUrl { get; private set; }
    public string? OriginalDescription { get; private set; }

    public DateTimeOffset? PublishedAtUtc { get; private set; }
    public DateTimeOffset FirstObservedAtUtc { get; private set; }
    public DateTimeOffset CapturedAtUtc { get; private set; }
    public DateTimeOffset LastObservedAtUtc { get; private set; }

    public CaptureMethod CaptureMethod { get; private set; }
}
```

---

## 5.5 Opportunity vs. Listing

**TD-008**

Ein externes `ExternalId`, eine URL oder eine Plattform-ID darf niemals als Opportunity-ID missverstanden werden.

Opportunity besitzt eine eigene lokale ID.

Listing besitzt eine eigene lokale ID.

---

## 5.6 Platform

```csharp
public sealed class Platform
{
    public long Id { get; init; }
    public string Key { get; init; }
    public string DisplayName { get; init; }
    public Uri? BaseUri { get; init; }
    public bool IsActive { get; init; }
}
```

`Key` ist ein stabiler technischer Schlüssel.

Beispiele:

```text
freelancermap
peopleperhour
randstad-professional-gulp
```

---

## 5.7 Capture Method

```csharp
public enum CaptureMethod
{
    Manual,
    Paste,
    Url,
    BrowserHelper,
    Api
}
```

Im MVP wird nur `Manual` aktiv verwendet.

---

# 6. Money- und Rate-Modell

## 6.1 Domain-Wert

**TD-009**

Geld-/Ratewerte werden im Domain-Code als `decimal` behandelt.

Keine fachliche Geldrechnung verwendet `double` oder `float`.

---

## 6.2 Currency Code

Währungen werden als ISO-artiger dreistelliger Code gespeichert.

Beispiele:

```text
EUR
GBP
USD
CHF
```

Der MVP benötigt keine Wechselkursdatenbank.

---

## 6.3 Price Range

Für ausgeschriebene Werte ist ein Range-Modell sinnvoll:

```csharp
public readonly record struct AmountRange(
    decimal? Minimum,
    decimal? Maximum,
    string CurrencyCode);
```

Regeln:

- mindestens Minimum oder Maximum gesetzt,
- kein Wert negativ,
- wenn beide gesetzt: Minimum <= Maximum.

---

## 6.4 Getrennte Konditionen

Listing hält getrennt:

- Fixed Budget Range,
- Hourly Rate Range,
- Daily Rate Range.

Proposal hält getrennt:

- Own Fixed Price,
- Own Hourly Rate,
- Own Daily Rate.

---

## 6.5 Keine Konvertierung

**TD-010**

Es existiert im MVP kein Service, der:

```text
Daily → Hourly
Fixed → Hourly
Hourly → Daily
```

automatisch umrechnet.

Spätere Ableitungen benötigen eine explizite Annahme.

---

# 7. Zeitmodell

## 7.1 Interner Typ

**TD-011**

Für echte Zeitpunkte wird im C#-Code `DateTimeOffset` verwendet.

Persistierte Domain-Zeitpunkte müssen Offset `+00:00` besitzen.

---

## 7.2 Date-only-Werte

Nicht jeder fachliche Wert ist ein Zeitpunkt.

Beispiel:

```text
ExpectedStartDate = 2026-09-15
```

ist ein Kalendertag und kann als `DateOnly` modelliert werden.

Ein `DateOnly` wird nicht künstlich auf Mitternacht UTC umgerechnet.

---

## 7.3 IClock

```csharp
public interface IClock
{
    DateTimeOffset UtcNow { get; }
}
```

Produktive Implementierung:

```text
SystemClock
```

Testimplementierung:

```text
FakeClock
```

---

## 7.4 Keine verstreuten `DateTime.Now`

**TD-012**

Application- und Domain-Code darf für fachlich relevante Zeitstempel nicht beliebig `DateTime.Now` aufrufen.

---

# 8. Proposal Design

## 8.1 Proposal

Konzeptionell:

```csharp
public sealed class Proposal
{
    public long Id { get; private set; }
    public long OpportunityId { get; private set; }
    public long? ListingId { get; private set; }

    public DateTimeOffset SubmittedAtUtc { get; private set; }
    public ProposalState State { get; private set; }
    public ProposalOutcome? Outcome { get; private set; }

    public string? CvProfileVersion { get; private set; }
    public string? NoteText { get; private set; }
}
```

---

## 8.2 Proposal State

```csharp
public enum ProposalState
{
    Submitted,
    AwaitingResponse,
    Closed
}
```

---

## 8.3 Proposal Outcome

```csharp
public enum ProposalOutcome
{
    Won,
    Rejected,
    Withdrawn,
    TimedOutByUser,
    Unknown
}
```

---

## 8.4 Invariante

**TD-013**

Wenn `State != Closed`, muss `Outcome == null` sein.

Wenn `State == Closed`, muss ein terminales Outcome vorliegen.

---

## 8.5 Listing-Verweis

**TD-014**

`ListingId` ist optional.

Wenn gesetzt, muss das Listing zur gleichen Opportunity gehören.

Diese Regel wird sowohl Application-seitig als auch durch die Datenbank abgesichert.

---

# 9. Skills und Notes

## 9.1 Skill

Skills werden normalisiert.

MVP-Normalisierung:

```text
trim
Unicode normalisieren
case-insensitive Vergleich
mehrfache Leerzeichen reduzieren
```

Nicht Bestandteil:

- Alias-Graph,
- Taxonomie,
- Skill-Hierarchie.

---

## 9.2 Notes

**TD-015**

Notes werden als eigene persistente Datensätze geführt.

Begründung:

- der alte Prototyp besitzt bereits mehrere `project_notes`,
- spätere mehrere Notes sind ohnehin vorgesehen,
- dadurch ist keine verlustbehaftete Zusammenfassung alter Notes nötig.

Die MVP-UI darf trotzdem eine einfache Darstellung anbieten.

---

## 9.3 Note ≠ Activity

Keine Note implementiert ein Activity-Interface oder wird als Activity-Type gespeichert.

---

# 10. Statushistorie

## 10.1 Entscheidung

**TD-016**

Opportunity-Statusänderungen werden weiterhin historisiert.

Begründung:

- existiert bereits im Prototyp,
- ist entscheidungsrelevant,
- kostet wenig Komplexität,
- liefert später wertvolle Funnel-/Workflow-Daten.

---

## 10.2 Nicht als Event Sourcing

Die Tabelle ist eine gezielte Historie.

Sie ist nicht die Quelle, aus der jede Opportunity rekonstruiert werden muss.

Der aktuelle Status bleibt im Opportunity-Datensatz gespeichert.

---

# 11. Application Layer

## 11.1 Use Cases

Der Application Layer enthält explizite Use Cases.

MVP-Kandidaten:

```text
CreateOpportunity
UpdateOpportunity
GetOpportunity
SearchOpportunities
ChangeOpportunityStatus
ArchiveOpportunity
RestoreOpportunity
DeleteOpportunity

AddOpportunityNote
UpdateOpportunityNote
DeleteOpportunityNote

SetOpportunitySkills

CreateProposal
UpdateProposal
CloseProposal

CreateBackup
OpenSourceUrl
```

---

## 11.2 Request-/Result-Modelle

UI-Formulare sollen Domain-Entitäten nicht direkt beliebig mutieren.

Beispiel:

```csharp
public sealed record CreateOpportunityRequest(
    string CanonicalTitle,
    CreateListingRequest Listing,
    IReadOnlyList<string> Skills,
    string? NoteText);
```

---

## 11.3 Result Pattern

**TD-017**

Erwartbare Fehler werden als explizite Ergebnisse zurückgegeben.

Beispiele:

- Validation Failed,
- Duplicate Listing,
- Not Found,
- Conflict.

Unerwartete technische Fehler bleiben Exceptions und werden an einer zentralen Grenze protokolliert.

---

## 11.4 Keine Exception als normale Validierung

Ein leerer Titel ist kein „unerwarteter Systemfehler“.

Er wird als Validation Error behandelt.

---

# 12. Ports

## 12.1 Repository Ports

Konkrete MVP-Ports:

```csharp
public interface IOpportunityRepository { ... }
public interface IProposalRepository { ... }
public interface IPlatformRepository { ... }
public interface ISkillRepository { ... }
```

Notes und Listings können zunächst über das Opportunity Repository bzw. gezielte Ports verwaltet werden.

---

## 12.2 Keine generische IRepository<T>

**TD-018**

Es wird kein generisches:

```csharp
IRepository<T>
```

als zentrales Architekturmodell eingeführt.

Repositories sollen fachliche Abfragen ausdrücken.

---

## 12.3 Weitere Ports

```text
IClock
IBackupService
IAppPaths
IBrowserLauncher
```

Später:

```text
IDiscoveryCapability
ICaptureCapability
IObservationCapability
ICredentialStore
```

---

# 13. Infrastructure Layer

## 13.1 SqliteConnectionFactory

Zentrale Verantwortung:

- Connection String,
- `PRAGMA foreign_keys = ON`,
- `busy_timeout`,
- Verbindungserzeugung.

---

## 13.2 Verbindung pro Operation

**TD-019**

Repositories sollen keine langlebige globale SQLite-Connection halten.

Bevorzugt:

> kurze Connection-Lebensdauer pro Use Case / Transaktion.

---

## 13.3 PRAGMA-Konfiguration

Für produktive Verbindungen vorgesehen:

```sql
PRAGMA foreign_keys = ON;
PRAGMA busy_timeout = 5000;
```

Für die Datenbankinitialisierung kann zusätzlich gesetzt werden:

```sql
PRAGMA journal_mode = WAL;
PRAGMA synchronous = NORMAL;
```

Die finale Wahl wird im Database Design dokumentiert.

---

# 14. Migration Runner

## 14.1 Migrationen

Migrationen werden nummeriert.

Beispiel:

```text
database/migrations/
  001_legacy_initial_schema.sql
  002_opportunity_listing_model.sql
  003_proposal_lite.sql
```

Die genaue Nummerierung wird an den tatsächlich vorhandenen Repository-Stand angepasst.

---

## 14.2 Checksum

**TD-020**

Eine bereits angewendete Migration darf nicht nachträglich still verändert werden.

`schema_migrations` speichert deshalb zusätzlich einen Checksum-Wert.

---

## 14.3 Transaktion

Migrationen werden soweit SQLite-technisch möglich atomar ausgeführt.

---

## 14.4 Backup vor Legacy-Migration

**TD-021**

Bevor eine vorhandene `projects`-Datenbank auf das neue Opportunity/Listing-Modell migriert wird, muss automatisch eine Sicherung des Altstands erzeugt werden.

---

# 15. Legacy-Migration

## 15.1 Grundidee

Alt:

```text
FreelanceProject
  Platform
  URL
  Description
  Status
  Budget/Rate
```

Neu:

```text
Opportunity
  ├── Listing
  ├── Notes
  ├── Skills
  └── optional Proposal
```

---

## 15.2 ID-Strategie

**TD-022**

Interne IDs bleiben für den Desktop-MVP 64-Bit-Integer (`long` / SQLite `INTEGER`).

Begründung:

- vorhandener Prototyp nutzt `long`,
- Migration kann Projekt-ID als Opportunity-ID erhalten,
- lokale Einzelanwenderdatenbank,
- keine aktuelle Multi-Device-Merge-Anforderung,
- weniger künstliche Komplexität.

Falls später globale IDs benötigt werden, können zusätzliche öffentliche IDs eingeführt werden.

---

## 15.3 Statusmigration

Empfohlene Semantik:

| Legacy Status | Neue Abbildung |
|---|---|
| `New` | Opportunity `New` |
| `Interesting` | Opportunity `Interesting` |
| `Watching` | Opportunity `Watching` |
| `Applied` | Opportunity `Interesting` + Proposal |
| `Rejected` ohne vorheriges `Applied` | Opportunity `Dismissed` |
| `Rejected` nach `Applied` | Opportunity `Closed` + Proposal `Rejected` |
| `Won` | Opportunity `Closed` + Proposal `Won` |
| `Archived` | archiviert; vorherigen fachlichen Status aus History rekonstruieren |

---

## 15.4 Ambiguität

**TD-023**

Wenn der Legacy-Status nicht eindeutig migrierbar ist, darf die Migration keine falsche Wahrheit erfinden.

Sie muss:

- einen sicheren Default wählen,
- eine Warnung protokollieren,
- im Migrationsreport auf den Datensatz hinweisen.

---

## 15.5 Legacy Notes

Alle vorhandenen `project_notes` werden zu `opportunity_notes`.

Keine Textnotiz wird verworfen.

---

## 15.6 Legacy Skills

`project_skills` wird zu `opportunity_skills`.

---

# 16. Datenbankpfad

## 16.1 Produktionspfad

Standard:

```text
%LOCALAPPDATA%\SASD\FreelancerLaunchPad\freelancer_launchpad.db
```

---

## 16.2 Warum LOCALAPPDATA

**TD-024**

Die aktive Datenbank ist Anwendungszustand und nicht primär ein roamingfähiges Dokument.

`LOCALAPPDATA` ist deshalb gegenüber `APPDATA` vorzuziehen.

---

## 16.3 Entwicklungs-/Testpfade

Tests dürfen niemals die produktive Benutzerdatenbank verwenden.

Infrastructure Tests erhalten pro Test bzw. Testklasse eine isolierte temporäre Datenbank.

---

# 17. Backup Design

## 17.1 Backup ist kein Datei-Copy bei offener WAL-Datenbank

**TD-025**

Die produktive Backup-Funktion darf nicht einfach blind die geöffnete `.db`-Datei kopieren.

---

## 17.2 Konsistenter Snapshot

Bevorzugt wird die SQLite-Backup-Funktion über `SqliteConnection`.

Ablauf:

```text
aktive DB
  ↓
SQLite Backup API
  ↓
temporäre Snapshot-DB
  ↓
optional ZIP + Manifest
  ↓
Zieldatei
```

---

## 17.3 Backup-Paket

Für den MVP darf das Backup-Paket enthalten:

```text
freelancer_launchpad.db
manifest.json
```

Manifest:

```json
{
  "product": "SASD Freelancer LaunchPad",
  "createdAtUtc": "...",
  "schemaVersion": 2,
  "applicationVersion": "..."
}
```

---

## 17.4 Verschlüsselung

Keine integrierte Backup-Verschlüsselung im MVP.

Der Benutzer ist für das Zielmedium verantwortlich.

---

# 18. Logging

## 18.1 Logging-Abstraktion

Anwendungscode verwendet `ILogger<T>`.

---

## 18.2 Lokale Datei

Der produktive Desktop-Stand soll ein einfaches lokales Rolling-File-Logging erhalten.

Der konkrete Provider darf im Implementierungsschritt gewählt werden.

---

## 18.3 Logpfad

Vorgesehen:

```text
%LOCALAPPDATA%\SASD\FreelancerLaunchPad\logs\
```

---

## 18.4 Keine sensiblen Volltexte

**TD-026**

Nicht standardmäßig loggen:

- vollständige Ausschreibungen,
- Proposal-Texte,
- Notes,
- Tokens,
- Credentials.

---

# 19. Fehlerbehandlung

## 19.1 Fehlerklassen

Technisch unterschieden werden:

```text
Validation
NotFound
Conflict
Persistence
Migration
Backup
ExternalIntegration
Unexpected
```

---

## 19.2 UI

Die UI erhält verständliche Meldungen.

Beispiel:

> „Die Opportunity konnte nicht gespeichert werden. Die lokalen Daten wurden nicht verändert.“

Technische Details gehören ins Log.

---

## 19.3 Globaler Fehlerhandler

**TD-027**

Unerwartete Exceptions auf der UI-Grenze werden zentral abgefangen und protokolliert.

Keine leeren `catch`-Blöcke.

---

# 20. Windows Forms Design

## 20.1 Hauptfenster

Der MVP-Hauptscreen besteht konzeptionell aus:

1. Menü/Toolbar,
2. Such- und Filterbereich,
3. Opportunity-Liste,
4. kompakter Detailbereich bzw. Detailaktion,
5. Statusleiste.

---

## 20.2 1280×720

**TD-028**

Die Oberfläche muss bei 1280×720 ohne horizontales „Formular-Chaos“ nutzbar bleiben.

Daher:

- keine übergroßen festen Dialoge,
- Scrollcontainer für lange Editoren,
- SplitContainer bzw. adaptive Bereiche,
- wichtige Aktionen bleiben sichtbar,
- sekundäre Informationen werden gruppiert.

---

## 20.3 Opportunity-Liste

`DataGridView` bleibt für den MVP geeignet.

Spaltenvorschlag:

```text
Status
Archiv
Titel
Plattform
Published
Remote
Rate/Budget kompakt
Skills kompakt
Updated
```

---

## 20.4 Mehrere Listings

Die Listenansicht zeigt zunächst einen Primary-/aktuellen Listing-Kontext.

**TD-029**

Die UI darf mehrere Listings nicht fachlich wegmodellieren.

Wenn später mehrere existieren, erscheint in der Detailansicht eine Listing-Sektion.

---

## 20.5 Opportunity Editor

Tabs/Abschnitte:

```text
Allgemein
Fundstelle
Konditionen
Skills
Notes
Proposal
```

Für 1280×720 sind Abschnitte oder Tabs besser als ein extrem langer Dialog.

---

# 21. Presenter Design

## 21.1 Keine SQL-Logik im Form

Forms kennen nur Presenter/Application Contracts.

---

## 21.2 Beispiel

```text
MainForm
  ↕
OpportunityListPresenter
  ↓
SearchOpportunitiesUseCase
```

---

## 21.3 Editor

```text
OpportunityEditForm
  ↕
OpportunityEditPresenter
  ↓
CreateOpportunity / UpdateOpportunity
```

---

## 21.4 Proposal

```text
ProposalForm
  ↕
ProposalPresenter
  ↓
CreateProposal / UpdateProposal / CloseProposal
```

---

# 22. Suche und Filter

## 22.1 MVP-Suche

MVP nutzt parameterisierte SQL-Abfragen.

Filter:

- Freitext,
- Plattform,
- Opportunity-Status,
- Skill,
- Published-Zeitraum,
- Archivstatus.

---

## 22.2 Kein FTS5-Zwang

**TD-030**

SQLite FTS5 wird zunächst nicht benötigt.

Der MVP darf mit `LIKE` / gezielten Joins starten.

FTS5 wird eingeführt, wenn Messdaten oder realer Datenumfang dies rechtfertigen.

---

## 22.3 Query Builder

Keine Stringverkettung aus Benutzereingaben.

Dynamische WHERE-Bedingungen verwenden ausschließlich SQL-Parameter.

---

## 22.4 Freitextfelder

Mindestens durchsucht:

- Opportunity Title,
- Listing Source Title,
- Original Description,
- Notes,
- Skills.

---

# 23. URL-Behandlung

## 23.1 Original URL

Das Listing speichert die vom Nutzer eingegebene Source URL.

---

## 23.2 Normalized URL

Zusätzlich darf ein normalisierter Vergleichswert gespeichert werden.

Sichere generische Normalisierung:

- trim,
- absolute URI,
- scheme/host lowercase,
- Fragment entfernen,
- Default-Port normalisieren.

---

## 23.3 Keine aggressive Query-Bereinigung

**TD-031**

Generische URL-Normalisierung darf nicht beliebige Query-Parameter entfernen.

Ein Parameter kann Teil der echten Listing-ID sein.

Plattformspezifische Normalisierung gehört später in den Adapter.

---

# 24. Duplikaterkennung

## 24.1 MVP

Frühe Signale:

```text
Platform + ExternalId
Platform + NormalizedUrl
```

---

## 24.2 Verhalten

Bei sicherem Treffer:

- nicht automatisch doppelt speichern,
- bestehende Opportunity anzeigen,
- Benutzer entscheiden lassen.

---

## 24.3 Semantische Ähnlichkeit

Kein MVP.

---

# 25. OpenSource/Browser

## 25.1 BrowserLauncher

Die UI öffnet Source URLs über:

```text
IBrowserLauncher
```

Infrastructure nutzt die Windows-Shell.

---

## 25.2 Validierung

Nur absolute `http`/`https` URLs werden aus normalen Listing-Feldern geöffnet.

---

# 26. Startup

## 26.1 Reihenfolge

```text
Program.Main
  ↓
Host bauen
  ↓
AppPaths bestimmen
  ↓
Logging initialisieren
  ↓
DatabaseInitializer
  ↓
MigrationRunner
  ↓
Seed/Reference Data
  ↓
MainForm erzeugen
  ↓
Application.Run
```

---

## 26.2 Migrationfehler

**TD-032**

Wenn die Datenbankmigration fehlschlägt, darf die normale UI nicht so starten, als sei alles in Ordnung.

Stattdessen:

- Fehlermeldung,
- Logpfad nennen,
- Originaldaten nicht löschen,
- Anwendung kontrolliert beenden oder Diagnosemodus anbieten.

---

# 27. Shutdown

## 27.1 Keine langlebigen DB-Verbindungen

Dadurch ist Shutdown einfach.

---

## 27.2 Background Services

Spätere Worker erhalten CancellationToken und werden kontrolliert beendet.

---

# 28. Dependency Injection

## 28.1 Composition Root

Einziger Ort für konkrete Verdrahtung:

```text
WinForms/Program.cs
oder
WinForms/Startup/ServiceRegistration.cs
```

---

## 28.2 Beispiel

```csharp
services.AddSingleton<IClock, SystemClock>();
services.AddSingleton<IAppPaths, WindowsAppPaths>();

services.AddTransient<IOpportunityRepository, SqliteOpportunityRepository>();
services.AddTransient<IProposalRepository, SqliteProposalRepository>();

services.AddTransient<CreateOpportunityHandler>();
services.AddTransient<SearchOpportunitiesHandler>();

services.AddTransient<MainForm>();
```

Konkrete Lifetimes werden bei Implementierung geprüft.

---

# 29. Testdesign

## 29.1 Domain Tests

Prüfen:

- Opportunity Status,
- Archive/Restore,
- Money Range,
- Proposal State/Outcome,
- `TimedOutByUser`,
- keine negative Rate,
- Minimum <= Maximum.

---

## 29.2 Application Tests

Prüfen:

- Create Opportunity + Listing,
- Duplicate Handling,
- Proposal belongs to Opportunity,
- Listing belongs to Opportunity,
- Statusänderung + History,
- Backup Use Case mit Fake/Temp Infrastructure.

---

## 29.3 Infrastructure Tests

Mit echter SQLite-Datei:

- Migrationen,
- FK-Constraints,
- Unique-Constraints,
- CRUD,
- komplexe Suche,
- Backup-Snapshot,
- Legacy-Migration.

---

## 29.4 Architecture Tests

**TD-033**

Automatisiert prüfen:

- Domain referenziert kein WinForms,
- Domain referenziert kein Microsoft.Data.Sqlite,
- Application referenziert kein WinForms,
- Application referenziert kein Microsoft.Data.Sqlite,
- WinForms-Forms enthalten keine direkten SQLiteConnection-Aufrufe.

---

# 30. Testdatenbanken

## 30.1 Isolation

Jeder Test verwendet eine temporäre isolierte Datenbank.

---

## 30.2 Produktivdaten

**TD-034**

Automatisierte Tests dürfen niemals `%LOCALAPPDATA%`-Produktivdaten öffnen.

---

## 30.3 Realistische Seeds

Zusätzlich zu Unit-Tests sind realistische Testdaten sinnvoll:

- mehrere Plattformen,
- gleiche Opportunity mit zwei Listings,
- unbekannte Rate,
- Hourly + Daily getrennt,
- Proposal TimedOutByUser,
- archivierte Dismissed Opportunity.

---

# 31. Security

## 31.1 SQL Injection

Alle SQL-Werte werden parametrisiert.

---

## 31.2 Secrets

Keine Plattformpasswörter in:

- DB,
- config,
- Log,
- Source Code.

---

## 31.3 Rohdaten

Importierter Inhalt wird als Daten behandelt, nicht als Code.

---

# 32. Performance

## 32.1 Datenmenge

Der MVP wird für einen Einzelanwender mit typischerweise:

```text
Hunderte bis einige Zehntausend Opportunities/Listings
```

ausgelegt.

---

## 32.2 Paging

Paging ist nicht zwingend für die erste kleine Datenbasis.

Die Repository-API soll jedoch später `Limit/Offset` bzw. Paging ergänzen können.

---

## 32.3 Lange Beschreibungen

Listenabfragen sollen Originalbeschreibungen nicht unnötig laden.

Für Grid-Zeilen werden Projektionen/Read Models verwendet.

---

# 33. Read Models

## 33.1 OpportunityListItem

Beispiel:

```csharp
public sealed record OpportunityListItem(
    long Id,
    string Title,
    OpportunityStatus Status,
    bool IsArchived,
    string PlatformName,
    DateTimeOffset? PublishedAtUtc,
    string? RateSummary,
    string SkillSummary);
```

---

## 33.2 Keine Domain-Entität als GridRow

**TD-035**

Die Hauptliste verwendet ein gezieltes Read Model.

So müssen große Description-Texte nicht pro Zeile geladen werden.

---

# 34. Datenänderungen

## 34.1 Created/Updated

Application Services setzen:

- `CreatedAtUtc`,
- `UpdatedAtUtc`.

---

## 34.2 Archiv

Archive setzt:

```text
IsArchived = true
ArchivedAtUtc = clock.UtcNow
```

Restore setzt:

```text
IsArchived = false
ArchivedAtUtc = null
```

Status bleibt unverändert.

---

## 34.3 LastObservedAt

**TD-036**

`LastObservedAtUtc` darf auch nach `Expired` oder `Closed` aktualisiert werden.

Es beschreibt eine Beobachtung, nicht Aktivität der Opportunity.

---

# 35. Statushistorie

## 35.1 Schreibregel

Bei tatsächlicher Statusänderung:

```text
old_status
new_status
changed_at_utc
```

speichern.

---

## 35.2 Kein History-Eintrag bei identischem Status

---

# 36. Datenbanktransaktionen

## 36.1 Create Opportunity

Atomar:

```text
Opportunity
+ first Listing
+ Skills
+ optional Note
```

---

## 36.2 Delete Opportunity

Atomar löschen:

- Opportunity,
- Listings,
- Proposal(s),
- Notes,
- Status History,
- Opportunity-Skill Links.

Skills und Platforms bleiben.

---

## 36.3 Proposal

Create/Update Proposal in eigener Transaktion.

---

# 37. Seed Data

## 37.1 Plattformen

Seed:

```text
Freelancermap
PeoplePerHour
Randstad Professional / GULP
```

---

## 37.2 Kein `Manual` als Plattform

**TD-037**

`Manual` ist eine Capture Method, keine Platform.

---

## 37.3 Skills

Keine große Skill-Liste auf Vorrat.

Optional wenige Demo-/Testskills nur in Testdaten.

Produktiv entstehen Skills aus Benutzereingaben.

---

# 38. Einstellungen

## 38.1 MVP

Keine große Settings-UI.

Technisch konfigurierbar:

- Datenbankpfad Override für Entwicklung,
- Log-Level,
- optional Standardwährung.

---

## 38.2 Zeitzone

Persistenz ist UTC.

Eine spätere Anzeige-Zeitzone wird als Presentation Setting ergänzt.

---

# 39. Dateiformate

## 39.1 Backup

ZIP + SQLite Snapshot + Manifest.

---

## 39.2 Export

Nicht mit Backup vermischen.

Spätere CSV/JSON-Exporte erhalten eigene Serializer.

---

# 40. Integrationen später

## 40.1 Erst bei realem Adapter

Wenn URL-/Paste-/Discovery-Integration beginnt, wird `Integrations` ergänzt.

---

## 40.2 Adapter darf keine DB kennen

Adapter liefert Candidate-DTO.

Application validiert und persistiert.

---

## 40.3 Capability Interfaces

Später lieber:

```text
ICaptureCapability
IDiscoveryCapability
IObservationCapability
```

als ein gigantisches Interface.

---

# 41. Codequalität

## 41.1 XML-Dokumentation

**TD-038**

Öffentliche APIs, Domain-Objekte und nicht triviale Application Contracts erhalten XML-Kommentare.

---

## 41.2 Inline-Kommentare

Erklären:

- warum eine Entscheidung nötig ist,
- ungewöhnliche SQLite-Eigenheiten,
- Migrationslogik,
- Sicherheits-/Integritätsgründe.

Nicht jeden offensichtlichen `if` kommentieren.

---

## 41.3 Methodenlänge

Keine harte Zeilengrenze.

Methoden sollen eine klar benennbare Verantwortung besitzen.

---

# 42. Verbotene Kurzschlüsse

**TD-039**

Nicht zulässig:

```text
Form -> SQLiteConnection
Form -> SQL
Platform Parser -> Repository
Domain -> MessageBox
Domain -> DateTime.Now
Opportunity.Status = Applied
Opportunity.Status = Archived
Opportunity.PlatformId
ProposalRate in Listing
ListingRate in Proposal
```

---

# 43. Refactoring des vorhandenen Projekts

## 43.1 `Core` → `Domain`

Bestehende reine Domain-Typen werden migriert.

`FreelanceProject` wird nicht einfach umbenannt, sondern fachlich aufgeteilt.

---

## 43.2 neues `Application`

Use Cases und Ports werden aus Core/UI herausgezogen.

---

## 43.3 `Data` → `Infrastructure`

SQLite-Implementierung wird fachlich neu ausgerichtet.

---

## 43.4 `App` → `WinForms`

UI bleibt Windows Forms, wird aber von Repository-Aufrufen entkoppelt.

---

## 43.5 Tests splitten

Der alte Gesamttestprojekt-Ansatz wird schrittweise aufgeteilt.

Kein Big-Bang nötig:

1. neue Testprojekte anlegen,
2. Tests verschieben,
3. altes Testprojekt leeren,
4. entfernen.

---

# 44. Keine Roadmap in diesem Dokument

**TD-040**

Dieses Technical Design enthält keine:

- Versionsnummern für Features,
- Meilenstein-Reihenfolge,
- Terminzusagen.

Dafür existiert `060_Product_Roadmap.md`.

---

# 45. Definition of Done für technische Änderungen

Eine technische Änderung ist erst fertig, wenn:

- Build erfolgreich,
- betroffene Tests erfolgreich,
- keine neue verbotene Abhängigkeit,
- DB-Migration vorhanden, falls nötig,
- Migrationstest vorhanden,
- Benutzerfehler verständlich,
- Logging ohne sensible Volltexte,
- XML-Doku an neuen öffentlichen APIs,
- relevante Dokumente aktualisiert.

---

# 46. Technical-Design-Compliance-Check

Vor Merge prüfen:

- [ ] Domain kennt kein UI.
- [ ] Domain kennt kein SQLite.
- [ ] Application kennt kein UI.
- [ ] Application kennt kein SQLite.
- [ ] UI verwendet keine SQLiteConnection.
- [ ] Opportunity und Listing bleiben getrennt.
- [ ] Proposal bleibt getrennt.
- [ ] Archive ist kein Status.
- [ ] Notes sind keine Activities.
- [ ] Hourly/Daily/Fixed bleiben getrennt.
- [ ] UTC wird eingehalten.
- [ ] DateOnly wird nicht künstlich UTC gemacht.
- [ ] Unknown wird nicht zu 0.
- [ ] SQL ist parametrisiert.
- [ ] Use Case ist bei Mehrfachschreibvorgängen transaktional.
- [ ] Schemaänderung hat Migration.
- [ ] Migration zerstört keine Alt-Daten.
- [ ] Backup nutzt konsistenten Snapshot.
- [ ] Tests verwenden keine Produktiv-DB.
- [ ] keine Zukunfts-Infrastruktur ohne aktuellen Use Case.

---

# 47. Zusammenfassung

Das konkrete MVP-Design basiert weiterhin auf:

```text
C#
.NET 10
Windows Forms
SQLite
Microsoft.Data.Sqlite
xUnit
```

Der technische Aufbau wird jedoch vom alten:

```text
App
Core
Data
projects
```

auf den beschlossenen, klareren Aufbau weiterentwickelt:

```text
WinForms
    ↓
Application
    ↓
Domain

Infrastructure
    ↑
Application Ports
```

und fachlich:

```text
Opportunity
  ├── Listing(s)
  ├── Skills
  ├── Notes
  └── Proposal(s)
```

Die zentrale technische Leitlinie bleibt:

> **Bekannte Sackgassen jetzt vermeiden – zukünftige Features aber erst implementieren, wenn sie tatsächlich gebraucht werden.**
