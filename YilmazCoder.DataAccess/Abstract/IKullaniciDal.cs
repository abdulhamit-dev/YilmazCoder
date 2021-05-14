using YilmazCoder.Core.DataAccess;
using YilmazCoder.Core.DataAccess.EntityFramework;
using YilmazCoder.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace YilmazCoder.DataAccess.Abstract
{
    public interface IKullaniciDal: IEntityRepository<Kullanici>
    {
    }
}
