using CoderBlog.Business.Abstract;
using CoderBlog.DataAccess.Concrete;
using CoderBlog.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Business.Concrete
{
    public class BegeniManager : IBegeni
    {
        BegeniDal bDal = new BegeniDal();
        public void Add(Begeni begeni)
        {
            bDal.Add(begeni);
        }

        public void Delete(Begeni begeni)
        {
            bDal.Delete(begeni);
        }

        public Begeni GetById(int begeniId)
        {
            return bDal.Get(x => x.Id == begeniId);
        }

        public IList<Begeni> GetList(int kullaniciId)
        {
            return bDal.GetList(x => x.KullaniciId == kullaniciId);
        }

        public Begeni GetYaziBegeni(int yaziId)
        {
          return  bDal.Get(x => x.YaziId == yaziId);
        }

        public void Update(Begeni begeni)
        {
             bDal.Update(begeni);
        }
    }
}
