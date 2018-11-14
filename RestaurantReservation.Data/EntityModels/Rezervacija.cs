using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RestaurantReservation.Data.EntityModels
{
   public  class Rezervacija
    {
        public int Id { get; set; }
        public string Vrsta { get; set; }
        public DateTime Datum { get; set; }
        public DateTime Vrijeme { get; set; }
        public int BrojOsoba { get; set; }


        [ForeignKey(nameof(Restoran))]
        public int? RestoranId { get; set; }
        public Restoran Restoran { get; set; }

        [ForeignKey(nameof(Korisnik))]
        public int? KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }

    }
}
