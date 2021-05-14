using YilmazCoder.Core.DataAccess;
using YilmazCoder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace YilmazCoder.DataAccess.Abstract
{
    public interface IYorumDal: IEntityRepository<Yorum>
    {
    }
}
