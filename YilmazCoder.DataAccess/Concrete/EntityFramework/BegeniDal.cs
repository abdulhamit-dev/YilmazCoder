using YilmazCoder.Core.DataAccess.EntityFramework;
using YilmazCoder.DataAccess.Abstract;
using YilmazCoder.DataAccess.Concrete.EntityFramework.Context;
using YilmazCoder.Entities;

namespace YilmazCoder.DataAccess.Concrete.EntityFramework
{
    public class BegeniDal :EfRepositoryBase<Begeni,YilmazCoderContext>,IBegeniDal //RepositoryBaseV2<Begeni>
    {
    }
}
