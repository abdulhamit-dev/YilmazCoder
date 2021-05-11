using CoderBlog.Business.Abstract;
using CoderBlog.Core.Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoderBlog.UI.Controllers
{
    public class AuthController : Controller
    {
        private IKullaniciService _kullaniciService;
        public AuthController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }
        public async Task< IActionResult> Login()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","home");
        }

        [HttpPost]
        public async Task<IActionResult> Giris(string kulAdi,string sifre)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Kullanici kul=_kullaniciService.GetById(kulAdi, sifre);

            if (kul != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,kul.KullaniciAdi),
                    new Claim(ClaimTypes.NameIdentifier,kul.Id.ToString()),
                };

                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                
                await HttpContext.SignInAsync(principal);

                
                return Json(true);
            }
            else
                return Json(false);
        }
        [HttpPost]
        public IActionResult KayitOl(string kulAdi, string sifre,string email)
        {
            Kullanici kul = _kullaniciService.GetKullaniciKontrol(kulAdi, email);

            if (kul == null)
            {
                kul = new Kullanici();
                kul.KullaniciAdi = kulAdi;
                kul.Sifre = sifre;
                kul.Eposta = email;
                _kullaniciService.Add(kul);

                return Json(true);
            }
            else
                return Json(false);
        }

        [HttpPost]
        public async Task<IActionResult> Cikis(string kulAdi, string sifre)
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Json(true);

        }
    }
}
