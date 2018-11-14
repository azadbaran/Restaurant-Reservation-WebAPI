using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Web.ViewModels.api
{
    public class RezervacijaAddVM
    {
     
        public string vrsta;
        public string datum;
        public string vrijeme;
        public int korsnikId;
        public int restoranId;
        public int brojOsoba;
    }
}
