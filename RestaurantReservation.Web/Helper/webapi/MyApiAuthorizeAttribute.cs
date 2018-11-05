using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Data.EF;
using RestaurantReservation.Data.EntityModels;
using RestaurantReservation.Web.Controllers;
using RestaurantReservation.Web.Helper.mvc;

namespace RestaurantReservation.Web.Helper.webapi
{

    public class MyApiAuthorizeAttribute : TypeFilterAttribute
    {
        public MyApiAuthorizeAttribute()
            : base(typeof(MyApiAuthorizeImpl))
        {
            Arguments = new object[] { };
        }
    }


    public class MyApiAuthorizeImpl : IAsyncActionFilter
    {
        public MyApiAuthorizeImpl()
        {
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
                KorisnickiNalog korisnickiNalog = context.HttpContext.GetKorisnikOfAuthToken();

                if (korisnickiNalog !=null)
                {
                     await next(); //ok - ima pravo pristupa
                     return;
                }

                //nema pravo pristupa
                context.Result = new UnauthorizedResult();
        }
    }
}

