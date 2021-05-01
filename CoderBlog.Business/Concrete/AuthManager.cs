using CoderBlog.Business.Abstract;
using CoderBlog.Core.Entities.Concrete;
using CoderBlog.Core.Utilities.Security.Jwt;
using CoderBlog.DataAccess.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IKullaniciService _kullaniciService;
        public AuthManager(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }
        JwtHelper jwtHelper;
        public AuthManager(IConfiguration configuration)
        {
            jwtHelper = new JwtHelper(configuration);
        }
        public AccessToken CreateAccessToken(Kullanici kullanici)
        {
            List<Yetki> yetkiList = _kullaniciService.YetkiList(kullanici);
            return jwtHelper.CreateToken(kullanici,yetkiList);
        }

        public Kullanici Login(Kullanici kullanici)
        {
            return _kullaniciService.GetById(kullanici.KullaniciAdi, kullanici.Sifre);
        }
    }
}
