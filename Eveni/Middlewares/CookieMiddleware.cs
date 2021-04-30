using Microsoft.AspNetCore.Http;
using RestSharp;
using System;
using System.Threading.Tasks;
using System.Web;


namespace Web.Middlewares
{
    public class CookieMiddleware
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

          private readonly RequestDelegate _next;
       // private readonly HttpContext _httpContext;
        public CookieMiddleware(IHttpContextAccessor httpContextAccessor,
        //    HttpContext httpContext,
          RequestDelegate next)
        {
            this._httpContextAccessor = httpContextAccessor;
          //  this._httpContext = httpContext;
            this._next = next;
        }

        [Obsolete]
        public async Task InvokeAsync(
             HttpContext context)
        {

            Set();
          //  HttpContext.Request.Cookies["site_user"];

            await this._next(context);
     //       context.Response.Cookies.Append();

        }

        [Obsolete]
        public  void Set()
        {
          

            string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies["site_user"];
            if (cookieValueFromContext == null)
            {
                string UserId = "site_user";
                string cookieValue = Guid.NewGuid().ToString();
                HttpCookie userIdCookie = new HttpCookie
                {
                    Value = cookieValue,
                    Expires = DateTime.Now.AddMinutes(1)
                };

             //   HttpContext.Response.Cookies.Append(UserId, userIdCookie.Value);
            }
        }
    }
}