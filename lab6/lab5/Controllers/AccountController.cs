using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab5.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Okta.AspNetCore;
using System.Linq;

namespace lab5.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignIn()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Challenge(OktaDefaults.MvcAuthenticationScheme);
            }

            return RedirectToAction("Index", "Home");
        }
        
        [HttpPost]
        public SignOutResult SignOut()
        {
            return new SignOutResult(
            new[]
            {
                OktaDefaults.MvcAuthenticationScheme,
                CookieAuthenticationDefaults.AuthenticationScheme
            },
            new AuthenticationProperties
            {
                RedirectUri = "/Home/"
            });

        }
        
        [HttpGet]
        public IActionResult Profile()
        {
            return View(new UserProfileModel()
                {
                    Email = HttpContext.User.FindAll(x => x.Type == "email").FirstOrDefault()!.Value.ToString(),
                    FirstName = HttpContext.User.FindAll(x => x.Type == "given_name").FirstOrDefault()!.Value.ToString(),
                    LastName = HttpContext.User.FindAll(x => x.Type == "family_name").FirstOrDefault()!.Value.ToString()
                }
            );
        }
    }
}