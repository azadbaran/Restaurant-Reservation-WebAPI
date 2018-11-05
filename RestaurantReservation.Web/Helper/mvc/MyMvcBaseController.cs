using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Data.EF;

namespace RestaurantReservation.Web.Helper.mvc
{
    public abstract class MyMvcBaseController : Controller
    {
        protected readonly MyContext _db;

        protected MyMvcBaseController(MyContext db)
        {
            _db = db;
        }

       
    }
}
