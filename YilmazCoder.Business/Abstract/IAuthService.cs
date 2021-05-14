using YilmazCoder.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace YilmazCoder.Business.Abstract
{
    public interface IAuthService
    {
        Kullanici Login(Kullanici kullanici);
        AccessToken CreateAccessToken(Kullanici kullanici);
    }
}
