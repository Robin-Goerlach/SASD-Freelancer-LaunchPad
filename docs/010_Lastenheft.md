# SASD Freelancer LaunchPad – Lastenheft

Version: 0.1  
Status: Arbeitsdokument / MVP-Planung  
Projekt: SASD Freelancer LaunchPad  
Organisation: SASD GmbH  
Dokumenttyp: Lastenheft  
Sprache: Deutsch  

---

# 1. Einleitung

## 1.1 Zweck des Dokuments

Dieses Lastenheft beschreibt die Anforderungen, Ziele und Rahmenbedingungen für die Entwicklung der Desktop-Anwendung **SASD Freelancer LaunchPad**.

Das Dokument dient als fachliche Grundlage für die spätere technische Umsetzung sowie für die Definition eines klar abgegrenzten MVPs (Minimum Viable Product).

Der Schwerpunkt liegt ausdrücklich auf einem schnellen praktischen Nutzen und nicht auf einer maximalen Funktionsvielfalt in der ersten Version.

---

## 1.2 Projektkontext

Freelancer-Plattformen wie PeoplePerHour veröffentlichen täglich neue Projektangebote. Für Freelancer entsteht dadurch die Herausforderung:

- relevante Projekte schnell zu erkennen
- interessante Projekte strukturiert zu verwalten
- Bewerbungen nachzuverfolgen
- Marktpreise und Anforderungen zu beobachten
- die eigene Positionierung zu verbessern

Derzeit erfolgt dies häufig unstrukturiert über Browser-Tabs, Bookmarks, Textdateien oder Notizen.

SASD Freelancer LaunchPad soll hierfür eine lokale, kontrollierbare und erweiterbare Desktop-Anwendung bereitstellen.

---

## 1.3 Zielgruppe des Dokuments

Dieses Dokument richtet sich an:

- Entwickler
- Projektverantwortliche
- spätere Mitwirkende
- Tester
- technische Reviewer

---

# 2. Projektübersicht

## 2.1 Projektname

SASD Freelancer LaunchPad

---

## 2.2 Kurzbeschreibung

SASD Freelancer LaunchPad ist eine lokale Windows-Desktop-Anwendung zur Verwaltung und Analyse von Freelancer-Projektangeboten.

Die Anwendung unterstützt Freelancer dabei:

- Projekte zu erfassen
- Projekte zu bewerten
- Bewerbungen zu dokumentieren
- Marktinformationen zu analysieren
- eigene Skills und Preise besser einzuordnen

---

## 2.3 Grundidee

Die erste Version soll bewusst klein, robust und sofort nutzbar sein.

Das Projekt verfolgt ausdrücklich NICHT das Ziel, sofort eine vollständige Freelancer-Plattform oder ein komplexes CRM-System zu entwickeln.

Der Fokus liegt auf:

> „Morgen produktiv nutzbar statt in Monaten perfekt.“

---

# 3. Projektziele

## 3.1 Hauptziele

Die Anwendung soll:

- relevante Projekte zentral verwalten
- lokale Datensouveränität ermöglichen
- schnelle Projektbewertungen unterstützen
- die Nachverfolgung von Bewerbungen erleichtern
- Marktbeobachtung ermöglichen
- später erweiterbar bleiben

---

## 3.2 Technische Ziele

- einfache lokale Installation
- geringer Ressourcenverbrauch
- einfache Wartbarkeit
- verständliche Architektur
- saubere Trennung von Komponenten
- SQLite-basierte Datenspeicherung

---

## 3.3 Organisatorische Ziele

- schneller MVP
- geringe Einstiegshürde
- iterative Weiterentwicklung
- kontrollierbare Komplexität

---

# 4. Nicht-Ziele

Die folgenden Funktionen gehören ausdrücklich NICHT zum MVP:

- automatische Bewerbung auf Projekte
- aggressive Scraping-Mechanismen
- Umgehung von Plattformschutzmaßnahmen
- Android- oder iOS-Version
- Cloud-Zwang
- Team-/Mandantenverwaltung
- komplexes CRM-System
- automatische AI-Preisfindung
- automatische Konkurrenzanalyse
- Multi-User-Betrieb
- Browser-Erweiterungen

---

# 5. Zielgruppe

## 5.1 Primäre Zielgruppe

- Einzel-Freelancer
- technische Freelancer
- Linux-/DevOps-/Software-Entwickler
- kleine selbstständige IT-Dienstleister

---

## 5.2 Sekundäre Zielgruppe

- kleine Agenturen
- Beratungsunternehmen
- SASD-interne Nutzung

---

# 6. Fachliche Anforderungen MVP

## 6.1 Projektverwaltung

Die Anwendung muss ermöglichen:

- Projekte anzulegen
- Projekte zu bearbeiten
- Projekte zu archivieren
- Projekte zu löschen
- Projekte nach Plattform zu kategorisieren

---

## 6.2 Projektdaten

Folgende Daten sollen mindestens speicherbar sein:

- Plattform
- Projekttitel
- URL
- Beschreibung
- Budget
- Stundensatz
- Projektstatus
- Veröffentlichungsdatum
- Notizen
- Skills/Keywords

---

## 6.3 Statusverwaltung

Mindestens folgende Stati sollen unterstützt werden:

- Neu
- Interessant
- Beobachten
- Beworben
- Abgelehnt
- Zuschlag erhalten
- Archiviert

---

## 6.4 Suche und Filterung

Die Anwendung soll ermöglichen:

- Volltextsuche
- Filter nach Status
- Filter nach Plattform
- Filter nach Skills
- Sortierung nach Datum
- Sortierung nach Budget

---

## 6.5 Notizen

Zu jedem Projekt sollen freie Notizen gespeichert werden können.

---

# 7. Benutzerabläufe

## 7.1 Neues Projekt erfassen

Der Benutzer:

1. öffnet die Anwendung
2. legt ein neues Projekt an
3. trägt Projektdaten ein
4. speichert das Projekt
5. bewertet die Relevanz

---

## 7.2 Bewerbung dokumentieren

Der Benutzer:

1. markiert ein Projekt als „beworben“
2. ergänzt Notizen
3. dokumentiert Preis/Stundensatz
4. verfolgt den weiteren Verlauf

---

## 7.3 Marktbeobachtung

Der Benutzer:

- durchsucht historische Projekte
- analysiert Budgetentwicklungen
- erkennt häufige Skills
- bewertet Markttrends

---

# 8. Datenhaltung

## 8.1 Datenbank

Die Anwendung verwendet SQLite als lokale Datenbank.

---

## 8.2 Datensouveränität

Alle Daten verbleiben lokal auf dem System des Benutzers.

Es besteht keine Pflicht zur Cloud-Nutzung.

---

## 8.3 Backupfähigkeit

Die SQLite-Datenbank soll einfach kopierbar und sicherbar sein.

---

# 9. Technische Randbedingungen

## 9.1 Zielplattform

- Windows Desktop

---

## 9.2 Technologie-Stack

- C#
- .NET 10
- Windows Forms
- SQLite
- Git
- GitHub

---

## 9.3 Architekturziele

- modulare Struktur
- saubere Schichten
- wartbarer Code
- verständliche Komponenten
- spätere Erweiterbarkeit

---

# 10. Rechtliche und organisatorische Aspekte

## 10.1 Plattformbezug

Die Anwendung steht in keiner offiziellen Verbindung zu PeoplePerHour oder anderen Plattformen.

---

## 10.2 Terms of Service

Mögliche spätere Import- oder Analysefunktionen müssen mit den jeweiligen Nutzungsbedingungen vereinbar sein.

---

## 10.3 Datenschutz

Es sollen keine unnötigen personenbezogenen Daten gespeichert werden.

---

# 11. Risiken

## 11.1 Technische Risiken

- Änderungen an Plattformseiten
- Importprobleme
- zukünftige API-Änderungen
- Performanceprobleme bei späterem Ausbau

---

## 11.2 Projektbezogene Risiken

- Überengineering
- zu frühe Automatisierung
- unnötige Komplexität
- fehlender Fokus auf Nutzbarkeit

---

# 12. MVP-Abgrenzung

Die erste Version gilt als erfolgreich, wenn:

- Projekte lokal gespeichert werden können
- Projekte schnell auffindbar sind
- Bewerbungen dokumentiert werden können
- einfache Marktbeobachtung möglich ist
- die Anwendung stabil und verständlich bleibt

---

# 13. Geplante spätere Erweiterungen

Mögliche spätere Versionen:

- CSV-/JSON-Import
- halbautomatische Projekterfassung
- Analysefunktionen
- Statistikfunktionen
- Skill-Scoring
- Budgetanalyse
- Dashboard-Erweiterungen
- Linux-Version
- Web-Version
- AI-Unterstützung

Diese Funktionen gehören ausdrücklich NICHT zum MVP.

---

# 14. Erfolgsdefinition

Das Projekt gilt als erfolgreich, wenn:

> Ein Freelancer innerhalb weniger Minuten neue Projektangebote lokal erfassen, bewerten, filtern und historisch verfolgen kann.

---

# 15. Leitprinzip des Projekts

Das wichtigste Projektprinzip lautet:

> Praktischer Nutzen vor Perfektion.

Die Anwendung soll zuerst ein funktionierendes Werkzeug sein und erst später ein umfangreiches Produkt werden.
