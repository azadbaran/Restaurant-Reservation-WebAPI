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


        [HttpGet]
        public ActionResult<RezervacijaPregledVM> Index(int id)
        {

            var model = new RezervacijaPregledVM
        {
            rows = _db.Rezervacija
                .Where(x=> x.Korisnik.KorisnickiNalogId== id)
                .Select(s => new RezervacijaPregledVM.Row
                {
                    id = s.Id,
                    datum = s.Datum.ToString("dd.MM.yyyy"),
                    vrijeme = s.Vrijeme.ToString("hh:mm"),
                    vrsta = s.Vrsta,
                    korsnik = s.Korisnik.Ime + " " + s.Korisnik.Prezime,
                    restoran = s.Restoran.Naziv,
                    brojOsoba=s.BrojOsoba
                }).ToList()
        };


            return model;
        }

        [HttpPost]
        public int Add([FromBody] RezervacijaAddVM input)
        {
            Rezervacija newRezervacija = new Rezervacija()
            {
                Datum = DateTime.Parse(input.datum),
                Vrijeme = DateTime.Parse(input.vrijeme),
                Vrsta = input.vrsta,
                KorisnikId = input.korsnikId,
                RestoranId = input.restoranId,
                BrojOsoba=input.brojOsoba
                
            };
            _db.Add(newRezervacija);
            _db.SaveChanges();
            return 0;
        }



        [HttpDelete]
        public ActionResult Obrisi(int id)
        {
            Rezervacija x = _db.Rezervacija.Find(id);
            if (x != null)
            {
                _db.Rezervacija.Remove(x);
                _db.SaveChanges();
            }
            return Ok();
        }
    }

   
}
