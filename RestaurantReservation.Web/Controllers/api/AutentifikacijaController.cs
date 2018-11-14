using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using RestaurantReservation.Data.EF;
using RestaurantReservation.Data.EntityModels;
using RestaurantReservation.Web.Helper;
using RestaurantReservation.Web.Helper.webapi;
using RestaurantReservation.Web.ViewModels.api;

namespace RestaurantReservation.Web.Controllers.api
{
    public class AutentifikacijaController : MyWebApiBaseController
    {
        public AutentifikacijaController(MyContext db) : base(db)
        {
        }

        [HttpPost]
        public ActionResult<AutentifikacijaResultVM> LoginCheck([FromBody] AutentifikacijaLoginPostVM input)
        {
            string token = Guid.NewGuid().ToString();

            AutentifikacijaResultVM model = _db.Korisnik
                .Where(w => w.KorisnickiNalog.KorisnickoIme == input.Username && w.KorisnickiNalog.Lozinka == input.Password)
                .Select(s => new AutentifikacijaResultVM
                {
                    korisnikId=s.Id,
                    ime = s.Ime,
                    korisnickiNalogId = s.KorisnickiNalogId,
                    prezime = s.Prezime,
                    username = s.KorisnickiNalog.KorisnickoIme,
                    token = token,
                    mail=s.Mail,
                    password=s.KorisnickiNalog.Lozinka
                
                }).SingleOrDefault();


            if (model != null)
            {
                _db.AutorizacijskiToken.Add(new AutorizacijskiToken
                {
                    Vrijednost = model.token,
                    KorisnickiNalogId = model.korisnickiNalogId.Value,
                    VrijemeEvidentiranja = DateTime.Now,
                    DeviceInfo = "Mobile app - " + input.deviceInfo,
                    IpAdresa = HttpContext.Connection.RemoteIpAddress + ":" + HttpContext.Connection.RemotePort
                });
                _db.SaveChanges();
            }

            return model;
        }


        [HttpDelete]
        public ActionResult Logout()
        {
            string tokenString = HttpContext.GetMyAuthToken();
            AutorizacijskiToken autorizacijskiToken = _db.AutorizacijskiToken.Find(tokenString);
            if (autorizacijskiToken != null)
            {
                _db.Remove(autorizacijskiToken);
                _db.SaveChanges();
            }
            return Ok();
        }
    }
}
