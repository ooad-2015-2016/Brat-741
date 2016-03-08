# Brat-741
## Špijunska Agencija

#### **Članovi tima**

1. Besim Arnautović
2. Rijad Muminović
3. Amar Čivgin
4. Tarik Pljevljaković

#### **Opis Teme**

U modernom vremenu djelovanja različitih terorističkih grupa, diktatorskih režima i 
moćnih zlikovaca, kao odgovor na sve ove prijetnje nastala je špijunska agencija
B.R.A.T. (Battle Response Action Taskforce) sa ciljem da se klijentima olakša proces
naručivanja usluga ili vrši proces dobavljanja informacija i podataka o metama.
Mete mogu biti različitog tipa, od pojedinaca do većih organizacija i vlada.
Kroz ovaj sistem korisnik može da prati trenutno stanje misije i zadaje nove zadatke,
tokom samog trajanja misije.
Ovaj sistem nije na prodaju, a i sumnjamo da možete priuštiti naše usluge.

Ova poruka će se samouništiti nakon 1.5 godina.

#### **Procesi**

###### **Kreiranje misije**

Klijent kreira zahtjev za špijuniranjem mete, ometanje rada, rušenje vlade
(Klijent K -> Direktor M). Zahtjev razmatra Direktor nakon konsultacije sa Direktorima sektora
i može ga ili odobriti ili odbiti. Nakon toga Direktor operacija i Direktor administracije
kreiraju misiju, što uključuje formiranje radne grupe, dodjeljivanje opreme, specifikacija cilja.

###### **Regrutovanje novih agenata**

Ukoliko nisu dostupni agenti traženih karakteristika, moguće je regrutovati nove agente
privremeno ili za stalno.

###### **Kontrola misije i izvještavanja**

Tokom trajanja same misije, tim operativaca koji može biti ili pojedinac ili grupa predvođena
sa glavnim agentom, daje dnevni izvještaj o stanju misije, a samu misiju nadgleda
Direktor operacija koji podnosi redovni izvještaj Direktoru agencije M. A ako dođe do
neodložive sitaucije koja mora biti riješena, šalje se hitni izvještaj Direktoru agencije
koji poduzima potrebne korake.

Ukoliko dođe do potrebe da se misija otkaže, direktor može tražiti ekstrakciju agenata. (Tražeći
pomoć od vojnih organa ili drugih prijateljskih organizacija)

###### **Održavanje i nabavka opreme**

Nakon završetka misije, sva oštećena oprema ide na opravku, izgubljena se nadomješćuje, a sva
ostala oprema se šalje na analizu koju nadgleda Direktor tehnologija. 

###### **Obrada prikupljenih informacija**

Prikupljene informacije se šalju klijentu, i čuva se u bazi podataka, kojoj potpun 
pristup ima samo Direktor agencije.



#### **Funkcionalnosti**

* [x] Sve je enkriptovano
* Različiti nivoi pristupa bazi podataka
* Modul za kontaktiranje agencije
* Modul za logiranje zaposlenika agencije
* Modul za kreiranje misije
* Modul za formiranje radne grupe
* Modul za slanje izvještaja (Direktor sektora -> M)
* Modul za nadzor opreme
* Modul za update informacija (Agent 00x -> Direktoru sektora)
* Modul za kontrolu misije
* Regrutovanje novih agenata
* Modul za pretragu baze podataka
* Modul za kontaktiranje vanjskih aktera
  * Kontaktiranje vojske
  * Kontaktiranje kineskih hakera

#### **Akteri**

* Klijent (naručilac misije)
  * Pravno lice (mogućnost naručivanja složenijih i obimnijih misija)
  * Fizičko lice
* Operativci
  * Agenti (operativci nižeg ranga, primaju naredbe od Agenta 00x)
  * Agent 00x (vođe operativnih timova)
* Direktor agencije M (veliki B.R.A.T.)
* Direktori sektora (M-ovi pomoćnici, obezbjeđuju nesmetan rad agencije)
  * Direktor tehnologija (zadužen za kontrolu opreme)
  * Direktor administracija (zadužen za kontrolu agenata)
  * Direktor operacija (zadužen za kontrolu tekućih misija)
* Eksterni akteri (pozivaju se u slučaju ekstremnih situacija)
  * Vojni organi (pomažu pri nenadanoj ekstrakciji agenata)
  * Druge agencije (razmjena resursa)
