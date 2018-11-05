using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Data.EF;
using RestaurantReservation.Web.Models;

using RestaurantReservation.Web.Helper;
using RestaurantReservation.Web.Helper.mvc;


namespace RestaurantReservation.Web.Controllers
{
    public class HomeController : MyMvcBaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TestDB()
        {
            MyDbInit.Run(_db);
            return View(_db);
        }

        public HomeController(MyContext db) : base(db)
        {
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
