# SASD Freelancer LaunchPad – Product Roadmap

**Version:** 0.1  
**Status:** Baseline-Kandidat  
**Projekt:** SASD Freelancer LaunchPad  
**Organisation:** SASD GmbH  
**Dokumenttyp:** Product Roadmap  
**Sprache:** Deutsch  
**Stand:** 24.08.2026  
**Führende Grundlagen:** `010_Lastenheft.md`, `020_Pflichtenheft_MVP.md`, `030_Technical_Design.md`, `040_Database_Design.md`, `050_Architecture.md`

---

# 0. Zweck

Dieses Dokument ist der führende Ort für:

> **Reihenfolge und Entwicklungsphasen.**

Lastenheft, Pflichtenheft, Architecture und Technical Design enthalten deshalb bewusst keine konkurrierende Milestone-Planung.

Die Roadmap ist **kein Terminkalender**.

Sie legt keine Fertigstellungsdaten fest.

---

# 1. Roadmap-Prinzipien

## 1.1 Praktischer Nutzen zuerst

Die Reihenfolge wird danach gewählt, wann LaunchPad im echten Freelancer-Alltag Nutzen erzeugt.

---

## 1.2 Keine Zukunft auf Vorrat

Eine spätere Produkt-MUSS-Anforderung wird berücksichtigt, aber nicht implementiert, bevor sie für einen realen Entwicklungsabschnitt benötigt wird.

---

## 1.3 Datenmodell vor Komfortautomation

Automatische Discovery ist erst sinnvoll, wenn:

- Opportunity,
- Listing,
- Duplicate Handling,
- Persistenz,
- Suche

verlässlich funktionieren.

---

## 1.4 Zuverlässigkeit vor Quellenanzahl

Ein zuverlässiger Adapter ist wertvoller als fünf fragile Adapter.

Insbesondere gilt:

> „Quelle konnte nicht geprüft werden“ darf niemals als „0 Treffer“ erscheinen.

---

# 2. Phase A – Baseline und kontrollierte Umstellung

## Ziel

Den alten Project-Prototyp auf die neue fachliche und technische Baseline umstellen.

## Inhalt

- Dokumentbaseline finalisieren
- `Core/Data/App` → `Domain/Application/Infrastructure/WinForms`
- `FreelanceProject` fachlich auflösen
- Opportunity + Listing einführen
- Proposal-Grundmodell einführen
- Archive vom Status trennen
- neues SQLite-Zielschema
- Legacy-Migrationspfad
- Architecture Tests

## Exit-Kriterien

- Build grün
- Tests grün
- vorhandene Legacy-Testdaten migrierbar
- keine direkte SQLite-Nutzung in Forms
- keine `Applied/Won/Archived` Opportunity-Statuswerte

---

# 3. Phase B – Opportunity-Arbeitsplatz

## Ziel

LaunchPad wird erstmals als tägliches lokales Opportunity-Werkzeug nutzbar.

## Inhalt

- Opportunity anlegen
- Listing manuell erfassen
- vollständige Ausschreibung sichern
- Plattform, URL, External ID
- PublishedAt / FirstObservedAt / CapturedAt / LastObservedAt
- Ort / Remote / Start / Laufzeit
- Fixed/Hourly/Daily getrennt
- Skills
- Notes
- Opportunity-Status
- Archivierung
- Source URL öffnen

## Exit-Kriterien

Eine echte Opportunity von Freelancermap, PeoplePerHour oder GULP/Randstad kann vollständig lokal erfasst, geschlossen, archiviert und später wiedergefunden werden.

---

# 4. Phase C – Daily Work: Suche und Filter

## Ziel

Die tägliche Arbeit wird schneller als Browser-Tabs und lose Notizen.

## Inhalt

- Freitextsuche
- Plattformfilter
- Statusfilter
- Skillfilter
- Archivfilter
- freie Published-Zeiträume
- Sortierung
- kompakte Opportunity-Liste
- 1280×720-Abnahme

## Exit-Kriterien

Der Nutzer kann beispielsweise beantworten:

> „Welche Linux-Opportunities von Freelancermap habe ich seit einem bestimmten Zeitpunkt gefunden?“

---

# 5. Phase D – Proposal Lite

## Ziel

Eigene Bewerbungs-/Angebotsentscheidungen werden nachvollziehbar.

## Inhalt

- Proposal erstellen
- SubmittedAt
- eigener Fixed/Hourly/Daily Preis
- Currency
- CV-/Profilversionsbezeichnung
- Proposal State
- Outcome
- `TimedOutByUser`
- Proposal Note
- Listing als Einreichungsweg

## Exit-Kriterien

Für jede Bewerbung kann nachvollzogen werden:

- wann,
- über welchen Weg,
- zu welchem Preis,
- mit welcher CV-/Profilversion,
- mit welchem aktuellen Ergebnis.

---

# 6. Phase E – Backup und MVP-Stabilisierung

## Ziel

Der lokale Datenbestand ist ausreichend sicher für regelmäßige echte Nutzung.

## Inhalt

- konsistentes SQLite Backup
- Manifest
- Migrationstests
- Startup-/Failure-Verhalten
- Logging
- Fehlermeldungen
- Datenintegrität
- Performance-Grundprüfung
- manuelle Abnahmeszenarien aus Pflichtenheft

## Exit-Kriterien

Der MVP erfüllt vollständig alle `MVP-MUSS`-Anforderungen und die zugeordneten Abnahmeszenarien.

---

# 7. Phase F – Capture Convenience

## Ziel

Abtippen wird deutlich reduziert.

## Reihenfolge als Arbeitsannahme

1. Paste Capture
2. URL Capture
3. Browser Helper

Die Reihenfolge darf nach Spikes geändert werden.

## Inhalt

- kanonisches Capture Candidate Model
- Import Preview
- Partial Import
- Duplicate Check
- Originaldaten erhalten
- Capture Method
- Fehlerdiagnose

---

# 8. Phase G – erste zuverlässige Discovery

## Ziel

LaunchPad findet neue Opportunities selbstständig bzw. auf Benutzeranforderung.

## Voraussetzung

Phase F und lokales Datenmodell sind stabil.

## Inhalt

- Search Profiles
- kanonisches Filtermodell
- erster Platform Discovery Adapter
- LastSuccessfulCheck pro SearchProfile × Platform
- lokale Nachfilterung
- Duplicate Handling
- Discovery Run Status
- Fehler ≠ 0 Treffer

## Qualitätsgate

Ein Adapter wird erst als zuverlässig betrachtet, wenn:

- Änderungen an Plattformantworten erkannt werden,
- Fehler klar signalisiert werden,
- Watermarks korrekt bleiben,
- bekannte Treffer nicht ständig neu erscheinen.

---

# 9. Phase H – weitere Plattformen

## Ziel

Discovery wird wirklich plattformübergreifend.

## Kandidaten

- Freelancermap
- PeoplePerHour
- GULP/Randstad Professional

Die tatsächliche Implementierungsreihenfolge wird nach:

- Nutzen,
- technischer Zugänglichkeit,
- Stabilität,
- rechtlicher Zulässigkeit

festgelegt.

---

# 10. Phase I – Observation

## Ziel

LaunchPad beginnt, Marktveränderungen historisch zu erhalten.

## Inhalt

- Observation pro Listing
- Status der Ausschreibung
- Rate/Budget-Veränderung
- Proposal Count, soweit sichtbar
- Award-Signale, soweit sichtbar
- manueller Recheck
- später gezielter automatischer Recheck

---

# 11. Phase J – Companies, Contacts und Activities

## Ziel

Wiederkehrende professionelle Beziehungen werden nachvollziehbar.

## Inhalt

- Company
- Contact
- Endkunde/Vermittler-Rollen
- Activity
- Follow-up
- Timeline

## Nicht Ziel

Kein generisches Enterprise CRM.

---

# 12. Phase K – Analytics

## Ziel

Aus der wachsenden Datenbasis lernen.

## Inhalt

- Funnel
- Response Rate
- Time to Proposal
- Rate-Verteilungen
- Skill-Trends
- Plattformvergleich
- Vermittler-/Company-Historie
- Stichprobengröße und Unsicherheit

---

# 13. Phase L – Profile Intelligence und Decision Support

## Ziel

Marktdaten mit eigener Positionierung verbinden.

## Inhalt

- Profile Snapshots
- Market vs. Profile
- Hard Filter vs. Soft Fit
- erklärbarer Opportunity Fit
- benutzerdefinierte Gewichtung

---

# 14. Phase M – optionale AI-Unterstützung

## Ziel

AI nur dort einsetzen, wo sie nachweislich Arbeit spart.

## Kandidaten

- Extraktion
- Skill-Erkennung
- Zusammenfassung
- Ähnlichkeitsvorschläge
- Analysehilfe

## Regel

AI darf nicht zur Voraussetzung für den Kernworkflow werden.

---

# 15. Release-Nummern

Konkrete Release-/Milestone-Nummern werden erst vergeben, wenn der jeweilige Entwicklungsabschnitt tatsächlich begonnen wird.

Damit wird vermieden, dass:

- Lastenheft,
- Pflichtenheft,
- Roadmap,
- GitHub-Milestones

unterschiedliche veraltete Versionspläne enthalten.

---

# 16. Priorisierungsregel bei neuen Ideen

Neue Ideen werden gegen folgende Fragen geprüft:

1. verbessert die Idee `Discover → Capture → Evaluate → Apply → Observe → Interact → Outcome → Learn`?
2. spart sie im aktuellen Alltag Zeit?
3. verhindert sie Datenverlust?
4. wird sie für einen bereits geplanten nächsten Schritt benötigt?
5. erzeugt sie mehr Architektur-/UI-Komplexität als Nutzen?

Wenn Punkt 5 überwiegt:

> zurückstellen.

---

# 17. Roadmap-Änderungen

Eine Änderung der Roadmap darf:

- Reihenfolge verschieben,
- Phasen teilen,
- Phasen zusammenfassen.

Sie darf nicht still:

- Lastenheft-Anforderungen löschen,
- Architecture-Regeln aufheben,
- MVP-MUSS abschwächen.

---

# 18. Zusammenfassung

Die Entwicklungsrichtung lautet:

```text
Baseline
→ Opportunity/Listing
→ Search & Daily Work
→ Proposal Lite
→ Backup/Stabilität
→ Capture Convenience
→ Reliable Discovery
→ Multi-Platform
→ Observation
→ Relationships
→ Analytics
→ Profile/Decision Support
→ optionale AI
```

Der entscheidende Maßstab bleibt:

> **LaunchPad soll mit jeder Phase praktisch nützlicher werden, ohne sich durch zu frühe Zukunftstechnik selbst auszubremsen.**
