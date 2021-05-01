using CoderBlog.Core.DataAccess;
using CoderBlog.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.DataAccess.Abstract
{
    public interface IYorumDal: IEntityRepository<Yorum>
    {
    }
}
