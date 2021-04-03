using CoderBlog.Business.Abstract;
using CoderBlog.Core.Entities.Concrete;
using CoderBlog.Core.Utilities.Security.Jwt;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        KullaniciManager kulManager = new KullaniciManager();
        JwtHelper jwtHelper;
        public AuthManager(IConfiguration configuration)
        {
            jwtHelper = new JwtHelper(configuration);
        }
        public AccessToken CreateAccessToken(Kullanici kullanici)
        {
            List<Yetki> yetkiList = kulManager.YetkiList(kullanici);
            return jwtHelper.CreateToken(kullanici,yetkiList);
        }

        public Kullanici Login(Kullanici kullanici)
        {
            return kulManager.GetById(kullanici.KullaniciAdi, kullanici.Sifre);
        }
    }
}
