using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Web.ViewModels.api
{
    public class RezervacijaAddVM
    {
        public int? id;
        public string vrsta;
        public DateTime datum;
        public DateTime vrijeme;
        public int korsnikId;
        public int restoranId;

    }
}
