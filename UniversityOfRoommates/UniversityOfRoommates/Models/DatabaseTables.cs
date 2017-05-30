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
        public string codiceFiscale { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public bool sesso { get; set; }
        public DateTime ddn { get; set; }
        public string cittàProvenienza { get; set; }
        public string email { get; set; }
        public string cell { get; set; }
        
        [ForeignKey("Interesse")]
        public int idInteresse { get; set; }
        public Interesse Interesse { get; set; }
    }
    public class Proprietario
    {
        [Key, ForeignKey("Utente")]
        public string codiceFiscale { get; set; }
        public Utente Utente { get; set; }
        public string iban { get; set; }
        public string paypalMe { get; set; }
        public byte[] cartaIdentità { get; set; }
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
        [Key]
        public int idCasa { get; set; }
        [ForeignKey("Proprietario")]
        public string codiceFiscale { get; set; }
        public Proprietario Proprietario { get; set; }
        public decimal longitudine { get; set; }
        public decimal latitudine { get; set; }
        public string indirizzo { get; set; }
        public string civico { get; set; }
        public int cap { get; set; }
        public int numeroServizi { get; set; }
        public double metraturaInterna { get; set; }
        public double metraturaEsterna { get; set; }
        public bool postoAuto { get; set; }
        public string descrizioneServizi { get; set; }
    }

	public class FotoCasa
	{ 
		[Key, ForeignKey("Casa")]
        [Column(Order = 1)]
        public int idCasa { get; set; }
        public Casa Casa { get; set; }
        [Key]
        [Column(Order = 2)]
        public int idFoto { get; set; }
		public byte[] foto { get; set; }
	}

	public class Stanza
	{
		[Key]
        [Column(Order = 1)]
        public int idStanza { get; set; }
		[Key, ForeignKey("Casa")]
        [Column(Order = 2)]
        public int idCasa { get; set; }
        public Casa Casa { get; set; }
        public int postiLetto { get; set; }
		public double metratura { get; set; }
		public byte[] foto { get; set; }
		public decimal prezzo { get; set; }
		
	}

    public class Affitto
    {
        [Key, ForeignKey("Stanza")]
        [Column(Order = 1)]
        public int idStanza { get; set; }
        [Key, ForeignKey("Stanza")]
        [Column(Order = 2)]
        public int idCasa { get; set; }
        public Stanza Stanza { get; set; }
        [Key, ForeignKey("Utente")]
        [Column(Order = 3)]
        public string codiceFiscale { get; set; }
        public Utente Utente { get; set; }
    }

}