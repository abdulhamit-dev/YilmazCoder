using CoderBlog.Core.Entities.Concrete;
using CoderBlog.Core.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CoderBlog.Core.Utilities.Security.Jwt
{
    public class JwtHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }
        public AccessToken CreateToken(Kullanici kullanici, List<Yetki> yetkiList)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var jwt = CreateJwtSecurityToken(_tokenOptions, kullanici, signingCredentials, yetkiList);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, Kullanici kullanici,SigningCredentials signingCredentials, List<Yetki> yetkiList)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(kullanici, yetkiList),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(Kullanici kullanici, List<Yetki> yetkiList)
        {
            var claims = new List<Claim> {
                new Claim("id",kullanici.Id.ToString()),
                new Claim("ad",kullanici.Ad),
                new Claim("soyad",kullanici.Soyad),
                new Claim("ePosta",kullanici.Eposta),
                new Claim("kullaniciAdi",kullanici.KullaniciAdi),
            };

            //new Claim("id", kul.Id.ToString()),
            //            new Claim("ad", kul.Ad),
            //            new Claim("soyad", kul.Soyad),
            //            new Claim("ePosta", kul.Eposta),
            //            new Claim("kullaniciAdi", kul.KullaniciAdi)

            //claims.AddNameIdentifier(kullanici.Id.ToString());
            //claims.AddEmail(kullanici.Eposta);
            //claims.AddName($"{kullanici.Ad} {kullanici.Soyad}");

            claims.AddRoles(yetkiList.Select(c => c.Adi).ToArray());

            return claims;
        }
    }
}
