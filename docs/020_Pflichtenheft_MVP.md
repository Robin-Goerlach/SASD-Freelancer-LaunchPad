# SASD Freelancer LaunchPad – Pflichtenheft MVP

**Version:** 0.2  
**Status:** Baseline-Kandidat – an Lastenheft 0.2 angepasst  
**Projekt:** SASD Freelancer LaunchPad  
**Organisation:** SASD GmbH  
**Dokumenttyp:** Pflichtenheft für den ersten praktisch nutzbaren Produktstand  
**Sprache:** Deutsch  
**Stand:** 24.08.2026  
**Führende fachliche Grundlage:** `010_Lastenheft.md`, Version 0.2 Baseline-Kandidat

---

# 0. Dokumentkontrolle

## 0.1 Zweck dieses Dokuments

Dieses Pflichtenheft konkretisiert die Anforderungen des Lastenhefts für den **ersten praktisch nutzbaren Stand** von SASD Freelancer LaunchPad.

Das Lastenheft beschreibt:

> **was das Produkt leisten soll und warum.**

Dieses Pflichtenheft beschreibt:

> **wie die MVP-Anforderungen aus Benutzersicht und funktionaler Systemsicht umgesetzt und abgenommen werden sollen.**

Das Dokument legt bewusst **keine Release-Nummern, Milestone-Reihenfolgen oder Zeitplanung** fest. Diese Informationen gehören ausschließlich in die Product Roadmap.

Ebenso beschreibt dieses Pflichtenheft nicht die vollständige Softwarearchitektur. Architektur-, Persistenz- und Technologieentscheidungen werden in den dafür vorgesehenen Dokumenten geführt.

---

## 0.2 Normativer MVP-Scope

Der normative MVP-Scope ergibt sich aus allen Anforderungen des Lastenhefts mit der Priorität:

```text
MVP-MUSS
```

Dieses Pflichtenheft darf diese Anforderungen konkretisieren, aber nicht abschwächen oder stillschweigend entfernen.

`PRODUKT-MUSS`, `SOLL`, `KANN` und `PRÜFEN` werden nur dann berücksichtigt, wenn eine kleine frühe Designentscheidung notwendig ist, damit der MVP spätere Produktziele **nicht unnötig verbaut**.

Dabei gilt ausdrücklich:

> **Für die Zukunft offen bleiben, ohne die Zukunft auf Vorrat zu implementieren.**

---

## 0.3 Abgrenzung zu anderen Dokumenten

| Dokument | Führende Frage |
|---|---|
| `010_Lastenheft.md` | Was soll das Produkt leisten und warum? |
| `020_Pflichtenheft_MVP.md` | Wie wird der erste nutzbare fachliche Funktionsumfang umgesetzt und abgenommen? |
| `030_Technical_Design.md` | Wie wird der aktuelle Entwicklungsstand technisch konkret realisiert? |
| `040_Database_Design.md` | Wie werden die fachlichen Daten persistent modelliert? |
| `050_Architecture.md` | Welche langfristigen Architekturgrenzen und Abhängigkeitsregeln gelten? |
| `060_Product_Roadmap.md` | In welcher Reihenfolge werden Anforderungen umgesetzt? |
| ADRs | Warum wurde eine konkrete Architekturentscheidung getroffen? |
| `080_Data_Protection.md` | Wie werden Datenschutz, Retention und spätere externe Verarbeitung konkretisiert? |

Dieses Pflichtenheft wiederholt Architekturentscheidungen deshalb nur soweit, wie sie für das **fachliche Verhalten oder die Abnahme des MVP** notwendig sind.

---

## 0.4 Ausgangslage und Altstand

Die bisherige Pflichtenheft-Fassung 0.1 basierte noch auf einem frühen `Project`-zentrierten Modell.

Sie ist fachlich überholt, insbesondere in folgenden Punkten:

- `Project` wird durch das fachliche Konzept `Opportunity` ersetzt.
- ein reales potentielles Projekt und seine konkrete Plattformveröffentlichung werden getrennt betrachtet.
- eine Plattformveröffentlichung wird als **Fundstelle / Listing** behandelt.
- Proposal ist kein Opportunity-Status, sondern ein eigenes fachliches Objekt.
- Archivierung ist kein Opportunity-Status.
- Budget, Hourly Rate und Daily Rate werden nicht in ein einziges Preisfeld gezwungen.
- Notes sind keine Activities.
- konkrete Versions- und Milestone-Planung gehört nicht mehr in das Pflichtenheft.

Vorhandene technische Artefakte aus der frühen `Project`-Phase gelten daher **nicht als normative Fachdefinition**.

---

## 0.5 Konformitätsregel

Bei einem Widerspruch gilt folgende Reihenfolge:

1. aktuelle, bewusst beschlossene Produktentscheidung im Lastenheft,
2. dieses Pflichtenheft für den MVP,
3. Architecture / Technical Design / Database Design für technische Details,
4. vorhandener Prototyp- oder Altcode.

Altcode darf keine inzwischen korrigierte Produktentscheidung zurück in das Fachmodell drücken.

---

# 1. Ziel des MVP

## 1.1 Arbeitsziel

Der MVP soll einen vollständigen, kleinen und täglich nutzbaren Arbeitsablauf bereitstellen:

```text
Opportunity auf einer Plattform finden
        ↓
manuell in LaunchPad erfassen
        ↓
Ausschreibung lokal sichern
        ↓
fachlich beurteilen
        ↓
mit Suche und Filtern wiederfinden
        ↓
gegebenenfalls Proposal dokumentieren
        ↓
Opportunity später erneut ansehen
```

Der MVP ist ausdrücklich **kein automatisches Discovery-System**.

Er soll aber eine belastbare lokale Datenbasis schaffen, auf der spätere Capture-, Discovery-, Observation- und Intelligence-Funktionen aufbauen können.

---

## 1.2 Praktischer Erfolgsmaßstab

Der MVP ist nicht erfolgreich, wenn zwar alle Datenfelder existieren, die tägliche Pflege aber so umständlich ist, dass der Nutzer Opportunities lieber nicht erfasst.

Die zentrale UX-Regel lautet daher:

> **Häufige Arbeitsschritte müssen kurz, verständlich und ohne unnötige Dialogketten möglich sein.**

---

## 1.3 Bewusst nicht Ziel des MVP

Der MVP muss insbesondere noch nicht enthalten:

- automatisierte Multi-Portal-Discovery,
- Browser Helper oder Browser Extension,
- URL-/HTML-Parser für Portale,
- automatische Skill-Erkennung,
- Observation Engine,
- Winning-Bid-Tracking,
- Company Management,
- Contact Management,
- Activity Timeline,
- Follow-up-System,
- Relationship Analytics,
- Skill Intelligence,
- Pricing Intelligence,
- Profile Intelligence,
- Opportunity Fit Score,
- AI-Funktionen,
- Notifications,
- Cloud Sync,
- Mobile App,
- Webversion,
- vollständiges Attachment- oder CV-Dokumentmanagement.

Diese Abgrenzung entfernt keine langfristigen Produktanforderungen.

---

# 2. Fachliches MVP-Modell

## 2.1 Grundsatz: Opportunity ist das reale potentielle Projekt

Eine `Opportunity` repräsentiert das **reale potentielle Projekt bzw. den potentiellen Auftrag**, auf den sich der Nutzer beziehen kann.

Beispiel:

```text
Endkundenprojekt:
Linux-/Ansible-Migration
```

Die Opportunity ist nicht identisch mit der Webseite, auf der das Projekt gefunden wurde.

---

## 2.2 Fundstelle / Listing

Eine `Fundstelle` repräsentiert die konkrete Veröffentlichung einer Opportunity auf einer Plattform.

Beispiel:

```text
Opportunity:
Linux-/Ansible-Migration

Fundstelle:
Platform: Freelancermap
URL: https://...
External ID: 12345
PublishedAt: ...
Published Hourly Rate: ...
Original Description: ...
```

Langfristig kann dieselbe Opportunity mehrere Fundstellen besitzen.

Beispiel:

```text
Opportunity
  ├── Fundstelle Freelancermap / Vermittler A
  └── Fundstelle GULP / Vermittler B
```

Im MVP darf die Benutzeroberfläche zunächst mit **einer bekannten Fundstelle pro neu erfasster Opportunity** arbeiten.

Die fachliche und persistente Struktur darf jedoch nicht unnötig voraussetzen, dass eine Opportunity für immer genau eine Fundstelle besitzen kann.

**PH-MVP-DOM-001**  
Die MVP-Umsetzung muss Opportunity und Fundstelle fachlich getrennt behandeln.

**PH-MVP-DOM-002**  
Die MVP-Oberfläche darf den Standardfall „eine Opportunity – eine bekannte Fundstelle“ optimieren.

**PH-MVP-DOM-003**  
Die technische Umsetzung darf die spätere Zuordnung weiterer Fundstellen nicht durch eine unnötig starre 1:1-Annahme verhindern.

---

## 2.3 Platform

Eine `Platform` bezeichnet das Portal, auf dem eine Fundstelle veröffentlicht ist.

Initial relevant sind insbesondere:

- Freelancermap,
- PeoplePerHour,
- Randstad Professional / GULP.

Die Platform-Liste soll fachlich erweiterbar bleiben.

**PH-MVP-DOM-004**  
Platform darf nicht als fest verdrahteter Teil des Opportunity-Status oder Proposal-Status behandelt werden.

---

## 2.4 Capture Method

Im MVP lautet die Capture Method regulär:

```text
Manual
```

Spätere Werte können beispielsweise sein:

- Paste,
- URL,
- Browser Helper,
- API.

Der MVP muss diese späteren Mechanismen nicht implementieren.

**PH-MVP-DOM-005**  
Bei manueller Erfassung muss `CaptureMethod = Manual` gesetzt bzw. fachlich eindeutig ableitbar sein.

---

## 2.5 Opportunity-Status

Der Opportunity-Status beschreibt die fachliche Einordnung des realen potentiellen Projekts.

Für den MVP werden folgende Zustände vorgesehen:

- `New`
- `Reviewing`
- `Interesting`
- `Watching`
- `Dismissed`
- `Closed`
- `Cancelled`
- `Expired`

Die UI darf benutzerfreundliche lokalisierte Bezeichnungen anzeigen.

**PH-MVP-DOM-006**  
Der Status muss unabhängig von Archivierung und Proposal verwaltet werden.

**PH-MVP-DOM-007**  
Der MVP erzwingt keine komplexe Status-Transition-Matrix. Der Nutzer darf einen fachlich erforderlichen Status direkt setzen.

---

## 2.6 Archivierung

Archivierung ist ein separater Zustand der Arbeitsorganisation.

Beispiel:

```text
Opportunity Status: Dismissed
Archived: Yes
```

oder:

```text
Opportunity Status: Closed
Archived: Yes
```

**PH-MVP-DOM-008**  
Archivieren darf den Opportunity-Status nicht überschreiben.

**PH-MVP-DOM-009**  
De-Archivieren muss den vorherigen Opportunity-Status unverändert wieder sichtbar machen.

---

## 2.7 Proposal

Ein `Proposal` dokumentiert die eigene Bewerbung bzw. das eigene Angebot auf eine Opportunity.

Proposal bleibt fachlich von Opportunity getrennt.

Im MVP ist ein einfacher Proposal-Lite-Workflow ausreichend.

**PH-MVP-DOM-010**  
Proposal-Daten dürfen nicht als Opportunity-Statusfelder modelliert werden.

**PH-MVP-DOM-011**  
Die MVP-Benutzeroberfläche darf pro Opportunity zunächst einen einfachen Proposal-Vorgang darstellen. Die persistente Fachstruktur soll eine spätere 1:n-Erweiterung nicht unnötig verhindern.

---

## 2.8 Proposal-Status und Outcome

Für den MVP wird zwischen laufendem Proposal-Zustand und terminalem Outcome unterschieden.

Geeignete einfache Proposal-Zustände:

- `Submitted`
- `AwaitingResponse`
- `Closed`

Mögliche Outcomes:

- `Won`
- `Rejected`
- `Withdrawn`
- `TimedOutByUser`
- `Unknown`

`Interview`, `Negotiation` und `Offer` sind keine terminalen Outcomes und werden im MVP nicht als Outcome-Werte missbraucht.

`No Response` wird im MVP nicht als vermeintlich gesicherte externe Entscheidung gespeichert.

Wenn der Nutzer den Vorgang selbst mit `TimedOutByUser` schließt, kann eine spätere Analytics daraus zusammen mit fehlender Response ein `No Response`-Signal ableiten.

**PH-MVP-DOM-012**  
Ein Outcome darf nur zu einem existierenden Proposal gespeichert werden.

**PH-MVP-DOM-013**  
`TimedOutByUser` muss erkennbar machen, dass der Nutzer den Vorgang für sich beendet hat und keine externe Absage behauptet wird.

---

## 2.9 Note

Die MVP-Note ist ein freier, vom Nutzer gepflegter Opportunity-Text.

Eine Note ist **keine Activity**.

Im MVP genügt ein einfaches Opportunity-Notizfeld.

Spätere mehrere Notes mit Zeitstempeln werden dadurch nicht ausgeschlossen.

**PH-MVP-DOM-014**  
User Notes dürfen nicht mit Originalausschreibungstexten vermischt oder durch Systemvorgänge überschrieben werden.

---

## 2.10 Skill

Ein Skill ist im MVP ein vom Nutzer zugeordnetes fachliches Stichwort.

Beispiele:

- Linux
- Debian
- C#
- .NET
- Ansible
- Kubernetes

Im MVP gibt es noch keine automatische Skill-Erkennung und keine komplexe Taxonomie.

**PH-MVP-DOM-015**  
Doppelte Skills derselben Opportunity sollen bei identischer normalisierter Schreibweise vermieden werden.

**PH-MVP-DOM-016**  
Unterschiedliche Begriffe dürfen im MVP zunächst getrennt bestehen bleiben; beispielsweise `PostgreSQL` und `Postgres` müssen noch nicht automatisch vereinigt werden.

---

# 3. Datensemantik des MVP

## 3.1 Pflicht und Optionalität

Der MVP soll reale Ausschreibungen erfassen können, auch wenn einzelne Informationen fehlen.

Daher gilt grundsätzlich:

> **Unknown ist besser als ein erfundener Wert.**

Nur Daten, die für die Identifizierbarkeit und Bedienbarkeit zwingend erforderlich sind, sollen die Speicherung blockieren.

**PH-MVP-DATA-001**  
Der Opportunity-Titel muss vorhanden sein.

**PH-MVP-DATA-002**  
Eine neu erfasste MVP-Opportunity muss mindestens eine Fundstelle mit einer Platform besitzen.

**PH-MVP-DATA-003**  
External ID, URL, PublishedAt, Rate, Budget, Remote-Anteil, Ort und weitere Quellinformationen dürfen unbekannt sein.

---

## 3.2 Titel

Der Titel dient der schnellen Erkennung und Suche.

**PH-MVP-DATA-004**  
Ein leerer oder nur aus Leerzeichen bestehender Titel darf nicht gespeichert werden.

**PH-MVP-DATA-005**  
Führende und nachfolgende Leerzeichen sollen beim Speichern bereinigt werden.

---

## 3.3 Fundstellenidentifikation

Für eine Fundstelle müssen erfasst werden können:

- Platform,
- External ID, soweit vorhanden,
- Source URL, soweit vorhanden,
- Capture Method,
- CapturedAt.

**PH-MVP-DATA-006**  
External ID ist optional.

**PH-MVP-DATA-007**  
Source URL ist optional speicherbar; wenn eine URL vorhanden ist, muss sie aus der Oberfläche wieder aufrufbar sein.

**PH-MVP-DATA-008**  
`CapturedAt` wird bei der manuellen Erfassung automatisch mit der aktuellen UTC-Zeit vorbelegt.

---

## 3.4 Originalausschreibung

Der relevante vollständige Ausschreibungstext soll lokal gespeichert werden.

**PH-MVP-DATA-009**  
Der Beschreibungstext muss mehrzeilig sein können und darf nicht auf eine kurze Zusammenfassung reduziert werden.

**PH-MVP-DATA-010**  
Speichern und erneutes Laden dürfen den Text nicht stillschweigend kürzen oder fachlich verändern.

**PH-MVP-DATA-011**  
User Notes und Originalausschreibung müssen getrennte Eingabebereiche besitzen.

---

## 3.5 Zeitinformationen

Der MVP muss folgende Zeitinformationen aufnehmen können, soweit bekannt:

- `PublishedAt` der Fundstelle,
- `FirstObservedAt`,
- `CapturedAt`,
- `LastObservedAt`,
- `Deadline`,
- `ExpectedStartDate`,
- `Duration`,
- `EstimatedEndDate`.

### Zeitbasis

Intern gilt zunächst UTC als kanonische Zeitbasis für exakte Zeitpunkte.

Die MVP-Oberfläche muss UTC klar kenntlich machen, wenn Uhrzeiten erfasst oder angezeigt werden.

Eine spätere konfigurierbare Anzeige in lokaler Zeitzone wird dadurch nicht ausgeschlossen.

**PH-MVP-DATA-012**  
`FirstObservedAt` wird bei Neuanlage standardmäßig auf den aktuellen UTC-Zeitpunkt gesetzt.

**PH-MVP-DATA-013**  
`CapturedAt` wird bei manueller Erfassung standardmäßig auf den aktuellen UTC-Zeitpunkt gesetzt.

**PH-MVP-DATA-014**  
`LastObservedAt` darf initial dem ersten Beobachtungszeitpunkt entsprechen und muss später unabhängig von Deadline, Status oder Archivierung aktualisierbar sein.

**PH-MVP-DATA-015**  
Ein einfacher Benutzerbefehl „jetzt erneut geprüft“ oder eine gleichwertige Bedienmöglichkeit soll `LastObservedAt` auf den aktuellen UTC-Zeitpunkt setzen können.

**PH-MVP-DATA-016**  
Wenn eine Quelle nur ein Datum und keine belastbare Uhrzeit liefert, darf LaunchPad keine scheinbar exakte Uhrzeit erfinden. Die technische Repräsentation dafür wird im Database Design konkretisiert.

**PH-MVP-DATA-017**  
`ExpectedStartDate`, `Deadline` und `EstimatedEndDate` dürfen unbekannt sein.

**PH-MVP-DATA-018**  
`Duration` darf im MVP pragmatisch als quellnaher Wert gespeichert werden; eine komplexe Normalisierung ist nicht erforderlich.

---

## 3.6 Ort, Remote und Reise

Soweit bekannt müssen erfasst werden können:

- Country,
- Location/City,
- Remote-Modus,
- Remote-Anteil,
- Hybrid/On-site-Information,
- Reiseanforderung.

Zur Vermeidung widersprüchlicher Checkbox-Kombinationen soll die Oberfläche einen verständlichen Hauptmodus verwenden, beispielsweise:

- Unknown
- Remote
- Hybrid
- On-site

Ein prozentualer Remote-Anteil kann ergänzend angegeben werden.

**PH-MVP-DATA-019**  
Remote-Anteil darf nur im sinnvollen Wertebereich 0 bis 100 Prozent liegen.

**PH-MVP-DATA-020**  
Unbekannte Remote-Angaben dürfen die Speicherung nicht blockieren.

**PH-MVP-DATA-021**  
Ort und Land dürfen Freitext sein; eine externe Geodatenbank ist kein MVP-Bestandteil.

---

## 3.7 Preis- und Rate-Angaben

Der MVP muss mindestens folgende Quellwerte getrennt aufnehmen können:

- Fixed Budget,
- Budget Minimum,
- Budget Maximum,
- Hourly Rate Minimum,
- Hourly Rate Maximum,
- Daily Rate Minimum,
- Daily Rate Maximum,
- Currency,
- Rate Unit bzw. fachlich eindeutige Einheit des jeweiligen Werts.

**PH-MVP-DATA-022**  
Monetäre Werte müssen Dezimalwerte unterstützen.

**PH-MVP-DATA-023**  
Negative Geldwerte dürfen nicht gespeichert werden.

**PH-MVP-DATA-024**  
Wenn Minimum und Maximum beide vorhanden sind, darf Minimum nicht größer als Maximum sein.

**PH-MVP-DATA-025**  
Wenn mindestens ein Geldwert vorhanden ist, soll eine Währung angegeben werden können und die UI soll auf eine fehlende Währung verständlich hinweisen.

**PH-MVP-DATA-026**  
Hourly, Daily und Fixed werden getrennt gespeichert und angezeigt.

**PH-MVP-DATA-027**  
Der MVP darf Hourly, Daily und Fixed **nicht stillschweigend ineinander umrechnen**.

**PH-MVP-DATA-028**  
Eine spätere Umrechnung darf nur mit expliziten Annahmen erfolgen; beispielsweise Arbeitsstunden pro Tag, Rabatte oder sonstige Konditionen. Diese Umrechnung ist kein MVP-Bestandteil.

---

## 3.8 Skills

**PH-MVP-DATA-029**  
Der Nutzer muss einer Opportunity beliebig mehrere einfache Skills/Keywords zuordnen können.

**PH-MVP-DATA-030**  
Skills müssen entfernbar sein, ohne die Opportunity zu löschen.

**PH-MVP-DATA-031**  
Skill-Eingabe soll schnell erfolgen können und darf keine umfangreiche Stammdatenpflege erzwingen.

---

# 4. Opportunity-Verwaltung

## 4.1 Opportunity anlegen

**PH-MVP-OPP-001**  
Der Nutzer muss aus dem Hauptfenster heraus eine neue Opportunity anlegen können.

**PH-MVP-OPP-002**  
Der Anlegevorgang muss mindestens Titel, erste Fundstelle, Beschreibung, Zeitinformationen, Ort/Remote, Preis/Rate, Skills, Status und Note zugänglich machen.

**PH-MVP-OPP-003**  
Nicht verfügbare optionale Felder dürfen die Speicherung nicht verhindern.

**PH-MVP-OPP-004**  
Beim erstmaligen Speichern werden Opportunity und erste Fundstelle als zusammengehöriger Vorgang persistiert. Ein Fehler darf nicht zu einer halben, inkonsistenten Neuanlage führen.

---

## 4.2 Opportunity bearbeiten

**PH-MVP-OPP-005**  
Alle im MVP bearbeitbaren Opportunity- und Fundstellenfelder müssen später erneut geöffnet und geändert werden können.

**PH-MVP-OPP-006**  
Änderungen werden erst nach einer bewussten Speicheraktion oder einem gleichwertig eindeutigen Commit übernommen.

**PH-MVP-OPP-007**  
Beim Verlassen mit ungespeicherten Änderungen soll die Anwendung einen unbeabsichtigten Datenverlust verhindern, beispielsweise durch Rückfrage oder ein gleichwertiges sicheres Verhalten.

---

## 4.3 Status ändern

**PH-MVP-OPP-008**  
Der Opportunity-Status muss in der Detailansicht änderbar sein.

**PH-MVP-OPP-009**  
Eine Statusänderung darf Archivierung, Notes, Skills, Fundstellen oder Proposal-Daten nicht verändern.

**PH-MVP-OPP-010**  
Eine separate Statushistorie ist kein MVP-MUSS. Das Datenmodell darf eine spätere History jedoch nicht unnötig erschweren.

---

## 4.4 Archivieren und De-Archivieren

**PH-MVP-OPP-011**  
Der Nutzer muss eine Opportunity archivieren können.

**PH-MVP-OPP-012**  
Archivierte Opportunities werden in der Standard-Arbeitsliste ausgeblendet, sofern der Nutzer nicht ausdrücklich archivierte Datensätze einblendet.

**PH-MVP-OPP-013**  
Der Nutzer muss archivierte Opportunities wieder de-archivieren können.

**PH-MVP-OPP-014**  
Archivieren oder De-Archivieren darf den fachlichen Status nicht verändern.

---

## 4.5 Löschen

Löschen ist für fehlerhaft erfasste Daten vorgesehen.

**PH-MVP-OPP-015**  
Der Nutzer muss eine Opportunity löschen können.

**PH-MVP-OPP-016**  
Vor dem endgültigen Löschen muss eine eindeutige Bestätigung verlangt werden.

**PH-MVP-OPP-017**  
Die Bestätigung soll darauf hinweisen, dass verbundene MVP-Daten wie Fundstelle, Skills, Note und Proposal mit betroffen sein können.

**PH-MVP-OPP-018**  
Das Löschen zusammengehöriger Daten muss atomar bzw. konsistent erfolgen.

---

## 4.6 Fundstellen-URL öffnen

**PH-MVP-OPP-019**  
Ist eine gültige Source URL gespeichert, muss die Anwendung sie über den Standardbrowser des Betriebssystems öffnen können.

**PH-MVP-OPP-020**  
Ist keine URL vorhanden, darf die Funktion nicht abstürzen; sie muss deaktiviert sein oder eine verständliche Meldung anzeigen.

**PH-MVP-OPP-021**  
Das Öffnen der URL ist die einzige normale MVP-Funktion, die zur Nutzung der externen Plattform führen kann. LaunchPad selbst benötigt dafür keinen eigenen Login-Mechanismus.

---

## 4.7 Manuelle erneute Beobachtung

**PH-MVP-OPP-022**  
Der Nutzer darf eine Opportunity auch nach Deadline, `Closed`, `Expired` oder Archivierung erneut öffnen.

**PH-MVP-OPP-023**  
`LastObservedAt` muss nach einer späteren manuellen Prüfung aktualisierbar sein.

Der MVP erstellt daraus noch keine vollständige Observation-Historie.

---

# 5. Notes

## 5.1 Opportunity Note

**PH-MVP-NOTE-001**  
Zu jeder Opportunity muss mindestens ein freies mehrzeiliges Notizfeld verfügbar sein.

**PH-MVP-NOTE-002**  
Das Notizfeld darf leer sein.

**PH-MVP-NOTE-003**  
Änderungen an Notes müssen zuverlässig gespeichert und wieder geladen werden.

**PH-MVP-NOTE-004**  
Notes dürfen den Originalausschreibungstext nicht überschreiben.

**PH-MVP-NOTE-005**  
Mehrere einzelne Notes, Kategorien, Tags und Pinning sind kein MVP-MUSS.

---

# 6. Proposal Lite

## 6.1 Proposal anlegen

Ein Proposal wird nur angelegt, wenn sich der Nutzer tatsächlich beworben bzw. ein Angebot abgegeben hat.

**PH-MVP-PROP-001**  
Der Nutzer muss zu einer Opportunity einen Proposal-Lite-Vorgang erfassen können.

**PH-MVP-PROP-002**  
Das Anlegen eines Proposals darf nicht automatisch den Opportunity-Status auf einen künstlichen Zustand `Applied` setzen, da Opportunity und Proposal getrennte Konzepte sind.

**PH-MVP-PROP-003**  
Die UI darf als Komfort optional anbieten, den Opportunity-Status im selben Arbeitsablauf bewusst anzupassen; dies muss eine eigenständige Nutzerentscheidung bleiben.

---

## 6.2 Proposal-Kerndaten

Der MVP muss mindestens erfassen können:

- SubmittedAt,
- eigener Preis / eigene Rate,
- Währung,
- logische CV-/Profil-/Bewerbungsunterlagen-Version,
- Proposal-Status,
- optionales Outcome,
- kurze Note.

**PH-MVP-PROP-004**  
`SubmittedAt` wird in UTC gespeichert bzw. als UTC eindeutig gekennzeichnet.

**PH-MVP-PROP-005**  
Die CV-/Profilversion ist optionaler Freitext, beispielsweise `CV Linux DevOps 2026-08`.

**PH-MVP-PROP-006**  
Der MVP verwaltet dafür keine CV-Dateien und benötigt kein Attachment-System.

**PH-MVP-PROP-007**  
Eigener Preis bzw. eigene Rate muss von den veröffentlichten Quellwerten getrennt gespeichert werden.

**PH-MVP-PROP-008**  
Auch beim eigenen Proposal dürfen Hourly, Daily und Fixed nicht stillschweigend umgerechnet werden.

---

## 6.3 Proposal-Status

**PH-MVP-PROP-009**  
Der Nutzer muss einen einfachen Proposal-Status pflegen können.

Vorgesehene MVP-Werte:

- Submitted
- AwaitingResponse
- Closed

Die Werte sind bewusst klein gehalten.

---

## 6.4 Outcome

**PH-MVP-PROP-010**  
Outcome ist optional.

**PH-MVP-PROP-011**  
Vorgesehene MVP-Outcomes sind:

- Won
- Rejected
- Withdrawn
- TimedOutByUser
- Unknown

**PH-MVP-PROP-012**  
`Interview`, `Negotiation` und `Offer` dürfen nicht als terminale Outcome-Werte angeboten werden.

**PH-MVP-PROP-013**  
`No Response` darf im MVP nicht automatisch allein aufgrund eines Zeitablaufs als externer Outcome gesetzt werden.

**PH-MVP-PROP-014**  
`TimedOutByUser` muss ausdrücklich vom Nutzer gewählt werden.

---

# 7. Suche, Filter und Wiederfinden

## 7.1 Lokale Suche

Die MVP-Suche arbeitet ausschließlich auf der lokal gespeicherten Datenbasis.

Sie ist **keine externe Plattform-Discovery**.

**PH-MVP-SRCH-001**  
Eine Freitextsuche muss mindestens folgende Bereiche berücksichtigen:

- Opportunity-Titel,
- Originalausschreibung der bekannten Fundstelle,
- User Note,
- Skills,
- Platform.

**PH-MVP-SRCH-002**  
Die Suche soll für typische Begriffe ohne Beachtung der Groß-/Kleinschreibung funktionieren.

**PH-MVP-SRCH-003**  
Eine leere Suche zeigt die nach den übrigen Filtern zulässigen Opportunities.

---

## 7.2 Filter

Mindestens verfügbar sein müssen:

- Platform,
- Opportunity-Status,
- Skill,
- Veröffentlichungszeitraum,
- archiviert / nicht archiviert.

**PH-MVP-SRCH-004**  
Mehrere aktive Filter wirken im MVP standardmäßig gemeinsam als UND-Verknüpfung.

Beispiel:

```text
Platform = Freelancermap
AND Skill = Linux
AND Status = Interesting
```

**PH-MVP-SRCH-005**  
Das Zurücksetzen aller Filter muss mit einer klaren Aktion möglich sein.

**PH-MVP-SRCH-006**  
Filteränderungen dürfen vorhandene Daten nicht verändern.

---

## 7.3 Flexible Zeitfilter

Der MVP filtert lokal auf Basis des bekannten `PublishedAt`.

Vorgesehen sind mindestens:

- frei definierbarer Startzeitpunkt,
- frei definierbarer Endzeitpunkt,
- optional komfortable Presets wie 24 Stunden oder 7 Tage.

**PH-MVP-SRCH-007**  
Die benutzerdefinierte Zeitspanne muss frei einstellbar sein und darf nicht auf ein 24-Stunden-Preset beschränkt werden.

**PH-MVP-SRCH-008**  
MVP-Zeitfilter werden in UTC interpretiert und in der Oberfläche als UTC kenntlich gemacht.

**PH-MVP-SRCH-009**  
Ein Datensatz ohne bekanntes `PublishedAt` wird bei einem ausdrücklich gesetzten Veröffentlichungszeitraum nicht fälschlich als innerhalb des Zeitraums ausgegeben.

**PH-MVP-SRCH-010**  
Ohne Veröffentlichungszeitfilter bleiben Opportunities mit unbekanntem `PublishedAt` normal sichtbar.

Hinweis: `seit letzter erfolgreicher Plattformprüfung` ist als langfristige Discovery-Funktion fachlich vorgesehen, aber nicht Teil der rein lokalen MVP-Suche, solange der MVP noch keine Plattformprüfung durchführt.

---

## 7.4 Skillfilter

**PH-MVP-SRCH-011**  
Der Nutzer muss nach mindestens einem zugeordneten Skill filtern können.

**PH-MVP-SRCH-012**  
Eine komplexe AND/OR-Skill-Ausdruckssprache ist kein MVP-MUSS.

---

## 7.5 Sortierung

Sortierung ist für eine brauchbare Arbeitsliste erforderlich, auch wenn sie nicht als eigenständige Lastenheft-MVP-ID geführt wird.

**PH-MVP-SRCH-013**  
Die Opportunity-Liste soll mindestens nach Titel, Veröffentlichungszeitpunkt, Erfassungszeitpunkt und Status sortierbar sein.

**PH-MVP-SRCH-014**  
Fehlende Werte müssen bei Sortierung stabil und nachvollziehbar behandelt werden; sie dürfen keine Exceptions auslösen.

---

# 8. Manuelle Erfassung und Capture-Grenze

## 8.1 Vollständige Nutzbarkeit ohne Import

**PH-MVP-IMP-001**  
Der komplette MVP-Workflow muss ohne automatisierten Import funktionieren.

Dazu gehören:

- Opportunity anlegen,
- Fundstelleninformationen eintragen,
- Beschreibung einfügen,
- Skills pflegen,
- Preis/Rate eintragen,
- Status setzen,
- Notes pflegen,
- Proposal dokumentieren,
- suchen und filtern,
- archivieren,
- Backup erstellen.

---

## 8.2 Paste als normale Texteingabe

Der Nutzer darf natürlich Ausschreibungstext aus dem Browser kopieren und in das Beschreibungsfeld einfügen.

Dies ist **noch kein strukturierter Paste Capture Import**.

**PH-MVP-IMP-002**  
Mehrzeiliges Einfügen per Zwischenablage muss im Beschreibungstext und in Notes zuverlässig funktionieren.

---

## 8.3 Keine Portalautomation im MVP

**PH-MVP-IMP-003**  
Der MVP fragt keine Freelancer-Plattform automatisiert ab.

**PH-MVP-IMP-004**  
Der MVP benötigt keine Portal-Credentials.

**PH-MVP-IMP-005**  
Das Öffnen der gespeicherten Source URL erfolgt über den normalen Webbrowser und nicht über eine eingebettete Login-Automation.

---

# 9. Backup und lokale Datenhoheit

## 9.1 Lokale Speicherung

**PH-MVP-BACKUP-001**  
Die persönliche LaunchPad-Datenbasis wird im MVP lokal auf dem Rechner des Nutzers gespeichert.

**PH-MVP-BACKUP-002**  
Der MVP benötigt für den normalen lokalen Workflow keinen Cloud-Dienst.

---

## 9.2 Backup erstellen

**PH-MVP-BACKUP-003**  
Die Anwendung muss eine verständliche Benutzerfunktion zum Erstellen eines vollständigen lokalen Backups anbieten.

**PH-MVP-BACKUP-004**  
Der Nutzer muss ein Ziel für das Backup auswählen bzw. erkennen können, wo das Backup gespeichert wurde.

**PH-MVP-BACKUP-005**  
Das Backup muss die vollständige für den MVP notwendige lokale Wissensbasis enthalten.

**PH-MVP-BACKUP-006**  
Das Backup muss aus einem konsistenten Datenzustand erzeugt werden und darf keine absichtlich halbfertigen Transaktionen enthalten.

**PH-MVP-BACKUP-007**  
Nach erfolgreichem Backup muss eine eindeutige Erfolgsmeldung mit Zielpfad angezeigt werden.

**PH-MVP-BACKUP-008**  
Bei Fehlschlag muss eine verständliche Fehlermeldung erscheinen; ein unvollständiges Backup darf nicht als erfolgreich gemeldet werden.

---

## 9.3 Bewusste MVP-Grenze

Nicht Bestandteil des MVP sind:

- automatische Backup-Rotation,
- Cloud Backup,
- Enterprise Backup Policies,
- eingebaute Verschlüsselung von USB-Sticks,
- automatische Backup-Retention,
- vollständiges Restore-Center.

Die sichere Aufbewahrung kopierter Backup-Medien bleibt in der lokalen Desktop-Version Aufgabe des Nutzers.

---

# 10. Benutzeroberfläche

## 10.1 Grundstruktur

Die MVP-Oberfläche soll die tägliche Arbeit ohne unnötige Navigation ermöglichen.

Mindestens erforderlich sind:

- Hauptfenster mit Opportunity-Liste,
- Such-/Filterbereich,
- Möglichkeit zum Anlegen,
- Opportunity-Detailansicht oder Editor,
- klarer Zugriff auf Archivierung und Löschung,
- Proposal-Lite-Bereich,
- Backup-Befehl.

Die konkrete visuelle Gestaltung gehört nicht als Pixel-Spezifikation in dieses Pflichtenheft.

---

## 10.2 Opportunity-Liste

Die Liste soll den Nutzer bei der Entscheidung unterstützen, welchen Datensatz er öffnen möchte.

Mindestens sichtbar bzw. leicht zugänglich sollen sein:

- Opportunity-Status,
- Archivkennzeichen bzw. Archivfilter,
- Platform,
- Titel,
- PublishedAt, soweit bekannt,
- ein kompakter Preis-/Rate-Hinweis, soweit vorhanden.

Skills und weitere Angaben dürfen in Detailansicht, Tooltip oder zusätzlicher Spalte erscheinen, wenn dies die 1280×720-Nutzbarkeit verbessert.

**PH-MVP-UI-001**  
Die Listenansicht darf wichtige Aktionen nicht hinter horizontalem Scrollen verstecken.

**PH-MVP-UI-002**  
Ein Doppelklick oder eine gleichwertig direkte Aktion soll eine Opportunity öffnen können.

---

## 10.3 Opportunity-Detailansicht

Die Detailansicht muss die MVP-Felder logisch gruppieren.

Empfohlene fachliche Gruppen:

1. Opportunity / Status
2. Fundstelle
3. Ausschreibung
4. Ort / Remote / Zeit
5. Preis / Rate
6. Skills
7. Note
8. Proposal Lite

Die genaue Control- und Tab-Struktur wird im UI-/Technical Design festgelegt.

**PH-MVP-UI-003**  
Originalausschreibung und User Note müssen optisch eindeutig getrennt sein.

**PH-MVP-UI-004**  
Opportunity-Status und Archivierung müssen als getrennte Bedienelemente erkennbar sein.

**PH-MVP-UI-005**  
Veröffentlichte Rate/Budget und eigene Proposal-Rate dürfen nicht so dargestellt werden, dass sie verwechselt werden können.

---

## 10.4 1280 × 720

**PH-MVP-UI-006**  
Alle Kernfunktionen müssen bei einer Bildschirmauflösung von 1280 × 720 Pixeln bei üblicher Windows-Skalierung erreichbar bleiben.

**PH-MVP-UI-007**  
Dialoge dürfen nicht so groß sein, dass Bestätigen/Abbrechen oder zentrale Eingabefelder außerhalb der nutzbaren Bildschirmfläche liegen.

**PH-MVP-UI-008**  
Vertikales Scrollen in einer umfangreichen Detailansicht ist zulässig. Zentrale Hauptaktionen müssen trotzdem zuverlässig erreichbar bleiben.

---

## 10.5 Bediengeschwindigkeit

**PH-MVP-UI-009**  
Opportunity anlegen, Status ändern, Note ergänzen, Source URL öffnen und Proposal dokumentieren müssen ohne unnötige mehrstufige Assistenten möglich sein.

**PH-MVP-UI-010**  
Die Oberfläche soll mit sinnvollen Defaults arbeiten, ohne optionale Felder zur Pflicht zu machen.

---

# 11. Persistenz, Datenintegrität und Migration

## 11.1 Persistenzgrundsatz

Die konkrete Tabellenstruktur wird im Database Design festgelegt.

Aus fachlicher Sicht müssen jedoch mindestens folgende Zusammenhänge sauber persistierbar sein:

```text
Opportunity
  ├── mindestens eine Fundstelle
  ├── Skills
  ├── Opportunity Note
  └── optional Proposal Lite
```

Archivierung und Opportunity-Status sind getrennte Informationen.

---

## 11.2 Atomare Änderungen

**PH-MVP-PERS-001**  
Zusammengehörige Änderungen müssen so persistiert werden, dass bei einem Fehler kein widersprüchlicher Teilzustand zurückbleibt.

Beispiele:

- Opportunity + erste Fundstelle bei Neuanlage,
- Löschen Opportunity + abhängige MVP-Daten,
- Proposal-Kerndaten.

---

## 11.3 Keine stillen Datenverluste

**PH-MVP-PERS-002**  
Ein erfolgreich gemeldeter Speichervorgang muss nach Neustart der Anwendung wieder vollständig lesbar sein.

**PH-MVP-PERS-003**  
Textfelder dürfen beim Speichern nicht stillschweigend abgeschnitten werden.

**PH-MVP-PERS-004**  
Optional unbekannte Werte dürfen beim erneuten Laden nicht in erfundene Default-Fachdaten umgewandelt werden.

---

## 11.4 Schema-Versionierung

Die vollständige langfristige Migrationsstrategie ist `PRODUKT-MUSS`, aber bereits der MVP soll keine Sackgasse erzeugen.

**PH-MVP-PERS-005**  
Die lokale Datenbasis muss eine erkennbare Schema-/Datenbankversion unterstützen oder technisch so vorbereitet sein, dass kontrollierte Migrationen eingeführt werden können.

**PH-MVP-PERS-006**  
Nach Beginn realer produktiver Nutzung darf ein reguläres Update nicht davon ausgehen, dass der Nutzer seine gesamte Datenbank löschen und neu anlegen kann.

---

## 11.5 Übergang vom frühen Project-Prototyp

**PH-MVP-PERS-007**  
Bestehende frühe Codebegriffe wie `FreelanceProject`, `projects` oder statusartige `Applied`-/`Archived`-Modelle müssen vor weiterer fachlicher Expansion gegen die Opportunity-Baseline geprüft und bei Bedarf refaktoriert werden.

**PH-MVP-PERS-008**  
Der Altcode darf nicht dazu führen, dass Proposal oder Archivierung wieder in den Opportunity-Status eingebaut werden.

---

# 12. Offline-Verhalten und externe Abhängigkeiten

## 12.1 Offline nutzbare MVP-Funktionen

Folgende MVP-Funktionen müssen ohne Netzwerk funktionieren:

- Anwendung starten,
- vorhandene Opportunities anzeigen,
- Opportunity anlegen und bearbeiten,
- Suche,
- lokale Filter,
- Skills pflegen,
- Notes pflegen,
- Proposal Lite pflegen,
- archivieren / de-archivieren,
- Backup erstellen.

**PH-MVP-OFF-001**  
Ein fehlender Internetzugang darf diese Funktionen nicht blockieren.

---

## 12.2 Source URL

Das Öffnen einer externen URL darf natürlich fehlschlagen, wenn kein Netzwerk verfügbar ist.

**PH-MVP-OFF-002**  
Ein solcher externer Fehler darf keine lokalen Daten beschädigen.

---

## 12.3 Interpretation von `LH-NF-008`

Das Lastenheft nennt in `LH-NF-008` auch lokale Analytics als Beispiel für grundsätzlich offline-fähige Funktionen.

Da Analytics ausdrücklich **nicht Bestandteil des MVP-Scope** sind, führt dieses Pflichtenheft dadurch keine Analytics-Funktion ein.

Die Regel lautet:

> **Jede lokale Funktion, die in einem späteren Release tatsächlich vorhanden ist und keine aktuellen externen Daten benötigt, soll auch dann offline arbeiten.**

---

# 13. Fehlerbehandlung und Stabilität

## 13.1 Validierungsfehler

**PH-MVP-ERR-001**  
Ungültige Benutzereingaben müssen verständlich erklärt werden.

Beispiele:

- Titel fehlt,
- Remote-Prozent außerhalb 0–100,
- Minimum größer als Maximum,
- ungültige URL,
- negative Rate.

**PH-MVP-ERR-002**  
Ein Validierungsfehler darf keine bereits gespeicherten Daten beschädigen.

---

## 13.2 Persistenzfehler

**PH-MVP-ERR-003**  
Kann eine Änderung nicht gespeichert werden, darf die Anwendung nicht so tun, als sei sie erfolgreich persistiert worden.

**PH-MVP-ERR-004**  
Der Nutzer muss eine verständliche Meldung erhalten und soweit möglich seine Eingaben weiter sehen, damit er sie korrigieren oder erneut speichern kann.

---

## 13.3 Einzelne fehlerhafte Datensätze

**PH-MVP-ERR-005**  
Ein einzelner fehlerhafter oder unerwarteter Datensatz darf die gesamte Opportunity-Liste nicht unnötig unbenutzbar machen.

---

## 13.4 Backupfehler

**PH-MVP-ERR-006**  
Fehlender Schreibzugriff, voller Datenträger oder ungültiges Backup-Ziel müssen als fehlgeschlagen gemeldet werden.

---

## 13.5 Technische Details

Technische Fehlerdetails können in Logs geschrieben werden.

Benutzertexte sollen dagegen handlungsorientiert bleiben.

Beispiel:

> „Das Backup konnte nicht erstellt werden. Der Zielordner ist nicht beschreibbar.“

statt nur:

```text
IOException 0x80070005
```

---

# 14. Performance und Ressourcen

## 14.1 Interaktive Nutzung

**PH-MVP-PERF-001**  
Öffnen der lokalen Opportunity-Liste, Suche und Filterung dürfen bei einer für einen Einzelanwender typischen Datenmenge nicht regelmäßig zu mehrsekündigen UI-Blockaden führen.

**PH-MVP-PERF-002**  
Die Oberfläche muss während normaler lokaler Datenpflege responsiv bleiben.

Die exakten Benchmark-Datenmengen und Messgrenzen werden mit einem repräsentativen Testbestand im Testplan festgelegt, statt im Pflichtenheft willkürlich vorweggenommen zu werden.

---

## 14.2 Hintergrundaktivität

**PH-MVP-PERF-003**  
Da der MVP keine automatische Discovery besitzt, darf er im normalen Leerlauf keine dauerhafte externe Netzwerkabfrage erzeugen.

**PH-MVP-PERF-004**  
Der MVP soll keine unnötige permanente CPU-Last verursachen.

---

# 15. Test- und Abnahmekonzept

## 15.1 Grundsatz

Der MVP wird nicht allein dadurch abgenommen, dass er kompiliert.

Abnahme bedeutet:

1. fachlicher Workflow funktioniert,
2. Daten bleiben erhalten,
3. zentrale Fehlerfälle sind beherrscht,
4. Lastenheft-MVP-Anforderungen sind nachvollziehbar erfüllt.

---

## 15.2 Automatisierte Tests

Automatisierte Tests sollen mindestens die fachlich kritische, UI-unabhängige Logik abdecken, soweit diese im jeweiligen Entwicklungsstand vorhanden ist.

Mindestens zu prüfen:

- Validierung von Preisbereichen,
- Validierung Remote-Prozent,
- Status vs. Archivierung,
- Proposal-Status vs. Outcome,
- Suche/Filterlogik,
- Speichern/Laden,
- Löschkonsistenz,
- Backup-Konsistenz soweit testbar,
- UTC-Zeitbehandlung,
- Skill-Zuordnung.

---

## 15.3 Manuelle Abnahmeszenarien

### AT-001 – Opportunity manuell anlegen

**Vorbedingung:** Anwendung läuft, lokale Datenbasis verfügbar.  
**Aktion:** Neue Opportunity mit Titel und Platform anlegen.  
**Erwartung:** Speichern erfolgreich; Opportunity erscheint in Liste und ist nach Neustart vorhanden.

### AT-002 – Vollständigen Ausschreibungstext sichern

**Aktion:** Mehrseitigen/mehzeiligen Ausschreibungstext einfügen und speichern.  
**Erwartung:** Text ist nach Neustart vollständig und unverändert vorhanden.

### AT-003 – Fundstelleninformationen

**Aktion:** Platform, External ID, URL und PublishedAt pflegen.  
**Erwartung:** Werte sind nach Neustart erhalten; URL ist aufrufbar.

### AT-004 – Unvollständige Opportunity

**Aktion:** Opportunity ohne Rate, ohne External ID und ohne PublishedAt speichern.  
**Erwartung:** Speicherung ist möglich; fehlende Werte bleiben unbekannt und werden nicht erfunden.

### AT-005 – Zeitinformationen UTC

**Aktion:** PublishedAt und Deadline mit UTC-Werten erfassen.  
**Erwartung:** UI kennzeichnet die Zeitbasis; Werte bleiben nach Neustart korrekt.

### AT-006 – LastObservedAt nach Ablauf

**Vorbedingung:** Opportunity ist `Expired`.  
**Aktion:** Datensatz erneut prüfen und LastObservedAt aktualisieren.  
**Erwartung:** Aktualisierung ist möglich, ohne Status automatisch zu verändern.

### AT-007 – Remote-Wert validieren

**Aktion:** Remote-Anteil 120 % eingeben.  
**Erwartung:** verständliche Validierung; Speichern dieses ungültigen Werts wird verhindert.

### AT-008 – Preisbereiche validieren

**Aktion:** Hourly Min = 100, Hourly Max = 80.  
**Erwartung:** verständliche Validierung.

### AT-009 – Keine Rate-Umrechnung

**Aktion:** Daily Rate 800 EUR speichern.  
**Erwartung:** Anwendung erzeugt daraus nicht automatisch 100 EUR/h oder einen anderen Hourly-Wert.

### AT-010 – Skills

**Aktion:** Linux, Debian und Ansible hinzufügen.  
**Erwartung:** Skills werden gespeichert, angezeigt, gefiltert und sind suchbar.

### AT-011 – Note getrennt von Originaltext

**Aktion:** Originalbeschreibung und User Note pflegen.  
**Erwartung:** Änderung der Note verändert die Originalbeschreibung nicht.

### AT-012 – Opportunity-Status

**Aktion:** `New → Interesting → Watching`.  
**Erwartung:** Status ändert sich; andere Daten bleiben erhalten.

### AT-013 – Archivierung separat

**Vorbedingung:** Status `Dismissed`.  
**Aktion:** archivieren und später de-archivieren.  
**Erwartung:** Status bleibt `Dismissed`.

### AT-014 – Archivfilter

**Aktion:** Opportunity archivieren.  
**Erwartung:** Standardliste blendet sie aus; mit Archivfilter ist sie wieder auffindbar.

### AT-015 – Löschen

**Aktion:** Opportunity mit Skills, Note und Proposal löschen.  
**Erwartung:** Bestätigung erforderlich; danach keine inkonsistenten abhängigen MVP-Daten zurücklassen.

### AT-016 – Freitextsuche Titel

**Aktion:** nach Teil eines Titels suchen.  
**Erwartung:** Opportunity wird gefunden.

### AT-017 – Freitextsuche Beschreibung

**Aktion:** nach einem Begriff suchen, der nur im Ausschreibungstext vorkommt.  
**Erwartung:** Opportunity wird gefunden.

### AT-018 – Freitextsuche Note

**Aktion:** nach einem Begriff suchen, der nur in der User Note vorkommt.  
**Erwartung:** Opportunity wird gefunden.

### AT-019 – Filterkombination

**Aktion:** Platform + Skill + Status kombinieren.  
**Erwartung:** nur Datensätze, die alle aktiven Filter erfüllen, werden angezeigt.

### AT-020 – Freier Zeitraum

**Aktion:** benutzerdefinierten Start-/Endzeitpunkt setzen.  
**Erwartung:** PublishedAt wird lokal korrekt gefiltert; Filter ist nicht auf 24 Stunden begrenzt.

### AT-021 – Unbekanntes PublishedAt

**Aktion:** Zeitraumfilter aktivieren.  
**Erwartung:** Opportunity ohne PublishedAt wird nicht fälschlich als Treffer innerhalb des Zeitraums ausgegeben.

### AT-022 – Proposal Lite

**Aktion:** SubmittedAt, eigene Hourly Rate, EUR, `CV Linux DevOps 2026-08`, Status und Note speichern.  
**Erwartung:** Daten bleiben nach Neustart erhalten und sind klar von ausgeschriebener Rate getrennt.

### AT-023 – TimedOutByUser

**Aktion:** Proposal auf `Closed` und Outcome `TimedOutByUser` setzen.  
**Erwartung:** System behauptet keine externe Absage und setzt nicht automatisch `Rejected`.

### AT-024 – Offlinebetrieb

**Vorbedingung:** Netzwerk getrennt.  
**Aktion:** Anwendung starten, Opportunity öffnen, suchen, ändern, Proposal pflegen, Backup erstellen.  
**Erwartung:** alle lokalen MVP-Funktionen arbeiten weiter.

### AT-025 – URL ohne Netzwerk

**Vorbedingung:** Netzwerk getrennt.  
**Aktion:** Source URL öffnen.  
**Erwartung:** Browser-/Netzwerkfehler beschädigt keine LaunchPad-Daten und beendet LaunchPad nicht.

### AT-026 – Backup

**Aktion:** Backup an beschreibbaren Zielort erstellen.  
**Erwartung:** Erfolgsmeldung mit Ziel; Backup enthält vollständige MVP-Datenbasis.

### AT-027 – Backupfehler

**Aktion:** Backup auf nicht beschreibbaren Zielort versuchen.  
**Erwartung:** klare Fehlermeldung; kein falscher Erfolg.

### AT-028 – Neustart/Persistenz

**Aktion:** mehrere Opportunities mit unterschiedlichen Feldern speichern, Anwendung schließen und neu starten.  
**Erwartung:** alle erfolgreich gespeicherten Daten bleiben korrekt erhalten.

### AT-029 – 1280 × 720

**Aktion:** Anwendung auf 1280 × 720 bei üblicher Skalierung nutzen.  
**Erwartung:** Liste, Suche, Anlegen, Editieren, Speichern, Archivieren, Proposal und Backup bleiben erreichbar.

### AT-030 – Ungültige Eingabe darf Anwendung nicht beenden

**Aktion:** mehrere Validierungsfehler provozieren.  
**Erwartung:** verständliche Hinweise; Anwendung bleibt nutzbar.

---

# 16. Traceability zum Lastenheft

Die folgende Matrix stellt sicher, dass jede aktuelle `MVP-MUSS`-Anforderung des Lastenhefts in diesem Pflichtenheft konkret behandelt wird.

| Lastenheft-ID | Inhalt | Umsetzung im Pflichtenheft |
|---|---|---|
| `LH-F-OPP-001` | manuelle Opportunity-Erfassung | 4.1, 8.1, AT-001 |
| `LH-F-OPP-003` | Fundstelle: Platform, External ID, URL, Capture Method, CapturedAt | 2.2–2.4, 3.3, AT-003 |
| `LH-F-OPP-005` | vollständige Ausschreibung lokal sichern | 3.4, AT-002 |
| `LH-F-OPP-007` | Zeitinformationen inkl. LastObservedAt | 3.5, 4.7, AT-005/006 |
| `LH-F-OPP-008` | Ort/Remote/Reise strukturiert | 3.6, AT-007 |
| `LH-F-OPP-010` | getrennte Budget-/Rate-Dimensionen | 3.7, AT-008/009 |
| `LH-F-OPP-011` | Skills/Keywords | 2.10, 3.8, AT-010 |
| `LH-F-OPP-013` | Opportunity-Status getrennt von Archiv/Proposal | 2.5, 4.3, AT-012 |
| `LH-F-OPP-016` | Archivierung separat | 2.6, 4.4, AT-013/014 |
| `LH-F-OPP-017` | Löschen | 4.5, AT-015 |
| `LH-F-OPP-018` | Source URL öffnen | 4.6, AT-003/025 |
| `LH-F-SRCH-001` | lokale Volltextsuche | 7.1, AT-016–018 |
| `LH-F-SRCH-002` | flexible Zeitfilter | 7.3, AT-020/021 |
| `LH-F-PROP-002` | Proposal Lite | 6, AT-022/023 |
| `LH-F-NOTE-001` | freie Opportunity-Notes | 5.1, AT-011 |
| `LH-F-NOTE-005` | Notes durchsuchbar | 7.1, AT-018 |
| `LH-F-SKILL-001` | Skills für Suche/Filter | 2.10, 3.8, 7.4, AT-010 |
| `LH-F-IMP-002` | MVP vollständig ohne automatisierten Import | 8.1–8.3 |
| `LH-F-EXP-002` | vollständiges lokales Backup | 9.2, AT-026/027 |
| `LH-DP-002` | lokale Wissensbasis | 9.1, 12.1 |
| `LH-NF-001` | wenige Schritte für häufige Aktionen | 1.2, 10.5 |
| `LH-NF-002` | responsive lokale Suche/Listen/Filter | 14.1 |
| `LH-NF-003` | Stabilität bei Fehlern | 13, AT-030 |
| `LH-NF-005` | Datenintegrität | 11.2–11.3, AT-028 |
| `LH-NF-008` | lokale Funktionen offline | 12, AT-024 |
| `LH-NF-013` | verständliche Fehlermeldungen | 13, AT-027/030 |
| `LH-NF-014` | 1280 × 720 | 10.4, AT-029 |

---

# 17. Explizit zurückgestellte Produktanforderungen

Dieses Kapitel dient nur der Scope-Sicherung. Es übernimmt die zurückgestellten Anforderungen **nicht** in den MVP.

## 17.1 Mehrere Fundstellen

Das Datenmodell soll nicht unnötig blockieren, dass eine Opportunity später mehrere Fundstellen erhält.

Der komfortable Workflow zum Erkennen, Vergleichen und Zuordnen mehrerer Listings ist jedoch nicht Bestandteil der MVP-Abnahme.

---

## 17.2 Duplikaterkennung

Technische Duplikaterkennung über Platform + External ID oder identische URL ist langfristig wichtig, aber nicht Teil der aktuellen `MVP-MUSS`-Menge.

Sie wird deshalb in diesem Pflichtenheft nicht als Abnahmevoraussetzung behandelt.

---

## 17.3 Dismiss Reason und Bewertung

Dismiss Reason und persönliche Bewertungsdimensionen sind sinnvoll, aber nicht `MVP-MUSS`.

Die Opportunity darf im MVP einfach auf `Dismissed` gesetzt und über die freie Note erläutert werden.

---

## 17.4 Automatisierte Discovery

Search Profiles, Plattformabfragen, last-successful-check Watermarks und zuverlässiger Plattformstatus sind langfristig zentral.

Der MVP führt jedoch keine externe Plattformprüfung aus.

Dadurch gibt es im MVP auch noch keinen künstlichen `LastSuccessfulPlatformCheck`-Wert.

---

## 17.5 Observation History

`LastObservedAt` ist im MVP ein einfacher aktueller Zeitwert.

Eine vollständige Folge historischer Observations ist noch nicht erforderlich.

---

## 17.6 Company, Contact und Activity

Diese Objekte bleiben aus dem MVP heraus.

Der MVP soll deshalb keine halbfertigen CRM-Tabellen oder UI-Masken auf Vorrat einführen.

---

## 17.7 Analytics

Der MVP sammelt Daten, die spätere Analytics ermöglichen.

Er implementiert noch keine Rate-, Funnel-, Skill-, Relationship- oder Profile-Intelligence.

---

# 18. Qualitäts- und Entwicklungsleitlinien

## 18.1 Verständlicher Code

Der technische Code soll nachvollziehbar bleiben.

Dazu gehören entsprechend der übergeordneten Produktanforderungen:

- sprechende Namen,
- XML-Dokumentation für öffentliche APIs,
- Inline-Kommentare bei nicht offensichtlicher Logik,
- keine unnötig clevere Abkürzung,
- kleine nachvollziehbare Verantwortlichkeiten.

Die konkrete Architektur wird außerhalb dieses Pflichtenhefts beschrieben.

---

## 18.2 Kein Overengineering

Der MVP soll keine komplexen Systeme implementieren, nur weil sie langfristig denkbar sind.

Beispiele, die **nicht auf Vorrat** gebaut werden sollen:

- generisches Plugin Framework,
- AI-Abstraktionsschicht ohne AI-Use-Case,
- umfangreiche Contact-/CRM-Struktur,
- vollwertiges Event-Sourcing,
- feldweise Provenance-Historie,
- Enterprise Backup Engine,
- universelle Rules Engine für Filter.

---

## 18.3 Keine Sackgassen

Gleichzeitig dürfen frühe Vereinfachungen fachlich bekannte Trennungen nicht wieder zerstören.

Dazu gehören insbesondere:

```text
Opportunity ≠ Fundstelle
Opportunity ≠ Proposal
Status ≠ Archivierung
Originalausschreibung ≠ User Note
Published Rate ≠ Own Proposal Rate
Hourly ≠ Daily ≠ Fixed
```

Diese Trennungen sind bereits bekannt und sollen deshalb im MVP respektiert werden.

---

# 19. Abnahmekriterien für die MVP-Baseline

Die MVP-Baseline gilt fachlich als erfüllt, wenn alle folgenden Bedingungen gleichzeitig erfüllt sind:

1. alle 27 `MVP-MUSS`-Requirements des Lastenhefts sind in der Traceability-Matrix abgedeckt,
2. die manuellen Abnahmeszenarien des implementierten Umfangs sind erfolgreich,
3. Opportunity und Fundstelle sind nicht wieder zu einem untrennbaren `Project`-Datensatz verschmolzen,
4. Archivierung und Opportunity-Status sind getrennt,
5. Proposal ist ein eigener fachlicher Vorgang,
6. vollständige Ausschreibung und User Note sind getrennt,
7. published Rate/Budget und Own Proposal Rate sind getrennt,
8. Hourly, Daily und Fixed werden nicht stillschweigend umgerechnet,
9. die lokale Suche findet Titel, Beschreibung, Notes, Skills und Platform,
10. flexible lokale Zeitfilter arbeiten auf der vereinbarten UTC-Basis,
11. die Kernfunktionen sind auf 1280 × 720 erreichbar,
12. lokale MVP-Funktionen arbeiten ohne Internet,
13. ein vollständiges lokales Backup kann erfolgreich erstellt werden,
14. ein Neustart verliert keine erfolgreich gespeicherten Daten,
15. ungültige Eingaben und einzelne Fehler beenden die Anwendung nicht unnötig.

---

# 20. Leitgedanke dieses Pflichtenhefts

> **Der MVP soll klein bleiben, aber fachlich richtig geschnitten sein.**

Er soll heute bereits nützlich sein und morgen erweiterbar bleiben.

Nicht benötigt wird eine vorweggenommene Komplettlösung.

Benötigt wird ein belastbarer Kern, auf dem später Discovery, Capture Automation, Observation, Relationship History und Intelligence aufbauen können, ohne dass die frühen Grunddaten erneut grundsätzlich umgedeutet werden müssen.
