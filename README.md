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

#### **Help**

##### **Forma za Login**

###### Username and Password

U ova polja unosite ime vašeg korisničkog naloga i šifru koju ste napravili. Šifra mora sadržavati
minimalno sedam karaktera. Ako ste novi radnik (tj. niste registrovani u bazu) klikom na Login dugme
bit ćete prebačeni na formu za registraciju gdje će te morati popuniti osnovne podatke o sebi.

###### Novi klijent

Ovu opciju možete izabrati ako želite naručiti novu misiju. Klikom na dugme "Novi klijent" bivate
prebačeni na novu formu za naručivanje misije gdje popunjavate pojedinosti o meti i način izvršavanja
misije.

##### **Forma za Kontakt**
 
###### Ime i prezime

U ova polja unosite vaše ime i prezime.

###### e-mail

Ovo polje je predviđeno za unos e-maila.

###### Broj telefona

Polje gdje upisujete vaš broj telefona.

##### **Forma za podnošenje izvještaja**

Trenutna (demo) verzija forme za podnoešenje izvještaja se sadrži od informacije o stanju budžeta
sa kojim agenti raspolažu na misiji i njihove trenutne lokacije.

###### Stanje budžeta

U textbox se unosi trenutno stanje budžeta. Ova informacija pomaže Direktoru i Menadžeru da znaju
da li je misija prevazišla predviđena sredstva.

###### Dobavi lokaciju

Klikom na ovu opciju će vam u poljima za Longitude i Latitude biti ispisane vaše tačne geografske 
koordinate i na mapi će vaša lokacija biti pingovana tako da Direktor može poslati tim za evakuaciju
ako dođe do nenadanih smetnji tokom misije.

##### **Forma za konektovanje sa Arduinom**

###### Connection Method

U ovoj padajućoj listi možete izabrati između 3 vrste konekcije Arduino uređaja sa vašim uređajem.
Postoje tri opcije:
- Bluethoot konekcija
- USB konekcija
- Network konekcija

Pošto je ovo demo verzija aplikacije, trenutno je funkcionalna samo USB konekcija Arduina.
Izabirom ove opcije aplikacija sama automatski određuje na koji USB port je priključen Arduino
i daje korisniku kontrolu nad uređajem.

##### **Forma za Direktora**

###### Uposlenici

Klikom na ovo dugme možete da pratite aktivnosti svih uposlenika agencije.

###### Izvještaji

Ova opcija vam pruža uvid u izvještaje koje Vam je Menadžer poslao. Pristupate bazi podataka sa
izvještajima sa svih misija.

###### Misije

Izabirom ove opcije pristupate bazi podataka svih misija gdje možete pratiti stanje tekućih misija
i po potrebi neke terminirati. Također možete pristupiti podacima već završenih i arhiviranih misija.

#### **Procesi**

###### **Kreiranje misije**

Klijent kreira zahtjev za špijuniranjem mete, ometanje rada, rušenje vlade
(Klijent K -> Direktor M). Zahtjev razmatra Direktor nakon konsultacije sa Menadžerom sektora
i može ga ili odobriti ili odbiti. Nakon toga Menadžer kreira misiju, što uključuje formiranje 
radne grupe, dodjeljivanje opreme, specifikacija cilja.

###### **Regrutovanje novih agenata**

Ukoliko nisu dostupni agenti traženih karakteristika, moguće je regrutovati nove agente
privremeno ili za stalno.

###### **Kontrola misije i izvještavanja**

Tokom trajanja same misije, tim operativaca koji može biti ili pojedinac ili grupa predvođena
sa glavnim agentom, daje dnevni izvještaj o stanju misije, a samu misiju nadgleda
Menadžer koji podnosi redovni izvještaj Direktoru agencije M. A ako dođe do
neodložive sitaucije koja mora biti riješena, šalje se hitni izvještaj Direktoru agencije
koji poduzima potrebne korake.

Ukoliko dođe do potrebe da se misija otkaže, Direktor M može tražiti ekstrakciju agenata. (Tražeći
pomoć od vojnih organa ili drugih prijateljskih organizacija)

###### **Održavanje i nabavka opreme**

Nakon završetka misije, sva oštećena oprema ide na opravku, izgubljena se nadomješćuje, a sva
ostala oprema se šalje na analizu koju nadgleda Menadžer. 

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
* Modul za slanje izvještaja (Menadžer -> M)
* Modul za nadzor opreme
* Modul za update informacija (Agent 00x -> Menadžeru)
* Modul za kontrolu misije
* Regrutovanje novih agenata
* Modul za pretragu baze podataka
* Modul za kontaktiranje vanjskih aktera
  * Kontaktiranje vojske
  * Kontaktiranje kineskih hakera

#### **Akteri**

* Klijent (naručilac misije)
  * Pravno lice (mogućnost naručivanja složenijih i obimnijih misija (VIP))
  * Fizičko lice
* Operativci
  * Agenti (operativci nižeg ranga, primaju naredbe od Agenta 00x)
  * Agent 00x (vođe operativnih timova)
* Direktor agencije M (veliki B.R.A.T.)
* Menadžer (obavlja sve poslove administracije i organizovanja misija)
* Eksterni akteri (pozivaju se u slučaju ekstremnih situacija)
  * Vojni organi (pomažu pri nenadanoj ekstrakciji agenata)
  * Druge agencije (razmjena resursa)
