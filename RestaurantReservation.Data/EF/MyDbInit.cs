using System;
using System.Collections.Generic;
using System.Linq;
using RestaurantReservation.Data.EntityModels;

namespace RestaurantReservation.Data.EF
{
    public static class MyDbInit
    {
        public static void Run(MyContext _context)
        {
           
            if (_context.Rezervacija.Any())
            {
                return; // DB has been seeded
            }
            
            List<Restoran> restorani = new List<Restoran>();
            List<Korisnik> korisnici = new List<Korisnik>();
            List<Rezervacija> rezervacije = new List<Rezervacija>();


            restorani.Add(new Restoran { Naziv = "Restoran Hindin Han"});
            restorani.Add(new Restoran { Naziv = "Restoran Malta"});
            restorani.Add(new Restoran { Naziv = "Restoran Marinero"});
            restorani.Add(new Restoran { Naziv = "Restoran Bella"});
            restorani.Add(new Restoran { Naziv = "Restoran Han"});
            restorani.Add(new Restoran { Naziv = "Restoran Orlando"});
            restorani.Add(new Restoran { Naziv = "Restoran Italiano" });
            restorani.Add(new Restoran { Naziv = "Restoran Kuluk" });
            restorani.Add(new Restoran { Naziv = "Restoran Novalica Kula" });

            korisnici.Add(new Korisnik { Ime ="Lejla", Prezime ="Spago",Mail="lejla.spago@edu.fit.ba", KorisnickiNalog = new KorisnickiNalog { KorisnickoIme = "Korisnik1", Lozinka = "test" } });
            korisnici.Add(new Korisnik { Ime = "Sejla", Prezime = "Spago", Mail = "sejla.spago@edu.fit.ba", KorisnickiNalog = new KorisnickiNalog { KorisnickoIme = "Korisnik2", Lozinka = "test" } });
            korisnici.Add(new Korisnik { Ime = "Jasmina", Prezime = "Spago", Mail = "jasmina.spago@edu.fit.ba", KorisnickiNalog = new KorisnickiNalog { KorisnickoIme = "Korisnik3", Lozinka = "test" } });
            korisnici.Add(new Korisnik { Ime = "Amina", Prezime = "Catic", Mail = "amina.catic@edu.fit.ba", KorisnickiNalog = new KorisnickiNalog { KorisnickoIme = "Korisnik4", Lozinka = "test" } });
            korisnici.Add(new Korisnik { Ime = "Melisa", Prezime = "Dzeko", Mail = "melisa.dzeko@edu.fit.ba", KorisnickiNalog = new KorisnickiNalog { KorisnickoIme = "Korisnik5", Lozinka = "test" } });


            for (int i = 0; i < 10; i++)
            {
                rezervacije.Add(new Rezervacija { Restoran = restorani.MyRandom(), Korisnik =korisnici.MyRandom(),Vrsta="Vecera",Datum=DateTime.Now,Vrijeme=DateTime.Now,BrojOsoba=5 });
            }
           
           

            _context.Restoran.AddRange(restorani);
            _context.Korisnik.AddRange(korisnici);
            _context.Rezervacija.AddRange(rezervacije);
          
          

            _context.SaveChanges();
        }

      


        static readonly Random random = new Random();

        private static T MyRandom<T>(this List<T> lista)
        {
            int r = random.Next(0, lista.Count);
            return lista[r];
        }

    }
}