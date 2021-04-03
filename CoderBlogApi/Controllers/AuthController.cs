using CoderBlog.Business.Concrete;
using CoderBlog.Core.Entities.Concrete;
using CoderBlog.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        AuthManager authManager;

        public AuthController(IConfiguration conf)
        {
            authManager = new AuthManager(conf);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(Kullanici kul)
        {


            //string token = "";
            kul = authManager.Login(kul);//manager.GetById(kul.KullaniciAdi, kul.Sifre);

            AccessToken token = new AccessToken();

            if (kul != null)
                token = authManager.CreateAccessToken(kul);
            else
                token.Token = "Hata";



            if (kul != null)
            {
                if (token.Token != "Hata")
                    return Ok(new { Token = token.Token });
                else
                    return Unauthorized(new { Token = token.Token });
            }
            else
                return Unauthorized(new { Token = token.Token });
            //if (kul != null)
            //{
            //    var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("helloWorld92@text.com19921992"));
            //    var signingCreadentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
            //    var tokenOptions = new JwtSecurityToken(
            //        issuer: "www.yilmazcoder.online",
            //        audience: "www.yilmazcoder.online",
            //        claims: new List<Claim> {
            //            new Claim("id", kul.Id.ToString()),
            //            new Claim("ad", kul.Ad),
            //            new Claim("soyad", kul.Soyad),
            //            new Claim("ePosta", kul.Eposta),
            //            new Claim("kullaniciAdi", kul.KullaniciAdi),

            //        },

            //        expires: DateTime.Now.AddMinutes(20),
            //        signingCredentials: signingCreadentials

            //        );
            //    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);


            //    return Ok(new { Token = tokenString });
            //}
            //return Unauthorized(new { Token = "Hatalı kullanıcı" });
        }
    }
}
