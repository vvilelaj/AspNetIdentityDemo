using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(AspNetIdentityDemo.Web.Startup))]

namespace AspNetIdentityDemo.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            // Create a DbContext
            app.CreatePerOwinContext(() => new IdentityDbContext("AspNetIdentityDemo.Web.DB"));

            // Create a UserStore that points to a previous DbContext
            app.CreatePerOwinContext<UserStore<IdentityUser>>((opt, ctx) => new UserStore<IdentityUser>(ctx.Get<IdentityDbContext>()));

            // Create a UserManager that poinrt to a previus UserStore
            app.CreatePerOwinContext<UserManager<IdentityUser>>((opt, ctx) => new UserManager<IdentityUser>(ctx.Get<UserStore<IdentityUser>>()));

            // Create a SingIngManager
            app.CreatePerOwinContext<SignInManager<IdentityUser, string>>((opt, ctx) => new SignInManager<IdentityUser, string>(ctx.Get<UserManager<IdentityUser>>(), ctx.Authentication));

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                
            });
        }
    }
}
