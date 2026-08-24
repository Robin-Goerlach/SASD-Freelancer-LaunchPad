# SASD Freelancer LaunchPad – Lastenheft

**Version:** 0.2  
**Status:** Baseline-Kandidat nach Konsistenzprüfung  
**Projekt:** SASD Freelancer LaunchPad  
**Organisation:** SASD GmbH  
**Dokumenttyp:** Lastenheft  
**Sprache:** Deutsch  
**Stand:** 24.08.2026

---

# 0. Dokumentkontrolle

## 0.1 Zweck dieser Fassung

Dieses Dokument ist die konsolidierte Fassung des Lastenhefts Version 0.2. Es ersetzt den vorherigen Arbeitsentwurf der Version 0.2 und integriert die im gemeinsamen Review getroffenen fachlichen Entscheidungen.

Die Überarbeitung verfolgt ausdrücklich zwei Ziele:

1. die **langfristige Produktvision vollständig und belastbar** zu beschreiben, und
2. gleichzeitig den **ersten praktisch nutzbaren Produktstand bewusst klein** zu halten.

Das Lastenheft beschreibt, **was SASD Freelancer LaunchPad leisten soll und warum**. Konkrete Klassen, Datenbanktabellen, Framework-Entscheidungen, Parserbibliotheken und Release-Termine gehören in nachgelagerte Dokumente.

Der zentrale Entwicklungsgrundsatz bleibt:

> **Schneller praktischer Nutzen hat Vorrang vor Vollständigkeit und Perfektion.**

Dies bedeutet ausdrücklich nicht, dass spätere Kernfunktionen entfallen. Es bedeutet:

> **Groß genug denken, klein genug liefern.**

## 0.2 Wesentliche Änderungen gegenüber Version 0.1

Die wichtigsten Änderungen dieser Fassung sind:

- `Opportunity` bezeichnet das reale potentielle Projekt bzw. die Auftragschance; die konkrete Veröffentlichung auf einem Portal wird davon als Fundstelle/Listing getrennt.
- Discovery wird als eigener Produktbereich verstanden und nicht nur als lokale Suche.
- PeoplePerHour, Freelancermap und GULP/Randstad Professional werden als initial besonders relevante Quellen betrachtet; weitere Quellen müssen ergänzbar sein.
- unterschiedliche Plattformen werden in ein gemeinsames LaunchPad-Fachmodell überführt; die konkrete technische Integrationsarchitektur wird im Architecture-Dokument festgelegt.
- der Fundort einer Opportunity bleibt sichtbar; mehrere Fundorte derselben realen Opportunity sollen später erhalten bleiben können.
- Search Profiles werden als langfristiger Produktkern aufgenommen.
- Filter sollen frei kombinierbar sein; Presets wie „letzte 24 Stunden“ dienen nur dem Komfort.
- halbautomatische bzw. automatische Übernahme vorhandener Plattformdaten wird als frühes Produktziel aufgenommen.
- Proposal wird als eigenes fachliches Objekt vorgesehen, im frühen Produktstand jedoch bewusst schlank gehalten.
- Observation wird als Grundlage historischer Marktbeobachtung aufgenommen.
- Company, Contact und Activity werden als spätere Kernobjekte berücksichtigt.
- Vermittler, Endkunde und Plattform werden fachlich getrennt.
- Source Provenance wird zum Produktprinzip.
- `History instead of overwrite` wird auf entscheidungs- und analyserelevante Änderungen präzisiert.
- Skill-, Rate-, Funnel-, Relationship- und Profile-Intelligence werden langfristig berücksichtigt, aber nicht zum MVP-Blocker.
- Datenschutz wird um Retention, Anonymisierung und abgestufte Aufbewahrung erweitert.
- Export, Backup und Datenportabilität werden als Teil der Datenhoheit geschärft.
- AI wird als optionale Hilfsfunktion verstanden, nicht als Produktfundament.
- Scope-Grenzen werden deutlicher definiert.

## 0.3 Referenzdokumente

Dieses Lastenheft steht insbesondere im Zusammenhang mit:

- `020_Pflichtenheft_MVP.md`
- `030_Technical_Design.md`
- `040_Database_Design.md`
- `045_Competitive_Product_Feature_Inventory.md`

Für die weitere Produktentwicklung sind zusätzlich vorgesehen:

- `050_Architecture.md`
- `060_Product_Roadmap.md`
- ADRs / Architecture Decision Records
- `080_Data_Protection.md`

Die geplanten Dokumente dienen der sauberen Trennung von Produktanforderung, Architektur, technischer Umsetzung, Roadmap und Datenschutzkonkretisierung.

---

# 1. Einleitung

## 1.1 Ausgangslage

Technische Freelancer und selbstständige IT-Spezialisten suchen regelmäßig nach projektbezogenen Aufträgen. Im frühen LaunchPad-Fokus geschieht dies vor allem über Freelancer-Portale wie PeoplePerHour, Freelancermap und GULP/Randstad Professional. Vermittler oder Recruiter treten dabei häufig innerhalb dieser Plattformen bzw. ihrer plattformeigenen Kommunikationswege auf. Weitere nicht-portalbasierte Quellen können später ergänzt werden.

Relevante Informationen sind dabei häufig auf viele Orte verteilt:

- Suchergebnisse auf Portalen
- Browser-Tabs und Links
- vollständige Ausschreibungstexte
- Budgets, Stunden- und Tagessätze
- Skills
- Starttermine und Laufzeiten
- Remote-Anteile und Einsatzorte
- Vermittler und Endkunden
- eigene Angebote und Bewerbungen
- verwendete CV-Versionen
- Gesprächsnotizen und Rückmeldungen
- spätere Zuschlagsinformationen
- Marktbeobachtungen
- persönliche Einschätzungen

Diese Informationen sind nicht nur verstreut, sondern häufig vergänglich. Projektseiten können geändert, geschlossen, gelöscht oder später nicht mehr öffentlich verfügbar sein. Auch sichtbare Marktsignale können verschwinden.

Dazu gehören beispielsweise:

- Budgetinformationen
- Rate-Angaben
- Projektstatus
- sichtbare Anzahl von Bewerbungen
- öffentliche Zuschlagsinformationen
- Plattformhinweise

LaunchPad soll Informationen deshalb nicht nur verwalten, sondern frühzeitig **sichern, strukturieren und später wieder nutzbar machen**.

Auch bewusst verworfene Opportunities können langfristig Erkenntniswert besitzen. Die Information, warum ein Projekt nicht weiterverfolgt wurde, kann später helfen, Search Profiles, Rate-Grenzen oder persönliche Auswahlkriterien zu verbessern.

## 1.2 Problemstellung

Ein Freelancer muss fortlaufend Entscheidungen treffen:

- Welche neuen Opportunities gibt es?
- Welche davon sind wirklich relevant?
- Welche sind neuer als ein bestimmter Zeitpunkt?
- Welche passen zu meinen Skills?
- Welche sind ausreichend remote?
- Ist das Budget oder die Rate interessant?
- Sollte ich mich bewerben?
- Wie schnell sollte ich reagieren?
- Mit welchem Preis oder Satz habe ich mich beworben?
- Welchen CV habe ich verwendet?
- Warum habe ich eine Opportunity bewusst verworfen?
- Habe ich mit diesem Vermittler schon einmal gearbeitet?
- Ist mir dieser Endkunde bereits begegnet?
- Was wurde aus einer früheren Opportunity?
- Welche Skills tauchen zunehmend auf?
- Welche Plattform liefert mir bessere Chancen?
- Welche Vermittler liefern häufig passende oder unpassende Projekte?
- Welche Preisbereiche führen bei mir häufiger zu Gesprächen?
- Wie lange vergehen typischerweise zwischen Discovery und Proposal?
- Welche Profileinstellungen oder Skills scheinen meine Sichtbarkeit zu verbessern?

Diese Entscheidungen sind ohne strukturierte Historie schwer nachvollziehbar.

LaunchPad soll deshalb nicht nur Daten sammeln, sondern die Voraussetzungen schaffen, aus **realen Opportunities und realen Outcomes** zu lernen.

## 1.3 Discovery ist mehr als Projektsuche

Discovery umfasst langfristig mehr als die Eingabe eines Suchbegriffs.

Ein typischer heutiger Ablauf kann beispielsweise sein:

```text
Suchbegriff: Linux
Zeitraum: neuer als 24 Stunden
```

Morgen kann ein anderer Zeitraum nötig sein:

```text
Suchbegriff: Linux
Zeitraum: seit Samstag 14:00 Uhr
Remote: mindestens 80 %
Rate: mindestens 70 €/h oder unbekannt
```

LaunchPad darf deshalb nicht auf starre Suchvorgaben festgelegt werden.

Discovery umfasst langfristig:

- freie Suchkriterien
- Search Profiles
- Zeitfilter
- Plattformauswahl
- Skillfilter
- Rate-/Budgetfilter
- Remote-Filter
- Ausschlusskriterien
- neue Ergebnisse seit letzter Prüfung
- wiederkehrende Quellen
- Hinweise auf bereits bekannte Opportunities
- spätere Trend- und Marktbeobachtung

---

# 2. Produktvision

## 2.1 Produktdefinition

**SASD Freelancer LaunchPad ist eine local-first Windows-Anwendung zum Entdecken, Erfassen, Bewerten, Verfolgen und Analysieren von Freelancer-Chancen, Angeboten und Bewerbungen, Marktinformationen und professionellen Beziehungen über mehrere Quellen hinweg.**

Die Anwendung soll zunächst für technische Freelancer besonders nützlich sein. Das fachliche Modell soll jedoch nicht so eng gestaltet werden, dass spätere projektorientierte Freelancer-Gruppen einen grundlegenden Architekturwechsel erfordern.

## 2.2 Produktkreislauf

Der langfristige Produktkreislauf lautet:

```text
Discover
   ↓
Capture
   ↓
Evaluate
   ↓
Apply
   ↓
Observe
   ↓
Interact
   ↓
Outcome
   ↓
Learn
   ↓
Improve
   ↺
```

### Discover
Neue Chancen aus unterschiedlichen Quellen finden.

### Capture
Relevante Informationen sichern, bevor sie verändert oder entfernt werden.

### Evaluate
Eine Opportunity fachlich, finanziell und persönlich beurteilen.

### Apply
Ein eigenes Angebot bzw. Proposal dokumentieren.

### Observe
Spätere Veränderungen und sichtbare Marktsignale nachvollziehen.

### Interact
Beruflich relevante Kontakte und Aktivitäten im Zusammenhang mit Opportunities nachvollziehbar halten.

### Outcome
Ergebnisse dokumentieren.

### Learn
Aus realen historischen Daten Muster erkennen.

### Improve
Suchstrategie, Rate, Profil, Priorisierung und Arbeitsweise auf Grundlage realer Erkenntnisse verbessern.

Nicht jede Opportunity durchläuft jeden Schritt. Wird keine Bewerbung abgegeben, endet der aktive Prozess beispielsweise nach `Evaluate` mit `Dismissed` oder `Watching`. `Outcome` bezeichnet in diesem Lastenheft das abschließende Ergebnis eines tatsächlich abgegebenen Proposals.

## 2.3 Produktidentität

LaunchPad ist:

> **die persönliche Arbeits- und Wissensschicht zwischen dem Freelancer und externen Plattformen, Vermittlern und anderen Opportunity-Quellen.**

Die Plattformen besitzen ihre eigenen Datenmodelle, Suchfunktionen und Workflows. LaunchPad führt die für den Nutzer relevanten Informationen in einem eigenen, einheitlichen Modell zusammen.

> **Plattformen sind Quellen, nicht das Produkt.**

## 2.4 Plattformübergreifender Ansatz

PeoplePerHour, Freelancermap und GULP/Randstad Professional sind initial besonders relevante Quellen.

Weitere Freelancer-Portale sollen ergänzbar sein, beispielsweise:

- Upwork
- Freelancer.com
- Malt
- weitere Freelancer-Portale

Nicht-portalbasierte Quellen, etwa direkte Recruiter-E-Mails oder persönliche Empfehlungen, können später ergänzt werden. Sie gehören nicht zum frühen Produktfokus.

Die fachliche Kernlogik darf nicht von den Begriffen oder Fähigkeiten einer einzelnen Plattform abhängig sein.

## 2.5 Langfristiger Mehrwert

Mit zunehmender Nutzungsdauer soll LaunchPad wertvoller werden.

Nach ausreichender Datenbasis soll der Nutzer beispielsweise beantworten können:

- welche Search Profiles die meisten relevanten Opportunities liefern,
- welche Plattformen bei bestimmten Skills besonders interessant sind,
- welche Skills häufiger nachgefragt werden,
- welche Rate-Bereiche typisch sind,
- welche eigenen angebotenen Rates häufiger zu Antworten führen,
- welche Vermittler wiederholt passende Projekte liefern,
- welche Companies bereits mehrfach aufgetaucht sind,
- wie schnell auf gute Opportunities reagiert wird,
- wie häufig Proposals beantwortet werden,
- welche Opportunity-Typen häufiger zu Interviews oder Zuschlägen führen.

---

# 3. Leitprinzipien

## 3.1 Praktischer Nutzen vor Perfektion

**LH-P-001 – Praktischer Nutzen [PRODUKT-MUSS]**

LaunchPad muss früh einen realen Arbeitsnutzen liefern.

Langfristige Funktionen dürfen in spätere Releases verschoben werden. Eine Verschiebung bedeutet ausdrücklich nicht, dass diese Funktionen aus der Produktvision entfallen.

> **Nicht im MVP bedeutet nicht gestrichen.**

## 3.2 Local-first, nicht local-only

**LH-P-002 – Lokale Datenhoheit [PRODUKT-MUSS]**

Die persönliche Wissensbasis des Nutzers soll lokal verfügbar und kontrollierbar sein.

Alle Funktionen, die keine aktuellen externen Daten benötigen, sollen ohne Netzwerkverbindung nutzbar sein.

Spätere externe Dienste sind zulässig, beispielsweise Plattformabfragen, APIs, Browser Helper oder optionale AI-Unterstützung. Die lokale Kernfunktion darf davon jedoch nicht abhängig sein.

## 3.3 Historisiere relevante Veränderungen

**LH-P-003 – History instead of overwrite [PRODUKT-MUSS]**

Nicht jede kleine Änderung benötigt eine Historie. Entscheidungs- und analyserelevante Veränderungen sollen jedoch soweit sinnvoll nachvollziehbar bleiben.

Dazu können gehören:

- Budget
- Rate
- Opportunity State
- Proposal Count
- Award-Informationen
- eigenes Proposal
- wichtige Activities
- relevante Profileinstellungen
- relevante Kontaktinteraktionen

Ein korrigierter Tippfehler muss dagegen nicht zwingend historisiert werden.

## 3.4 Explainable Intelligence

**LH-P-004 – Nachvollziehbare Intelligence [PRODUKT-MUSS]**

Spätere Scores, Empfehlungen und Analysen müssen soweit möglich erklärbar sein. Ein Opportunity Fit darf nicht nur eine Zahl darstellen; die zugrunde liegenden Faktoren sollen nachvollziehbar sein.

## 3.5 Evidence before automated decisions

**LH-P-005 – Evidenz vor automatisierter Empfehlung [PRODUKT-MUSS]**

AI darf früh bei technischen Hilfsaufgaben unterstützen, beispielsweise Extraktion, Strukturierung, Zusammenfassung und Skill-Erkennung.

Strategische Empfehlungen zu Rate, Opportunity Fit, Profil, Suchstrategie oder Priorisierung sollen jedoch auf nachvollziehbaren Daten und ausreichender Evidenz beruhen.

## 3.6 Plattformunabhängigkeit

**LH-P-006 – Plattformen sind Quellen [PRODUKT-MUSS]**

PeoplePerHour, Freelancermap, GULP/Randstad Professional und weitere Plattformen werden als externe Quellen betrachtet. Das einheitliche interne Datenmodell gehört LaunchPad.

Plattformspezifische Besonderheiten dürfen erhalten bleiben, aber nicht die Facharchitektur dominieren.

## 3.7 Datenschutz durch Zweckbindung und Datenminimierung

**LH-P-007 – Datenminimierung [PRODUKT-MUSS]**

Personenbezogene Daten dürfen nur gespeichert werden, wenn sie für Opportunity Management, Proposal-Verfolgung, professionelle Beziehungspflege, nachvollziehbare berufliche Historie oder sachliche Analyse einen nachvollziehbaren Zweck erfüllen.

Private Lebensumstände sollen nicht systematisch als strukturierte Persönlichkeitsdaten gesammelt werden.

## 3.8 Source Provenance

**LH-P-008 – Datenherkunft [PRODUKT-MUSS]**

Extern gewonnene Informationen sollen soweit sinnvoll erkennen lassen:

- woher sie stammen,
- wann sie beobachtet wurden,
- wie sie erfasst wurden.

Dieser Grundsatz verlangt im frühen Produktstand keine lückenlose Provenance-Historie für jedes einzelne Feld. Zunächst genügt eine robuste Herkunft auf Fundstellen-/Importebene; feinere Provenance kann später dort ergänzt werden, wo sie echten Nutzen bringt.

## 3.9 Graceful Automation

**LH-P-009 – Automatisierung mit Rückfallebene [PRODUKT-MUSS]**

Automatisierung soll den manuellen Workflow verbessern, nicht ersetzen.

Fällt eine Plattformintegration oder externer Dienst aus, müssen soweit möglich weiterhin funktionieren:

- lokale Suche
- lokale Datenpflege
- andere Plattformen
- manuelle Erfassung
- vorhandene Daten

## 3.10 Useful defaults, full control when needed

**LH-P-010 – Sinnvolle Defaults bei hoher Flexibilität [PRODUKT-MUSS]**

LaunchPad soll komfortable Standardwerte und Presets anbieten. Fortgeschrittene Nutzer dürfen dadurch nicht unnötig eingeschränkt werden.

Beispiel:

- „letzte 24 Stunden“ als Preset
- frei definierbare Zeiträume als vollständige Funktion



## 3.11 Zukunftsoffen ohne Overengineering

**LH-P-011 – Zukunftsoffen ohne Overengineering [PRODUKT-MUSS]**

Das Produkt soll absehbare spätere Erweiterungen nicht unnötig verbauen. Gleichzeitig dürfen Funktionen, Datenstrukturen oder Abstraktionen nicht allein deshalb vollständig implementiert werden, weil sie irgendwann nützlich sein könnten.

Es gilt:

> **Für die Zukunft offen bleiben, ohne die Zukunft auf Vorrat zu implementieren.**

Der frühe Produktstand soll einfache, verständliche Lösungen bevorzugen, sofern diese eine spätere saubere Erweiterung nicht unnötig verhindern.
---

# 4. Zielgruppen

## 4.1 Primäre Zielgruppe

Die erste Produktzielgruppe sind technische Freelancer und selbstständige IT-Spezialisten.

Typische Beispiele:

- Softwareentwickler
- Linux-/Unix-/DevOps-Spezialisten
- Administratoren
- technische Berater
- Cloud-/Infrastructure-Spezialisten
- verwandte technische Freelancer

Diese Gruppe wird bewusst zuerst adressiert, weil ihre realen Workflows, Plattformen, Suchmuster und Projektformen gut als Referenz für die Produktentwicklung dienen.

## 4.2 Spätere Erweiterung

Das fachliche Datenmodell soll nicht unnötig IT-spezifisch sein.

Eine spätere Erweiterung auf weitere projektorientierte Freelancer-Berufe soll möglich bleiben, ohne den heutigen Produktfokus zu verwässern.

## 4.3 Sekundäre Zielgruppen

Später können unter anderem profitieren:

- kleine Beratungen
- kleine Agenturen
- Freelancer mit mehreren parallelen Opportunity-Quellen
- kleine Teams mit ähnlichen Akquiseprozessen

## 4.4 Nicht primär adressierte Zielgruppen

Nicht primär vorgesehen ist LaunchPad für:

- große Recruiting-Abteilungen
- klassische HR-Abteilungen
- Enterprise Sales Teams
- Personalverwaltung
- vollständige Multi-User-CRM-Umgebungen
- große Projektorganisationen

---

# 5. Begriffe und fachliche Kernobjekte

## 5.1 Opportunity

Eine **Opportunity** ist das reale potentielle Projekt bzw. die reale Auftragschance, für die der Nutzer entscheiden kann, ob er sie weiterverfolgt und gegebenenfalls ein Proposal abgibt.

Eine Opportunity ist nicht automatisch ein Auftrag und nicht automatisch ein eigenes Projekt im Sinne der späteren Auftragsdurchführung.

Dasselbe reale Projekt kann über mehrere Plattformen oder Vermittler angeboten werden. Diese Veröffentlichungen sind keine unterschiedlichen realen Projekte, sondern unterschiedliche **Fundstellen/Listings** derselben Opportunity, sobald die Gleichheit ausreichend sicher erkannt wurde.

Eine Opportunity kann deshalb langfristig eine oder mehrere Fundstellen besitzen. Für die lokale Arbeit darf sie einen eigenen Arbeits-/Anzeigetitel besitzen, der beispielsweise beim ersten Capture aus dem Fundstellentitel übernommen und später vom Nutzer angepasst werden kann.

## 5.2 Fundstelle / Listing

Eine **Fundstelle** bzw. ein **Listing** ist die konkrete Veröffentlichung oder Darstellung einer Opportunity auf einer Plattform.

Eine Fundstelle kann insbesondere besitzen:

- Platform
- externe Listing-/Opportunity-ID der Plattform
- ursprünglichen Titel der Fundstelle
- URL
- Veröffentlichungszeitpunkt
- Erfassungszeitpunkt
- ursprünglichen Ausschreibungstext
- plattformspezifische Skills
- sichtbares Budget bzw. sichtbare Rate
- Vermittler, soweit aus dieser Fundstelle bekannt
- weitere plattformspezifische Angaben

Dadurch kann dasselbe reale Projekt beispielsweise gleichzeitig über Freelancermap und GULP oder über mehrere Vermittler angeboten werden, ohne dass quellspezifische Informationen verloren gehen.

Im frühen Produktstand darf eine Opportunity zunächst nur eine bekannte Fundstelle besitzen. Das fachliche Modell darf mehrere Fundstellen später jedoch nicht unnötig verhindern.

## 5.3 Proposal

Ein **Proposal** ist die konkrete eigene Reaktion des Nutzers auf eine Opportunity.

Je nach Plattform kann dies beispielsweise heißen:

- Proposal
- Bid
- Bewerbung
- Angebot
- Quote

Ein Proposal soll, soweit relevant, erkennen lassen, **über welche Fundstelle bzw. welchen Vermittlungsweg** es abgegeben wurde.

Eine Opportunity kann kein Proposal, ein Proposal oder langfristig gegebenenfalls mehrere Proposal-Vorgänge besitzen.

## 5.4 Observation

Eine **Observation** ist ein zeitlich gebundener Schnappschuss ausgewählter beobachtbarer Eigenschaften einer Opportunity oder einer ihrer Fundstellen.

Observation ist kein vollständiger Klon der Opportunity und kein Ersatz für Status.

Typische Werte können sein:

- Beobachtungszeitpunkt
- sichtbarer Zustand der Fundstelle
- Budget oder Rate
- Proposal Count
- sichtbare Client Activity
- Award-Status
- Winning Bid, sofern bekannt

Bei mehreren Fundstellen muss nachvollziehbar bleiben, auf welche Fundstelle sich ein beobachteter quellspezifischer Wert bezieht.

## 5.5 Platform

Eine **Platform** ist ein externes Portal, über das Opportunities veröffentlicht, gefunden oder bearbeitet werden können.

Initial besonders relevant sind:

- PeoplePerHour
- Freelancermap
- GULP/Randstad Professional

Nicht jede Platform muss dieselben Informationen oder Funktionen liefern.

## 5.6 Search Profile

Ein **Search Profile** beschreibt eine wiederverwendbare Suchabsicht.

Beispiele:

- Linux Remote
- C# Backend
- DevOps Deutschland
- MariaDB / MySQL Migration

Es kann langfristig Keywords, Skills, Ausschlüsse, Plattformen, Zeiträume, Remote-Anforderungen, Rate-/Budgetkriterien, Vertragsart, Standort und weitere Filter enthalten.

## 5.7 Company

Eine **Company** ist eine Organisation.

Ihre Rolle entsteht aus der Beziehung zu einer Opportunity oder Fundstelle und ist nicht zwingend eine feste Eigenschaft der Company.

Mögliche Rollen:

- Endkunde
- Vermittler
- Agentur
- Recruiting-Unternehmen

Ein Vermittler ist Teil des Vermittlungswegs. Er ist nicht die Opportunity selbst.

## 5.8 Contact

Ein **Contact** ist eine beruflich relevante natürliche Person.

Mögliche Rollen:

- Recruiter
- Headhunter
- Hiring Manager
- Buyer
- Endkunden-Ansprechpartner
- Ansprechpartner beim Vermittler

## 5.9 Activity

Eine **Activity** ist ein zeitlich zuordenbares Ereignis oder eine geplante Aktion.

Beispiele:

- Proposal Submitted
- E-Mail bzw. Plattformnachricht
- Telefonat
- Video Call
- Interview
- Follow-up
- Reminder
- Offer
- Rejection
- Award

Eine **Note ist keine Activity**. Notes und Activities können später gemeinsam in einer Timeline erscheinen, bleiben fachlich aber getrennte Konzepte.

Eine Interaction ist fachlich eine Activity mit Kommunikationscharakter und benötigt nicht zwingend ein paralleles Kernmodell.

## 5.10 Skill

Ein **Skill** ist eine fachliche Fähigkeit, Technologie, Methode oder Kompetenz, die für Opportunities, Profile, Suche oder Analyse relevant ist.

## 5.11 Outcome

Ein **Outcome** beschreibt das abschließende Ergebnis eines eigenen Proposal-Vorgangs.

Ein Outcome ist deshalb nur relevant, wenn tatsächlich ein Proposal bzw. eine Bewerbung abgegeben wurde.

Mögliche Proposal Outcomes sind beispielsweise:

- Won
- Rejected / Lost
- Withdrawn
- TimedOutByUser
- Unknown

`Interview`, `Negotiation` und `Offer` sind keine terminalen Outcomes. Sie sind Ereignisse bzw. Zwischenstufen des Proposal-Prozesses und können über Activities bzw. den Funnel nachvollzogen werden.

`TimedOutByUser` bedeutet ausdrücklich nicht, dass extern sicher eine Absage erfolgt ist. Es bedeutet nur, dass der Nutzer den Vorgang für seine eigene Arbeitsorganisation nicht länger als aktiv offen betrachtet. Wenn bis dahin keine Reaktion vorliegt, kann dies später analytisch als `No Response` ausgewertet werden.

# 6. Prioritätsmodell

Zur Vermeidung von Missverständnissen gelten folgende Prioritäten:

| Priorität | Bedeutung |
|---|---|
| **MVP-MUSS** | Für den ersten wirklich nutzbaren Stand erforderlich |
| **PRODUKT-MUSS** | Verbindlicher langfristiger Produktkern, aber nicht zwingend im ersten Release |
| **SOLL** | Hoher Nutzwert, soll nach Möglichkeit umgesetzt werden |
| **KANN** | Sinnvolle optionale Erweiterung |
| **PRÜFEN** | Fachlich interessant; technische oder rechtliche Umsetzbarkeit muss noch geklärt werden |
| **NICHT-KERN** | Bewusst nicht Bestandteil des fachlichen Produktkerns |

## 6.1 Bedeutung von PRODUKT-MUSS

Eine PRODUKT-MUSS-Anforderung darf in einen späteren Release verschoben werden. Sie soll aber nicht stillschweigend aus der Produktvision verschwinden. Ihre Entfernung erfordert eine bewusste Produktentscheidung.

## 6.2 Bedeutung von NICHT-KERN

NICHT-KERN bedeutet nicht zwingend „niemals“.

Solche Funktionen können später integriert, referenziert, an andere SASD-Produkte übergeben oder durch externe Werkzeuge gelöst werden. LaunchPad selbst soll dadurch jedoch nicht unnötig aufgebläht werden.

---

# 7. Funktionsbereich Opportunity Management

## 7.1 Opportunity erfassen

**LH-F-OPP-001 [MVP-MUSS]**

Der Nutzer muss eine Opportunity jederzeit manuell erfassen können. Manuelle Erfassung ist die zuverlässige Rückfallebene.

## 7.2 Opportunity und Fundstelle unterscheiden

**LH-F-OPP-002 [PRODUKT-MUSS]**

Das reale potentielle Projekt wird als Opportunity behandelt. Die konkrete Veröffentlichung auf einer Plattform wird als Fundstelle/Listing behandelt.

Eine Opportunity kann langfristig mehrere Fundstellen besitzen.

Im MVP darf die Oberfläche zunächst von genau einer bekannten Fundstelle ausgehen, sofern das Datenmodell eine spätere Erweiterung auf mehrere Fundstellen nicht unnötig erschwert.

## 7.3 Fundstelle und Herkunft

**LH-F-OPP-003 [MVP-MUSS]**

Für eine bekannte Fundstelle sollen mindestens speicherbar sein:

- Platform
- externe ID, soweit vorhanden
- Fundstellen-/Source-URL
- Capture Method
- CapturedAt

Der Nutzer muss erkennen können, auf welchem Portal die Opportunity gefunden wurde.

## 7.4 Mehrere Fundstellen erhalten

**LH-F-OPP-004 [PRODUKT-MUSS]**

Wird dasselbe reale Projekt über mehrere Plattformen oder Vermittler angeboten, sollen die bekannten Fundstellen erhalten bleiben können.

Quellspezifische Unterschiede dürfen dadurch nicht verloren gehen.

Beispiele:

- unterschiedliche URLs
- unterschiedliche Vermittler
- unterschiedliche veröffentlichte Rates
- unterschiedliche Beschreibungstexte
- unterschiedliche Veröffentlichungszeitpunkte

## 7.5 Vollständige Ausschreibung sichern

**LH-F-OPP-005 [MVP-MUSS]**

Der relevante vollständige Ausschreibungstext einer erfassten Fundstelle soll lokal gespeichert werden können.

Bei mehreren Fundstellen sollen die jeweiligen Originaltexte getrennt erhalten bleiben können.

## 7.6 Original, Interpretation und persönliche Notiz trennen

**LH-F-OPP-006 [PRODUKT-MUSS]**

Originalinformationen dürfen nicht unnötig mit Nutzerkorrekturen, automatisch erkannten Skills, Zusammenfassungen, AI-Inhalten oder persönlichen Notes vermischt werden.

Für den frühen Produktstand genügt eine pragmatische Trennung. Eine aufwendige feldweise Provenance-Historie ist nicht erforderlich.

## 7.7 Zeitinformationen

**LH-F-OPP-007 [MVP-MUSS]**

Soweit verfügbar oder sinnvoll, sollen unterschieden werden können:

- PublishedAt der Fundstelle
- FirstObservedAt
- CapturedAt
- LastObservedAt
- Deadline
- ExpectedStartDate
- Duration
- EstimatedEndDate

Nicht jeder Wert muss vorhanden sein.

`LastObservedAt` darf auch nach Ablauf oder Schließung einer Opportunity aktualisiert werden, wenn der Nutzer die Fundstelle später erneut prüft.

## 7.8 Ort und Remote

**LH-F-OPP-008 [MVP-MUSS]**

Soweit bekannt sollen strukturiert erfasst werden können:

- Land
- Ort
- Remote möglich
- Remote-Anteil
- Hybrid
- On-site
- Reiseanforderung, soweit relevant

Wenn mehrere Fundstellen widersprüchliche Angaben enthalten, sollen die ursprünglichen Quellwerte später nachvollziehbar bleiben können.

## 7.9 Vertrags- und Einsatzart

**LH-F-OPP-009 [SOLL]**

Die Opportunity soll unterschiedliche Einsatz-/Vergütungsmodelle abbilden können, beispielsweise:

- Freelance
- Contract
- Fixed Price
- Hourly
- Daily Rate
- Project-based
- sonstige
- unbekannt

Die Liste soll erweiterbar sein.

## 7.10 Preis- und Rate-Angaben

**LH-F-OPP-010 [MVP-MUSS]**

Ein einzelnes `Budget`-Feld reicht nicht aus.

Soweit vorhanden sollen unterschieden werden können:

- Fixed Budget
- Budget Minimum
- Budget Maximum
- Hourly Rate Minimum
- Hourly Rate Maximum
- Daily Rate Minimum
- Daily Rate Maximum
- Currency
- Rate Unit

Veröffentlichte Preis-/Rate-Angaben sind quellenbezogene Angaben. Wenn mehrere Fundstellen unterschiedliche Werte nennen, dürfen sie nicht zu einem vermeintlich eindeutigen Opportunity-Wert zusammengezogen werden.

## 7.11 Skills

**LH-F-OPP-011 [MVP-MUSS]**

Opportunities müssen Skills bzw. Keywords zugeordnet werden können.

Langfristig sollen unterschiedliche Herkünfte möglich sein:

- Platform Skill
- Detected Skill
- User Added Skill

## 7.12 Vermittler und Endkunde

**LH-F-OPP-012 [PRODUKT-MUSS]**

Soweit bekannt soll unterschieden werden zwischen:

- Platform
- Vermittler
- Endkunde
- Contact

Der Vermittler ist Teil des Vermittlungswegs. Derselbe Endkundenauftrag kann über mehrere Vermittler angeboten werden.

## 7.13 Opportunity-Status

**LH-F-OPP-013 [MVP-MUSS]**

Ein früher einfacher fachlicher Zustand muss möglich sein.

Geeignete Zustände sind beispielsweise:

- New
- Reviewing
- Interesting
- Watching
- Dismissed
- Closed
- Cancelled
- Expired

Der Opportunity-Status ist **nicht** die Archivierung und **nicht** der Proposal-Status.

Zusätzlich kann eine Fundstelle einen eigenen beobachteten Plattformzustand besitzen, beispielsweise `Open`, `Closed`, `Expired` oder `Unavailable`. Bei mehreren Fundstellen darf das Schließen einer einzelnen Fundstelle nicht automatisch behaupten, dass das reale Projekt insgesamt geschlossen ist.

## 7.14 Dismiss Reason

**LH-F-OPP-014 [SOLL]**

Wenn eine Opportunity bewusst nicht weiterverfolgt wird, soll optional ein Grund speicherbar sein.

Beispiele:

- Rate zu niedrig
- Skill-Fit zu gering
- Remote-Anteil ungeeignet
- Einsatzort ungeeignet
- Laufzeit ungeeignet
- keine Kapazität
- Vermittler uninteressant
- Endkunde uninteressant
- Projekt unklar
- Projekt wirkt unseriös
- persönliches Interesse fehlt
- sonstiges

Dismiss-Gründe sollen später auswertbar sein können.

## 7.15 Persönliche Bewertung

**LH-F-OPP-015 [SOLL]**

Opportunities sollen manuell bewertet werden können.

Der frühe Stand darf mit einer einfachen Interessenbewertung beginnen. Langfristig können getrennte Dimensionen folgen, beispielsweise Interest, Skill Fit, Rate Fit, Strategic Value oder Availability Fit.

## 7.16 Archivieren

**LH-F-OPP-016 [MVP-MUSS]**

Eine Opportunity muss unabhängig von ihrem fachlichen Status archiviert bzw. aus aktiven Arbeitslisten ausgeblendet werden können, ohne ihre Historie zu verlieren.

Beispiele:

```text
Status: Dismissed
Archived: Yes
```

oder:

```text
Status: Closed
Archived: Yes
```

## 7.17 Löschen

**LH-F-OPP-017 [MVP-MUSS]**

Fehlerhaft erfasste Opportunities müssen löschbar sein.

Bei historisch relevanten Datensätzen soll Archivierung der bevorzugte Weg sein.

## 7.18 Fundstellen-URL öffnen

**LH-F-OPP-018 [MVP-MUSS]**

Eine gespeicherte Fundstellen-/Source-URL muss direkt aus LaunchPad geöffnet werden können.

Bei mehreren bekannten Fundstellen soll später die gewünschte Fundstelle auswählbar sein.

## 7.19 Technische Duplikaterkennung

**LH-F-OPP-019 [PRODUKT-MUSS]**

Mindestens folgende technischen Dubletten sollen erkannt werden können:

- gleiche Platform + externe ID
- gleiche URL

Eine identische Fundstelle ist eine technische Dublette. Eine weitere Fundstelle desselben realen Projekts ist dagegen keine technische Dublette und muss als solche erhalten bzw. später derselben Opportunity zugeordnet werden können.

# 8. Suche, Filter und Arbeitslisten

## 8.1 Lokale Volltextsuche

**LH-F-SRCH-001 [MVP-MUSS]**

Die lokale Wissensbasis muss durchsuchbar sein.

Mindestens:

- Opportunity-Titel
- Ausschreibungstexte der Fundstellen
- Notes
- Skills
- Platform
- später Company/Contact

## 8.2 Flexible Zeitfilter

**LH-F-SRCH-002 [MVP-MUSS]**

Zeiträume müssen in LaunchPad flexibel wählbar sein.

Presets dürfen angeboten werden, beispielsweise:

- heute
- letzte 24 Stunden
- letzte 48 Stunden
- letzte 7 Tage
- seit letzter erfolgreicher Prüfung

Zusätzlich sollen benutzerdefinierte Zeiträume möglich sein.

Die gewünschte LaunchPad-Zeitspanne ist unabhängig davon, welche Zeitfilter eine externe Plattform direkt anbietet. Kann eine Plattform beispielsweise nur „letzte 24 Stunden“ liefern, darf LaunchPad diese Quellfunktion nutzen und anschließend lokal weiterfiltern, soweit die verfügbaren Daten dies erlauben.

## 8.3 Zeitbasis

**LH-F-SRCH-003 [PRODUKT-MUSS]**

Zeitpunkte müssen zwischen unterschiedlichen Quellen konsistent vergleichbar sein.

Für den frühen Produktstand soll UTC die kanonische Zeitbasis sein. Eine spätere konfigurierbare Anzeige in lokaler Zeitzone, beispielsweise `Europe/Berlin`, ist zulässig.

Quellangaben mit eigener Zeitzone oder Offset sollen korrekt auf die kanonische Zeitbasis abbildbar sein. Bei unklaren Zeitangaben darf keine Scheingenauigkeit erzeugt werden.

## 8.4 Freie Filterkombination

**LH-F-SRCH-004 [PRODUKT-MUSS]**

Filter sollen langfristig möglichst frei kombinierbar sein.

Beispiele:

- Keyword
- Skill
- Platform
- Veröffentlichungszeitraum
- Remote-Anteil
- Rate
- Budget
- Vertragsart
- Ort
- Status
- Ausschlussbegriffe

Unbekannte Quellwerte bleiben zulässige Datenzustände. Die konkrete Filter-UX für unbekannte Werte darf schrittweise entwickelt werden und muss nicht bereits im Lastenheft eine komplexe Boolesche Ausdruckssprache festlegen.

## 8.5 Search Profiles

**LH-F-SRCH-005 [PRODUKT-MUSS]**

Der Nutzer soll wiederverwendbare Search Profiles speichern können.

Beispiele:

- Linux Remote
- C# Backend
- DevOps Deutschland
- MariaDB / MySQL Migration

## 8.6 Ausschlusskriterien

**LH-F-SRCH-006 [SOLL]**

Search Profiles sollen später Ausschlusskriterien unterstützen.

Beispiel:

```text
Linux
NOT SAP
NOT onsite
```

## 8.7 Plattformübergreifende Suchabsicht

**LH-F-SRCH-007 [PRODUKT-MUSS]**

LaunchPad soll eine gemeinsame Suchabsicht auf unterschiedliche Plattformen abbilden können.

Nicht jede Plattform muss alle Kriterien unterstützen. Plattformseitig nicht verfügbare Kriterien können soweit möglich nach dem Abruf lokal angewendet werden.

## 8.8 Local Search vs. External Discovery

**LH-F-SRCH-008 [PRODUKT-MUSS]**

Es muss fachlich unterschieden werden zwischen:

### Local Search

Suche in bereits gespeicherten LaunchPad-Daten.

### External Discovery

Suche nach neuen Opportunities bzw. Fundstellen auf externen Plattformen.

Beide Bereiche dürfen ähnliche UI-Elemente verwenden, sind aber fachlich nicht dasselbe.

## 8.9 Neue Ergebnisse seit letzter erfolgreicher Prüfung

**LH-F-SRCH-009 [PRODUKT-MUSS]**

Search Profiles sollen langfristig erkennen lassen, welche Fundstellen seit der letzten **erfolgreichen** Prüfung neu hinzugekommen sind.

## 8.10 Zuverlässiger Prüfstatus je Plattform

**LH-F-SRCH-010 [PRODUKT-MUSS]**

Für automatisierte bzw. teilautomatisierte Discovery muss der letzte erfolgreiche Prüfstand je Search Profile und Platform nachvollziehbar sein.

Ein fehlgeschlagener oder unvollständiger Plattformabruf darf den Marker für die letzte erfolgreiche Prüfung nicht so fortschreiben, dass beim nächsten Lauf ein Zeitraum übersprungen werden könnte.

Beispiel:

```text
Search Profile: Linux Remote
Freelancermap: zuletzt erfolgreich 24.08.2026 04:00 UTC
GULP:          zuletzt erfolgreich 23.08.2026 04:00 UTC
PeoplePerHour: zuletzt erfolgreich 24.08.2026 04:05 UTC
```

> **Discovery, dessen Vollständigkeit nicht nachvollziehbar ist, darf nicht so dargestellt werden, als sei sicher nichts Neues vorhanden.**

## 8.11 Gelesen / geprüft

**LH-F-SRCH-011 [SOLL]**

Eine Opportunity soll langfristig zwischen neu, gesehen und geprüft unterscheidbar sein.

Dies ist unabhängig von der Entscheidung `Interesting`.

## 8.12 Arbeitslisten

**LH-F-SRCH-012 [SOLL]**

Sinnvolle Arbeitslisten können als gespeicherte Filter bzw. Views umgesetzt werden.

Beispiele:

- Heute entdeckt
- Neu
- Interessant
- Beobachten
- Proposal offen
- Antwort ausstehend
- Follow-up fällig
- kürzlich geschlossen
- Archiv

# 9. Proposal Management

## 9.1 Proposal als eigenes Objekt

**LH-F-PROP-001 [PRODUKT-MUSS]**

Proposal und Opportunity bleiben fachlich getrennt.

Wenn eine Opportunity mehrere Fundstellen besitzt, soll ein Proposal soweit relevant der Fundstelle bzw. dem Vermittlungsweg zugeordnet werden können, über den es abgegeben wurde.

## 9.2 Proposal Lite im frühen Produktstand

**LH-F-PROP-002 [MVP-MUSS]**

Der frühe Produktstand soll mit möglichst wenig Eingabeaufwand dokumentieren können:

- Proposal gesendet / beworben
- SubmittedAt
- eigener Preis bzw. eigene Rate
- Währung
- verwendete CV-/Profil-/Bewerbungsunterlagen-Version, soweit relevant
- einfacher Proposal-Status
- optionales Outcome
- kurze Note

Die Unterlagen-Version darf zunächst eine einfache logische Bezeichnung sein, beispielsweise:

```text
CV Linux DevOps 2026-08
```

Eine vollständige Attachment- oder CV-Dokumentverwaltung ist dafür nicht erforderlich.

Langfristig ist es wünschenswert, die Zahl unnötiger CV-Varianten zu reduzieren, ohne unterschiedliche Job-Typen künstlich in ein einziges Profil zu zwingen.

## 9.3 Proposal-Status und Outcome trennen

**LH-F-PROP-003 [PRODUKT-MUSS]**

Zwischen laufendem Proposal-Zustand, Prozessereignissen und terminalem Outcome ist zu unterscheiden.

Beispielhafte laufende Zustände können sein:

- Submitted
- Active / Awaiting Response
- Closed

Prozessereignisse wie Response, Interview, Negotiation oder Offer werden nicht als terminales Outcome modelliert.

Mögliche terminale Outcomes sind beispielsweise:

- Won
- Rejected / Lost
- Withdrawn
- TimedOutByUser
- Unknown

`TimedOutByUser` wird bewusst durch den Nutzer gesetzt und behauptet keine externe Absage.

## 9.4 Optionale Proposal-Details

**LH-F-PROP-004 [SOLL]**

Zusätzliche Informationen dürfen optional speicherbar sein, beispielsweise:

- Proposal Text
- Referenzen
- Arbeitsproben
- geplante Laufzeit
- Aufwandsschätzung
- Deliverables
- Fragen/Antworten
- Attachments
- Gesprächsnotizen

Diese Felder dürfen den normalen Workflow nicht zu einem Formularzwang machen.

## 9.5 Proposal History

**LH-F-PROP-005 [PRODUKT-MUSS]**

Später sollen relevante Proposal-Ereignisse nachvollziehbar sein.

Beispiele:

- Submitted
- Viewed, soweit bekannt
- Response
- Interview
- Negotiation
- Offer
- Rejection
- Award / Won
- Withdrawal

Nicht jedes Ereignis muss auf jeder Plattform verfügbar sein.

## 9.6 No Response und TimedOutByUser

**LH-F-PROP-006 [PRODUKT-MUSS]**

`No Response` soll nicht allein aufgrund einer willkürlich abgelaufenen Zeit automatisch als gesicherter externer Outcome gesetzt werden.

Der Nutzer kann einen offenen Vorgang mit `TimedOutByUser` für seine eigene Arbeitsorganisation schließen. Wenn bis dahin keine Response dokumentiert ist, darf die Analytics diesen Fall als `No Response` klassifizieren.

Eine spätere konfigurierbare Automatisierung kann vorgeschlagen werden, darf aber die fachliche Bedeutung nicht verfälschen.

## 9.7 Proposal-Vorlagen

**LH-F-PROP-007 [KANN]**

Wiederverwendbare Proposal-Vorlagen oder Textbausteine können später sinnvoll sein.

LaunchPad soll daraus jedoch kein automatisiertes Massenbewerbungssystem entwickeln.

# 10. Market Observation

## 10.1 Historische Observation

**LH-F-OBS-001 [PRODUKT-MUSS]**

Eine Opportunity soll langfristig zu unterschiedlichen Zeitpunkten beobachtbar sein.

## 10.2 Relevante Marktdaten

**LH-F-OBS-002 [PRODUKT-MUSS]**

Soweit verfügbar, sollen Observation-Daten enthalten können:

- ObservedAt
- beobachtete Fundstelle
- Fundstellen-/Listing State
- Budget
- Rate
- Proposal/Bid Count
- Average Bid
- Client Activity
- Awarded
- Winning Bid
- Awarded Freelancer
- weitere plattformspezifische Signale

Quellspezifische Werte wie Rate, Proposal Count oder Listing State müssen der Fundstelle zuordenbar bleiben, von der sie beobachtet wurden. Nicht jede Plattform liefert alle Werte. Fehlende Daten sind zulässig.

## 10.3 Gewinnerinformationen sind optional

**LH-F-OBS-003 [PRODUKT-MUSS]**

Wenn der Nutzer eine Opportunity nicht gewinnt, ist häufig nicht bekannt, wer den Zuschlag erhalten hat.

Daher gilt:

- `AwardedFreelancer` ist optional.
- `WinningBid` ist optional.
- `Awarded` kann unbekannt sein.
- spätere Ergänzung muss möglich sein.

## 10.4 Relevante Opportunities beobachten

**LH-F-OBS-004 [SOLL]**

Nicht jede gespeicherte Opportunity muss dauerhaft automatisch überwacht werden.

Es soll später möglich sein:

- nicht beobachten
- beobachten
- erneut prüfen
- abgeschlossen markieren

## 10.5 Manuelle und automatische Observation

**LH-F-OBS-005 [PRODUKT-MUSS]**

Observation soll manuell möglich sein. Spätere automatische Prüfung ist zulässig, sofern technisch und rechtlich sinnvoll.

## 10.6 Veränderungen sichtbar machen

**LH-F-OBS-006 [SOLL]**

Relevante Änderungen zwischen Observations sollen später erkennbar sein.

Beispiele:

- Proposal Count gestiegen
- Budget geändert
- Fundstelle geschlossen bzw. nicht mehr verfügbar
- Award bekannt
- Beschreibung verändert

---

# 11. Plattformen und Discovery

## 11.1 Initial wichtige Plattformen

**LH-F-PLAT-001 [PRODUKT-MUSS]**

Initial besonders relevant sind:

- PeoplePerHour
- Freelancermap
- GULP/Randstad Professional

Weitere Freelancer-Portale sollen ergänzt werden können.

## 11.2 Unterschiedliche Plattformfähigkeiten

**LH-F-PLAT-002 [PRODUKT-MUSS]**

LaunchPad darf nicht voraussetzen, dass jede Plattform dieselben Funktionen oder Daten bereitstellt.

Mögliche Fähigkeiten einer Plattform sind beispielsweise:

- Opportunity Search
- URL Capture
- Saved Search
- Remote Filter
- Budget/Rate
- End Client
- Intermediary
- Proposal Count
- Award Information
- API
- Feed
- Browser Capture

Wie diese Unterschiede technisch gekapselt werden, gehört in das Architecture-Dokument.

## 11.3 Zwei Filterstufen

**LH-F-PLAT-003 [PRODUKT-MUSS]**

LaunchPad soll langfristig unterscheiden zwischen:

### Plattformseitiger Vorauswahl

Nutzung der Such- und Filtermöglichkeiten, die das jeweilige Portal tatsächlich bereitstellt.

### Lokaler LaunchPad-Nachfilterung

Anwendung zusätzlicher Kriterien auf die bereits gewonnenen Daten.

Damit darf ein flexibler LaunchPad-Filter nicht fälschlich voraussetzen, dass das Portal selbst denselben Filter unterstützt.

## 11.4 Discovery als Opportunity Radar

**LH-F-PLAT-004 [PRODUKT-MUSS]**

Discovery umfasst langfristig insbesondere:

- Search Profiles
- neue Treffer
- Ergebnisse seit letzter erfolgreicher Prüfung
- plattforminterne Hinweise bzw. Einladungen, soweit zugänglich
- ähnliche Opportunities
- Trendhinweise
- wiederkehrende Companies/Vermittler

Nicht alle Funktionen gehören in frühe Releases.

## 11.5 Neue Fundstellen erkennen

**LH-F-PLAT-005 [PRODUKT-MUSS]**

LaunchPad soll erkennen können, welche konkrete Fundstellen bereits bekannt und welche neu sind.

Eine neue Fundstelle kann entweder eine neue Opportunity beschreiben oder eine weitere Fundstelle einer bereits bekannten Opportunity sein.

## 11.6 Mehrfachfundstellen desselben Projekts

**LH-F-PLAT-006 [SOLL]**

LaunchPad soll später Hinweise geben können, wenn unterschiedliche Fundstellen wahrscheinlich dasselbe reale Projekt beschreiben.

Eine solche Zuordnung darf bei Unsicherheit nicht ohne Nutzerkontrolle erfolgen.

Nach bestätigter Zuordnung sollen die Fundstellen derselben Opportunity zugeordnet werden können, ohne quellspezifische Informationen zu verlieren.

## 11.7 Vermittlungswege erhalten

**LH-F-PLAT-007 [PRODUKT-MUSS]**

Platform, Fundstelle, Vermittler und Endkunde sollen soweit bekannt getrennt erhalten bleiben.

## 11.8 Status einer Plattformprüfung

**LH-F-PLAT-008 [SOLL]**

LaunchPad soll später sichtbar machen können:

- wann eine Plattform für ein Search Profile zuletzt erfolgreich geprüft wurde,
- ob die aktuelle Prüfung erfolgreich war,
- ob nur ein Teil der Daten verfügbar war,
- wie viele neue Fundstellen gefunden wurden.

Wichtig:

> **„Keine Treffer“ und „Plattform konnte nicht zuverlässig geprüft werden“ sind unterschiedliche Zustände.**

## 11.9 Kein Credential-Zwang

**LH-F-PLAT-009 [PRODUKT-MUSS]**

Soweit möglich sollen öffentliche oder bereits über die Plattform zugängliche Daten ohne Speicherung von Plattformpasswörtern genutzt werden.

Falls Authentifizierung erforderlich ist, sind bevorzugt geeignete sichere Mechanismen zu verwenden. Die konkrete technische Credential-Strategie gehört in Architecture/Technical Design.

## 11.10 Rechtliche und technische Prüfung

**LH-F-PLAT-010 [PRÜFEN]**

Für tiefergehende Plattformautomation sind vor Implementierung zu prüfen:

- verfügbare APIs
- Feeds
- Browser Capture
- Login-Anforderungen
- Nutzungsbedingungen
- zulässige Abfragefrequenz
- Schutzmechanismen

Aggressives Scraping oder das Umgehen von Schutzmaßnahmen ist kein Produktziel.

# 12. Company Management

## 12.1 Company als neutrales Objekt

**LH-F-COMP-001 [PRODUKT-MUSS]**

Eine Company ist zunächst eine neutrale Organisation. Ihre Rolle entsteht durch Beziehungen und ist nicht zwingend eine feste Eigenschaft.

Beispiel:

```text
Opportunity A:
Company X = Endkunde

Opportunity B:
Company X = Vermittler
```

## 12.2 Company-Daten

**LH-F-COMP-002 [SOLL]**

Langfristig sinnvoll:

- Name
- Website
- Standort
- Land
- Branche
- Notes
- Plattformidentitäten
- erste bekannte Aktivität
- letzte bekannte Aktivität

## 12.3 Company History

**LH-F-COMP-003 [PRODUKT-MUSS]**

Später sollen zu einer Company sichtbar sein können:

- frühere Opportunities
- frühere Proposals
- Outcomes
- Contacts
- Activities
- Notes

## 12.4 Eigene Erfahrungen

**LH-F-COMP-004 [SOLL]**

Der Nutzer soll sachliche geschäftliche Erfahrungen dokumentieren können.

Beispiele:

- mehrfach niedrige Rate
- schnelle Kommunikation
- wiederholt keine Rückmeldung
- gute technische Gespräche
- unklare Endkundenangaben

## 12.5 Keine automatische Blacklist

**LH-F-COMP-005 [PRODUKT-MUSS]**

LaunchPad soll Erfahrungen sichtbar machen, aber nicht automatisch pauschal entscheiden, dass bei einer Company nicht mehr reagiert werden soll.

## 12.6 Company-Dubletten

**LH-F-COMP-006 [SOLL]**

Mögliche Company-Dubletten sollen später erkennbar sein. Automatische Zusammenführung ohne Nutzerkontrolle soll vermieden werden.


---

# 13. Contact Management

## 13.1 Contact als eigenes Objekt

**LH-F-CONT-001 [PRODUKT-MUSS]**

Beruflich relevante Personen sollen als eigenständige Contacts verwaltet werden können.

Ein Contact kann mit mehreren Opportunities, Companies und Activities verbunden sein.

## 13.2 Schlanker beruflicher Datenkern

**LH-F-CONT-002 [SOLL]**

Sinnvolle Kerndaten sind:

- Name
- berufliche Rolle/Funktion
- Company
- berufliche E-Mail
- Telefonnummer
- Plattform-/LinkedIn-Profil
- Quelle des Kontakts
- FirstContactAt
- LastContactAt
- NextFollowUp
- beruflich relevante Notes

Der Contact-Bereich soll nicht zu einem umfangreichen privaten Personenprofil werden.

## 13.3 Beziehungshistorie

**LH-F-CONT-003 [PRODUKT-MUSS]**

LaunchPad soll später beantworten können:

- Wann entstand der erste Kontakt?
- Wann gab es zuletzt Kontakt?
- Welche Opportunities waren mit dieser Person verbunden?
- Welche Outcomes entstanden?
- Ist ein Follow-up fällig?
- Ist der Contact bereits über eine andere Plattform oder Quelle bekannt?

## 13.4 Sachliche Signale statt pauschaler Bewertung

**LH-F-CONT-004 [SOLL]**

Statt einer simplen Sternebewertung sollen nachvollziehbare berufliche Fakten bevorzugt werden.

Beispiele:

- Anzahl vermittelter Opportunities
- davon relevant
- Anzahl Proposals
- Responses
- Interviews
- Wins
- No Responses
- letzte Aktivität

Ein späterer Score ist kein Kernziel.

## 13.5 Follow-up

**LH-F-CONT-005 [SOLL]**

Der Nutzer soll später Wiedervorlagen für Kontakte setzen können.

Beispiele:

- in sechs Wochen wieder melden
- nach Projektende erneut kontaktieren
- nach Interview nachfassen

## 13.6 Private Informationen

**LH-F-CONT-006 [PRODUKT-MUSS]**

Private Lebensumstände sollen nicht als umfangreiche strukturierte Persönlichkeitsmerkmale gesammelt werden.

Beruflich relevante Gesprächskontexte dürfen in angemessenem Umfang als freie Interaction Notes dokumentiert werden, sofern ein nachvollziehbarer beruflicher Zweck besteht.

## 13.7 Aufbewahrung und Reduktion

**LH-F-CONT-007 [PRODUKT-MUSS]**

Personenbezogene Detailinformationen sollen später nach konfigurierbaren Aufbewahrungsregeln:

- behalten,
- reduzieren,
- anonymisieren,
- löschen

werden können.

Geschäftlich relevante aggregierte Erkenntnisse sollen soweit sinnvoll erhalten bleiben können.

## 13.8 Mehrere Kontaktwege

**LH-F-CONT-008 [SOLL]**

Ein Contact kann mehrere Kontaktwege besitzen.

Beispiele:

- E-Mail
- Telefon
- LinkedIn
- Plattformnachricht

Diese sollen langfristig flexibel modellierbar sein.

## 13.9 Contact-Dubletten

**LH-F-CONT-009 [SOLL]**

LaunchPad soll mögliche doppelte Contacts später erkennen können.

Automatische Zusammenführung ohne Nutzerkontrolle soll vermieden werden.

---

# 14. Activities, Interactions und Follow-ups

## 14.1 Gemeinsames Activity-Modell

**LH-F-ACT-001 [PRODUKT-MUSS]**

LaunchPad soll langfristig ein gemeinsames Activity-Modell verwenden.

Eine Activity ist ein zeitlich zuordenbares Ereignis oder eine geplante Aktion im Zusammenhang mit einer Opportunity, einem Proposal, einem Contact oder einer Company.

Dadurch sollen nicht für jede Art von Vorgang separate parallele Systeme entstehen.

## 14.2 Interaction als Untergruppe

**LH-F-ACT-002 [PRODUKT-MUSS]**

Eine Interaction ist fachlich eine Activity mit Kommunikationscharakter.

Beispiele:

- E-Mail
- Telefonat
- Videocall
- Plattformnachricht
- persönliches Gespräch

Ein eigenes paralleles Interaction-Kernmodell ist nicht erforderlich, solange Activity diese Anforderungen sauber abbildet.

## 14.3 Activity-Typen

**LH-F-ACT-003 [SOLL]**

Typische Activity-Typen sind:

- Proposal Submitted
- Email
- Platform Message
- Phone Call
- Video Call
- Meeting
- Interview
- Follow-up
- Offer
- Rejection
- Award
- Reminder

Die Liste soll erweiterbar sein.

## 14.4 Zeitmodell

**LH-F-ACT-004 [PRODUKT-MUSS]**

Activities sollen unterscheiden können zwischen:

- `OccurredAt` – vergangenes Ereignis
- `DueAt` – geplante Aktion
- `CompletedAt` – erledigte geplante Aktion

Damit können Follow-ups und vergangene Ereignisse im selben Modell abgebildet werden.

## 14.5 Flexible Verknüpfungen

**LH-F-ACT-005 [PRODUKT-MUSS]**

Eine Activity soll mit einem oder mehreren fachlichen Kontexten verbunden sein können:

- Opportunity
- Proposal
- Contact
- Company

## 14.6 Timeline

**LH-F-ACT-006 [SOLL]**

Relevante Activities sollen später in einer verständlichen chronologischen Timeline dargestellt werden können.

Beispiel:

```text
23.08.2026 09:03  Opportunity discovered
23.08.2026 09:41  Proposal submitted
24.08.2026 14:12  Response received
25.08.2026 10:00  Interview
27.08.2026 15:30  Rejected
```

## 14.7 Automatisch erzeugte Activities

**LH-F-ACT-007 [SOLL]**

Bestimmte fachlich relevante Ereignisse können später automatisch eine Activity erzeugen.

Beispiele:

- Proposal Submitted
- Opportunity Closed
- Follow-up Completed

Belanglose UI-Aktionen dürfen nicht zu einer Activity-Flut führen.

## 14.8 Follow-ups

**LH-F-ACT-008 [SOLL]**

Follow-ups sollen fachlich als geplante Activities behandelt werden können.

Dadurch können später Ansichten entstehen wie:

- heute fällig
- überfällig
- diese Woche
- erledigt

## 14.9 Activity Outcomes

**LH-F-ACT-009 [KANN]**

Für bestimmte Activity-Typen können optionale Outcomes sinnvoll sein.

Beispiele Telefonat:

- reached
- no answer
- voicemail
- follow-up required

Diese Angaben sollen nicht zum Pflichtformular für jede Interaktion werden.

---

# 15. Notes

## 15.1 Freie Notes

**LH-F-NOTE-001 [MVP-MUSS]**

Der Nutzer muss freie Notes zu Opportunities speichern können.

## 15.2 Zeitliche Nachvollziehbarkeit

**LH-F-NOTE-002 [SOLL]**

Langfristig sollen mehrere einzelne Notes mit Zeitstempel möglich sein.

Beispiel:

```text
23.08.2026 21:10
Projekt wirkt interessant, Rate fehlt.

24.08.2026 09:30
Vermittler telefonisch erreicht; Rate etwa 85 €/h.
```

Der MVP darf zunächst ein einfaches Notizfeld verwenden.

## 15.3 Notes an weiteren Objekten

**LH-F-NOTE-003 [PRODUKT-MUSS]**

Später sollen Notes möglich sein an:

- Opportunity
- Proposal
- Company
- Contact
- Activity

## 15.4 Note und Activity trennen

**LH-F-NOTE-004 [PRODUKT-MUSS]**

Eine Note beschreibt Gedanken oder Zusatzinformationen.

Eine Activity beschreibt ein Ereignis oder eine geplante Aktion.

Beide können später gemeinsam in einer Timeline erscheinen, bleiben fachlich aber unterscheidbar.

## 15.5 Suche in Notes

**LH-F-NOTE-005 [MVP-MUSS]**

Freie Notes müssen in der lokalen Suche berücksichtigt werden.

## 15.6 Kategorien und Tags

**LH-F-NOTE-006 [KANN]**

Notes können später optionale Kategorien oder Tags besitzen.

Sie dürfen keine Pflicht sein.

Mögliche Kategorien:

- General
- Evaluation
- Client
- Recruiter
- Rate
- Technical
- Follow-up
- Interview
- Risk

## 15.7 Pinned Notes

**LH-F-NOTE-007 [KANN]**

Wichtige Notes können später angeheftet werden.

## 15.8 Trennung von User Notes, Originaldaten und generierten Inhalten

**LH-F-NOTE-008 [PRODUKT-MUSS]**

User Notes dürfen nicht durch Import, automatische Zusammenfassungen oder AI-Ausgaben überschrieben werden.

Mindestens fachlich sollen unterscheidbar bleiben:

- Original Source Text
- User Notes
- Generated Summary

---

# 16. Skills und Skill Intelligence

## 16.1 Skills im frühen Produkt

**LH-F-SKILL-001 [MVP-MUSS]**

Opportunities müssen Skills bzw. relevante Keywords zugeordnet werden können.

Skills sollen mindestens für Suche und Filter nutzbar sein.

## 16.2 Skill-Herkunft

**LH-F-SKILL-002 [SOLL]**

Langfristig sollen folgende Herkunftstypen unterscheidbar sein:

- Platform Skill
- Detected Skill
- User Added Skill

Dadurch bleibt nachvollziehbar, ob ein Skill von der Quelle stammt, automatisch erkannt oder vom Nutzer ergänzt wurde.

## 16.3 Skill-Normalisierung und Aliases

**LH-F-SKILL-003 [SOLL]**

Unterschiedliche Schreibweisen desselben Skills sollen später zusammengeführt werden können.

Beispiele:

- PostgreSQL / Postgres
- Kubernetes / K8s
- C# / C Sharp
- .NET / dotnet

Der Originalbegriff soll soweit sinnvoll erhalten bleiben.

## 16.4 Keine frühe Übermodellierung

**LH-F-SKILL-004 [PRODUKT-MUSS]**

LaunchPad soll im frühen Produktstand keine umfangreiche Skill-Ontologie oder starre Taxonomie voraussetzen.

Hierarchien, Skill-Gruppen und Skill Evidence sollen erst eingeführt werden, wenn reale Daten einen Nutzen zeigen.

## 16.5 Skill-Häufigkeit und Trends

**LH-F-SKILL-005 [PRODUKT-MUSS]**

Später sollen analysierbar sein:

- Skill-Häufigkeit
- Skill-Trends über Zeit
- Plattformverteilung
- häufige Skill-Kombinationen

## 16.6 Skill-Erfolg

**LH-F-SKILL-006 [SOLL]**

Später soll untersucht werden können, welche Skills oder Skill-Kombinationen mit:

- Responses
- Interviews
- Wins
- höheren Rates

korrelieren.

## 16.7 Keine erfundenen Skills

**LH-F-SKILL-007 [PRODUKT-MUSS]**

LaunchPad darf aus Marktdaten nicht ableiten, dass der Nutzer Skills in ein Profil aufnehmen soll, die er tatsächlich nicht besitzt.

Stattdessen darf es beispielsweise sachlich darauf hinweisen:

> „Kubernetes erscheint häufig in ansonsten gut passenden Opportunities, ist im aktuellen Profil aber nicht prominent vertreten.“

---

# 17. Rate und Pricing Intelligence

## 17.1 Preisdimensionen strikt trennen

**LH-F-RATE-001 [PRODUKT-MUSS]**

Folgende Konzepte dürfen nicht in einem einzigen Feld vermischt werden:

- Advertised Budget
- Advertised Hourly Rate
- Advertised Daily Rate
- Own Proposed Price
- Own Proposed Hourly Rate
- Own Proposed Daily Rate
- Winning Bid, soweit bekannt

Zusätzlich müssen Mindest-/Maximalwerte und Currency berücksichtigt werden können.

## 17.2 Unbekannte Preise und Rates

**LH-F-RATE-002 [PRODUKT-MUSS]**

Unbekannte Preise und Rates sind ein normaler Zustand und kein Datenfehler.

Filter und Analytics müssen unbekannte Werte eindeutig behandeln. Eine spezielle Boolesche Filtersprache für `OR unknown` ist keine frühe Produktanforderung.

## 17.3 Eigenes Angebot getrennt vom Marktpreis

**LH-F-RATE-003 [PRODUKT-MUSS]**

Es gilt:

```text
Advertised Price != Proposed Price != Winning Price
```

Beispiel:

```text
Kunde nennt: 60–80 €/h
Eigenes Angebot: 90 €/h
Winning Rate: unbekannt
```

## 17.4 Originalwährung erhalten

**LH-F-RATE-004 [PRODUKT-MUSS]**

Originalwert und Originalwährung sollen unverändert erhalten bleiben.

Spätere Umrechnungen in eine gemeinsame Vergleichswährung sind abgeleitete Werte.

## 17.5 Eigene Rate-Historie

**LH-F-RATE-005 [SOLL]**

Eigene Plattform-Rates sollen später historisch speicherbar sein.

Damit kann nachvollzogen werden, ob Rate-Änderungen mit veränderten Outcomes korrelieren.

## 17.6 Plattformgebühren

**LH-F-RATE-006 [SOLL]**

Später können Plattformgebühren berücksichtigt werden, um nominelle und geschätzte Net Rates besser zu vergleichen.

## 17.7 Effektiver Satz

**LH-F-RATE-007 [KANN]**

Ein effektiver Satz kann später optional aus Projektpreis und manuell eingetragenem tatsächlichem Aufwand abgeleitet werden.

LaunchPad soll dafür keinen Time Tracker voraussetzen.

## 17.8 Pricing Analytics

**LH-F-RATE-008 [PRODUKT-MUSS]**

Mögliche Analysen:

- Median
- Durchschnitt
- Perzentile
- Rate nach Skill
- Rate nach Skill-Kombination
- Rate nach Plattform
- Rate nach Projekttyp
- Rate nach Remote-Anteil
- Rate über Zeit
- Own Rate vs. Response
- Own Rate vs. Win

## 17.9 Datenmenge und Unsicherheit

**LH-F-RATE-009 [PRODUKT-MUSS]**

Analytics müssen die zugrunde liegende Datenbasis sichtbar machen.

Beispiel:

```text
Median: 88 €/h
Datenbasis: 7 Opportunities
Aussagekraft: gering
```

LaunchPad soll keine Scheingenauigkeit erzeugen.

## 17.10 Markt und persönliche Ergebnisse getrennt

**LH-F-RATE-010 [PRODUKT-MUSS]**

LaunchPad soll unterscheiden:

### Marktperspektive
Was wird ausgeschrieben?

### persönliche Perspektive
Mit welchem eigenen Preis oder Satz entstehen Responses, Interviews oder Wins?

## 17.11 Keine automatische Preissenkung

**LH-F-RATE-011 [PRODUKT-MUSS]**

Pricing Intelligence soll Entscheidungsunterstützung liefern und keine automatische Unterbietungsstrategie erzeugen.

Der Nutzer entscheidet.

## 17.12 Mindest- und Zielrate

**LH-F-RATE-012 [SOLL]**

Später können persönliche Referenzwerte hinterlegt werden:

- Minimum Rate
- Target Rate
- gegebenenfalls Desired Rate

Diese Werte dienen Hinweisen und dürfen nicht zwingend als automatische Ausschlusskriterien wirken.

## 17.13 Keine stillschweigende Umrechnung zwischen Vergütungsarten

**LH-F-RATE-013 [PRODUKT-MUSS]**

Hourly Rate, Daily Rate und Fixed Price dürfen nicht ohne explizite Annahmen ineinander umgerechnet werden.

Beispielsweise ist ein Tagessatz nicht automatisch durch Division durch acht ein Stundensatz. Vertragsbedingungen, Tageslänge, Rabatte, Mindestabnahmen oder andere Konditionen können den tatsächlichen wirtschaftlichen Vergleich verändern.

Wenn später Vergleichswerte abgeleitet werden, müssen die verwendeten Annahmen nachvollziehbar sein.

---

# 18. Funnel Analytics

## 18.1 Persönlicher Funnel

**LH-F-ANL-001 [PRODUKT-MUSS]**

LaunchPad soll später den persönlichen Opportunity-/Proposal-Funnel auswerten können.

Konzeptionell:

```text
Discovered
→ Reviewed
→ Qualified
→ Proposal Sent
→ Response
→ Interview
→ Offer
→ Won
```

Nicht jede Opportunity muss alle Stufen durchlaufen.

## 18.2 Funnel aus echten Domänendaten ableiten

**LH-F-ANL-002 [PRODUKT-MUSS]**

Der Funnel soll möglichst aus:

- Opportunities
- Proposals
- Activities
- Outcomes

abgeleitet werden.

Ein separates manuell gepflegtes FunnelStage-Feld soll vermieden werden, wenn dadurch Inkonsistenzen entstehen könnten.

## 18.3 Reviewed und Qualified

**LH-F-ANL-003 [PRODUKT-MUSS]**

Automatisch gefundene Opportunities dürfen nicht sofort als aktiv bearbeitete Chancen gezählt werden.

Langfristig soll unterschieden werden:

- Discovered
- Reviewed
- Qualified

`Interesting` kann zusätzlich eine persönliche Einschätzung sein.

## 18.4 No Response

**LH-F-ANL-004 [PRODUKT-MUSS]**

`No Response` soll als relevante analytische Kategorie berücksichtigt werden können.

Sie darf beispielsweise verwendet werden, wenn ein Proposal vom Nutzer mit `TimedOutByUser` geschlossen wurde und bis dahin keine Response dokumentiert ist. `No Response` soll nicht allein aufgrund eines starren Zeitablaufs als gesicherte externe Absage interpretiert werden.

## 18.5 Conversion Rates

**LH-F-ANL-005 [PRODUKT-MUSS]**

Beispiele:

- Reviewed → Qualified
- Qualified → Proposal
- Proposal → Response
- Response → Interview
- Interview → Offer
- Offer → Win

Die zugrunde liegenden absoluten Zahlen müssen sichtbar bleiben.

## 18.6 Zeitkennzahlen

**LH-F-ANL-006 [SOLL]**

Später sollen analysiert werden können:

- Publication → Discovery
- Discovery → Review
- Discovery → Proposal
- Proposal → Response
- Response → Interview
- Proposal → Outcome

## 18.7 Segmentierung

**LH-F-ANL-007 [SOLL]**

Funnel-Ergebnisse sollen später segmentierbar sein nach:

- Plattform
- Skill
- Search Profile
- Vermittler
- Endkunde
- Rate-Bereich
- Remote-Anteil
- Zeitraum

## 18.8 Keine Gamification

**LH-F-ANL-008 [PRODUKT-MUSS]**

Der Funnel ist ein Analysewerkzeug und kein Produktivitätsdruck-System.

Mehr Proposals sind nicht automatisch besser.

## 18.9 Historische Vergleiche

**LH-F-ANL-009 [SOLL]**

Später können Zeiträume oder Veränderungen verglichen werden, beispielsweise:

- Q3 vs. Q4
- vor/nach Rate-Änderung
- vor/nach Profiländerung

Korrelation darf nicht automatisch als Ursache dargestellt werden.

---

# 19. Relationship Analytics

## 19.1 Priorität

Relationship Analytics ist ein späterer Ausbau und kein MVP-Blocker.

## 19.2 Sachliche Kennzahlen

**LH-F-REL-001 [SOLL]**

Später können zu Contacts oder Companies beispielsweise dargestellt werden:

- Opportunities
- relevante Opportunities
- Proposals
- Responses
- Interviews
- Wins
- No Responses
- durchschnittliche Reaktionszeit
- letzte Aktivität

## 19.3 Contact und Company getrennt

**LH-F-REL-002 [SOLL]**

Contact- und Company-Erfahrungen sollen getrennt analysiert werden.

Ein guter Contact kann innerhalb einer weniger interessanten Company existieren und umgekehrt.

## 19.4 Wiederkehrende Beziehungen

**LH-F-REL-003 [SOLL]**

LaunchPad soll später erkennen können:

- „Mit diesem Contact gab es bereits Kontakt.“
- „Diese Company ist bereits bei mehreren Opportunities aufgetaucht.“

## 19.5 Plattformübergreifende Historie

**LH-F-REL-004 [SOLL]**

Berufliche Beziehungen sollen langfristig plattformübergreifend betrachtet werden können.

Die Plattform ist der Fundort, nicht die Identität des Contacts oder der Company.

## 19.6 Negative Erfahrungen sachlich erhalten

**LH-F-REL-005 [SOLL]**

LaunchPad soll negative Erfahrungen nicht pauschal als Blacklist behandeln, sondern sachlich sichtbar machen.

Beispiel:

> „7 passende Opportunities, 5 Proposals, keine Response.“

## 19.7 Keine private Personenprofilierung

**LH-F-REL-006 [PRODUKT-MUSS]**

Relationship Analytics basiert auf beruflichen Interaktionen und Outcomes, nicht auf privaten Eigenschaften natürlicher Personen.

---

# 20. Profile Intelligence

## 20.1 Priorität

Profile Intelligence ist ein späterer Produktbereich und kein MVP-Blocker.

## 20.2 Eigene Profile lokal abbilden

**LH-F-PROF-001 [SOLL]**

Der Nutzer soll später eigene Plattformprofile lokal dokumentieren können.

Mögliche Inhalte:

- Profilbeschreibung
- Skills
- Rate
- Verfügbarkeit
- Sprachen
- Positionierung
- Portfolio-Referenzen

## 20.3 Profile Snapshot

**LH-F-PROF-002 [SOLL]**

Wichtige Änderungen am eigenen Profil sollen später als zeitliche Snapshots gespeichert werden können.

## 20.4 Visibility Metrics

**LH-F-PROF-003 [KANN]**

Soweit Plattformen entsprechende Daten zugänglich machen, können später gespeichert werden:

- Profile Views
- Invitations
- Impressions
- Clicks
- Portfolio Views

## 20.5 Markt-vs.-Profil-Analyse

**LH-F-PROF-004 [SOLL]**

LaunchPad soll später Hinweise auf relevante Lücken zwischen real beobachteten Marktanforderungen und dem eigenen Profil geben können.

Beispiel:

> „Ansible erscheint häufig in gut passenden Opportunities, ist im aktuellen Profil aber wenig sichtbar.“

## 20.6 Keine erfundenen Qualifikationen

**LH-F-PROF-005 [PRODUKT-MUSS]**

Profile Intelligence darf nicht zur Angabe nicht vorhandener Fähigkeiten verleiten.

---

# 21. Opportunity Fit und Decision Support

## 21.1 Manuelle Bewertung zuerst

**LH-F-FIT-001 [SOLL]**

Der Nutzer soll Opportunities zunächst selbst bewerten können.

Geeignete frühe Aspekte sind:

- persönliches Interesse
- fachlicher Fit
- Rate attraktiv
- Remote passend
- derzeit verfügbar

## 21.2 Automatischer Fit Score

**LH-F-FIT-002 [KANN]**

Später kann ein erklärbarer Opportunity Fit Score berechnet werden.

Mögliche Faktoren:

- Skill Fit
- Rate Fit
- Remote Fit
- Location Fit
- Availability Fit
- Contract Type Fit
- Duration Fit
- Language Fit
- Experience Fit
- Competition Signal
- Company/Vendor Experience

## 21.3 Nutzergewichtung

**LH-F-FIT-003 [SOLL]**

Gewichtungen sollen später durch den Nutzer oder Search Profiles beeinflussbar sein.

## 21.4 Search-Profile-spezifische Prioritäten

**LH-F-FIT-004 [SOLL]**

Unterschiedliche Search Profiles dürfen unterschiedliche Prioritäten besitzen.

Beispiel:

```text
Linux Remote:
Remote = sehr wichtig
Linux/Unix = sehr wichtig
Rate = wichtig

C# Desktop:
C#/.NET = sehr wichtig
WinForms/WPF = hoch
Remote = hoch
```

## 21.5 Hard Filter und Soft Fit trennen

**LH-F-FIT-005 [PRODUKT-MUSS]**

Hard Filter entscheiden, welche Opportunities überhaupt angezeigt werden.

Soft Fit priorisiert sichtbare Opportunities.

Beide Mechanismen dürfen nicht vermischt werden.

## 21.6 Fehlende Daten nicht bestrafen

**LH-F-FIT-006 [PRODUKT-MUSS]**

Unbekannte Werte sollen als unbekannt behandelt werden und nicht automatisch negativ wirken.

## 21.7 Explainable Fit

**LH-F-FIT-007 [PRODUKT-MUSS]**

Ein Score muss erklären können, welche Faktoren zu seinem Ergebnis beigetragen haben.

## 21.8 Nutzerentscheidung hat Vorrang

**LH-F-FIT-008 [PRODUKT-MUSS]**

Eine automatisch niedrig bewertete Opportunity muss vom Nutzer jederzeit trotzdem priorisiert oder als interessant markiert werden können.

---

# 22. Import und Capture

## 22.1 Grundprinzip

**LH-F-IMP-001 [PRODUKT-MUSS]**

Bereits vorhandene Informationen sollen möglichst übernommen und nicht erneut abgetippt werden müssen.

Manuelle Erfassung bleibt jederzeit verfügbar.

## 22.2 Capture-Stufen

Die fachliche Entwicklungsrichtung lautet:

```text
Manual Entry
↓
Paste Capture
↓
URL Capture
↓
Browser Helper
↓
Automated Discovery
```

Die konkrete Release-Reihenfolge gehört ausschließlich in die Roadmap.

## 22.3 Manuelle Erfassung

**LH-F-IMP-002 [MVP-MUSS]**

Die Anwendung muss ohne automatisierten Import vollständig für den MVP-Workflow nutzbar sein.

## 22.4 Paste Capture

**LH-F-IMP-003 [PRODUKT-MUSS]**

Kopierter Ausschreibungstext soll später schnell übernommen und strukturiert werden können.

Mögliche erkannte Informationen:

- Titel
- Beschreibung
- Skills
- Budget/Rate
- Startdatum
- Laufzeit
- Remote
- Vermittler
- Endkunde, soweit erkennbar

## 22.5 URL Capture

**LH-F-IMP-004 [PRODUKT-MUSS]**

Eine angegebene unterstützte Fundstellen-URL soll soweit technisch und rechtlich möglich direkt ausgewertet werden können.

## 22.6 Importvorschau

**LH-F-IMP-005 [PRODUKT-MUSS]**

Vor dem endgültigen Speichern automatisch erkannter Daten soll der Nutzer eine Vorschau erhalten und Werte korrigieren können.

## 22.7 Partial Import

**LH-F-IMP-006 [PRODUKT-MUSS]**

Ein unvollständiger Import ist zulässig.

Beispiel:

```text
✓ Titel
✓ Beschreibung
✓ Skills
? Rate
? Endkunde
```

Fehlende Werte dürfen ergänzt werden.

## 22.8 Importierte und eigene Daten trennen

**LH-F-IMP-007 [PRODUKT-MUSS]**

Ein Quellwert und eine spätere Nutzerkorrektur sollen nicht stillschweigend dasselbe sein.

Für den frühen Produktstand genügt eine einfache nachvollziehbare Trennung; eine komplexe Provenance-Struktur pro Feld ist nicht erforderlich.

## 22.9 Originalbeschreibung erhalten

**LH-F-IMP-008 [PRODUKT-MUSS]**

Die ursprüngliche relevante Beschreibung einer Fundstelle soll möglichst unverändert erhalten bleiben.

Strukturierte Felder, Zusammenfassungen und erkannte Skills sind davon getrennte Informationen.

## 22.10 Unsicherheit zulassen

**LH-F-IMP-009 [PRODUKT-MUSS]**

Ein Parser darf bei Unsicherheit lieber `unknown` liefern als einen Wert zu erfinden.

## 22.11 Technische Duplikatprüfung beim Import

**LH-F-IMP-010 [PRODUKT-MUSS]**

Beim Import soll geprüft werden, ob dieselbe Fundstelle bereits bekannt ist.

Sichere Hinweise sind insbesondere:

- gleiche Platform + externe ID
- gleiche URL

Bei einer technischen Dublette soll beispielsweise angeboten werden:

- vorhandene Opportunity/Fundstelle öffnen
- neuen beobachteten Stand ergänzen
- Import abbrechen

## 22.12 Weitere Fundstelle desselben Projekts

**LH-F-IMP-011 [SOLL]**

Wenn eine neue Fundstelle wahrscheinlich ein bereits bekanntes reales Projekt beschreibt, soll sie später derselben Opportunity zugeordnet werden können.

Bei Unsicherheit erfolgt keine automatische aggressive Zuordnung.

## 22.13 Browser Helper

**LH-F-IMP-012 [SOLL]**

Ein späterer Browser-Helfer kann die gerade geöffnete Fundstelle an LaunchPad übergeben.

Dies kann vorhandene Browser-Sessions nutzen, ohne Plattformpasswörter in LaunchPad speichern zu müssen.

## 22.14 Automatische Skill-Erkennung

**LH-F-IMP-013 [SOLL]**

LaunchPad kann später zusätzliche Skills aus Beschreibungstexten erkennen.

Die Herkunft erkannter Skills soll nachvollziehbar bleiben.

## 22.15 Erneuter Import

**LH-F-IMP-014 [SOLL]**

Ein erneuter Import einer bekannten Fundstelle soll später relevante Änderungen erkennen können, anstatt vorhandene Daten blind zu überschreiben.

## 22.16 Importhistorie

**LH-F-IMP-015 [SOLL]**

Später soll nachvollziehbar sein:

- wann importiert wurde,
- von welcher Platform/Fundstelle,
- ob der Import erfolgreich, teilweise oder fehlgeschlagen war.

## 22.17 Plattformautomation

**LH-F-IMP-016 [PRÜFEN]**

Automatisierte regelmäßige Plattformabfragen werden erst nach technischer und rechtlicher Prüfung umgesetzt.

# 23. Export, Backup und Datenportabilität

## 23.1 Datenhoheit

**LH-F-EXP-001 [PRODUKT-MUSS]**

Vom Nutzer erzeugte und gesammelte Daten müssen lokal sicherbar und in dokumentierten bzw. offenen Formaten exportierbar sein.

> **Die Daten dürfen nicht zu einer proprietären Datenfalle werden.**

## 23.2 Backup

**LH-F-EXP-002 [MVP-MUSS]**

Ein vollständiges lokales Backup muss früh möglich sein.

Mindestens soll eine verständliche Möglichkeit bestehen, die vollständige lokale Datenbasis zu sichern.

In der lokalen Desktop-Version bleibt die sichere Aufbewahrung externer Backup-Medien grundsätzlich Aufgabe des Nutzers. Eine eingebaute Verschlüsselungs- oder Enterprise-Backup-Verwaltung ist keine frühe Produktanforderung.

## 23.3 Restore

**LH-F-EXP-003 [PRODUKT-MUSS]**

Backups müssen später benutzerfreundlich wiederherstellbar sein.

## 23.4 Vollständiger Export und Listenexport

**LH-F-EXP-004 [PRODUKT-MUSS]**

Langfristig sollen unterschieden werden:

### vollständiger Datenexport
für Migration, Archivierung oder externe Verarbeitung.

### Listen-/Analyseexport
für konkrete Arbeitszwecke.

## 23.5 CSV

**LH-F-EXP-005 [SOLL]**

Flache Listen und Analysedaten sollen als CSV exportierbar sein.

## 23.6 JSON

**LH-F-EXP-006 [PRODUKT-MUSS]**

Strukturierte vollständige Exporte sollen langfristig als dokumentiertes JSON-Format möglich sein.

## 23.7 Datenbank-/Backup-Paket

**LH-F-EXP-007 [PRODUKT-MUSS]**

Ein vollständiges Backup kann langfristig Datenbank, Metadaten und gegebenenfalls Attachments in einem Paket enthalten.

## 23.8 Attachments

**LH-F-EXP-008 [PRODUKT-MUSS]**

Ein vollständiges Backup muss später auch gespeicherte Attachments bzw. Source-Artefakte enthalten.

## 23.9 Backup-Versionierung

**LH-F-EXP-009 [PRODUKT-MUSS]**

Backups sollen eine Format-/Schema-Version enthalten können, damit spätere Releases ältere Sicherungen erkennen und migrieren können.

## 23.10 Selektiver Export

**LH-F-EXP-010 [SOLL]**

Später sollen Teilmengen exportierbar sein, beispielsweise:

- Zeitraum
- Plattform
- Search Profile
- Opportunities
- Proposals
- Contacts
- Analytics

## 23.11 Personenbezogene Daten im Export

**LH-F-EXP-011 [PRODUKT-MUSS]**

Der Nutzer soll später entscheiden können, ob personenbezogene Daten:

- enthalten,
- ausgeschlossen,
- anonymisiert

werden.

## 23.12 Export für externe Analyse

**LH-F-EXP-012 [SOLL]**

Ausgewählte Datensätze sollen später beispielsweise für externe oder AI-gestützte Analyse exportierbar sein, ohne unnötige personenbezogene Daten mitzugeben.

## 23.13 Automatische Backups

**LH-F-EXP-013 [SOLL]**

Später können konfigurierbare automatische Backups unterstützt werden.

## 23.14 Backup-Rotation und Integritätsprüfung

**LH-F-EXP-014 [KANN]**

Spätere stabile Releases können Backup-Rotation und Integritätsprüfungen unterstützen.

## 23.15 Migration auf neuen Rechner

**LH-F-EXP-015 [PRODUKT-MUSS]**

Ein Backup/Restore soll langfristig einen einfachen Umzug auf einen neuen Rechner ermöglichen.

## 23.16 Originalausschreibungstexte im Export

**LH-F-EXP-016 [SOLL]**

Vollständige Exporte dürfen die lokal gespeicherten Originalausschreibungstexte enthalten.

Für selektive oder externe Exporte soll eine einfache Option vorgesehen werden können, die Originalausschreibungstexte auszuschließen.

Damit kann der Nutzer beispielsweise strukturierte Markt- und Proposal-Daten exportieren, ohne zwangsläufig alle übernommenen Ausschreibungstexte mitzugeben.

---

# 24. Notifications

## 24.1 Grundprinzip

**LH-F-NOT-001 [PRODUKT-MUSS]**

Notifications sollen einen klaren Handlungswert besitzen.

Sie sollen konfigurierbar, unaufdringlich und verständlich sein.

## 24.2 Neue Opportunities

**LH-F-NOT-002 [SOLL]**

Bei automatisierter Discovery können neue passende Opportunities signalisiert werden.

Bevorzugt zusammengefasst:

> `Linux Remote: 8 neue Treffer`

statt vieler einzelner Popups.

## 24.3 Follow-ups

**LH-F-NOT-003 [SOLL]**

Fällige oder überfällige Follow-ups können später erinnert werden.

## 24.4 Opportunity Changes

**LH-F-NOT-004 [KANN]**

Wichtige Veränderungen beobachteter Opportunities können gemeldet werden.

Beispiele:

- geschlossen
- Budget geändert
- Rate geändert
- Award bekannt

## 24.5 Proposal Events

**LH-F-NOT-005 [KANN]**

Soweit entsprechende Informationen zuverlässig verfügbar sind, können relevant sein:

- Proposal viewed
- Response
- Interview
- Award
- Rejection

## 24.6 Digests

**LH-F-NOT-006 [SOLL]**

Zusammenfassungen sollen bei vielen Ereignissen einzelnen Popup-Meldungen vorgezogen werden können.

Beispiel:

```text
Seit gestern:
14 neue Opportunities
2 beobachtete Opportunities geändert
1 Follow-up fällig
```

## 24.7 Notification-Kanäle

**LH-F-NOT-007 [SOLL]**

Zunächst sinnvoll:

- In-App Notification Center
- Windows Toast
- Tray-Hinweis

E-Mail, Mobile Push und ähnliche externe Kanäle sind kein früher Kern.

## 24.8 Konfiguration und Ruhezeiten

**LH-F-NOT-008 [PRODUKT-MUSS]**

Notifications müssen abschaltbar und konfigurierbar sein.

Später können Ruhezeiten unterstützt werden.

## 24.9 Keine Gamification

**LH-F-NOT-009 [PRODUKT-MUSS]**

LaunchPad soll keine Meldungen erzeugen, die künstlichen Bewerbungs- oder Produktivitätsdruck aufbauen.

## 24.10 Intelligente Meldungen erklären

**LH-F-NOT-010 [PRODUKT-MUSS]**

Wenn LaunchPad später eine Opportunity als besonders passend meldet, soll nachvollziehbar sein, warum.


---

# 25. Datenschutz und personenbezogene Daten

## 25.1 Datenschutz als Produktprinzip

**LH-DP-001 [PRODUKT-MUSS]**

LaunchPad speichert nur Daten, die für Opportunity Management, Proposal-Verfolgung, Marktbeobachtung, professionelle Beziehungspflege oder nachvollziehbare Analyse einen legitimen und verständlichen Zweck erfüllen.

Das Ziel lautet nicht, Daten um jeden Preis zu minimieren. Das Ziel lautet:

> **so viel wie nötig, so wenig wie unnötig.**

## 25.2 Local-first als Schutzmechanismus

**LH-DP-002 [MVP-MUSS]**

Die persönliche Wissensbasis soll im Kern lokal gespeichert werden.

Damit müssen berufliche Kontakte, Proposals, Notes und Marktdaten nicht zwangsläufig an einen Cloud-Dienst übertragen werden.

Spätere externe Funktionen sind möglich, dürfen aber nicht die lokale Datenhoheit aufheben.

## 25.3 Datenklassen

**LH-DP-003 [PRODUKT-MUSS]**

Fachlich sollen mindestens folgende Kategorien unterschieden werden können:

### Marktdaten

Beispiele:

- Budget
- Rate
- Skills
- Veröffentlichungsdatum
- Opportunity State
- Proposal Count
- Observations
- öffentlich bekannte Award-Signale

### berufliche personenbezogene Daten

Beispiele:

- Name eines Recruiters
- berufliche E-Mail
- berufliche Telefonnummer
- Rolle
- Company
- berufliche Interaction History

### private oder besonders sensible Informationen

Diese sollen grundsätzlich nicht als reguläre strukturierte LaunchPad-Felder vorgesehen werden.

## 25.4 Aufbewahrung nach Datenart

**LH-DP-004 [PRODUKT-MUSS]**

Personenbezogene Detailinformationen sollen später nach konfigurierbaren Regeln:

- behalten,
- reduzieren,
- anonymisieren,
- löschen

werden können.

Die Aufbewahrung darf je Datenart unterschiedlich sein.

Beispielsweise kann eine historische Rate langfristig analytisch wertvoll sein, während eine alte Telefonnummer nach mehreren Jahren keinen Nutzen mehr besitzt.

## 25.5 Geschäftserkenntnis trotz Datenreduktion erhalten

**LH-DP-005 [PRODUKT-MUSS]**

Wenn personenbezogene Details nicht mehr benötigt werden, sollen sachliche Geschäftserkenntnisse soweit sinnvoll erhalten bleiben können.

Beispiel vorher:

```text
Contact: Max Mustermann
Telefon: ...
E-Mail: ...
Company: Example Recruiting GmbH
8 Opportunities
5 Proposals
0 Responses
```

Mögliche spätere Reduktion:

```text
Ehemaliger Contact bei Example Recruiting GmbH
8 Opportunities
5 Proposals
0 Responses
```

Damit kann die Lernerfahrung erhalten bleiben, ohne unnötig Detaildaten dauerhaft vorzuhalten.

## 25.6 Keine blinde automatische Löschung

**LH-DP-006 [PRODUKT-MUSS]**

Retention-Regeln sollen nicht ohne Nutzerkontrolle irreversibel löschen.

Bevorzugt ist ein kontrollierter Ablauf, beispielsweise:

> „23 Contacts überschreiten die definierte Aufbewahrungsfrist. Prüfen?“

Mögliche Entscheidungen:

- behalten
- Frist verlängern
- Details reduzieren
- anonymisieren
- vollständig löschen

## 25.7 Freie Notes

**LH-DP-007 [PRODUKT-MUSS]**

Freie Notes sollen primär beruflich zweckgebunden bleiben.

LaunchPad soll keine strukturierten Felder anbieten, die zur Sammlung unnötiger privater Eigenschaften ermutigen.

Eine technische vollständige Kontrolle freier Texte ist nicht Ziel des Produkts.

## 25.8 Rohdaten und abgeleitete Erkenntnisse

**LH-DP-008 [PRODUKT-MUSS]**

LaunchPad soll fachlich unterscheiden können zwischen:

- personenbezogener Rohinformation
- sachlich abgeleiteter Geschäftserkenntnis

Dadurch kann eine spätere Anonymisierung möglich werden, ohne jede historische Erkenntnis zu verlieren.

## 25.9 Exporte und Datenschutz

**LH-DP-009 [PRODUKT-MUSS]**

Bei Exporten soll langfristig auswählbar sein, ob personenbezogene Daten enthalten werden.

Beispiel:

Ein Export `Linux Market Analysis` kann Opportunity-, Skill-, Rate- und Outcome-Daten enthalten, ohne Namen, E-Mail-Adressen oder Telefonnummern zu exportieren.

## 25.10 AI und externe Verarbeitung

**LH-DP-010 [PRODUKT-MUSS]**

Wenn LaunchPad später externe AI-Dienste nutzt, muss transparent sein, welche Daten übertragen werden.

Soweit sinnvoll soll eine Option bestehen, personenbezogene Daten vor externer Analyse zu reduzieren oder zu entfernen.

## 25.11 Credentials

**LH-DP-011 [PRODUKT-MUSS]**

Plattformpasswörter sollen nicht in der normalen LaunchPad-Datenbasis gespeichert werden.

Bevorzugt sind:

- Browser-Session
- OAuth
- offizielle Tokens
- Betriebssystem-Credential-Store

Die konkrete technische Lösung gehört in das Sicherheits-/Architekturdokument.

## 25.12 Löschung ohne unnötige Historienzerstörung

**LH-DP-012 [PRODUKT-MUSS]**

Das Löschen oder Anonymisieren eines Contacts darf nicht unnötig:

- Opportunity-Historie
- Marktdaten
- Proposal-Historie
- aggregierte Erkenntnisse

zerstören.

## 25.13 Transparenz

**LH-DP-013 [SOLL]**

Die Anwendung soll später verständlich anzeigen können:

- welche Daten gespeichert werden,
- wo sie gespeichert werden,
- welche Retention-Regeln gelten,
- wann zuletzt ein Backup erstellt wurde.

## 25.14 Keine heimliche Personenprofilierung

**LH-DP-014 [PRODUKT-MUSS]**

LaunchPad soll keine versteckte oder manipulative Bewertung natürlicher Personen aus privaten Merkmalen erzeugen.

Relationship Signals dürfen auf beruflichen Fakten beruhen, beispielsweise:

- Opportunities
- Responses
- Interviews
- Outcomes
- Follow-ups

nicht auf privaten Lebensumständen.

---

# 26. Nichtfunktionale Anforderungen

## 26.1 Bedienbarkeit

**LH-NF-001 [MVP-MUSS]**

Häufige Aktionen sollen mit wenigen Schritten möglich sein.

Insbesondere:

- Opportunity erfassen oder übernehmen
- Opportunity wiederfinden
- Status ändern
- Note ergänzen
- Source URL öffnen
- Proposal Lite dokumentieren
- Filter anwenden

Häufige Arbeitsabläufe sollen ohne unnötige Dialogketten auskommen.

## 26.2 Responsive lokale Performance

**LH-NF-002 [MVP-MUSS]**

Lokale Listen, Suche und Filter sollen sich bei typischer Einzelanwender-Datenmenge direkt und responsiv anfühlen.

Das Lastenheft schreibt keine künstlichen Millisekundenwerte vor, verlangt aber eine für tägliche Desktop-Nutzung angemessene Reaktionsgeschwindigkeit.

## 26.3 Stabilität

**LH-NF-003 [MVP-MUSS]**

Fehlerhafte Eingaben, einzelne Importprobleme oder einzelne fehlerhafte Datensätze dürfen nicht unnötig zum vollständigen Programmabbruch führen.

## 26.4 Fehlerisolation

**LH-NF-004 [PRODUKT-MUSS]**

Fehler sollen lokal begrenzt bleiben.

Eine fehlerhafte Plattformintegration darf nicht:

- andere Quellen blockieren,
- lokale Suche verhindern,
- vorhandene Daten unzugänglich machen.

## 26.5 Datenintegrität

**LH-NF-005 [MVP-MUSS]**

Gespeicherte Daten müssen zuverlässig erhalten bleiben.

Kritische zusammengehörige Änderungen sollen technisch so umgesetzt werden, dass inkonsistente Teilzustände vermieden werden.

## 26.6 Wartbarkeit

**LH-NF-006 [PRODUKT-MUSS]**

Neue Plattformintegrationen, Filterkriterien und spätere Analysefunktionen sollen ohne grundlegenden Umbau der gesamten Anwendung ergänzt werden können.

## 26.7 Code-Verständlichkeit

**LH-NF-007 [PRODUKT-MUSS]**

Der Code soll nachvollziehbar und wartbar sein.

Dazu gehören:

- klare Benennung
- XML-Kommentare an öffentlichen APIs
- sinnvolle Inline-Kommentare bei nicht offensichtlicher Logik
- keine unnötig komplizierte oder „clevere“ Magie
- dokumentierte Architekturentscheidungen

## 26.8 Offline-Fähigkeit

**LH-NF-008 [MVP-MUSS]**

Alle Funktionen, die keine aktuellen externen Plattformdaten benötigen, sollen offline funktionieren.

Dazu gehören mindestens:

- vorhandene Opportunities ansehen
- suchen
- filtern
- Notes bearbeiten
- Proposal-Daten pflegen
- lokale Analytics auf bereits vorhandenen Daten
- Backup/Export

## 26.9 Graceful Degradation

**LH-NF-009 [PRODUKT-MUSS]**

Externe Ausfälle dürfen die lokale Anwendung nicht unnötig beeinträchtigen.

## 26.10 Erweiterbarkeit

**LH-NF-010 [PRODUKT-MUSS]**

Die Architektur soll funktionale Erweiterungen ermöglichen für:

- Plattformintegrationen
- Importer
- Exporter
- Analytics
- Notifications
- spätere AI-Hilfen

Ein öffentliches Plugin-System ist kein MVP-MUSS.

## 26.11 Security by default

**LH-NF-011 [PRODUKT-MUSS]**

Sichere Defaults sind zu bevorzugen.

Beispiele:

- keine unnötige Credential-Speicherung
- externe Übertragungen transparent
- sensible Einstellungen nicht unnötig im Klartext
- externe Funktionen standardmäßig kontrollierbar

## 26.12 Logging

**LH-NF-012 [SOLL]**

Sinnvolles Logging soll möglich sein für:

- Start/Stop
- Importversuche
- Fehler externer Plattformintegrationen
- Datenbankfehler
- Migrationen
- Backups
- kritische Exceptions

Logs sollen keine unnötigen personenbezogenen oder vertraulichen Inhalte enthalten.

## 26.13 Verständliche Fehlermeldungen

**LH-NF-013 [MVP-MUSS]**

Benutzerfehlermeldungen sollen handlungsorientiert sein.

Beispiel gut:

> „Die Opportunity konnte nur teilweise importiert werden. Titel und Beschreibung wurden übernommen; die Rate konnte nicht erkannt werden.“

Technische Details dürfen zusätzlich im Log stehen.

## 26.14 Bildschirmauflösung

**LH-NF-014 [MVP-MUSS]**

Die Anwendung soll mindestens ab **1280 × 720 Pixeln** bei üblicher Windows-Skalierung sinnvoll nutzbar sein.

## 26.15 Tastaturbedienung

**LH-NF-015 [SOLL]**

Häufige Aktionen sollen langfristig effizient per Tastatur bedienbar sein.

Beispiele:

- Suche fokussieren
- Dialog bestätigen/abbrechen
- Status ändern
- Opportunity öffnen

## 26.16 Accessibility

**LH-NF-016 [SOLL]**

Grundlegende Zugänglichkeit soll berücksichtigt werden:

- ausreichende Kontraste
- keine Information ausschließlich durch Farbe
- lesbare Schriftgrößen
- skalierbare UI
- sinnvolle Standard-Controls

## 26.17 Windows-first

**LH-NF-017 [PRODUKT-MUSS]**

LaunchPad ist zunächst Windows-first.

Das fachliche Modell und die Kernlogik sollen jedoch nicht unnötig an UI-spezifische Windows-Details gekoppelt werden.

## 26.18 Startzeit

**LH-NF-018 [SOLL]**

LaunchPad soll ohne unnötige Verzögerung starten.

Dies ist besonders wichtig für ein Werkzeug, das gegebenenfalls mehrmals täglich geöffnet wird.

## 26.19 Ressourcenverbrauch

**LH-NF-019 [PRODUKT-MUSS]**

LaunchPad soll keine unnötig hohe dauerhafte CPU-, RAM- oder Netzwerkbelastung verursachen.

Automatische Discovery soll kontrolliert und nicht permanent aggressiv laufen.

## 26.20 Testbarkeit

**LH-NF-020 [PRODUKT-MUSS]**

Kernlogik soll automatisiert testbar sein.

Besonders relevant:

- Duplikaterkennung
- Preis-/Rate-Normalisierung
- Search Profile Logic
- Importer
- Datenmigration
- Funnel-Berechnung
- Export/Restore

## 26.21 Datenmigration

**LH-NF-021 [PRODUKT-MUSS]**

Schemaänderungen müssen versioniert und kontrolliert migrierbar sein.

Nach dem Prototypstadium ist „Datenbank löschen und neu anfangen“ keine akzeptable reguläre Upgrade-Strategie.

---

# 27. Explizite Nicht-Ziele

## 27.1 Kein eigener Freelancer Marketplace

**LH-OUT-001 [NICHT-KERN]**

LaunchPad betreibt keinen eigenen Freelancer-Marktplatz.

Nicht Ziel sind:

- eigene Job Postings für externe Kunden
- eigenes Bidding-Netzwerk
- Kundenkonten als Marketplace
- Vermittlungsprovisionen als Plattformmodell

## 27.2 Keine Zahlungsplattform

**LH-OUT-002 [NICHT-KERN]**

Nicht Kern:

- Escrow
- Wallet
- Zahlungsabwicklung
- Kreditkartenzahlungen
- Auszahlungen
- Payment Disputes

## 27.3 Keine vollständige Rechnungs- oder Buchhaltungssoftware

**LH-OUT-003 [NICHT-KERN]**

Nicht Kern:

- Rechnungsstellung
- Umsatzsteuerlogik
- Buchhaltung
- Mahnwesen
- DATEV-Ersatz
- Forderungsmanagement

Nach einem gewonnenen Auftrag kann später eine Übergabe an andere Werkzeuge sinnvoll sein.

## 27.4 Kein vollständiges Contract Management

**LH-OUT-004 [NICHT-KERN]**

Nicht Kern:

- E-Signaturen
- Vertragsvorlagenverwaltung
- Klauselmanagement
- juristische Vertragsprüfung
- automatische Vertragsverhandlung

## 27.5 Kein Time Tracker und keine Überwachung

**LH-OUT-005 [NICHT-KERN]**

Nicht Kern:

- Screenshot Tracking
- Maus-/Tastaturüberwachung
- Aktivitätsmonitoring
- detaillierte automatische Arbeitszeiterfassung

Ein tatsächlicher Aufwand kann später freiwillig manuell für Analysezwecke eingetragen werden.

## 27.6 Kein vollständiges Projektmanagement

**LH-OUT-006 [NICHT-KERN]**

Nach einem gewonnenen Auftrag soll LaunchPad nicht automatisch auch:

- Sprintplanung
- Gantt
- Ticketing
- Teamkoordination
- Source-Code-Management
- vollständiges Delivery Management

übernehmen.

Der fachliche Schwerpunkt liegt primär auf:

```text
Discover
→ Capture
→ Evaluate
→ Apply
→ Observe
→ Interact
→ Outcome
→ Learn
```

## 27.7 Kein generisches Enterprise CRM

**LH-OUT-007 [NICHT-KERN]**

Nicht Kern:

- Marketing Automation
- Newsletter
- Massenmailing
- Sales Campaigns
- Lead Nurturing
- komplexe Enterprise-Pipelines

Company und Contact Management bleiben ausschließlich auf den Freelancer-Akquise-Kontext fokussiert.

## 27.8 Kein vollständiges ATS / HR-System

**LH-OUT-008 [NICHT-KERN]**

LaunchPad ist zunächst kein vollständiges Bewerbermanagementsystem für Festanstellungen.

Nicht Ziel sind:

- Arbeitgeber-Bewerberverwaltung
- Personalakten
- Onboarding
- Talent Pools für Unternehmen
- HR-Prozesse

## 27.9 Kein automatisiertes Massenbewerbungssystem

**LH-OUT-009 [NICHT-KERN]**

LaunchPad soll keine hunderten automatischen Proposals oder generischen AI-Bewerbungen ohne Nutzerentscheidung verschicken.

Die Entscheidung zum Absenden bleibt beim Nutzer.

## 27.10 Kein aggressiver Plattform-Crawler

**LH-OUT-010 [NICHT-KERN]**

Nicht Kern:

- permanentes Massenscraping
- CAPTCHA-Umgehung
- Umgehen von Plattformlimits
- Replizieren kompletter Plattformdatenbanken
- massenhaftes Absaugen fremder Profile

## 27.11 Kein allgemeines DMS

**LH-OUT-011 [NICHT-KERN]**

LaunchPad darf relevante Dokumente referenzieren oder speichern, wird aber kein allgemeines Dokumentenmanagementsystem.

## 27.12 Kein allgemeines Wissensmanagement

**LH-OUT-012 [NICHT-KERN]**

Notes dienen der LaunchPad-Domäne.

LaunchPad wird kein zweites allgemeines Notes-/Obsidian-System.

## 27.13 Kein universelles BI

**LH-OUT-013 [NICHT-KERN]**

Analytics bleiben auf die LaunchPad-Domäne fokussiert.

LaunchPad wird kein frei konfigurierbares Enterprise-BI- oder Data-Warehouse-System.

## 27.14 Kein AI-first-Zwang

**LH-OUT-014 [NICHT-KERN]**

Die Kernanwendung muss ohne AI funktionieren.

AI kann später bei geeigneten Hilfsaufgaben unterstützen.

## 27.15 Bedeutung der Nicht-Ziele

Nicht-Ziel bedeutet nicht zwingend „für immer verboten“.

Wenn später Bedarf entsteht, sollen bevorzugt:

- Integrationen
- Schnittstellen
- andere SASD-Produkte
- externe Fachwerkzeuge

verwendet werden, statt LaunchPad selbst unnötig aufzublähen.

---

# 28. MVP – erster praktisch nutzbarer Stand

## 28.1 Normative Abgrenzung

Der normative MVP-Scope ergibt sich aus der Gesamtheit aller Anforderungen mit Priorität **`MVP-MUSS`**.

Dieses Kapitel fasst den MVP nur verständlich zusammen. Es führt keine zusätzliche Versions- oder Milestone-Planung ein.

Die konkrete Reihenfolge der Umsetzung gehört ausschließlich in die Product Roadmap.

## 28.2 Ziel des MVP

Der MVP soll einen vollständigen kleinen Arbeitsablauf ermöglichen:

```text
Opportunity finden
→ erfassen
→ prüfen
→ bewerten
→ wiederfinden
→ Proposal dokumentieren
→ später erneut ansehen
```

Er muss noch keine umfassende Discovery-Automation oder Marktintelligenz liefern.

Er soll Daten jedoch so erfassen, dass spätere Funktionen nicht durch unnötig enge Frühentscheidungen verbaut werden.

## 28.3 Opportunity und erste Fundstelle

Der MVP muss mindestens ermöglichen:

- Opportunity anlegen und bearbeiten
- mindestens eine Platform/Fundstelle erfassen
- Fundstellen-/Source-URL speichern und öffnen
- externe ID speichern, soweit vorhanden
- Titel speichern
- vollständigen Ausschreibungstext speichern
- relevante Zeitangaben gemäß MVP-MUSS-Anforderungen pflegen
- Skills zuordnen
- Status pflegen
- Notes speichern
- Opportunity unabhängig vom Status archivieren
- fehlerhafte Datensätze löschen

Mehrere Fundstellen derselben Opportunity müssen noch nicht als komfortabler täglicher UI-Workflow umgesetzt sein. Das frühe Modell soll eine spätere Erweiterung jedoch nicht unnötig erschweren.

## 28.4 Einsatz- und Preisdaten

Soweit vorhanden sollen die als `MVP-MUSS` definierten Einsatz- und Preisdaten erfasst werden können, insbesondere:

- Fixed Budget
- Hourly Rate
- Daily Rate
- Währung
- Startdatum
- Laufzeit
- Remote-Information
- Ort/Land

Es dürfen keine stillschweigenden Umrechnungen zwischen Hourly, Daily und Fixed erfolgen.

## 28.5 Suche und Filter

Der MVP muss mindestens die als `MVP-MUSS` definierten lokalen Such- und Filterfunktionen bereitstellen.

Dazu gehören insbesondere:

- Freitextsuche
- Platform
- Status
- Skills
- Veröffentlichungszeitraum
- frei wählbarer Zeitraum
- Archivfilter
- Sortierung

Komfortable Presets dürfen hinzukommen.

Die kanonische Zeitbasis ist zunächst UTC.

## 28.6 Proposal Lite

Der Proposal-Bereich bleibt bewusst klein.

Er soll mindestens ermöglichen:

- Proposal/Bewerbung als gesendet markieren
- SubmittedAt
- eigener Preis bzw. eigene Rate
- Währung
- optionale Bezeichnung der verwendeten CV-/Profilversion, beispielsweise `CV Linux DevOps 2026-08`
- einfacher Proposal-Status
- optionales Outcome
- kurze Note

Eine umfassende CV-, Attachment- oder Proposal-Dokumentverwaltung ist kein MVP-MUSS.

## 28.7 Capture

Manuelle Erfassung ist die sichere MVP-Basis.

Paste Capture, URL Capture, Browser Helper und automatisierte Discovery sind wichtige spätere Ausbaustufen, ihre konkrete Reihenfolge gehört aber in die Roadmap und nicht in dieses Lastenheft.

## 28.8 Duplikaterkennung

Der Produktstand soll früh sichere technische Dubletten anhand von Platform + External ID oder identischer URL erkennen können.

Die Erkennung, dass unterschiedliche Fundstellen dasselbe reale Projekt beschreiben, ist fachlich ein anderer Vorgang und kein notwendiger MVP-Komfortworkflow.

## 28.9 Backup

Ein einfaches vollständiges lokales Backup gehört zum frühen produktiven Stand.

Ein komplexes Backup-Center, automatische Verschlüsselung externer Medien oder Enterprise-Backup-Verwaltung sind kein MVP-MUSS.

## 28.10 Bewusst nicht Voraussetzung des MVP

Insbesondere nicht Voraussetzung für den ersten nutzbaren Stand sind:

- automatische tägliche Multi-Portal-Discovery
- Browser Helper / Browser Extension
- vollständige Observation Engine
- Winning-Bid-Tracking
- Contacts
- Companies
- Activity Timeline
- Follow-up Reminder
- Relationship Analytics
- Skill Intelligence
- Rate Intelligence
- Profile Intelligence
- Opportunity Fit Score
- AI
- umfangreiche Dashboards
- Notifications
- Cloud Sync
- Mobile App
- Webversion

Diese Abgrenzung entfernt keine `PRODUKT-MUSS`-Anforderung aus dem langfristigen Zielbild.

## 28.11 Kernaussage des MVP

> **Freelancer-Opportunities schnell erfassen, strukturiert beurteilen, wiederfinden und den eigenen Proposal-Vorgang dokumentieren.**

# 29. Typische Benutzerabläufe

Dieses Kapitel beschreibt fachliche Arbeitsabläufe. Die Kennzeichnung **MVP**, **PRODUKTZIEL** oder **SPÄTER** zeigt nur, ob ein Ablauf bereits zum ersten nutzbaren Kern gehört. Die konkrete Release-Zuordnung und Reihenfolge wird ausschließlich in der Roadmap festgelegt.

## 29.1 [MVP] Opportunity manuell erfassen

1. Nutzer findet eine interessante Ausschreibung auf einer Plattform.
2. Nutzer legt eine Opportunity an.
3. Er erfasst mindestens die bekannte Fundstelle mit Platform und URL.
4. Titel, Beschreibung, Skills und weitere bekannte Daten werden ergänzt.
5. FirstObservedAt und CapturedAt werden gesetzt.
6. Opportunity wird gespeichert und kann später wiedergefunden werden.

## 29.2 [MVP] Opportunity beurteilen

1. Nutzer liest die vollständige Beschreibung.
2. Er prüft beispielsweise fachlichen Fit, Rate/Budget, Remote-Anteil, Starttermin, Laufzeit und Vermittler/Endkunde.
3. Er setzt einen Opportunity-Status.
4. Optional ergänzt er Interesse, Dismiss Reason oder Note.

## 29.3 [MVP] Opportunity nicht weiterverfolgen

1. Opportunity wird geprüft.
2. Nutzer entscheidet sich dagegen.
3. Optional wird ein Dismiss Reason gespeichert.
4. Opportunity bleibt erhalten.
5. Sie kann unabhängig von `Dismissed` zusätzlich archiviert werden.

## 29.4 [MVP] Proposal dokumentieren

1. Nutzer bewirbt sich auf der externen Plattform.
2. LaunchPad dokumentiert SubmittedAt, eigenen Preis/Satz, Währung und optional die verwendete CV-/Profilversion.
3. Proposal-Status und gegebenenfalls späteres Outcome werden gepflegt.
4. Opportunity bleibt zur späteren Prüfung verfügbar.

## 29.5 [MVP] Opportunity später erneut prüfen

1. Nutzer öffnet eine ältere Opportunity.
2. Er öffnet die bekannte Fundstellen-URL.
3. Er prüft den aktuellen Stand, auch wenn die Opportunity bereits abgelaufen oder geschlossen ist.
4. `LastObservedAt` kann aktualisiert werden.
5. Zuschlag, Gewinner oder Rate bleiben unbekannt, wenn sie nicht zuverlässig bekannt sind.

## 29.6 [MVP] Frühere Opportunity wiederfinden

Beispiel:

> „Da war vor drei Monaten dieses Debian-Projekt bei irgendeinem Vermittler.“

Der Nutzer sucht nach `Debian`.

LaunchPad durchsucht mindestens relevante lokale Opportunity-/Fundstellen-Daten, Skills und Notes.

## 29.7 [PRODUKTZIEL] Opportunity komfortabel übernehmen

1. Nutzer findet eine interessante Fundstelle.
2. Daten werden per Paste, URL oder später Browser Helper übernommen.
3. LaunchPad erkennt soweit möglich Titel, URL, Beschreibung, Skills, Budget/Rate, Remote, Ort, Start, Laufzeit, Vermittler und Endkunde.
4. Eine Importvorschau erscheint.
5. Nutzer korrigiert bei Bedarf.
6. Speichern.

Ziel:

> **Nicht abschreiben, sondern prüfen und übernehmen.**

## 29.8 [PRODUKTZIEL] Tägliche Discovery mit Search Profile

1. Nutzer startet LaunchPad.
2. Er wählt beispielsweise `Linux Remote`.
3. LaunchPad prüft die unterstützten Plattformen soweit möglich.
4. Plattformseitige Suchmöglichkeiten werden genutzt; zusätzliche Kriterien können lokal nachgefiltert werden.
5. neue Fundstellen werden einheitlich angezeigt.
6. pro Plattform bleibt erkennbar, ob die Prüfung erfolgreich, unvollständig oder fehlgeschlagen war.
7. nur eine erfolgreiche Prüfung aktualisiert den jeweiligen erfolgreichen Prüfzeitpunkt.

## 29.9 [PRODUKTZIEL] Search Profile erneut verwenden

1. Nutzer öffnet ein Search Profile.
2. LaunchPad kennt je Plattform den letzten erfolgreichen Prüfzeitpunkt.
3. Der gewünschte LaunchPad-Zeitraum kann daraus vorgeschlagen werden.
4. Nutzer kann den Zeitraum jederzeit verändern.

Ein Portal muss den exakten Zeitraum nicht selbst unterstützen; LaunchPad kann verfügbare Quellfilter mit lokaler Nachfilterung kombinieren.

## 29.10 [PRODUKTZIEL] Technische Dublette

1. gleiche Platform-ID oder identische URL wird erneut importiert.
2. LaunchPad erkennt die bekannte Fundstelle.
3. Nutzer kann vorhandenen Datensatz öffnen, einen neuen beobachteten Stand ergänzen oder abbrechen.

## 29.11 [SPÄTER] Dasselbe reale Projekt über mehrere Fundstellen

1. Opportunity wird beispielsweise auf Freelancermap entdeckt.
2. später erscheint dasselbe reale Endkundenprojekt bei GULP oder über einen anderen Vermittler.
3. LaunchPad weist auf eine mögliche Übereinstimmung hin.
4. Nutzer bestätigt die Zuordnung, wenn sie ausreichend sicher ist.
5. beide Fundstellen bleiben unter derselben Opportunity erhalten.
6. Unterschiede wie Vermittler, URL, Beschreibung oder ausgeschriebene Rate bleiben quellspezifisch nachvollziehbar.

Keine aggressive automatische Zusammenführung.

## 29.12 [PRODUKTZIEL] Fehlerhafte Plattformprüfung

1. eine Plattform kann nicht zuverlässig geprüft werden oder liefert nur unvollständige Daten.
2. LaunchPad zeigt diesen Zustand ausdrücklich an.
3. der letzte erfolgreiche Prüfzeitpunkt wird nicht fälschlich fortgeschrieben.
4. lokale Anwendung und andere Plattformen funktionieren weiter.

## 29.13 [SPÄTER] Relationship-Workflow

Wenn Contacts später eingeführt sind, kann eine bekannte berufliche Person mit früheren Opportunities, Companies und Activities wiedererkannt werden.

Direkte Recruiter-E-Mails außerhalb der Plattformen sind kein früher Discovery-Kanal und können später gesondert ergänzt werden.

## 29.14 [SPÄTER] Marktanalyse

1. Nutzer wählt Zeitraum, Platform oder Skill.
2. LaunchPad zeigt beispielsweise Opportunity-Anzahl, typische Rates, häufige Skills, Plattformverteilung, eigene Proposals und Responses/Wins.
3. Nutzer entscheidet auf Grundlage dieser Daten über Search Profiles, Rate oder Profil.

# 30. Erfolgskriterien

## 30.1 Zentraler Erfolgssatz

> **LaunchPad ist erfolgreich, wenn der Nutzer relevante Freelancer-Chancen mit weniger Aufwand erfassen und verfolgen kann und aus der wachsenden eigenen Datenbasis zunehmend bessere Entscheidungen ableiten kann.**

## 30.2 MVP-Erfolg

Der MVP gilt als erfolgreich, wenn ein Nutzer innerhalb weniger Minuten:

- eine reale Opportunity erfassen,
- deren vollständige Informationen lokal sichern,
- Platform/Fundstelle erkennen,
- flexible Suche und Filter verwenden,
- Status und Notes pflegen,
- eine Bewerbung mit Kerndaten dokumentieren,
- die Fundstellen-URL erneut öffnen,
- die Opportunity später wiederfinden,
- ein Backup erstellen

kann.

## 30.3 Zeitersparnis

Eine interessante Opportunity soll langfristig nicht dazu führen, dass mehrere Minuten Daten abgetippt werden müssen.

Ziel:

> **Vorhandene Informationen werden übernommen; der Nutzer prüft und ergänzt.**

## 30.4 Wiederfinden

Eine vor Wochen oder Monaten gespeicherte Opportunity muss über Titel, Beschreibung, Skill, Plattform oder Note schnell wieder auffindbar sein.

## 30.5 Discovery-Erfolg

Sobald automatische bzw. teilautomatische Discovery vorhanden ist, gilt sie als erfolgreich, wenn:

- neue Opportunities zuverlässig erkannt werden,
- bekannte nicht ständig erneut als neu erscheinen,
- Search Profiles nachvollziehbare Treffer liefern,
- flexible Zeiträume funktionieren,
- die Fundstelle/Platform sichtbar bleibt,
- einzelne Plattformfehler nicht das Gesamtsystem verschleiern.

Das Ziel ist nicht maximale Trefferzahl, sondern:

> **weniger irrelevante Treffer und weniger übersehene relevante Opportunities.**

## 30.6 Datenqualität

Importierte Daten sollen:

- Herkunft behalten,
- korrigierbar sein,
- Unsicherheit zulassen,
- Originalinformationen nicht stillschweigend verfälschen.

Lieber `Rate: unbekannt` als ein erfundener Wert.

## 30.7 Proposal Tracking

Der frühe Proposal-Bereich ist erfolgreich, wenn der Nutzer später zuverlässig beantworten kann:

- auf welche Opportunities habe ich mich beworben?
- wann?
- mit welchem Preis/Satz?
- mit welchem CV?
- was wurde daraus?

## 30.8 Historischer Nutzen

LaunchPad soll nach sechs oder zwölf Monaten nützlicher sein als am ersten Tag.

Der Wert wächst durch:

- Opportunity-Historie
- Proposal-Historie
- Rate-Daten
- Skill-Daten
- spätere Contact-/Company-Historie
- Observations

## 30.9 Intelligence-Erfolg

Spätere Analytics sind erfolgreich, wenn sie konkrete Entscheidungen unterstützen und die zugrunde liegenden Daten transparent machen.

## 30.10 Relationship-Erfolg

Company/Contact Management ist später erfolgreich, wenn LaunchPad schnell beantworten kann:

- „Mit dieser Person hatte ich bereits Kontakt.“
- „Diese Company ist bereits bei mehreren Opportunities aufgetaucht.“

## 30.11 Zuverlässigkeit

Technischer Erfolg bedeutet unter anderem:

- keine regelmäßigen Abstürze
- keine stillen Datenverluste
- Datenbankmigrationen funktionieren
- Backup/Restore funktioniert
- Fehler der Plattformintegration bleiben isoliert
- lokale Nutzung funktioniert ohne Internet
- Suche bleibt bei wachsender Datenmenge angemessen schnell

## 30.12 Bedienbarkeit

Ein wichtiger Realitätstest lautet:

> Wenn der Nutzer eine Opportunity lieber nicht erfasst, weil die Erfassung zu viel Arbeit ist, ist der Workflow nicht gut genug.

## 30.13 Kein Funktionszwang

Erweiterte Funktionen dürfen den einfachen Basisworkflow nicht unnötig komplizieren.

Auch eine spätere Version soll weiterhin erlauben:

```text
Opportunity
→ speichern
→ Note
→ fertig
```

## 30.14 Erfolg nicht an Feature-Anzahl messen

Erfolg wird nicht daran gemessen, wie viele Funktionen Version 1.0 besitzt.

Wichtiger sind:

- Zeitersparnis
- weniger Informationsverlust
- besserer Überblick
- nachvollziehbarere Entscheidungen
- wachsende Erkenntnis aus historischen Daten

---

# 31. Risiken

## 31.1 Scope Creep

**Risiko:** Discovery, CRM, Analytics, AI, Contacts, Browser Helper, Plattformintegrationen, Notifications und Profile Intelligence werden gleichzeitig gebaut.

**Gegenmaßnahme:** harte MVP-Grenze, kleine Releases, Roadmap.

## 31.2 Zu viel Architektur zu früh

**Risiko:** Zukünftige Objekte werden technisch vollständig implementiert, bevor sie gebraucht werden.

**Gegenmaßnahme:** im Zielbild berücksichtigen, erst bei realem Bedarf implementieren.

## 31.3 Plattformabhängigkeit

**Risiko:** HTML, APIs, Loginverfahren und sichtbare Daten ändern sich.

**Gegenmaßnahme:** plattformspezifische Unterschiede sauber isolieren, Plattformfähigkeiten berücksichtigen und eine manuelle Rückfallebene erhalten. Die technische Ausgestaltung gehört in das Architecture-Dokument.

## 31.4 Plattformzugriff wird eingeschränkt

**Risiko:** technisch mögliche Automation ist nicht dauerhaft zulässig oder stabil.

**Gegenmaßnahme:** offizielle APIs, Feeds und Browser Capture bevorzugen; aktuelle Bedingungen vor Implementierung prüfen.

## 31.5 „Keine Treffer“ wird mit „Quelle ausgefallen“ verwechselt

**Risiko:** relevante Projekte werden übersehen.

**Gegenmaßnahme:** Status der Plattformintegration transparent machen.

## 31.6 Schlechte Importdaten

**Risiko:** falsche Rates, Firmen, Skills oder Zeitpunkte.

**Gegenmaßnahme:** Importvorschau, Partial Import, `unknown` statt Erfinden, Source Provenance.

## 31.7 Duplikate und falsches Zusammenführen

**Risiko:** dieselbe Fundstelle wird mehrfach gespeichert, dieselbe reale Opportunity über mehrere Fundstellen wird nicht erkannt oder verschiedene reale Projekte werden fälschlich einer Opportunity zugeordnet.

**Gegenmaßnahme:** sichere technische Fundstellen-Dubletten erkennen; mögliche Mehrfachfundstellen nur vorschlagen und die endgültige Zuordnung bei Unsicherheit dem Nutzer überlassen.

## 31.8 Plattformbegriffe verunreinigen das Kernmodell

**Risiko:** LaunchPad wird an einzelne Plattformbegriffe gekoppelt.

**Gegenmaßnahme:** gemeinsame Domänenbegriffe wie Opportunity, Fundstelle, Proposal und Observation; plattformspezifische Besonderheiten werden technisch außerhalb des fachlichen Kerns gekapselt.

## 31.9 Zu viel Pflichtdateneingabe

**Risiko:** Nutzer erfasst Opportunities irgendwann nicht mehr.

**Gegenmaßnahme:** kleiner Pflichtkern, optionale Zusatzinformationen, automatische Übernahme.

## 31.10 Datenmenge ohne Erkenntnis

**Risiko:** tausende Opportunities werden gesammelt, ohne Nutzen zu erzeugen.

**Gegenmaßnahme:** nur Daten strukturiert erfassen, die einen operativen oder analytischen Zweck besitzen.

## 31.11 Scheingenauigkeit

**Risiko:** kleine Stichproben erzeugen überzeugend aussehende, aber wenig belastbare Prozentzahlen.

**Gegenmaßnahme:** absolute Anzahl, Zeitraum und Unsicherheit anzeigen.

## 31.12 Falsche Pricing-Empfehlungen

**Risiko:** System leitet aus höherer Win Rate bei niedrigeren Rates automatisch eine Preissenkung ab.

**Gegenmaßnahme:** Rate, Response, Win, Projektqualität und wirtschaftlichen Nutzen getrennt betrachten.

## 31.13 AI überschreibt Fakten

**Risiko:** generierte Inhalte ersetzen Originaldaten oder User Notes.

**Gegenmaßnahme:** Source, Extraktion, Summary und User Notes getrennt halten.

## 31.14 Unnötige personenbezogene Datensammlung

**Risiko:** Relationship Tracking entwickelt sich zur privaten Personenprofilierung.

**Gegenmaßnahme:** Zweckbindung, kleiner strukturierter Datenkern, Retention.

## 31.15 Zu aggressive Retention

**Risiko:** wichtige Geschäftserkenntnisse gehen durch zu frühes Löschen verloren.

**Gegenmaßnahme:** konfigurierbare Aufbewahrung, Vorschau und Anonymisierung statt pauschaler Vernichtung.

## 31.16 Verlust der lokalen Wissensbasis

**Risiko:** Datenbankdefekt oder Rechnerverlust zerstört wertvolle Langzeithistorie.

**Gegenmaßnahme:** frühe Backups, später Restore, Integritätsprüfung und offene Exporte.

## 31.17 Migrationen beschädigen historische Daten

**Risiko:** Datenmodelländerungen führen zu Datenverlust.

**Gegenmaßnahme:** versionierte Schema-Migrationen, Tests und Backups vor kritischen Änderungen.

## 31.18 UI wird mit wachsender Funktionalität unbenutzbar

**Risiko:** Contacts, Observations, Proposals und Analytics überladen die Oberfläche.

**Gegenmaßnahme:** progressive Offenlegung; einfacher täglicher Workflow bleibt erhalten.

## 31.19 Automatisierung erzeugt zu viel Hintergrundlast

**Risiko:** mehrere Quellen werden unnötig häufig geprüft.

**Gegenmaßnahme:** kontrollierte Intervalle, Search-Profile-bezogene Abfragen, Backoff.

## 31.20 Produkt verliert seine Identität

**Risiko:** LaunchPad wird CRM + Projektmanagement + Buchhaltung + AI-Assistent.

**Gegenmaßnahme:** Neue Funktionen müssen danach bewertet werden, ob sie den Kernkreislauf verbessern:

```text
Discover
→ Capture
→ Evaluate
→ Apply
→ Observe
→ Interact
→ Outcome
→ Learn
```

Funktionen außerhalb dieses Kreislaufs benötigen eine besonders starke Begründung oder gehören in ein anderes Produkt.

---

# 32. Offene Produktentscheidungen

Dieses Kapitel enthält nur Fragen, die nach dem fachlichen Review tatsächlich offen geblieben sind. Bereits entschiedene Punkte werden hier nicht erneut zusammengefasst.

## 32.1 Reihenfolge der Plattformintegrationen

Noch offen ist, in welcher Reihenfolge die initial relevanten Plattformen technisch unterstützt werden.

Diese Entscheidung gehört in die Roadmap und darf anhand von Nutzen, technischem Aufwand und zulässigen Integrationswegen getroffen werden.

## 32.2 Reihenfolge der Capture-Mechanismen

Die fachliche Entwicklungsrichtung ist bekannt, die konkrete Release-Reihenfolge von Paste Capture, URL Capture, Browser Helper und automatisierter Discovery bleibt der Roadmap vorbehalten.

## 32.3 Erster automatischer Discovery-Umfang

Noch offen sind beispielsweise:

- nur manuell ausgelöst oder zeitgesteuert?
- ein oder mehrere Search Profiles?
- ein oder mehrere Portale gleichzeitig?
- welche Refresh-Frequenz?

Unabhängig davon ist entschieden, dass Discovery zuverlässig zwischen erfolgreicher, unvollständiger und fehlgeschlagener Prüfung unterscheiden muss.

## 32.4 Observation-Automatisierung

Noch offen:

- nur manuell?
- per Wiedervorlage?
- automatisch nach Regeln?
- abhängig vom Opportunity-Alter oder Status?

Eine Opportunity darf auch nach Ablauf oder Schließung manuell erneut betrachtet werden.

## 32.5 Skill-Modell

Noch offen sind:

- Hierarchien
- Skill-Gruppen
- Synonyme
- Skill Evidence
- automatische Normalisierung

Diese Themen sollen nicht vorab übermodelliert werden.

## 32.6 Retention-Fristen

Das Prinzip ist entschieden.

Noch offen sind konkrete Zeiträume und Default-Werte. Diese gehören später in `080_Data_Protection.md`.

## 32.7 Profile Intelligence

Der Produktbereich ist langfristig vorgesehen. Konkrete Profile-Daten, Metriken und Analysemechanismen bleiben offen.

## 32.8 Opportunity Fit

Die Grundprinzipien sind entschieden. Formel und Gewichtung bleiben offen.

## 32.9 AI-Einsatz

Noch offen sind:

- lokale oder externe Modelle
- konkrete Anbieter
- Kosten
- Datenschutz
- Opt-in
- konkrete AI-Funktionen

AI bleibt **PRÜFEN**, bis ein konkreter Use Case entschieden wird.

## 32.10 Attachments

Noch offen:

- nur Pfade/Links?
- Dateien in LaunchPad kopieren?
- CV-Versionen als echte Dateien verwalten?
- Screenshots von Listings?

Die einfache logische Bezeichnung einer verwendeten CV-/Profilversion benötigt diese Entscheidung noch nicht.

## 32.11 Backup-Strategie

Das Ziel eines einfachen vollständigen lokalen Backups ist entschieden.

Technische Details wie Paketformat, Rotation oder Automatisierung bleiben offen und gehören in die nachgelagerten technischen Dokumente bzw. Roadmap.

Die sichere Aufbewahrung externer Backup-Medien ist in der Desktop-Version zunächst Aufgabe des Nutzers.

## 32.12 Linux / Web

Windows-first ist entschieden.

Linux- oder Webversion bleiben mögliche spätere Optionen ohne derzeitiges Produktversprechen.

## 32.13 Integration mit anderen SASD-Produkten

Bleibt offen und soll nur eingeführt werden, wenn ein konkreter Nutzen entsteht.

## 32.14 Geschäftsmodell

Falls LaunchPad später veröffentlicht wird, bleibt offen:

- Open Source
- kostenloses SASD-Tool
- Community Edition
- kommerzielles Produkt
- Supportmodell

Diese Frage darf die aktuelle Produktentwicklung nicht blockieren.

## 32.15 Umfang der Konfiguration

Offen bleibt die UX-Balance zwischen sinnvollen Defaults und hoher Flexibilität.

Leitidee:

> **Useful defaults, full control when needed.**

## 32.16 Regel für offene Entscheidungen

> **Offene Zukunftsentscheidungen dürfen die Umsetzung bereits ausreichend verstandener Produktbereiche nicht blockieren.**

# 33. Abgrenzung zu nachgelagerten Dokumenten

## 33.1 Lastenheft

Das Lastenheft beantwortet:

> **Was soll das Produkt leisten und warum?**

Hier gehören hinein:

- Produktziele
- Zielgruppen
- Funktionsbereiche
- fachliche Begriffe
- Muss-/Soll-/Kann-Anforderungen
- Nicht-Ziele
- Datenschutzprinzipien
- Erfolgskriterien
- fachliche Risiken
- langfristiger Produktscope

## 33.2 Pflichtenheft

Das Pflichtenheft beantwortet:

> **Wie erfüllen wir die Anforderungen des Lastenhefts in einem konkreten Release?**

Beispiel:

Lastenheft:

> LaunchPad soll Opportunities aus verschiedenen Quellen übernehmen können.

Pflichtenheft für einen konkreten Umsetzungsstand:

> Die Erfassung erfolgt in diesem Umsetzungsstand manuell; automatisierte Capture-Verfahren werden noch nicht realisiert.

Das Pflichtenheft beschreibt den konkreten Lösungsumfang, ohne selbst eine Release-Roadmap zu werden. Die zeitliche Reihenfolge bleibt Aufgabe der Roadmap.

## 33.3 Architecture

`050_Architecture.md` soll die langfristige fachliche und technische Struktur beschreiben.

Insbesondere:

- Modulgrenzen
- Abhängigkeiten
- Plattformintegrationsschicht
- Domain Model
- Application Services
- Persistence-/Infrastructure-Grenzen
- Integrationsgrenzen

Die konkrete technische Kapselung unterschiedlicher Plattformen – beispielsweise über Adapter, Connectoren oder eine andere Integrationsstruktur – wird ausschließlich im Architecture-Dokument festgelegt und nicht im Lastenheft vorweggenommen.

## 33.4 Technical Design

`030_Technical_Design.md` beschreibt die konkrete technische Umsetzung des jeweiligen Entwicklungsstands.

Beispiele:

- .NET-Version
- WinForms
- Projektstruktur
- Dependency Injection
- Repository Pattern
- SQLite-Zugriff
- Logging
- Error Handling
- konkrete UI-Struktur

Kurz:

> **Architecture = langfristige Struktur und Regeln**

> **Technical Design = konkrete technische Umsetzung**

## 33.5 Database Design

`040_Database_Design.md` beschreibt die Persistenz.

Es muss auf Basis dieses Lastenhefts erneut geprüft werden, insbesondere wegen:

- Opportunity statt Project
- Platform
- Fundstelle / Listing
- Search Profile
- Proposal
- Observation
- Company
- Contact
- Activity
- Notes
- Skills
- Outcomes

Nicht alle Zielobjekte müssen sofort als Tabellen implementiert werden.

## 33.6 Competitive Research

`045_Competitive_Product_Feature_Inventory.md` ist Research.

Es dokumentiert:

- welche Produkte untersucht wurden,
- welche Funktionen beobachtet wurden,
- welche Konzepte für LaunchPad interessant sein könnten.

Es ist **keine automatische Anforderungsliste**.

## 33.7 Roadmap

`060_Product_Roadmap.md` beantwortet:

> **Wann ungefähr werden welche Anforderungen umgesetzt?**

Das Lastenheft sagt **was**.

Die Roadmap sagt **wann bzw. in welcher Reihenfolge**.

## 33.8 ADR – Architecture Decision Records

ADRs dokumentieren:

> **Warum wurde eine konkrete Architekturentscheidung getroffen?**

Mögliche ADRs:

- Opportunity statt Project
- technische Plattformintegrationsgrenze
- SQLite als lokale Datenbasis
- Local-first
- WinForms für frühe Windows-Version
- Activity als gemeinsames Ereignismodell
- Credential Strategy

## 33.9 Data Protection

`080_Data_Protection.md` konkretisiert später:

- Datenkategorien
- Retention
- Anonymisierung
- Löschung
- Export
- AI-Übertragung
- Credentials
- Backup
- Logs

## 33.10 Führender Dokumentationsort

**Dokumentationsregel:**

> **Eine Entscheidung soll genau einen führenden Ort besitzen. Andere Dokumente verweisen darauf, statt dieselbe Entscheidung vollständig redundant zu pflegen.**

Beispiel:

- Produktanforderung Plattformunabhängigkeit → Lastenheft
- technische Plattformintegrationsschicht → Architecture
- Reihenfolge der Plattformintegrationen → Roadmap
- konkrete Interfaces → Technical Design/Pflichtenheft

## 33.11 Versionskonsistenz

Ändert sich eine grundlegende Produktentscheidung, müssen betroffene nachgelagerte Dokumente geprüft werden.

Beispiel:

```text
Project → Opportunity
```

Betroffen können sein:

- Pflichtenheft
- Architecture
- Database Design
- Code
- Tests

Die Dokumente dürfen eigene Versionsnummern besitzen.

---

# 34. Forschungsgrundlage

## 34.1 Grundlagen

Diese Fassung basiert auf:

- Lastenheft Version 0.1
- bisherigem Pflichtenheft
- Technical Design
- Database Design
- `045_Competitive_Product_Feature_Inventory.md`
- gemeinsamer Produktdiskussion
- Analyse etablierter Referenzprodukte

## 34.2 Untersuchte Referenzprodukte und Quellen

Insbesondere:

- PeoplePerHour
- Freelancermap
- GULP / Randstad Professional
- Upwork
- Freelancer.com
- Malt
- Huntr
- Teal
- Contra
- HubSpot als CRM-Referenz

## 34.3 Research ist keine automatische Anforderung

Eine Funktion wird nicht deshalb Teil von LaunchPad, weil ein Wettbewerber sie besitzt.

Zwischen Research und Implementierung liegt eine bewusste Produktentscheidung.

## 34.4 Plattforminformationen verändern sich

Konkrete Plattformfunktionen müssen vor technischer Integration erneut geprüft werden.

Dies betrifft insbesondere:

- APIs
- Suchfilter
- sichtbare Projektdaten
- Award-Informationen
- Loginverfahren
- Nutzungsbedingungen
- Produktnamen und Plattformstrukturen

## 34.5 Offizielle Quellen bevorzugen

Für technische und rechtliche Integrationsentscheidungen sollen offizielle Produkt-, Support-, API- und Nutzungsbedingungen bevorzugt werden.

Community-Erfahrungen können ergänzen, sind aber nicht alleinige Grundlage für sensible Integrationsentscheidungen.

## 34.6 Reale Nutzung als Forschungsquelle

Die tägliche Nutzung des MVP ist eine wesentliche zukünftige Erkenntnisquelle.

Anforderungen dürfen aus realen Problemen und Nutzungsmustern weiterentwickelt werden.

## 34.7 Produktprozess

```text
Research / reale Nutzung
        ↓
Produktentscheidung
        ↓
Lastenheft
        ↓
Pflichtenheft / Architektur
        ↓
Implementierung
```

## 34.8 Keine Kopie fremder Produkte

Referenzprodukte dienen zur Analyse von Konzepten und Workflows.

Nicht kopiert werden sollen:

- Branding
- proprietäre Inhalte
- fremde UI-Designs
- proprietäre Texte

LaunchPad übernimmt Erkenntnisse und Prinzipien, nicht fremde Produkte.

---

# 35. Konsistenz- und Auslegungsregel

Dieses Lastenheft enthält **bewusst keine zweite zusammenfassende Wiederholung aller Produktentscheidungen**.

Maßgeblich sind die fachlichen Definitionen, Anforderungen, Prioritäten und Abgrenzungen der Kapitel 1 bis 34. Eine Anforderung soll an ihrem führenden Dokumentationsort gepflegt werden, statt in einer zweiten Kurzfassung erneut beschrieben und später möglicherweise widersprüchlich geändert zu werden.

Für die weitere Projektarbeit gilt daher:

> **Bei Änderungen wird die führende Anforderung geändert; abhängige Dokumente werden geprüft, aber fachliche Aussagen werden nicht unnötig dupliziert.**

Diese Regel dient ausdrücklich der Lesbarkeit und der langfristigen Konsistenz der Projektdokumentation.

# 36. Leitmotiv

## 36.1 Entwicklungsleitmotiv

> **Praktischer Nutzen vor Perfektion.**

Das bedeutet:

- früh nutzbar,
- schrittweise erweitern,
- langfristige Ziele nicht vergessen,
- keine Perfektion als Voraussetzung für den ersten Nutzen.

## 36.2 Datenleitmotiv

> **Capture first. History instead of overwrite.**

Eine Opportunity und ihre Fundstellen können später analysiert werden.

Eine verschwundene Ausschreibungsinformation kann verloren sein.

Relevante Veränderungen sollen deshalb nachvollziehbar bleiben.

## 36.3 Intelligence-Leitmotiv

> **Learn from real opportunities and real outcomes.**

LaunchPad soll nicht behaupten, ohne Evidenz zu wissen:

- welche Rate optimal ist,
- welcher Skill entscheidend ist,
- welche Plattform die beste ist,
- welche Opportunity objektiv perfekt passt.

Stattdessen soll die Anwendung reale Daten sammeln und daraus mit der Zeit nachvollziehbare Erkenntnisse ermöglichen.

## 36.4 Produktentwicklung

LaunchPad beginnt als:

> **schnelles, zuverlässiges Werkzeug für die tägliche Opportunity-Arbeit.**

Mit zunehmender Datenbasis entwickelt es sich schrittweise zu:

> **einem persönlichen, plattformübergreifenden Freelancer Opportunity & Market Intelligence System.**

## 36.5 Kurzer Produktsatz

> **Find opportunities. Keep the history. Learn what works.**
