using System.ComponentModel.DataAnnotations;
using RestaurantReservation.Web.Helper;

namespace RestaurantReservation.Web.ViewModels.api
{
    public class AutentifikacijaResultVM
    {
        public int korisnikId;
        public string username;
        public string ime;
        public string prezime;
        public string token;
        public string mail;
        public string password;

        public int? korisnickiNalogId;
    }
}
