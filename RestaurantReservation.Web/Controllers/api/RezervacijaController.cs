using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Data.EF;
using RestaurantReservation.Web.Helper.webapi;

using RestaurantReservation.Data.EntityModels;

using RestaurantReservation.Web.ViewModels.api;

namespace RestaurantReservation.Web.Controllers.api
{
    [MyApiAuthorize]
    public class RezervacijaController : MyWebApiBaseController
    {
        public RezervacijaController(MyContext db) : base(db)
        {

        }


        //[HttpGet]
        //public ActionResult<RezervacijaPregledVM> Index()
        //{


        //    var model = new RezervacijaPregledVM
        //    {
        //        rows = _db.Rezervacija
        //            .OrderByDescending(s => s.Id)
        //            .Select(s => new RezervacijaPregledVM.Row
        //            {
        //                id = s.Id,
        //                datum = s.Datum.ToString("dd.MM.yyyy"),
        //                vrijeme = s.Vrijeme.ToString("dd.MM.yyyy"),
        //                vrsta = s.Vrsta,
        //                korsnik = s.Korisnik.Ime+" "+s.Korisnik.Prezime,
        //                restoran = s.Restoran.Naziv

        //            }).ToList()
        //    };


        //    return model;
        //}

        [HttpPost]
        public int Add([FromBody] RezervacijaAddVM input)
        {
            Rezervacija newRezervacija = new Rezervacija()
            {
                Datum = input.datum,
                Vrijeme = input.vrijeme,
                Vrsta = input.vrsta,
                KorisnikId = input.korsnikId,
                RestoranId = input.restoranId,

                
            };
            _db.Add(newRezervacija);
            _db.SaveChanges();
            return 0;
        }
    }
}