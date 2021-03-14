using CoderBlog.Business.Concrete;
using CoderBlog.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoderBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        KullaniciManager manager = new KullaniciManager();
        [HttpPost]
        [Route("login")]
        public IActionResult Login(Kullanici kul)
        {



            kul = manager.GetById(kul.KullaniciAdi, kul.Sifre);
            if (kul != null)
            {
                var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("helloWorld92@text.com19921992"));
                var signingCreadentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "www.yilmazcoder.online",
                    audience: "www.yilmazcoder.online",
                    claims: new List<Claim> {
                        new Claim("id", kul.Id.ToString()),
                        new Claim("ad", kul.Ad),
                        new Claim("soyad", kul.Soyad),
                        new Claim("ePosta", kul.Eposta),
                        new Claim("kullaniciAdi", kul.KullaniciAdi)
                    },
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: signingCreadentials

                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }
            return Unauthorized(new { Token = "Hatalı kullanıcı" });
        }
    }
}
