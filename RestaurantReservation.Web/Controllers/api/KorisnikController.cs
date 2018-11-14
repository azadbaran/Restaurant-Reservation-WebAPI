using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Data.EF;
using RestaurantReservation.Data.EntityModels;
using RestaurantReservation.Web.Helper;
using RestaurantReservation.Web.Helper.webapi;
using RestaurantReservation.Web.ViewModels.api;

namespace Posiljka.Web.Controllers.api
{
   // [MyApiAuthorize]
    public class KorisnikController : MyWebApiBaseController
    {
        public KorisnikController(MyContext db) : base(db)
        {
        }

        //[HttpGet]
        //public KorisnikPregledVM Find()
        //{
        //    return Find("");
        //}

        [HttpGet]
        public KorisnikPregledVM Find(string name)
        {
            var result = new KorisnikPregledVM
            {
                rows = _db.Korisnik
                .Where(w => (w.Ime + " " + w.Prezime).StartsWith(name) || (w.Prezime + " " + w.Ime).StartsWith(name))
                .Select(s => new KorisnikPregledVM.Row
                {
                    id = s.Id,
                    ime = s.Ime,
                    prezime = s.Prezime,
                    email = s.Mail,
                    password=s.KorisnickiNalog.Lozinka
                    
                }).ToList()
            };
            return result;
        }

        [HttpGet]
        public KorisnikPregledVM FindById(int id)
        {
            var result = new KorisnikPregledVM
            {
                rows = _db.Korisnik
                .Where(w => w.Id==id)
                .Select(s => new KorisnikPregledVM.Row
                {
                    id = s.Id,
                    ime = s.Ime,
                    prezime = s.Prezime,
                    email = s.Mail,
                    password=s.KorisnickiNalog.Lozinka
                    
                }).ToList()
            };
            return result;
        }

        [HttpPost]
        public int AddKorisnik([FromBody] KorisnikAddVM input)
        {
            KorisnickiNalog newNalog = new KorisnickiNalog()
            {
                KorisnickoIme = input.username,
                Lozinka=input.password

            };

           
            _db.KorisnickiNalog.Add(newNalog);
            _db.SaveChanges();

            Korisnik newKorisnik = new Korisnik()
            {
                Ime = input.ime,
                Prezime = input.prezime,
                Mail = input.email,
                KorisnickiNalogId=newNalog.Id

            };
            _db.Korisnik.Add(newKorisnik);
            
            _db.SaveChanges();
            return 0;
        }


        [HttpPost]
        public KorisnikPregledVM.Row Add([FromBody]KorisnikAddVM input)
        {
            Korisnik newKorisnik = new Korisnik
            {
                Ime = input.ime,
                Prezime = input.prezime,
                Mail = input.email,
                KorisnickiNalog = new KorisnickiNalog
                {
                    KorisnickoIme = input.ime + "." + input.prezime,
                    Lozinka = "test"
                }
            };
            _db.Korisnik.Add(newKorisnik);
            _db.SaveChanges();


            var result= _db.Korisnik
                    .Where(w => w.Id == newKorisnik.Id)
                    .Select(s => new KorisnikPregledVM.Row
                    {
                        id = s.Id,
                        ime = s.Ime,
                        prezime = s.Prezime,
                        email = s.Mail
                    })
                    .Single();

            return result;
        }

        [HttpPut]
        public ActionResult Update(int id,[FromBody]KorisnikPregledVM.Row input)
        {
            KorisnickiNalog userUpdate = _db.KorisnickiNalog.Where(w => w.Id == id).FirstOrDefault();

            if(userUpdate==null)
            {
                return NotFound();
            }

            userUpdate.Lozinka =input.password;

            _db.KorisnickiNalog.Update(userUpdate);

            _db.SaveChanges();

            return Ok();

        }
      
    }
}
