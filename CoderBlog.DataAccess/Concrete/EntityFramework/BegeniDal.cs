using CoderBlog.Core.DataAccess.EntityFramework;
using CoderBlog.DataAccess.Abstract;
using CoderBlog.DataAccess.Concrete.EntityFramework.Context;
using CoderBlog.Entities;

namespace CoderBlog.DataAccess.Concrete.EntityFramework
{
    public class BegeniDal :EfRepositoryBase<Begeni,CoderBlogContext>,IBegeniDal //RepositoryBaseV2<Begeni>
    {
    }
}
