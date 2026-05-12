# SASD Freelancer LaunchPad – Pflichtenheft MVP

Version: 0.1  
Status: MVP-Umsetzungsvorbereitung  
Projekt: SASD Freelancer LaunchPad  
Organisation: SASD GmbH  
Dokumenttyp: Pflichtenheft  
Sprache: Deutsch  

---

# 1. Einleitung

## 1.1 Zweck des Dokuments

Dieses Pflichtenheft beschreibt die technische und funktionale Umsetzung des MVPs (Minimum Viable Product) der Anwendung **SASD Freelancer LaunchPad**.

Das Dokument konkretisiert die im Lastenheft beschriebenen Anforderungen und definiert:

- Systemstruktur
- Architektur
- technische Komponenten
- Datenhaltung
- Benutzeroberflächen
- Projektgrenzen
- MVP-Umfang

---

## 1.2 Projektphilosophie

Das Projekt verfolgt ausdrücklich folgende Philosophie:

> Zuerst ein funktionierendes Werkzeug entwickeln, danach Komfort und Automatisierung erweitern.

Die erste Version soll:
- schnell verfügbar sein
- stabil arbeiten
- lokal nutzbar sein
- einfach wartbar bleiben

Perfekte Optik oder maximale Featuretiefe sind NICHT Ziel der MVP-Version.

---

# 2. Systemübersicht

## 2.1 Produktname

SASD Freelancer LaunchPad

---

## 2.2 Produkttyp

Lokale Windows-Desktop-Anwendung.

---

## 2.3 Systemziel

Die Anwendung soll Freelancer unterstützen bei:

- Verwaltung von Projektangeboten
- Nachverfolgung von Bewerbungen
- Marktbeobachtung
- Dokumentation von Projektdaten
- Analyse von Budgets und Anforderungen

---

# 3. Technische Architektur

## 3.1 Zielplattform

- Microsoft Windows

---

## 3.2 Technologie-Stack

| Komponente | Technologie |
|---|---|
| Programmiersprache | C# |
| Framework | .NET 10 |
| GUI | Windows Forms |
| Datenbank | SQLite |
| Datenzugriff | Microsoft.Data.Sqlite |
| Versionskontrolle | Git |
| Repository | GitHub |
| Entwicklungsumgebung | Visual Studio |

---

## 3.3 Architekturprinzipien

Die Anwendung soll:

- lokal ausführbar sein
- ohne Cloudzwang funktionieren
- modular aufgebaut werden
- einfach erweiterbar bleiben
- gut verständlichen Code besitzen

---

## 3.4 Projektstruktur

Geplante Solution-Struktur:

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
  docs/
```

---

# 4. MVP-Funktionsumfang

## 4.1 Enthaltene Funktionen

Die MVP-Version muss folgende Funktionen enthalten:

### Projektverwaltung
- Projekt anlegen
- Projekt bearbeiten
- Projekt archivieren
- Projekt löschen

### Projektdaten
- Plattform erfassen
- Titel erfassen
- URL speichern
- Beschreibung speichern
- Budget speichern
- Stundensatz speichern
- Veröffentlichungsdatum speichern
- Skills speichern

### Statusverwaltung
- Status setzen
- Status ändern
- Statushistorie speichern

### Suche und Filterung
- Volltextsuche
- Filter nach Status
- Filter nach Plattform
- Sortierung nach Datum
- Sortierung nach Budget

### Notizen
- Freie Projektnotizen
- Zeitstempel für Notizen

---

## 4.2 Nicht enthaltene Funktionen

Folgende Funktionen gehören ausdrücklich NICHT zum MVP:

- automatische Bewerbungen
- Browser-Automatisierung
- Login-Automatisierung
- Scraping
- CAPTCHAs
- KI-gestützte Preisoptimierung
- Teamverwaltung
- Multi-User-Betrieb
- Cloud-Synchronisierung
- mobile Apps
- Webversion
- automatische Skillanalyse

---

# 5. Benutzeroberfläche

## 5.1 UI-Ziele

Die Oberfläche soll:

- funktional
- übersichtlich
- schnell bedienbar
- wartbar
- ressourcenschonend

sein.

---

## 5.2 Hauptfenster

Das Hauptfenster soll enthalten:

- Projektliste
- Suchfeld
- Filterbereich
- Toolbar
- Statusanzeige

---

## 5.3 Projektliste

Die Projektliste soll tabellarisch dargestellt werden.

Geplante Spalten:

- Status
- Plattform
- Titel
- Budget
- Stundensatz
- Veröffentlichungsdatum
- Letzte Änderung

---

## 5.4 Projektdetailansicht

Die Detailansicht soll ermöglichen:

- Bearbeitung aller Projektdaten
- Bearbeitung von Notizen
- Verwaltung von Skills
- Änderung des Status

---

# 6. Datenmodell

## 6.1 Datenbanktyp

SQLite-Datei lokal auf dem System.

---

## 6.2 Geplante Tabellen MVP

### platforms
Plattformdefinitionen.

### projects
Zentrale Projektdaten.

### project_notes
Freie Notizen zu Projekten.

### project_status_history
Historie von Statusänderungen.

### skills
Skilldefinitionen.

### project_skills
Zuordnung Projekt ↔ Skills.

---

## 6.3 Datenhaltungsprinzipien

- möglichst einfache Tabellenstruktur
- nachvollziehbare Beziehungen
- einfache Backupfähigkeit
- einfache Wartbarkeit

---

# 7. Geschäftslogik

## 7.1 Projektstatus

Der Status eines Projekts soll zentral verwaltet werden.

Geplante Status:

- Neu
- Interessant
- Beobachten
- Beworben
- Abgelehnt
- Zuschlag erhalten
- Archiviert

---

## 7.2 Suchlogik

Die Anwendung soll schnelle lokale Suchvorgänge ermöglichen.

Suchfelder:
- Titel
- Beschreibung
- Skills
- Plattform
- Notizen

---

## 7.3 Archivierung

Archivierte Projekte sollen standardmäßig ausgeblendet werden können.

---

# 8. Persistenz und Speicherung

## 8.1 Datenbankdatei

Die SQLite-Datei soll lokal gespeichert werden.

---

## 8.2 Backupfähigkeit

Die Anwendung darf keine komplizierte Backupstrategie erzwingen.

Ein einfaches Kopieren der Datenbankdatei soll ausreichend sein.

---

## 8.3 Offlinefähigkeit

Die Anwendung muss vollständig offline nutzbar bleiben.

---

# 9. Import- und Erweiterungsstrategie

## 9.1 MVP-Strategie

Im MVP erfolgt die Projekterfassung ausschließlich manuell.

---

## 9.2 Spätere Erweiterungen

Mögliche spätere Erweiterungen:

- CSV-Import
- JSON-Import
- halbautomatische Projekterfassung
- Feed-Import
- Analysefunktionen
- Dashboard-Erweiterungen

---

## 9.3 Scraping-Strategie

Automatisiertes Scraping wird ausdrücklich NICHT Teil der ersten Version.

Vor einer späteren Einführung müssen geprüft werden:

- Nutzungsbedingungen
- technische Risiken
- Plattformstabilität
- rechtliche Risiken

---

# 10. Sicherheit und Datenschutz

## 10.1 Lokale Datenhaltung

Alle Daten verbleiben lokal.

---

## 10.2 Externe Kommunikation

Die MVP-Version benötigt keine verpflichtende Internetkommunikation.

---

## 10.3 Datenschutz

Es sollen keine unnötigen personenbezogenen Daten gespeichert werden.

---

# 11. Qualitätsanforderungen

## 11.1 Wartbarkeit

Der Code soll:

- gut kommentiert
- logisch strukturiert
- nachvollziehbar
- modular

sein.

---

## 11.2 Erweiterbarkeit

Die Architektur soll spätere Erweiterungen ermöglichen.

---

## 11.3 Stabilität

Wichtiger als maximale Features ist:

- Stabilität
- Vorhersagbarkeit
- einfache Bedienung

---

# 12. Teststrategie

## 12.1 MVP-Testansatz

Die MVP-Version soll mindestens folgende Tests durchlaufen:

- Start der Anwendung
- Anlegen eines Projekts
- Bearbeiten eines Projekts
- Löschen eines Projekts
- Archivierung
- Suchfunktion
- Datenbankpersistenz

---

## 12.2 Testarten

- manuelle Funktionstests
- einfache Unit-Tests
- Debugging in Visual Studio

---

# 13. Entwicklungsstrategie

## 13.1 Iterative Entwicklung

Das Projekt soll iterativ entwickelt werden.

---

## 13.2 Kleine Meilensteine

Geplante frühe Meilensteine:

### Meilenstein 1
- Projektstruktur
- SQLite-Anbindung
- Projektliste

### Meilenstein 2
- Projekteditor
- Speicherung
- Statusverwaltung

### Meilenstein 3
- Suche und Filter
- Notizen
- Archivierung

---

## 13.3 Copy-&-Paste-Strategie

Codegenerierung soll bevorzugt in vollständigen Dateien erfolgen.

Die Dateien sollen direkt in das lokale Repository kopiert werden können.

---

# 14. Risiken

## 14.1 Technische Risiken

- zu frühe Komplexität
- Überengineering
- unnötige Automatisierung
- instabile externe Plattformen

---

## 14.2 Projektbezogene Risiken

- Fokusverlust
- zu viele Features
- langsame Entwicklung
- mangelnde Priorisierung

---

# 15. Erfolgsdefinition MVP

Der MVP gilt als erfolgreich, wenn:

- Projekte lokal verwaltet werden können
- die Bedienung schnell möglich ist
- Projekte strukturiert auffindbar sind
- Bewerbungen dokumentiert werden können
- die Anwendung stabil läuft
- die Architektur verständlich bleibt

---

# 16. Leitprinzip

Das wichtigste Prinzip des Projekts lautet:

> Praktischer Nutzen vor Perfektion.

Die Anwendung soll zuerst ein hilfreiches Werkzeug und erst später ein umfangreiches Produkt werden.
