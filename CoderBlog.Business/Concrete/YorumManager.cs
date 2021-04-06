using CoderBlog.Business.Abstract;
using CoderBlog.DataAccess.Concrete;
using CoderBlog.Entities;
using System.Collections.Generic;

namespace CoderBlog.Business.Concrete
{
    public class YorumManager : IYorum
    {
        YorumDal yDal = new YorumDal();
        public void Add(Yorum yorum)
        {
            yDal.Add(yorum);
        }

        public void Delete(Yorum yorum)
        {
            yDal.Delete(yorum);
        }

        public Yorum GetById(int yorumId)
        {
            return yDal.Get(x => x.Id == yorumId);
        }

        public IList<Yorum> GetList(int kullaniciId)
        {
            return yDal.GetList(x => x.Id == kullaniciId);
        }

        public void Update(Yorum yazi)
        {
            yDal.Update(yazi);
        }
    }
}
