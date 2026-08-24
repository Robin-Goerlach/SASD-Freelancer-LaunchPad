# SASD Freelancer LaunchPad – Competitive Product Feature Inventory

**Date:** 2026-08-23  
**Version:** 0.2  
**Status:** Research baseline – fachlich in Lastenheft 0.2 überführt; Rechercheinhalt historisch erhalten  
**Project:** SASD Freelancer LaunchPad  
**Document type:** Competitive research / feature inventory  
**Language:** English product names, German analysis  

---

# 0. Einordnung nach Abschluss des Lastenheft-Reviews

## 0.1 Rolle dieses Dokuments

Dieses Dokument bleibt eine **Research- und Evidenzsammlung**.

Es ist keine normative Produkt-, Architektur- oder Datenmodellvorgabe.

Seit Erstellung der ursprünglichen Research-Fassung wurden die Produktentscheidungen gemeinsam konsolidiert. Führend sind jetzt:

1. `010_Lastenheft.md`
2. `020_Pflichtenheft_MVP.md`
3. `050_Architecture.md`
4. `030_Technical_Design.md`
5. `040_Database_Design.md`

Wenn eine vorläufige Empfehlung dieses Research-Dokuments von einer späteren bewussten Produktentscheidung abweicht, gilt die spätere Entscheidung.

---

## 0.2 Wichtige nachgelagerte Entscheidungen

Die Recherche führte unter anderem zu folgenden inzwischen verbindlich konkretisierten Entscheidungen:

- `Opportunity` bezeichnet das **reale potentielle Projekt**.
- Eine konkrete Veröffentlichung auf PeoplePerHour, Freelancermap, GULP/Randstad Professional oder einer anderen Plattform wird davon als **Listing / Fundstelle** getrennt.
- Eine Opportunity kann mehrere Listings besitzen, etwa wenn dasselbe Endkundenprojekt über verschiedene Vermittler angeboten wird.
- PeoplePerHour ist nicht mehr als alleiniger oder zwingend erster Produktfokus zu verstehen. PeoplePerHour, Freelancermap und GULP/Randstad Professional sind initial besonders relevante Quellen.
- Proposal/Bewerbung ist ein eigenes fachliches Objekt und kein Opportunity-Status.
- `Applied`, `Won` oder `Rejected` dürfen deshalb nicht als Opportunity-Lifecycle missverstanden werden.
- Archivierung ist eine separate Arbeitsorganisationseigenschaft und kein Opportunity-Status.
- Notes und Activities bleiben getrennte Konzepte.
- Advertised Budget/Rate, Own Proposal Rate und spätere Winning Rate bleiben fachlich getrennt.
- Discovery und zuverlässige Search Profiles gehören langfristig zum Produktkern, aber nicht zum manuellen MVP.
- Die Research-Empfehlungen zu Company, Contact, Relationship Analytics, Profile Intelligence und AI bleiben langfristige Hinweise und ziehen diese Funktionen nicht in den MVP.

---

## 0.3 Historischer Charakter einzelner Formulierungen

Einige Abschnitte der ursprünglichen Recherche sprechen beispielsweise von:

- „Project“ statt der später präzisierten Opportunity-/Listing-Trennung,
- PeoplePerHour als erstem konkreten Einsatzfall,
- möglichen Statusketten mit `Applied`,
- vorläufigen Datenmodellideen.

Diese Formulierungen werden im Research-Teil **nicht rückwirkend umgeschrieben**, weil sie den Erkenntnisweg dokumentieren.

Sie sind als Forschungsnotizen zu lesen, nicht als aktuelle Spezifikation.

---

## 0.4 Forschungsprinzip

Der Nutzen dieses Dokuments liegt gerade darin, zwischen:

```text
Beobachtung
→ Schlussfolgerung
→ spätere Produktentscheidung
```

unterscheiden zu können.

Das verhindert, dass Wettbewerberfunktionen ungeprüft zu Anforderungen werden.

---



## 1. Zweck des Dokuments

Dieses Dokument erfasst und beschreibt die für **SASD Freelancer LaunchPad** relevanten Funktionen ausgewählter Referenzprodukte.

Es ist ausdrücklich **noch kein Lastenheft** und keine verbindliche Anforderungsliste. Ziel ist zunächst, den Lösungsraum vollständig genug zu verstehen, bevor das Lastenheft 0.2 formuliert wird.

Die Untersuchung verfolgt drei Ziele:

1. Funktionen identifizieren, die sich in etablierten Freelancer-, Job-Tracking- und CRM-Produkten bewährt haben.
2. Funktionen erkennen, die für LaunchPad relevant sein könnten, ohne sie vorschnell in den MVP aufzunehmen.
3. Funktionen dokumentieren, die bewusst **nicht** zum Produktkern gehören sollen.

Die wichtigste Leitfrage lautet:

> Welche Informationen und Arbeitsabläufe helfen einem Freelancer dabei, relevante Chancen zu finden, gute Bewerbungsentscheidungen zu treffen, Beziehungen zu pflegen, Ergebnisse zu beobachten und aus dem Markt zu lernen?

---

## 2. Untersuchungsrahmen

Untersucht wurden folgende Referenzprodukte:

1. **PeoplePerHour**
2. **Upwork**
3. **Freelancer.com**
4. **Contra**
5. **Malt**
6. **Huntr**
7. **Teal**
8. **HubSpot CRM** als generische CRM-Referenz

Die Produkte wurden nicht nur nach sichtbaren UI-Funktionen untersucht, sondern nach den dahinterliegenden fachlichen Konzepten:

- Opportunity Discovery
- Search & Filtering
- Alerts
- Project / Opportunity Capture
- Proposal / Bid Management
- Client / Company Information
- Contacts / Recruiters
- Activities / Interactions
- Follow-ups
- Skills
- Profile Positioning
- Pricing
- Reputation
- Funnel Metrics
- Market Intelligence
- Historical Observation
- Documents
- Export
- Work Execution
- Billing / Payment
- Trust / Safety

---

# 3. PeoplePerHour

## 3.1 Rolle als Referenzprodukt

PeoplePerHour war zum Zeitpunkt der ursprünglichen Recherche besonders wichtig, weil die Plattform damals als erster konkreter Einsatzfall betrachtet wurde. Die spätere Produktbaseline erweitert den initialen Fokus ausdrücklich auf mehrere relevante Plattformen.

PeoplePerHour trennt bereits fachlich zwischen:

- Job Post
- Offer
- Buyer
- Freelancer
- Proposal
- WorkStream
- Escrow
- Invoice
- Feedback

Diese Trennung ist wichtig, weil sie zeigt, dass ein gefundenes Projektangebot, eine eigene Bewerbung und die spätere Zusammenarbeit unterschiedliche fachliche Objekte sind.

---

## 3.2 Projekt- und Opportunity-Suche

### Projektsuche

Freelancer können veröffentlichte Projekte durchsuchen und passende Jobs auswählen.

### Gespeicherte Suchvorgänge

Suchvorgänge können gespeichert werden.

### Benachrichtigungen für neue Projekte

Gespeicherte Suchvorgänge können neue passende Projekte per E-Mail melden.

**Relevanz für LaunchPad:** sehr hoch.

LaunchPad sollte Suchdefinitionen langfristig als eigenständige Objekte betrachten können, beispielsweise:

- Suchbegriff
- Plattform
- Budgetbereich
- Skill
- Zeitpunkt der letzten Prüfung
- aktiv/inaktiv

---

## 3.3 Job Post

Ein Job Post beschreibt einen individuellen Auftrag eines Buyers.

Relevante Informationen sind typischerweise:

- Titel
- Beschreibung
- gewünschte Deliverables
- Zeitraum
- Skills
- angegebenes Budget
- Buyer
- Veröffentlichungszeitpunkt

**Wichtige Erkenntnis:** Das angegebene Budget ist ein Marktsignal, aber kein verlässlicher Wert für den tatsächlich möglichen Preis.

---

## 3.4 Offers

PeoplePerHour kennt zusätzlich vorkonfigurierte Freelancer-Leistungen, sogenannte Offers.

Ein Offer ist kein ausgeschriebenes Projekt, sondern ein vom Freelancer angebotener standardisierter Service.

Typische Eigenschaften:

- Leistungsbeschreibung
- Preis
- Lieferumfang
- Lieferzeit
- Freelancer-Profil

**Relevanz für LaunchPad:** später interessant.

LaunchPad könnte langfristig nicht nur Nachfrage analysieren, sondern auch helfen zu erkennen, welche standardisierbaren Dienstleistungen im Markt sinnvoll angeboten werden könnten.

---

## 3.5 Proposal

Ein Proposal ist die Bewerbung bzw. das Angebot eines Freelancers auf einen Job.

PeoplePerHour empfiehlt darin unter anderem:

- Deliverables
- Zeitrahmen
- Skills
- Preis
- relevante Arbeitsproben
- Rückfragen

### Bedeutung für LaunchPad

Ein Proposal sollte langfristig eine eigene Entität sein und nicht lediglich durch `Opportunity.Status = Applied` dargestellt werden.

Sinnvolle LaunchPad-Daten:

- Opportunity
- SubmittedAt
- ProposedPrice
- ProposedHourlyRate
- EstimatedEffort
- ProposedTimeline
- ProposalText
- Deliverables
- Questions
- Attachments/References
- Outcome

---

## 3.6 Geschwindigkeit der Bewerbung

PeoplePerHour weist darauf hin, dass frühe Bewerbungen Vorteile haben können, weil Buyers Proposals in Eingangsreihenfolge prüfen können.

**Relevanz für LaunchPad:** hoch.

Daraus ergibt sich eine spätere Kennzahl:

```text
TimeToProposal = Proposal.SubmittedAt - Opportunity.FirstObservedAt
```

LaunchPad könnte später analysieren:

- Erfolgsquote nach Bewerbungszeitpunkt
- durchschnittliche Reaktionsgeschwindigkeit
- besonders zeitkritische Projektarten

---

## 3.7 Preispositionierung

PeoplePerHour weist darauf hin, dass angegebene Budgets Richtwerte sein können und ein Freelancer einen höheren Preis anbieten kann, wenn er seinen Mehrwert nachvollziehbar begründet.

LaunchPad sollte daher mindestens unterscheiden:

- Advertised Budget
- Own Proposed Price
- Own Proposed Hourly Rate
- Known Awarded Price
- Historical Market Range

---

## 3.8 Buyer / Kunde

Der Buyer ist der Auftraggeber.

Für die Bewertung können relevant sein:

- bisherige Aktivitäten
- Reputation
- Feedback
- frühere Zusammenarbeit
- Kommunikation

### LaunchPad-Perspektive

Langfristig sollte der Buyer nicht nur als Textfeld am Projekt gespeichert werden.

Er kann als:

- Company
- Contact
- PlatformIdentity

modelliert werden.

---

## 3.9 WorkStream

Der WorkStream bündelt Kommunikation und operative Vorgänge zwischen Buyer und Freelancer.

Er unterstützt unter anderem:

- Nachrichten
- Dateianhänge
- Proposal
- Invoice
- Zahlung
- Deposit
- Refund
- Dispute

### Relevanz für LaunchPad

LaunchPad soll den WorkStream nicht ersetzen.

Relevant ist jedoch das Konzept einer **chronologischen Interaction History**.

---

## 3.10 Escrow und Deposit

PeoplePerHour verwendet Escrow, um Gelder zwischen Buyer und Freelancer zu sichern.

Funktionen:

- Deposit
- Escrow Balance
- Freigabe nach Leistung
- Unterstützung bei Streitfällen

**LaunchPad-Entscheidung:** kein Produktkern.

LaunchPad soll keine Zahlungsplattform werden.

Allenfalls könnten später externe Zahlungs-/Vertragszustände dokumentiert werden.

---

## 3.11 Invoice

Nach Projektabschluss kann der Freelancer eine Rechnung innerhalb der Plattform stellen.

**LaunchPad-Entscheidung:** nicht nachbauen.

Ein Status wie `ProjectCompleted` oder `PaymentCompleted` könnte später dokumentiert werden, aber Rechnungsstellung gehört nicht zum Kern.

---

## 3.12 Feedback und Reputation

Nach abgeschlossenen Arbeiten können Bewertungen entstehen.

Reputation beeinflusst:

- Vertrauen
- Sichtbarkeit
- zukünftige Auftragschancen

**LaunchPad-Relevanz:** hoch für Analyse, aber nicht als eigenes Bewertungssystem.

Mögliche spätere historische Werte:

- ProfileRating
- CompletedJobs
- ReviewCount
- Ranking
- RepeatBusiness

---

## 3.13 Portfolio und Profil

Freelancer präsentieren:

- Profilbeschreibung
- Skills
- Arbeitsbeispiele
- Erfahrungen
- Portfolio
- Bewertungen

### LaunchPad-Relevanz

LaunchPad sollte später eine lokale Abbildung des eigenen Plattformprofils speichern können.

Damit könnten Veränderungen mit Marktdaten verglichen werden:

- Welche Skills werden häufig gesucht?
- Welche Skills fehlen im Profil?
- Welche Formulierungen passen zu erfolgreichen Opportunity-Clustern?

---

## 3.14 PeoplePerHour – wichtigste übertragbare Funktionen

**Direkt relevant:**

- Projektsuche
- gespeicherte Suchen
- Alerts
- Projektbeschreibung sichern
- Buyer-Bezug
- Proposal als eigene Entität
- angebotener Preis getrennt vom Kundenbudget
- Zeit bis Bewerbung
- Feedback-/Reputationssignale
- Kommunikationshistorie

**Nicht nachbauen:**

- Escrow
- Wallet
- Rechnungsstellung
- Dispute Resolution
- Payment Processing

---

# 4. Upwork

## 4.1 Rolle als Referenzprodukt

Upwork ist insbesondere für seine Daten- und Analysefunktionen interessant.

Für LaunchPad ist weniger wichtig, die Plattform selbst nachzubauen. Interessant ist, **welche Daten Upwork für Freelancer als entscheidungsrelevant betrachtet**.

---

## 4.2 Job Search

Upwork bietet Suche über:

- Keywords
- Kategorien
- Skills
- Jobbeschreibung
- Budget
- Client Location
- Veröffentlichungszeitpunkt

### Advanced Search

Unterstützt werden detailliertere Suchausdrücke und Suchfilter.

### Saved Searches

Suchdefinitionen können gespeichert werden.

### Job Feed

Gespeicherte oder automatisch abgeleitete Suchkriterien erzeugen persönliche Job-Feeds.

### Job Alerts

Neue passende Projekte können über Benachrichtigungen signalisiert werden.

Teilweise werden Alerts auch aus der bisherigen Proposal-Historie abgeleitet.

**LaunchPad-Relevanz:** sehr hoch.

Langfristig sollte LaunchPad sowohl benutzerdefinierte als auch lernende Suchprofile unterstützen können.

---

## 4.3 Job Bookmarking

Interessante Jobs können gespeichert werden.

### LaunchPad-Erkenntnis

Eine Opportunity braucht nicht sofort einen Bewerbungsstatus.

Zwischen `Discovered` und `Applied` existieren sinnvolle Zustände wie:

- New
- Review
- Interesting
- Watching
- Preparing
- Applied
- Rejected
- Closed

---

## 4.4 Proposal-Erstellung

Bei einer Bewerbung können unter anderem festgelegt werden:

- Freelancer oder Agency
- Hourly Rate
- Fixed Price
- geplante Rate Increases
- Milestones
- Projektdauer
- Cover Letter
- Screening Questions
- Work Samples
- Profile Highlights
- Attachments
- Boosting

### LaunchPad-Relevanz

Das unterstützt die Entscheidung, Proposal als eigenständiges Objekt zu modellieren.

---

## 4.5 Proposal Editing

Upwork kennt unterschiedliche Änderungsmöglichkeiten abhängig davon:

- wie lange das Proposal schon existiert
- ob es bereits angesehen wurde
- ob ein Offer vorliegt

**LaunchPad-Erkenntnis:** Proposal-Historie kann langfristig relevant sein.

Anstatt eine Bewerbung nur zu überschreiben, könnten Versionen oder wichtige Änderungen protokolliert werden.

---

## 4.6 Proposal Insights

Upwork zeigt für einzelne Job Posts unter anderem:

- Total Submitted Proposals
- Opened Proposals
- Shortlisted Proposals
- Responded Proposals
- Average Bid
- Average Bid bei beantworteten Proposals
- Bid-Werte von Top-Rated-Freelancern
- durchschnittliche Earnings der Bewerber
- durchschnittliche Jobs der Bewerber
- häufige Skills konkurrierender Freelancer

### LaunchPad-Relevanz: sehr hoch

Diese Funktion bestätigt einen zentralen LaunchPad-Schwerpunkt:

> Marktinformationen zu einer Opportunity sollen historisch beobachtbar sein.

Mögliche spätere Observation-Felder:

- ObservedAt
- ProposalCount
- OpenedCount
- ShortlistedCount
- ResponseCount
- AverageBid
- TopRatedAverageBid
- ClientActivity
- OpportunityState

Nicht alle Werte sind auf jeder Plattform öffentlich verfügbar. Das Datenmodell sollte deshalb optionale Beobachtungen erlauben.

---

## 4.7 Profile Metrics

Upwork misst unter anderem:

- Profile Views
- Invitations
- Impressions
- Clicks

### LaunchPad-Relevanz

Später könnte LaunchPad eigene Plattformmetriken historisieren.

Beispiel:

```text
ProfileSnapshot
- CapturedAt
- Platform
- ProfileViews
- Invitations
- SearchImpressions
- Clicks
```

Damit ließen sich Profiländerungen mit Sichtbarkeit vergleichen.

---

## 4.8 Proposal Funnel

Upwork unterscheidet:

- Sent
- Viewed
- Interviews / Responses
- Hires

Zusätzlich wird teilweise zwischen:

- boosted
- organic

unterschieden.

### LaunchPad-Relevanz: sehr hoch

Ein eigener Funnel sollte später möglich sein:

```text
Discovered
→ Qualified
→ Proposal Prepared
→ Proposal Sent
→ Viewed
→ Response
→ Interview
→ Offer
→ Won
```

---

## 4.9 Client Relationship Metrics

Upwork betrachtet Wiederholungsaufträge und langfristige Kundenbeziehungen.

### LaunchPad-Relevanz

Wichtige Kennzahlen:

- RepeatClientCount
- RepeatHireRate
- RevenueFromRepeatClients
- AverageRelationshipDuration

Damit wird Contact/Company-Management strategisch relevant.

---

## 4.10 Talent Search

Auf Kundenseite können Freelancer nach Kriterien wie:

- Skills
- Hourly Rate
- Feedback
- Availability
- Languages
- Location

gefiltert werden.

### LaunchPad-Erkenntnis

Für die eigene Positionierungsanalyse sind genau diese Felder relevant.

LaunchPad könnte langfristig ein lokales `FreelancerProfile` besitzen mit:

- Skills
- Rate
- Languages
- Availability
- Location
- Experience
- Profile Keywords

---

## 4.11 Boosting / Advertising

Upwork bietet:

- Boosted Proposal
- Profile Boosting
- Advertising Credits

### LaunchPad-Relevanz

Nicht nachbauen.

Aber ein Proposal könnte markieren:

- Organic
- Boosted
- PromotionCost

Damit ließe sich später messen, ob bezahlte Sichtbarkeit einen Effekt hatte.

---

## 4.12 Reporting und Export

Upwork bietet verschiedene Reports, unter anderem zu:

- Transaktionen
- Stunden
- Aktivitäten
- Zahlungen

Teilweise exportierbar.

### LaunchPad-Relevanz

Datenexport ist relevant.

Operatives Finanzreporting gehört dagegen nicht zum Kern.

---

# 5. Freelancer.com

## 5.1 Rolle als Referenzprodukt

Freelancer.com ist besonders interessant, weil die Plattform sehr deutlich trennt zwischen:

- Project
- Bid
- Award
- Milestone
- Client
- Freelancer

Außerdem besitzt sie bemerkenswert detaillierte **Bid Insights**.

---

## 5.2 Project Discovery

Projektangebote können durchsucht werden.

Filter:

- Fixed Price / Hourly
- Skills
- Budget
- Location
- Languages
- Listing Type

---

## 5.3 Live Notifications

Neue Projekte, die zu den Profil-Skills passen, können als Live Notifications angezeigt werden.

---

## 5.4 Newsletter / Matching Alerts

Passende Projekte können per E-Mail angekündigt werden.

---

## 5.5 Project Bookmarking

Projekte können zum späteren Prüfen gespeichert werden.

### LaunchPad-Relevanz

Bestätigung für eine eigene Watchlist/Interessant-Logik.

---

## 5.6 Saved Searches

Projektsuchen können gespeichert werden.

### LaunchPad-Relevanz

Sehr hoch für spätere automatisierte Marktbeobachtung.

---

## 5.7 Bid

Ein Bid enthält unter anderem:

- Bid Amount
- Delivery Time
- Proposal Text
- Milestones
- Portfolio-/Experience-Bezug
- optional Sponsoring

### LaunchPad-Relevanz

Bestätigt erneut:

`Opportunity != Proposal/Bid`.

---

## 5.8 Active Bids

Offene eigene Bewerbungen werden separat verwaltet.

### LaunchPad-Relevanz

LaunchPad sollte später eine Ansicht besitzen können:

- Active Proposals
- Waiting for Response
- Interviewing
- Won
- Lost
- Withdrawn

---

## 5.9 Public Clarification Board

Freelancer können vor einer Bewerbung öffentlich Fragen zum Projekt stellen.

### LaunchPad-Relevanz

Interessantes Datenkonzept:

`OpportunityQuestion`.

Für den MVP unnötig, später eventuell als Teil von Notes oder Interaction.

---

## 5.10 Bid Insights

Freelancer.com zeigt unter anderem:

- Projekte der letzten Bewerbungen
- Time to Bid
- Bid Rank
- Winning Bid
- Own Bid
- Client Seen Bid
- Client Visited Profile
- Client Rated Bid
- Client Country
- Client Rating
- Client Review Count

### LaunchPad-Relevanz: extrem hoch

Besonders wertvoll ist:

**Winning Bid**

Damit wird exakt unser ursprünglicher Wunsch bestätigt:

> Nach älteren Projekten prüfen, wer den Zuschlag erhielt und welche Preis-/Marktsignale daraus entstehen.

Mögliche LaunchPad-Felder:

```text
AwardObservation
- OpportunityId
- ObservedAt
- Awarded
- AwardedFreelancer
- WinningBid
- KnownAwardDate
```

---

## 5.11 Award

Der Kunde vergibt ein Projekt an einen Freelancer.

Der Freelancer kann den Award anschließend annehmen oder ablehnen.

### LaunchPad-Erkenntnis

Es ist sinnvoll, getrennte Zustände zu modellieren:

- Awarded
- Accepted
- Declined
- Expired

---

## 5.12 Client Evaluation

Clients können Bewerber vergleichen anhand von:

- Bid
- Zeitplanung
- Proposal
- Profile
- Reviews
- Portfolio
- Certifications
- ähnlicher Erfahrung

### LaunchPad-Relevanz

Diese Informationen können später helfen zu verstehen, welche Profilbestandteile Erfolg beeinflussen.

---

## 5.13 Freelancer Reputation

Freelancer.com zeigt unter anderem:

- Average Star Rating
- Review Count
- Earnings Score
- Accept Rate
- Jobs Completed
- On-Time Rate
- On-Budget Rate
- Repeat Hire Rate

### LaunchPad-Relevanz

Sehr interessantes Vorbild für ein langfristiges persönliches Performance-Dashboard.

---

## 5.14 Messaging

Direkte Kommunikation zwischen Client und Freelancer.

### LaunchPad-Entscheidung

Nicht ersetzen.

Aber Kontakt-/Interaction-Historie lokal dokumentieren.

---

## 5.15 Milestone Payments

Zahlungen können an Meilensteine gekoppelt werden.

**LaunchPad:** nicht nachbauen.

---

## 5.16 Desktop Time Tracker

Freelancer.com besitzt zusätzlich:

- Zeiterfassung
- Screenshots
- Offline Tracking
- Notes
- Projektbenachrichtigungen

**LaunchPad:** bewusst außerhalb des Kernprodukts.

---

# 6. Contra

## 6.1 Rolle als Referenzprodukt

Contra zeigt einen modernen Freelancer-Workflow, der weit über Opportunity Discovery hinausgeht.

Für LaunchPad ist Contra vor allem interessant als Beispiel dafür, **wo wir bewusst eine Grenze ziehen sollten**.

---

## 6.2 Job Feed

Freelancer können einen Feed mit Opportunities durchsuchen.

---

## 6.3 Job Filtering

Filter sind unter anderem möglich nach:

- Tools
- Skills
- Budgets

---

## 6.4 Apply / Dismiss

Eine Opportunity kann:

- beworben
- verworfen

werden.

### LaunchPad-Relevanz

Ein explizites `Dismissed` mit Grund ist interessanter als bloßes Löschen.

Mögliche Gründe:

- Rate too low
- Skill mismatch
- No remote
- Bad client signal
- Too much competition
- Not interesting
- Time unavailable

Diese Daten können später für Suchprofilverbesserungen genutzt werden.

---

## 6.5 Job Referral

Nicht passende Jobs können anderen Personen empfohlen werden.

**LaunchPad-Relevanz:** niedrig.

Allenfalls später als Share-Funktion.

---

## 6.6 Freelancer Profile

Contra-Profile enthalten unter anderem:

- Profilbild
- One-liner
- Cover Image / Video
- Work Samples
- Rate
- Social Links
- Portfolio

### LaunchPad-Relevanz

Profile Snapshot / Profile Positioning.

---

## 6.7 Discoverability

Profilvollständigkeit und Qualität beeinflussen, ob Freelancer von Clients gefunden werden.

### LaunchPad-Relevanz

Bestätigt die Bedeutung eines späteren Profile-Health-Moduls.

---

## 6.8 Portfolio Analytics

Contra Pro bietet beispielsweise:

- Portfolio Views
- Traffic Sources
- Visibility Insights

### LaunchPad-Relevanz

Profile-Metrics-Historisierung könnte später helfen, Profiländerungen zu bewerten.

---

## 6.9 Paid Project

Contra modelliert einen Auftrag als strukturierte Vereinbarung mit:

- Scope
- Payment Structure
- Timeline

Projektarten:

- One-Time Fixed
- One-Time Hourly
- Milestones
- Fixed Invoice Billing
- Hourly Invoice Billing

---

## 6.10 Contracts

Contra unterstützt:

- Contract Templates
- lokal angepasste Verträge
- Custom PDF Contracts
- E-Signatures

**LaunchPad:** nicht nachbauen.

---

## 6.11 Escrow

Unterstützung für:

- Fixed
- Hourly
- Milestone Escrow

**LaunchPad:** nicht nachbauen.

---

## 6.12 Invoice Billing

Contra unterstützt wiederkehrende Abrechnung:

- Fixed
- Hourly
- Weekly
- Bi-weekly
- Monthly

**LaunchPad:** nicht nachbauen.

---

## 6.13 One-Off Invoices

Rechnungen können separat von Projekten gestellt werden.

**LaunchPad:** nicht nachbauen.

---

## 6.14 Payment Links

Einmalige oder wiederkehrende Payment Links.

**LaunchPad:** nicht nachbauen.

---

## 6.15 Digital Products

Contra unterstützt den Verkauf digitaler Produkte.

**LaunchPad:** außerhalb des Scopes.

---

## 6.16 Empfehlungen und Reputation

Positive Empfehlungen und Portfolioqualität beeinflussen Sichtbarkeit und besondere Freelancer-Status.

### LaunchPad-Relevanz

Später für Profile Positioning interessant.

---

# 7. Malt

## 7.1 Rolle als Referenzprodukt

Malt ist besonders wertvoll als Referenz für:

- Matching
- Skill-Modell
- Rate-Modell
- Availability
- Profile Visibility
- Projekt-Fit

---

## 7.2 Opportunity Matching

Malt nutzt einen zweistufigen Matching-Prozess:

1. Filterung anhand harter Kriterien
2. Berechnung eines Fit Scores

Wichtige Matchingfaktoren sind:

- Skills
- Job Title
- Average Daily Rate
- Location
- weitere Projektdetails

Nur ausreichend passende Opportunities werden ausgespielt.

### LaunchPad-Relevanz: sehr hoch

Das ist ein starkes Vorbild für ein späteres Opportunity Scoring.

---

## 7.3 Matching Score

Ein Match wird numerisch bewertet.

### LaunchPad-Perspektive

Ein späterer `OpportunityFitScore` könnte aus transparenten Teilwerten entstehen:

- Skill Fit
- Rate Fit
- Remote Fit
- Location Fit
- Availability Fit
- Experience Fit
- Language Fit
- Duration Fit
- Personal Preference

Wichtig:

Der Score sollte erklärbar bleiben.

---

## 7.4 Respond / Decline Feedback Loop

Malt berücksichtigt, dass Freelancer auf Opportunities reagieren oder diese ablehnen.

### LaunchPad-Erkenntnis

Ein Ablehnungsgrund ist analytisch wertvoll.

Er kann helfen:

- Suchprofile zu verbessern
- irrelevante Opportunities zu erkennen
- Rate- und Skill-Schwellen zu lernen

---

## 7.5 Availability

Freelancer pflegen:

- verfügbar
- nicht verfügbar
- zukünftiges Verfügbarkeitsdatum

Aktualität der Verfügbarkeit beeinflusst Sichtbarkeit.

### LaunchPad-Relevanz

Eine lokale `Availability`-Information sollte später Teil des eigenen Profils sein.

---

## 7.6 Daily Rate

Malt arbeitet mit einem Average Daily Rate.

Dieser dient:

- Marktpositionierung
- Such-/Matchinglogik
- Kundenorientierung

### LaunchPad-Relevanz: sehr hoch

LaunchPad sollte Rate-Historien unterstützen können:

```text
RateSnapshot
- CapturedAt
- Platform
- HourlyRate
- DailyRate
- Currency
```

Damit kann später untersucht werden, wie Preisänderungen mit Opportunity-Qualität und Erfolg zusammenhängen.

---

## 7.7 Freelancer Profile

Relevante Profildaten umfassen:

- Description
- Profile Image
- Work Location Preferences
- Remote Preference
- Skills
- Top Skills
- Industry Expertise
- Work Experience
- Certifications
- Languages
- Experience Level
- Daily Rate
- Availability

---

## 7.8 Skill Management

Malt unterscheidet:

- Skills
- Top Skills
- Industry Expertise
- Skills in konkreten Experiences
- Certifications

### LaunchPad-Erkenntnis

Skill ist langfristig mehr als ein String.

Mögliche Zukunft:

```text
Skill
SkillAlias
ProfileSkill
OpportunitySkill
SkillEvidence
Certification
```

Nicht für den MVP, aber wichtig für die Architektur.

---

## 7.9 Profile Visibility

Die Sichtbarkeit hängt unter anderem ab von:

- Profilvollständigkeit
- Skills
- Experience
- Language
- Rate
- Location
- Availability
- Responsiveness
- Rating
- Aktivität

### LaunchPad-Relevanz

Daraus lässt sich später ein eigenes `ProfileHealth`-Konzept ableiten.

---

## 7.10 Secure Messaging

Kommunikation mit Clients findet innerhalb der Plattform statt.

**LaunchPad:** nicht ersetzen; nur Interaktionen dokumentieren.

---

## 7.11 Quote

Freelancer können Angebote direkt an Clients senden.

### LaunchPad-Relevanz

Entspricht unserem Proposal-Konzept.

---

## 7.12 Project Types

Malt unterscheidet:

- Time-Based
- Fixed Price

### LaunchPad-Relevanz

Opportunity / Proposal sollten CompensationType berücksichtigen.

---

## 7.13 Project Management / Activity Reports

Malt unterstützt operative Projektverwaltung und Tätigkeitsberichte.

**LaunchPad:** nicht Kern.

---

## 7.14 Legal Documents, Billing, Payments

Malt verwaltet:

- rechtliche Dokumente
- Quotes
- Rechnungen
- Payments

**LaunchPad:** nicht nachbauen.

---

# 8. Huntr

## 8.1 Rolle als Referenzprodukt

Huntr ist für LaunchPad besonders wertvoll, weil es zeigt, wie ein persönliches Opportunity-Tracking-System strukturiert werden kann.

Huntr ist kein Freelancer-Marktplatz, sondern ein persönliches Job-Search-Management-System.

---

## 8.2 Job Board

Zentrale Übersicht über alle Opportunities.

Das Board fungiert als Single Source of Truth.

Typischer Workflow:

- Saved
- Applied
- Interview
- Offer
- Accepted

### LaunchPad-Relevanz

Sehr hoch.

LaunchPad sollte eine zentrale Opportunity-Liste besitzen.

Ein Kanban kann später optional sein, darf aber nicht die einzige Ansicht sein.

---

## 8.3 Job Capture

Jobs können erfasst werden:

- manuell
- per Browser Extension

Die Browser Extension übernimmt unter anderem:

- Title
- Company
- Description
- Salary
- URL

### LaunchPad-Relevanz

Sehr hoch für spätere halbautomatische Erfassung.

---

## 8.4 Vollständige Job Description sichern

Die Beschreibung wird lokal/zentral im Job Record gespeichert.

### LaunchPad-Relevanz: sehr hoch

Plattformseiten verschwinden oder ändern sich.

Daher sollte LaunchPad bei Opportunity Capture möglichst speichern:

- Current Description
- Original Source Text
- Capture Timestamp
- Source URL

---

## 8.5 Job Card

Jede Opportunity besitzt eine Detailkarte.

Dort werden relevante Informationen zusammengeführt.

Beispiele:

- Company
- Job Title
- URL
- Description
- Salary
- Deadline
- Application
- Interview
- Contacts
- Activities

### LaunchPad-Relevanz

Sehr gutes Vorbild für die Detailansicht.

---

## 8.6 Activities

Huntr trennt Aktivitäten von Jobstatus.

Aktivitätstypen sind beispielsweise:

- Application
- Interview
- Offer
- Networking
- Follow-up

Eigenschaften:

- Datum
- Notes
- verknüpfter Job
- Kategorie
- Completion Status
- Due Date

### LaunchPad-Relevanz: extrem hoch

Das ist ein gutes Vorbild für eine generische `Activity`-Entität.

---

## 8.7 Automatische Activity-Erzeugung

Beim Verschieben eines Jobs zwischen bestimmten Stadien erzeugt Huntr automatisch passende Aktivitäten.

### LaunchPad-Relevanz

Später könnte LaunchPad beispielsweise bei Statuswechsel:

`Interesting → Applied`

automatisch eine Activity `ProposalSubmitted` erzeugen.

---

## 8.8 Timeline

Alle Aktivitäten eines Jobs können chronologisch angezeigt werden.

### LaunchPad-Relevanz

Sehr sinnvoll für:

- Bewerbungen
- Gespräche
- Follow-ups
- Statuswechsel
- spätere Marktbeobachtungen

---

## 8.9 Tasks / Upcoming Activities

Aktivitäten können auch zukünftige Aufgaben sein.

Beispiele:

- Follow-up schreiben
- Interview vorbereiten
- Recruiter kontaktieren

### LaunchPad-Relevanz

Wichtig für Relationship CRM, aber nach dem ersten MVP.

---

## 8.10 Contacts

Huntr speichert Kontaktinformationen wie:

- Name
- Job Title
- Company
- Location
- E-Mail
- Phone
- Social Media

Kontakte können Opportunities zugeordnet werden.

### LaunchPad-Relevanz: hoch

Bestätigung für `Contact` als eigene Entität.

---

## 8.11 Documents

Huntr speichert unter anderem:

- Resume
- Cover Letter
- Thank-you Letter
- Offer Decline Letter

Dokumente können kategorisiert werden.

### LaunchPad-Relevanz

Für Proposal-Versionen und Export später interessant.

Ein vollständiges Dokumentenmanagement ist nicht für den MVP nötig.

---

## 8.12 Application Packets

Huntr bündelt Materialien zu einer Bewerbung.

Enthalten bzw. dargestellt werden unter anderem:

- Job
- Match Score
- Submission Status
- Application Documents

### LaunchPad-Relevanz

Später könnte ein `ProposalPacket` interessant sein, aber kein früher Kern.

---

## 8.13 Metrics

Huntr besitzt einen Funnel:

- Jobs Saved
- Applications
- Interviews
- Offers

Daraus werden Conversion Rates berechnet.

### LaunchPad-Relevanz: extrem hoch

Ein Freelancer sollte erkennen können:

- Wie viele Opportunities prüfe ich?
- Auf wie viele bewerbe ich mich?
- Wie viele Antworten bekomme ich?
- Wie viele Interviews entstehen?
- Wie viele Aufträge gewinne ich?

---

## 8.14 Response Time / Performance Metrics

Huntr betrachtet unter anderem:

- Application Frequency
- Interview Conversion
- Response Times
- Overall Cadence

### LaunchPad-Relevanz

Später sehr wichtig für Strategieoptimierung.

---

## 8.15 Maps

Opportunities können geografisch dargestellt werden.

### LaunchPad-Relevanz

Für unseren zunächst Remote-orientierten Anwendungsfall gering.

Später optional.

---

## 8.16 Export

Huntr unterstützt vollständigen Datenexport.

Exportiert werden unter anderem:

- Job Data
- Activity Data
- Profile Data
- Contact Data

Zusätzlich können Metrics exportiert werden.

### LaunchPad-Relevanz: sehr hoch

Eine lokale Anwendung sollte Daten niemals einschließen.

CSV-/JSON-Export gehört langfristig zum guten Produktstandard.

---

# 9. Teal

## 9.1 Rolle als Referenzprodukt

Teal ist besonders interessant für:

- Job Tracker
- Company Tracker
- Contact Tracker
- Job-spezifische Notes
- Follow-ups
- Guidance
- Profile/Resume Matching

---

## 9.2 Job Tracker

Teal verwaltet Opportunities über ihren gesamten Lebenszyklus.

Gespeichert werden unter anderem:

- Job Title
- Company
- Location
- Salary
- Application Status
- Date Saved
- Date Applied
- Follow-up Dates
- Excitement Level
- Notes
- Contacts
- Resume Used

### LaunchPad-Relevanz

Sehr hoch.

Besonders gut ist die Idee einer expliziten persönlichen Priorisierung (`Excitement Level`).

LaunchPad könnte langfristig unterscheiden:

- Objective Fit Score
- Personal Interest
- Strategic Value

---

## 9.3 Opportunity Capture

Jobs können:

- manuell
- per Browser Extension

gespeichert werden.

Die vollständige Job Description soll erhalten bleiben.

### LaunchPad-Relevanz

Sehr hoch.

---

## 9.4 Job Status Pipeline

Beispiele:

- Bookmarked
- Applied
- Interviewing
- Negotiating
- Accepted

### LaunchPad-Relevanz

Bestätigung für eine Pipeline-Ansicht, aber nicht als Ersatz für Activity History.

---

## 9.5 Notes

Jede Opportunity besitzt eigene Notizen.

Mögliche Inhalte:

- Warum interessant?
- Interviewfragen
- Gesprächseindrücke
- spätere Referenzpunkte
- wichtige Details

### LaunchPad-Relevanz

Direkt MVP-relevant.

---

## 9.6 Guidance

Je nach Status gibt Teal Handlungsempfehlungen.

Beispiele:

- Skills prüfen
- Company recherchieren
- Interesse bewerten
- Referral suchen
- Resume anpassen
- Recruiter finden
- Follow-up senden

### LaunchPad-Relevanz

Später interessant.

Nicht sofort als AI-Funktion.

Eine regelbasierte Guidance könnte zunächst reichen.

---

## 9.7 Checklists

Je Pipeline-Stufe existieren empfohlene Aufgaben.

### LaunchPad-Relevanz

Später sinnvoll für wiederholbare Proposal-Qualität.

---

## 9.8 Resume Attachments

Teal merkt, welche Resume-Version für welche Bewerbung verwendet wurde.

### LaunchPad-Übertragung

LaunchPad könnte analog speichern:

- verwendetes Proposal Template
- Profile Snapshot
- CV Version
- Portfolio References

---

## 9.9 Match Score

Teal gleicht Job Description und Resume unter anderem anhand von Keywords ab.

### LaunchPad-Relevanz

Sehr hoch für spätere Skill-/Profile-Gap-Analyse.

---

## 9.10 Contacts Tracker

Kontakte besitzen unter anderem:

- Relationship
- Goal
- Status
- Follow-up Date
- Work Experience
- Notes

Kontakte können mit Jobs verknüpft werden.

### LaunchPad-Relevanz: sehr hoch

Dieses Modell ist näher an unserem Recruiter-Anwendungsfall als ein einfaches Adressbuch.

---

## 9.11 Company Tracker

Unternehmen können unabhängig von einer konkreten Opportunity gespeichert werden.

Nützlich für:

- frühere Bewerbungen
- zukünftiges Interesse
- positive/negative Eindrücke
- mehrere Opportunities desselben Unternehmens

### LaunchPad-Relevanz: hoch

---

## 9.12 Email Templates

Teal besitzt situationsabhängige Vorlagen, beispielsweise:

- Thank-you
- Follow-up
- Reference Request
- Withdrawal
- Offer Decline

### LaunchPad-Relevanz

Für Freelancer später interessant:

- Proposal Follow-up
- Recruiter Follow-up
- Thank-you
- Availability Update
- Rate Discussion

Aber nicht MVP.

---

## 9.13 Follow-up Dates

Kontakte und Opportunities können Follow-ups besitzen.

### LaunchPad-Relevanz

Sehr wichtig für Relationship CRM.

---

## 9.14 Weekly Review / Pipeline Hygiene

Teal empfiehlt regelmäßige Reviews:

- stale jobs archivieren
- Pipeline prüfen
- Muster erkennen

### LaunchPad-Relevanz

Später könnte LaunchPad eine Review-Ansicht besitzen:

- Opportunities ohne Entscheidung
- Proposals ohne Follow-up
- Kontakte mit fälligem Follow-up
- alte offene Opportunities

---

# 10. HubSpot CRM

## 10.1 Rolle als Referenzprodukt

HubSpot ist kein direkter Wettbewerber für LaunchPad.

Es dient als Referenz für reife CRM-Modellierung.

Besonders wichtig ist:

> Entitäten, Beziehungen und Aktivitäten werden getrennt gespeichert.

---

## 10.2 Contacts

Personen sind eigenständige Records.

### LaunchPad

Recruiter, Hiring Manager, Buyer und andere berufliche Kontakte sollten langfristig eigene Contact-Records sein.

---

## 10.3 Companies

Unternehmen sind eigenständige Records.

### LaunchPad

Mehrere Contacts und Opportunities können derselben Company zugeordnet werden.

---

## 10.4 Deals / Opportunities

Deals besitzen:

- Stage
- Value
- Pipeline
- Relationship
- Activities

### LaunchPad

Unsere Opportunity ist fachlich vergleichbar, aber speziell auf Freelancer-Märkte zugeschnitten.

---

## 10.5 Associations

Records können miteinander verknüpft werden.

Beispiel:

- Contact ↔ Company
- Deal ↔ Company
- Deal ↔ Contact
- Activity ↔ Contact
- Activity ↔ Deal

### LaunchPad-Relevanz: sehr hoch

Das spricht gegen eine flache Tabelle mit Recruiter-Name direkt in `Opportunity`.

---

## 10.6 Activity Timeline

HubSpot verwaltet chronologisch:

- Notes
- Emails
- Calls
- Meetings
- Tasks
- LinkedIn Messages
- SMS
- WhatsApp
- Postal Mail

### LaunchPad-Relevanz

Für uns reicht eine viel kleinere Activity-Taxonomie.

Beispielsweise:

- Proposal Submitted
- Message
- Email
- Call
- Meeting
- Interview
- Follow-up
- Offer
- Award
- Note

---

## 10.7 Tasks

Activities können zukünftige Aufgaben darstellen.

### LaunchPad

Geeignet für Follow-ups und Wiedervorlagen.

---

## 10.8 Activity Outcomes

HubSpot speichert beispielsweise Call Outcomes.

### LaunchPad

Später nützlich:

- No Response
- Interested
- Follow-up Needed
- Rejected
- Introduced to Client
- Interview Scheduled

---

## 10.9 Record History

Historische Aktivitäten und Änderungen bleiben am Record nachvollziehbar.

### LaunchPad-Relevanz

Unterstützt unser Prinzip:

> History instead of overwrite.

---

# 11. Produktübergreifende Funktions-Taxonomie

Die folgenden Funktionen ergeben sich aus der Gesamtschau.

---

## 11.1 Opportunity Discovery

Mögliche Funktionen:

- manuelle Erfassung
- URL-Erfassung
- Browser-Import
- Feed-Import
- API-Import
- Saved Searches
- Search Profiles
- Alerts
- Skill Matching
- Budget Filter
- Location Filter
- Remote Filter
- Language Filter
- Project Type Filter
- Time/Duration Filter

**LaunchPad:** Kernbereich.

---

## 11.2 Opportunity Capture

Zu speichernde Informationen:

- Platform
- External ID
- URL
- Title
- Description
- Original Source Text
- Buyer/Company
- Contacts
- Budget
- Compensation Type
- Currency
- Skills
- Location
- Remote Status
- Duration
- Publication Time
- First Observed At
- Last Observed At
- Deadline
- Project State

**LaunchPad:** Kernbereich.

---

## 11.3 Opportunity Evaluation

Mögliche Bewertungen:

- Manual Rating
- Personal Interest
- Strategic Importance
- Skill Fit
- Rate Fit
- Remote Fit
- Availability Fit
- Experience Fit
- Language Fit
- Competition
- Client Quality
- Risk
- Expected Value

**LaunchPad:** manuell früh, automatisiert später.

---

## 11.4 Watchlist

Funktionen:

- Interesting
- Watching
- Bookmark
- Snooze
- Archive
- Dismiss
- Dismiss Reason
- Re-evaluate Later

**LaunchPad:** sehr relevant.

---

## 11.5 Proposal Management

Funktionen:

- Proposal erstellen
- Proposal Text speichern
- Price
- Hourly Rate
- Fixed Price
- Timeline
- Effort
- Milestones
- Deliverables
- Questions
- Work Samples
- Profile References
- Submitted At
- Edited At
- Withdrawn At
- Boosted/Organic
- Cost of Promotion
- Outcome

**LaunchPad:** eigener Kernbereich nach V0.1.

---

## 11.6 Proposal Funnel

Mögliche Zustände:

- Prepared
- Submitted
- Viewed
- Shortlisted
- Response
- Interview
- Negotiation
- Offer
- Awarded
- Won
- Lost
- Withdrawn
- Expired

**LaunchPad:** wichtig für Analytics.

---

## 11.7 Company Management

Funktionen:

- Company Name
- Website
- Location
- Industry
- Notes
- Platform Identities
- Previous Opportunities
- Previous Proposals
- Relationship Strength
- Last Interaction
- Next Follow-up
- Client Quality Rating

**LaunchPad:** späterer Kern.

---

## 11.8 Contact Management

Funktionen:

- Name
- Role
- Company
- Professional Email
- Phone
- LinkedIn
- Platform Profile
- Relationship Type
- Relationship Status
- Notes
- First Contact
- Last Contact
- Follow-up
- Related Opportunities
- Related Activities

**LaunchPad:** späterer Kern.

Hinweis:

Private Informationen sollten nicht als umfangreiche strukturierte Persönlichkeitsprofile gesammelt werden. Gesprächsrelevante Kontextinformationen gehören eher in datensparsame Interaction Notes.

---

## 11.9 Activities / Interactions

Mögliche Typen:

- Note
- Platform Message
- Email
- Phone Call
- Video Call
- Meeting
- Proposal Submitted
- Interview
- Follow-up
- Offer
- Award
- Rejection
- Referral
- Reminder

Eigenschaften:

- OccurredAt
- DueAt
- CompletedAt
- Type
- Direction
- Outcome
- Notes
- Related Opportunity
- Related Proposal
- Related Contact
- Related Company

**LaunchPad:** langfristig sehr wichtig.

---

## 11.10 Observation / Market History

Dies ist eine besonders wichtige LaunchPad-spezifische Funktion.

Bei wiederholter Beobachtung einer Opportunity können gespeichert werden:

- ObservedAt
- Project State
- Budget
- Proposal Count
- Average Bid
- Winning Bid
- Client Activity
- Award Status
- Awarded Freelancer
- Published/Closed State
- Changed Fields

Damit wird Marktverhalten historisch nachvollziehbar.

**LaunchPad:** potenzielles Alleinstellungsmerkmal.

---

## 11.11 Skill Intelligence

Mögliche Funktionen:

- Opportunity Skills
- Profile Skills
- Skill Frequency
- Skill Trend
- Skill Co-occurrence
- Missing Profile Skills
- Skill Win Rate
- Skill Rate Distribution
- Skill Competition
- Aliases / Normalization

**LaunchPad:** später sehr wichtig.

---

## 11.12 Rate Intelligence

Mögliche Daten:

- Advertised Rate
- Advertised Budget
- Own Bid
- Winning Bid
- Hourly Rate
- Daily Rate
- Currency
- Platform Fee
- Effective Net Rate

Mögliche Analysen:

- Median
- Percentile
- Skill-specific Rates
- Platform-specific Rates
- Rate vs. Win Rate
- Rate vs. Response Rate
- Rate over Time

**LaunchPad:** Kernanalyse nach ausreichender Datenbasis.

---

## 11.13 Profile Intelligence

Mögliche Funktionen:

- Profile Snapshot
- Skills Snapshot
- Rate Snapshot
- Description Snapshot
- Visibility Metrics
- Profile Views
- Invitations
- Search Impressions
- Portfolio Views
- Profile Gap Analysis
- Before/After Comparison

**LaunchPad:** später.

---

## 11.14 Funnel Analytics

Mögliche Kennzahlen:

- Opportunities Discovered
- Opportunities Qualified
- Proposals Sent
- Viewed
- Responses
- Interviews
- Offers
- Wins
- Losses

Conversion Rates:

- Discovery → Qualified
- Qualified → Proposal
- Proposal → Response
- Response → Interview
- Interview → Offer
- Offer → Win

**LaunchPad:** sehr wichtig.

---

## 11.15 Relationship Analytics

Mögliche Kennzahlen:

- Repeat Clients
- Repeat Recruiters
- Follow-up Success
- Response Time
- Relationship Duration
- Opportunities per Contact
- Wins per Contact
- Wins per Company

**LaunchPad:** später.

---

## 11.16 Documents

Mögliche Dokumente:

- Proposal Versions
- CV Versions
- Cover Letter
- Portfolio References
- Screenshots
- Source HTML/Text
- Notes Export

**LaunchPad:** begrenzter Dokumentbezug sinnvoll; kein DMS bauen.

---

## 11.17 Export / Portability

Mögliche Formate:

- CSV
- JSON
- ZIP Backup
- SQLite Backup

**LaunchPad:** wichtig.

Local-first bedeutet auch:

> Der Benutzer muss seine Daten einfach sichern und exportieren können.

---

## 11.18 Import

Mögliche Stufen:

1. Manual Entry
2. Paste Text
3. CSV
4. JSON
5. Browser Helper
6. RSS/Feed
7. API
8. Carefully Governed HTML Import

**LaunchPad:** schrittweise.

---

## 11.19 Notifications

Mögliche Ereignisse:

- New Matching Opportunity
- Follow-up Due
- Opportunity Changed
- Opportunity Awarded
- Proposal Still Unanswered
- Contact Follow-up Due
- Saved Search Match

**LaunchPad:** später.

---

## 11.20 Payments, Billing und Project Delivery

Referenzprodukte bieten teilweise:

- Escrow
- Milestones
- Invoices
- Payment Processing
- Contracts
- Time Tracking
- Screenshots
- Disputes

### LaunchPad-Entscheidung

Diese Bereiche sollen **nicht** zum Kernprodukt werden.

LaunchPad endet fachlich primär bei:

```text
Discover
→ Evaluate
→ Apply
→ Observe
→ Relate
→ Outcome
→ Learn
```

Nach einem gewonnenen Auftrag kann später eine Übergabe an andere Systeme erfolgen.

---

# 12. Vorläufige Priorisierung für LaunchPad

Diese Tabelle ist noch **keine verbindliche Lastenheft-Priorisierung**, sondern eine Forschungsbewertung.

| Funktionsgruppe | Einordnung |
|---|---|
| Opportunity Capture | MVP-Kern |
| Full Description Storage | MVP-Kern |
| URL / Platform | MVP-Kern |
| Budget / Rate | MVP-Kern |
| Skills | MVP-Kern |
| Notes | MVP-Kern |
| Search / Filter | MVP-Kern |
| Status / Watchlist | MVP-Kern |
| Open Source URL | MVP-Kern |
| Proposal Entity | Früh nach MVP |
| Proposal Price / Rate | Früh nach MVP |
| Proposal Funnel | Früh |
| Observation History | Früh / strategisch |
| Company | Späterer Kern |
| Contact | Späterer Kern |
| Activity / Interaction | Späterer Kern |
| Follow-ups | Später |
| Opportunity Score | Später |
| Skill Intelligence | Später |
| Rate Intelligence | Später |
| Profile Intelligence | Später |
| Funnel Analytics | Später |
| Browser Import | Später |
| Platform API / Feed Import | Später |
| Export / Backup | Früh |
| Invoice | Nicht Kern |
| Escrow | Nicht Kern |
| Payment Processing | Nicht Kern |
| Contracts | Nicht Kern |
| Time Tracking | Nicht Kern |
| Screenshot Monitoring | Nicht Kern |
| Full Project Management | Nicht Kern |

---

# 13. Produktmuster, die sich über mehrere Vorbilder wiederholen

## 13.1 Opportunity und Proposal sind getrennt

PeoplePerHour, Upwork und Freelancer.com behandeln Ausschreibung und Bewerbung als unterschiedliche Objekte.

**Folgerung:** LaunchPad sollte das langfristig ebenfalls tun.

---

## 13.2 Historie ist wertvoller als nur aktueller Status

Huntr, Teal, Freelancer.com und CRM-Systeme zeigen, dass Aktivitäten und Verlauf entscheidend sind.

**Folgerung:** Statuswechsel und Beobachtungen sollten nicht einfach alte Informationen vernichten.

---

## 13.3 Kontakte gehören nicht als Textfeld in Opportunities

Huntr, Teal und HubSpot verwalten Kontakte separat und verknüpfen sie.

**Folgerung:** Recruiter und Hiring Manager sollten langfristig eigene Contact-Records sein.

---

## 13.4 Company ist ebenfalls eine eigene Entität

Mehrere Opportunities können von derselben Organisation stammen.

**Folgerung:** Company und Contact sollten getrennt modelliert werden.

---

## 13.5 Vollständige Ausschreibung sichern

Huntr und Teal speichern vollständige Jobbeschreibungen, weil Originalanzeigen verschwinden können.

**Folgerung:** LaunchPad sollte Source Text und Capture Timestamp ernst nehmen.

---

## 13.6 Ablehnungen liefern Daten

Malt und moderne Matching-Systeme nutzen auch negative Entscheidungen.

**Folgerung:** Nicht nur „interessant“ speichern, sondern später auch `DismissReason`.

---

## 13.7 Funnel-Daten sind strategisch wertvoll

Upwork, Freelancer.com und Huntr messen den Weg von Opportunity/Bid bis Hire/Offer.

**Folgerung:** LaunchPad sollte Analytics nicht auf Projektanzahl reduzieren.

---

## 13.8 Preis ist mehrdimensional

Der Markt kennt:

- advertised budget
- hourly rate
- daily rate
- own bid
- winning bid
- effective rate

**Folgerung:** Ein einziges `Budget`-Feld reicht langfristig nicht.

---

## 13.9 Profile und Markt beeinflussen sich gegenseitig

Malt, Upwork, Contra und Freelancer.com zeigen, dass Skills, Rate, Profilvollständigkeit, Reputation und Verfügbarkeit die Sichtbarkeit beeinflussen.

**Folgerung:** LaunchPad kann später die Schleife schließen:

```text
Market Demand
→ Opportunity Results
→ Profile Analysis
→ Profile Adjustment
→ New Market Results
```

---

# 14. Vorläufige Produktidentität von SASD Freelancer LaunchPad

Nach der Feature-Inventur erscheint folgende Positionierung am sinnvollsten:

> **SASD Freelancer LaunchPad ist eine local-first Windows-Anwendung zum Erfassen, Bewerten, Verfolgen und Analysieren von Freelancer-Chancen, Bewerbungen, Marktinformationen und beruflichen Beziehungen.**

Der zentrale Produktkreislauf lautet:

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
Improve targeting / profile / rate
   ↺
```

---

# 15. Bewusste Abgrenzung

LaunchPad soll voraussichtlich **nicht** werden:

- Freelancer Marketplace
- Payment Provider
- Escrow Provider
- Accounting System
- Invoice System
- Time Tracker
- Employee Monitoring Tool
- Contract Management Suite
- Full Project Management System
- Generic Enterprise CRM
- Resume Builder Clone

Diese Funktionen können bei Bedarf durch Integration oder Verweise an andere Werkzeuge angebunden werden.

---

# 16. Empfehlungen für das kommende Lastenheft 0.2

Das neue Lastenheft sollte mindestens folgende langfristige Produktbereiche ausdrücklich berücksichtigen:

1. Opportunity Management
2. Proposal Management
3. Market Observation
4. Skills
5. Pricing / Rate Signals
6. Company Management
7. Contact Management
8. Activities / Interactions
9. Follow-ups
10. Analytics
11. Profile Intelligence
12. Import / Capture
13. Export / Backup
14. Privacy / Data Minimization
15. Platform Independence

Gleichzeitig sollte das Lastenheft den frühen MVP klar abgrenzen:

> Der langfristige Scope darf die sofort nutzbare erste Version nicht verzögern.

---

# 17. Forschungsquellen

Alle Quellen wurden für diese Research-Baseline am 23.08.2026 geprüft. Bevor aus einzelnen Plattformfunktionen verbindliche technische Integrationen abgeleitet werden, sollten die jeweiligen Nutzungsbedingungen und aktuell verfügbaren APIs/Feeds erneut geprüft werden.

## PeoplePerHour

- PeoplePerHour Support – Glossary: PPH words and phrases  
  https://support.peopleperhour.com/hc/en-us/articles/205217157-Glossary-PPH-words-and-phrases

- PeoplePerHour Support – Freelancer Guide  
  https://support.peopleperhour.com/hc/en-us/articles/205217167-Freelancer-Guide

- PeoplePerHour Support – Submitting Proposals  
  https://support.peopleperhour.com/hc/en-us/articles/205217567-Submitting-Proposals

- PeoplePerHour Support – Approving a Proposal  
  https://support.peopleperhour.com/hc/en-us/articles/205217227-Approving-a-proposal

- PeoplePerHour Support – The Buyer Guide  
  https://support.peopleperhour.com/hc/en-us/articles/205217177-The-Buyer-Guide

- PeoplePerHour Support – WorkStream Policies  
  https://support.peopleperhour.com/hc/en-us/articles/205218197-WorkStream-Policies

- PeoplePerHour Support – Escrow  
  https://support.peopleperhour.com/hc/en-us/articles/205217357-Escrow

## Upwork

- Upwork Support – How to search for jobs  
  https://support.upwork.com/hc/en-us/articles/211063078-How-to-search-for-jobs-on-Upwork

- Upwork Support – Advanced search techniques  
  https://support.upwork.com/hc/en-us/articles/1500007921782-How-to-use-advanced-search-techniques-to-find-jobs

- Upwork Support – Instant job alerts  
  https://support.upwork.com/hc/en-us/articles/36001273797907-How-to-get-instant-job-alerts

- Upwork Support – Submit a Proposal  
  https://support.upwork.com/hc/en-us/articles/211062998-How-to-submit-a-proposal-on-Upwork

- Upwork Support – Proposal Insights  
  https://support.upwork.com/hc/en-us/articles/34019683309587-Proposal-insights

- Upwork Support – Stats and Trends  
  https://support.upwork.com/hc/en-us/articles/211062968-How-to-use-your-Upwork-stats-and-trends

- Upwork Support – Talent Search  
  https://support.upwork.com/hc/en-us/articles/211063528-How-to-search-for-freelancers-on-Upwork

## Freelancer.com

- Freelancer Support – Bidding on Projects  
  https://www.freelancer.com/support/Project/how-to-bid-1633

- Freelancer Support – Bookmark Projects  
  https://www.freelancer.com/support/project/how-do-i-bookmark-projects

- Freelancer Support – Bid Insights  
  https://www.freelancer.com/support/project/bid-insights

- Freelancer Support – Finding Work  
  https://www.freelancer.com/support/freelancer/project/how-to-find-projects

- Freelancer Support – Freelancer Ratings  
  https://www.freelancer.com/support/project/freelancer-ratings

- Freelancer – How It Works  
  https://www.freelancer.com/info/how-it-works

## Contra

- Contra Help – Applying to Jobs  
  https://help.contra.com/en/articles/9322973-applying-to-jobs-on-contra

- Contra Help – Onboarding and Completing Your Profile  
  https://help.contra.com/en/articles/9322381-onboarding-and-completing-your-profile

- Contra Help – Paid Projects  
  https://help.contra.com/en/articles/9322763-paid-projects

- Contra Help – Invoices  
  https://help.contra.com/en/articles/9322851-invoices

- Contra Help – Contra Pro  
  https://help.contra.com/en/articles/9322981-what-is-contra-pro

## Malt

- Malt Help – Opportunities for Freelancers  
  https://help.malt.com/hc/en-150/articles/29534878703506-How-do-opportunities-work-for-freelancers

- Malt Help – Freelancer Profile  
  https://help.malt.com/hc/en-150/articles/29517405925778-How-do-I-complete-and-modify-my-profile-on-Malt

- Malt Help – Profile Visibility  
  https://help.malt.com/hc/en-150/articles/29532973052178-Visibility-of-my-profile

- Malt Help – Availability  
  https://help.malt.com/hc/en-150/articles/29532261225746-How-do-I-manage-my-availability-on-Malt

- Malt Help – Average Daily Rate  
  https://help.malt.com/hc/en-150/articles/29580630770706-What-is-the-average-daily-rate-for-freelancers

- Malt Help – Project Types  
  https://help.malt.com/hc/en-150/articles/29571442838418-What-are-the-project-types-on-Malt

## Huntr

- Huntr Help – Job Tracker  
  https://help.huntr.co/en/articles/9883324-job-tracker

- Huntr Help – Job Board  
  https://help.huntr.co/en/articles/13413245-the-job-board

- Huntr Help – Job Card  
  https://help.huntr.co/en/articles/12640406-understanding-the-job-card

- Huntr Help – Activities  
  https://help.huntr.co/en/articles/10042702-activities

- Huntr Help – Contacts and Documents  
  https://help.huntr.co/en/articles/10089169-contacts-and-documents

- Huntr Help – Maps and Metrics  
  https://help.huntr.co/en/articles/10042709-maps-and-metrics

- Huntr Help – Data Export  
  https://help.huntr.co/en/articles/11757717-download-export-your-board

## Teal

- Teal Knowledge Base – Job Tracker  
  https://help.tealhq.com/en/articles/14435727-how-to-track-your-job-applications

- Teal Knowledge Base – Job Tracker Tools  
  https://help.tealhq.com/en/articles/9525013-leveraging-your-job-tracker-tools

- Teal Knowledge Base – Contacts Tracker  
  https://help.tealhq.com/en/articles/9509581-getting-started-contacts-tracker

- Teal Knowledge Base – Companies Tracker  
  https://help.tealhq.com/en/articles/9509624-getting-started-companies-tracker

- Teal Knowledge Base – Taking Notes  
  https://help.tealhq.com/en/articles/9530145-job-tracker-taking-notes

- Teal Knowledge Base – Guidance  
  https://help.tealhq.com/en/articles/9530119-job-tracker-guidance

## HubSpot CRM

- HubSpot Knowledge Base – Understand Objects  
  https://knowledge.hubspot.com/records/understand-objects

- HubSpot Knowledge Base – Work with Records  
  https://knowledge.hubspot.com/records/work-with-records

- HubSpot Knowledge Base – Log Activities  
  https://knowledge.hubspot.com/records/manually-log-activities-on-records

- HubSpot Knowledge Base – Associate Activities  
  https://knowledge.hubspot.com/records/associate-activities-with-records

---

# 18. Abschluss

Dieses Dokument soll als Recherchegrundlage dienen.

Der nächste sinnvolle Schritt ist **nicht sofort Code**, sondern die Überarbeitung des Lastenhefts auf Basis dieser Funktionsinventur.

Dabei sollten wir bewusst unterscheiden zwischen:

- langfristiger Produktvision
- frühem Produktkern
- MVP
- späteren Analysefunktionen
- ausdrücklich ausgeschlossenen Bereichen

Dadurch kann LaunchPad schnell nützlich werden, ohne sich langfristig auf ein zu kleines Daten- und Produktmodell festzulegen.
