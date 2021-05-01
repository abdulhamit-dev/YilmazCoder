using CoderBlog.Core.DataAccess.EntityFramework;
using CoderBlog.Core.Entities.Concrete;
using CoderBlog.DataAccess.Abstract;
using CoderBlog.DataAccess.Concrete.EntityFramework.Context;

namespace CoderBlog.DataAccess.Concrete.EntityFramework
{
    public class KullaniciDal : EfRepositoryBase<Kullanici,CoderBlogContext>,IKullaniciDal
    {

    }
}
