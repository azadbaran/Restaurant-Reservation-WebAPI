using System.ComponentModel.DataAnnotations;
using RestaurantReservation.Web.Helper;

namespace RestaurantReservation.Web.ViewModels.api
{
    public class AutentifikacijaResultVM
    {
        public string username;
        public string ime;
        public string prezime;
        public string token;
        public int? korisnickiNalogId;
    }
}
