using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AspNetIdentityDemo.Web.Models.Account;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace AspNetIdentityDemo.Web.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> UserManager
        {
            get { return HttpContext.GetOwinContext().Get<UserManager<IdentityUser>>(); }
        }

        private SignInManager<IdentityUser,string> SignInManager
        {
            get { return HttpContext.GetOwinContext().Get<SignInManager<IdentityUser, string>>(); }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await UserManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                var result = await UserManager.CreateAsync(new IdentityUser(model.UserName), model.Password);
                if (result == IdentityResult.Success)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("UserNameExists", "UserName exits");

            return View(model);
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LogIn(LogInModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, true, true);

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Home");
                    break;
                case SignInStatus.LockedOut:
                    break;
                case SignInStatus.RequiresVerification:
                    break;
                case SignInStatus.Failure:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return RedirectToAction("Index", "Home");

        }
    }
}