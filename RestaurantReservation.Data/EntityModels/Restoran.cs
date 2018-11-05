using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantReservation.Data.EntityModels
{
   public class Restoran
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Grad { get; set; }
        public string Adresa { get; set; }
        public string Mail { get; set; }
        public string Telefon { get; set; }


    }
}
