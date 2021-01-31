using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MekashronDomain.Models;
using MekashronDomain.Services;
using MekashronWeb.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MekashronWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _service;

        public AccountController(AccountService service)
        {
            _service = service;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All fields is required");

                return View(model);
            }

            var entity = await _service.Login(new LoginRequest
            {
                UserName = model.UserName,
                Password = model.Password,
                IPs = ""
            });

            if (!entity.IsSuccess)
            {
                ModelState.AddModelError("", entity.ErrorMessage);

                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, $"{entity.ResultData.EntityId}"),
                new Claim(ClaimTypes.Name, model.UserName),
                new Claim(ClaimTypes.GivenName, $"{entity.ResultData.FirstName} {entity.ResultData.LastName}"),
                new Claim(ClaimTypes.MobilePhone, entity.ResultData.Mobile),
                new Claim(ClaimTypes.HomePhone, entity.ResultData.Phone),
                new Claim(ClaimTypes.StreetAddress, entity.ResultData.Address),
                new Claim(ClaimTypes.Country, entity.ResultData.Country),
                new Claim(ClaimTypes.Email, entity.ResultData.Email),
                new Claim(ClaimTypes.StateOrProvince, entity.ResultData.City),
                new Claim(ClaimTypes.PostalCode, entity.ResultData.Zip),
                new Claim(ClaimTypes.Locality, entity.ResultData.Company),
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme); 
          
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Info", "Cabinet");
        }

    }
}
