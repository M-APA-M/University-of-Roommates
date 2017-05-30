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
    }
    public class Proprietario
    {
        [Key][ForeignKey ("Utente")]
        public string codiceFiscale { get; set; }
        public string iban { get; set; }
        public string paypalMe { get; set; }
        public Bitmap cartaIdentità { get; set; }
    }
    public class Interesse
    {
        [Key][ForeignKey("Utente")]
        public string codiceFiscale { get; set; }
        public string p1 { get; set; }
        public string p2 { get; set; }
        public string p3 { get; set; }
        public string p4 { get; set; }
        public string p5 { get; set; }
        public string p6 { get; set; }
        public string p7 { get; set; }
        public string p8 { get; set; }
    }
}