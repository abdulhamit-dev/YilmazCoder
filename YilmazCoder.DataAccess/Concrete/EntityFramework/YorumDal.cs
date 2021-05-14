using YilmazCoder.Core.DataAccess.EntityFramework;
using YilmazCoder.DataAccess.Abstract;
using YilmazCoder.DataAccess.Concrete.EntityFramework.Context;
using YilmazCoder.Entities;

namespace YilmazCoder.DataAccess.Concrete.EntityFramework
{
    public class YorumDal : EfRepositoryBase<Yorum,YilmazCoderContext>,IYorumDal
    {
    }
}
