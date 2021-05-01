using CoderBlog.Core.DataAccess;
using CoderBlog.Core.DataAccess.EntityFramework;
using CoderBlog.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.DataAccess.Abstract
{
    public interface IKullaniciDal: IEntityRepository<Kullanici>
    {
    }
}
