# powerdistributionsystem

# Projektni zadatak 4 – Power distribution system

Potrebno je napraviti dizajn sistema, arhitekturu sistema, implementirati i istestirati rešenje koje simulira rad sistema za distribuciju električne energije. Sistem sadrži distributivni centar, vetrogeneratore, solarne panele, jednu hidroelektranu i potrošače. Svi generatori šalju proizvedenu električnu energiju distributivnom centru, svi potrošači šalju zahtev za električnom energijom takođe distributivnom centru.
## Consumer
-	Korisniku nudi UI unutar kog se može izvršiti odabir uređaja koji korisnik uključuje
-	Potrošač ima par uređaja koji zahtevaju različitu količinu električne energije po satu
-	Prilikom uključivanja uređaja potrošač javlja distributivnom centru kolika je trenutna potražnja energije na osnovu čega zatim prima energiju od ditributivnog centra kao i informaciju o ceni po kWh
-	Svaki prijem el. energije potrebno je zabeležiti na konzoli i logovati sve događaje u .txt fajl
## Distribution centar
-	Prima zahteve potrošača za električnom energijom i na osnovu toga šalje zahtev hidroelektrani da pojača ili smanji proizvodnju
-	Prima informacije o tome koliko električne energije trenutno proizvode solarni paneli i vetrogeneratori. Te informacije uključuje u jednačinu za računanje potrebe za  radom hidroelektrane.
-	Distributivni centar računa cenu el.energije koju potrošač potražuje i šalje mu izveštaj
-	Loguje sve događaje u .txt fajl
## Solar panels and  wind generators
-	Potrebno je da korisnik unese vrednost snage sunca/vetra ili da se vrednost random generiše 
0 – 100 %. U odnosu na date podatke generatori šalju distributivnom centru informaciju o svojoj trenutnoj proizvodnji. Snaga sunca i vetra potrebno je da se menja na neko određeno vreme
-	Može postojati više instanci solarnih panela i vetrogeneratora
-	Svaka instanca panela i vetrogeneratora mora promene snage čuvati u bazi podataka
-	Podaci za upis u bazu moraju sadržati informaciju o snazi resursa kao i Timestamp promene
## Hydroelectric power plant
-	Hidroelektrana je glavni izvor električne energije u sistemu ali njena proizvodnja može biti regulisana 0 - 100%. Regulaciju rada hidroelektrane vršiće distributivni centar u odnosu na potražnju i energiju generisanu obnovljivim izvorima.
-	Podatke o regulaciji rada hidroelektrane moraju biti sačuvani u bazu podataka. Podaci sadrže informacije o procentu angažovanosti elektrane i Timestamp promene režima rada

**Sva vremena moraju biti konfigurabilna**
