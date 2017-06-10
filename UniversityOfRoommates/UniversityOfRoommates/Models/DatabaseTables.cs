using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Drawing;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityOfRoommates.Models
{
    public class DatabaseTables
    {    }
    public class Utente
    {
        [Key]
        public string nick { get; set; }

        public string pass { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public bool sesso { get; set; }
        public DateTime ddn { get; set; }
        public string cittàProvenienza { get; set; }
        public string email { get; set; }
        public string cell { get; set; }
        
        public ICollection<DebitiCrediti> Debiti { get; set; }
        public ICollection<DebitiCrediti> Crediti { get; set; }
        //public ICollection<Proprietario> Proprietario { get; set; }
        //public ICollection<Interesse> Interesse { get; set; }
        public ICollection<Affitto> Affitto { get; set; }
    }
    public class Proprietario
    {
        [Key, ForeignKey("Utente")]
        public string nick { get; set; }
        public Utente Utente { get; set; }

        public string iban { get; set; }
        public string paypalMe { get; set; }
        public byte[] cartaIdentità { get; set; }

        public ICollection<Casa> Casa { get; set; }
    }
    public class Interesse
    {
        [Key, ForeignKey("Utente")]
        public string codiceFiscale { get; set; }
        public Utente Utente { get; set; }

        public string p1 { get; set; }
        public string p2 { get; set; }
        public string p3 { get; set; }
        public string p4 { get; set; }
        public string p5 { get; set; }
        public string p6 { get; set; }
        public string p7 { get; set; }
        public string p8 { get; set; }
    }
    public class Casa
    {
        [Key,Column(Order = 1)]
        public string nomeCasa {get; set; }

        [Key, Column(Order = 2)]
        public decimal longitudine { get; set; }

        [Key, Column(Order = 3)]
        public decimal latitudine { get; set; }

        [ForeignKey("Proprietario")]
        public string codiceFiscale { get; set; }
        public Proprietario Proprietario { get; set; }

        public string provincia{ get; set; }
        public string city { get; set; }
        public string indirizzo { get; set; }
        public string civico { get; set; }
        public int cap { get; set; }
        public int numeroServizi { get; set; }
        public double metraturaInterna { get; set; }
        public double metraturaEsterna { get; set; }
        public bool postoAuto { get; set; }
        public string descrizioneServizi { get; set; }

        public ICollection<FotoCasa> FotoCasa { get; set; }
        public ICollection<Stanza> Stanza { get; set; }
    }

    public class FotoCasa
	{ 
		[Key, ForeignKey("Casa")]
        [Column(Order = 1)]
        public string nomeCasa { get; set; }

        [Key, ForeignKey("Casa")]
        [Column(Order = 2)]
        public decimal longitude { get; set; }

        [Key, ForeignKey("Casa")]
        [Column(Order = 3)]
        public decimal latitude { get; set; }

        public Casa Casa { get; set; }

        [Key]
        [Column(Order = 4)]
        public int idFoto { get; set; }
		public string linkFoto { get; set; }
	}

	public class Stanza
	{
		[Key]
        [Column(Order = 1)]
        public int idStanza { get; set; }

		[Key, ForeignKey("Casa")]
        [Column(Order = 2)]
        public string nomeCasa { get; set; }

        [Key, ForeignKey("Casa")]
        [Column(Order = 3)]
        public decimal longitude { get; set; }

        [Key, ForeignKey("Casa")]
        [Column(Order = 4)]
        public decimal latitude { get; set; }

        public Casa Casa { get; set; }

        public int postiLetto { get; set; }
		public double metratura { get; set; }
		public byte[] foto { get; set; }
		public decimal prezzo { get; set; }

        public ICollection<Affitto> Affitto { get; set; }
    }

    public class Affitto
    {
        [Key, ForeignKey("Stanza"), Column(Order = 1)]        
        public int idStanza { get; set; }

        [Key, ForeignKey("Stanza"), Column(Order = 2)]
        public string nomeCasa { get; set; }
        public Stanza Stanza { get; set; }

        [Key, ForeignKey("Stanza")]
        [Column(Order = 3)]
        public decimal longitude { get; set; }

        [Key, ForeignKey("Stanza")]
        [Column(Order = 4)]
        public decimal latitude { get; set; }

        [Key, ForeignKey("Utente"), Column(Order = 5)]
        public string codiceFiscale { get; set; }
        public Utente Utente { get; set; }

        public DateTime inizioContratto { get; set; }
        public DateTime fineContratto { get; set; }

        //public ICollection<GestioneCasa> GestioneCasa { get; set; }
    }
    public class GestioneCasa
    {
        [Key,ForeignKey("Casa")]
        [Column(Order = 1)]
        public string nomeCasa { get; set; }

        [Key, ForeignKey("Casa")]
        [Column(Order = 2)]
        public decimal longitude { get; set; }

        [Key, ForeignKey("Casa")]
        [Column(Order = 3)]
        public decimal latitude { get; set; }

        public Casa Casa { get; set; }

        public string noteComuni { get; set; }

        public ICollection<Evento> Evento { get; set; }
    }
    public class Evento
    {
        [Key, ForeignKey("GestioneCasa"), Column(Order = 1)]
        public string nomeCasa { get; set; }

        [Key, ForeignKey("GestioneCasa")]
        [Column(Order = 2)]
        public decimal longitude { get; set; }

        [Key, ForeignKey("GestioneCasa")]
        [Column(Order = 3)]
        public decimal latitude { get; set; }

        public GestioneCasa GestioneCasa { get; set; }

        [Key, Column(Order = 4)]
        public int idEvento { get; set; }

        public string nick { get; set; }
        public string descrizione { get; set; }
        public DateTime data { get; set; }
        public int giorno { get; set; }
    }   

    public class DebitiCrediti
    {
        public DebitiCrediti() { }

        [Key, Column(Order = 0)]
        public int idCreditiDebiti { get; set; }

        [ForeignKey("UtenteC")]
        public string codiceFiscaleCreditore { get; set; }
        public Utente UtenteC { get; set; }

        [ForeignKey("UtenteD")]
        public string codiceFiscaleDebitore { get; set; }
        public Utente UtenteD { get; set; }

        public double cifra { get; set; }
        public string descrizione { get; set; }
        public DateTime data { get; set; }
    }
}


