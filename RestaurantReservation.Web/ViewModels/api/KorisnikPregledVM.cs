using System.Collections.Generic;

namespace RestaurantReservation.Web.ViewModels.api
{
    public class KorisnikPregledVM
    {
        public class Row
        {
            public int? id;
            public string ime;
            public string prezime;
            public string email;
            public string password;

        }

        public List<Row> rows;
    }
}
