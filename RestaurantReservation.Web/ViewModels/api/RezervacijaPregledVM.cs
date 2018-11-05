using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Web.ViewModels.api
{
    public class RezervacijaPregledVM
    {

        public class Row
        {
            public int? id;
            public string vrsta;
            public string datum;
            public string vrijeme;
            public string korsnik;
            public string restoran;

          
        }

        public List<Row> rows;
    }
}
