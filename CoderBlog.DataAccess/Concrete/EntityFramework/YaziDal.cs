using CoderBlog.Core.DataAccess.EntityFramework;
using CoderBlog.DataAccess.Abstract;
using CoderBlog.DataAccess.Concrete.EntityFramework.Context;
using CoderBlog.Entities;

namespace CoderBlog.DataAccess.Concrete.EntityFramework
{
    public class YaziDal : EfRepositoryBase<Yazi,CoderBlogContext>,IYaziDal
    {

    }
}
