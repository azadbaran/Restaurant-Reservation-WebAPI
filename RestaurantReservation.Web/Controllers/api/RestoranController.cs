using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Data.EF;
using RestaurantReservation.Web.Helper.webapi;
using RestaurantReservation.Web.ViewModels.api;

namespace RestaurantReservation.Web.Controllers.api
{
    [MyApiAuthorizeAttribute] 
    public class RestoranController : MyWebApiBaseController
    {
        public RestoranController(MyContext db) : base(db)
        {

        }


        [HttpGet]
        public ActionResult<RestoranPregledVM> Index()
        {


            var model = new RestoranPregledVM
        {
            rows = _db.Restoran
                .OrderByDescending(s => s.Id)
                .Select(s => new RestoranPregledVM.Row
                {
                    id = s.Id,
                    naziv = s.Naziv,
                    opis = s.Opis,
                    grad = s.Grad,
                    adresa = s.Adresa,
                    telefon = s.Telefon,
                    mail=s.Mail
                    
                }).ToList()
        };


            return Json(model);
        }


}
}