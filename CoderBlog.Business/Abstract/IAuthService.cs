using CoderBlog.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Business.Abstract
{
    public interface IAuthService
    {
        Kullanici Login(Kullanici kullanici);
        AccessToken CreateAccessToken(Kullanici kullanici);
    }
}
