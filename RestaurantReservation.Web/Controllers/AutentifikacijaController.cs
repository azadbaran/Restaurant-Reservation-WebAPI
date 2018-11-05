using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Data.EF;
using RestaurantReservation.Data.EntityModels;
using RestaurantReservation.Web.Helper;
using RestaurantReservation.Web.Helper.mvc;
using RestaurantReservation.Web.ViewModels;
namespace RestaurantReservation.Web.Controllers
{
    public class AutentifikacijaController : MyMvcBaseController
    {

        public AutentifikacijaController(MyContext db) : base(db)
        {
        }
        public IActionResult Index()
        {

            return View(new LoginVM()
            {
                SavePassword = true,
            });
        }

        public IActionResult Login(LoginVM input)
        {
            KorisnickiNalog korisnik = _db.KorisnickiNalog
                .SingleOrDefault(x => x.KorisnickoIme == input.Username /*&& x.Lozinka == input.password*/);

            if (korisnik == null)
            {
                TempData["error_poruka"] = "pogrešan username ili password";
                return View("Index", input);
            }

            HttpContext.SetLogiraniKorisnik(korisnik, input.SavePassword);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {

            return RedirectToAction("Index");
        }

       
    }
}