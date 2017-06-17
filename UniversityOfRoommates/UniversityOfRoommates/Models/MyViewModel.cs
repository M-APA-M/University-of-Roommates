using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityOfRoommates.Models
{

    //questo docuento serve a caricarci tutte le classi che ci potrebbero servire per i vari scopi e utilizzi



    public class Circondariato //questa serve per non caricare la pagina della mappa con tutte le minchiate di Casa
    {
        public string nomeCasa { get; set; }
        public float lon { get; set; }
        public float lat { get; set; }
        public string indirizzo { get; set; }
    }
}