using YilmazCoder.Core.DataAccess.EntityFramework;
using YilmazCoder.Core.Entities.Concrete;
using YilmazCoder.DataAccess.Abstract;
using YilmazCoder.DataAccess.Concrete.EntityFramework.Context;

namespace YilmazCoder.DataAccess.Concrete.EntityFramework
{
    public class KullaniciDal : EfRepositoryBase<Kullanici,YilmazCoderContext>,IKullaniciDal
    {

    }
}
