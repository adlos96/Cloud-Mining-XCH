# [Task]
 Lore:
 al momento per come è strutturato il programma, il core gestisce praticamente tutto il progetto, appoggiandosi alla rete chia per effettuare le transazioni.
 
 Una volta che sono stati impostati:
 - Indirizzo xch (Obbligatorio)
 - Somma depositata nel software (Obbligatorio)
 - Impostato il livello di bonus 0% <-> 18% (Opzionale)
 - Nome utente (Opzionale)
 
 Il core effettua le proprie operazioni ricavando così un file .xml che verrà poi aperto da un database autocostruito per lo scopo.
 Una volta che il/gli utenti sono stati inseriti nel database il loop può essere avviato, se durante il loop viene aggiunto un nuovo utente, tale utente verrà incluso nelle transazioni nello stesso loop oppure 24h dopo che il primo ciclo sia completato.
 
 Per ogni transazione eseguita verrà creata una cartella transazioni, la quale conterrà al suo intenro una serie di cartelle (es1. 1_Carlo) (es2. xch9876INDIRIZZOtest_1_Carlo ) contenenti le transazioni di tutti gli utenti.
 

//Core
- [x] Pagamenti automatici rete chia
- [x] Controllo effettiva inclusione della transazione in mempool sulla rete chia
- [x] Database clienti
- [x] Database transazioni
- [x] Ottenimento dato (-tx) per l'avvenuta inclusione della transazione
- [x] Caricamento e salvataggio dati ad ogni ciclo completato (24h)
- [x] Auto calcolo del tempo di dalay causato dal codice per effettuare i pagamenti
- [x] Invio di email automatico se richesto con i dati della transazione
- [x] Rendimento annuo 3% sul capitale depositato
- [x] Funzione di liquidazione se un determinato rapporto viene rispettato
- [x] Calcolo totale depositi effettuali sul programma
- [x] Calcolo credito totale che deve ancora essere pagato dal programma
- [x] Conta il numero delle transazioni che sono state effettuate verso un dato cliente


//Server (Minimo indispensabile)
- [] Autentica il clienti e verifica se è già presente nel database
- [] Permette il passaggio di dati dal clienti ad core.
(L'aggiunta al database da parte del core è impostato in maniera manuale, qualcuno dal pc deve premere col mouse su aggiungi al database ♦)
- [] Permette il pasaggio dei file/dati dal core al client per la visualizzazione
- [] Permette la comunicaione di più client in contemporanea

Futuro remoto
- [] Permette il prelievo dei fondi (USDT) escluso il bonus iniziale dopo un periodo di tempo (Penale)
- [] Gestione di vari fullnode o partialnode se disponibili (Ethereum - Chia Network - Terra Luna - Conos chain)
- [] Gestione automatico staking
- [] Gestione automatico withdraw
- [] Swap automatico per ribilanciamento

//Client (Minimo indispensabile)

- [] Autenticare il client così da riconoscerlo ed inviare i file solo a lui, e non ad un'altro a caso
(Come autenticazione, inizialmente pensavo di utilizzare un'indirizzo XCH che l'utente deve fornire, visto che gli indirizzi sono univoci. Nel futuro sarebbe carino rendere tale processo più siguro e più complicato da "verificare" dall'esterno)
- [] Possibilità di effettuare un deposito in USDT ed attendere 60 minuti.
Prima dell'annullamento della richiesta nel caso in cui la cifra selezionata non venga depositata in tale finestra temporale [
Rete Etherem(ERC20) (Preferibile)
Poligon				(Fee basse)
Tron(TRC20)			(Beh)

- [] Richiesta di tali dati dal server ed il server deve richiederli al core (sono salvati in file .xml)
- [] Naturalmente un pochetto di crittografia dei dati ♦