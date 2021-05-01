using CoderBlog.Business.Abstract;
using CoderBlog.DataAccess.Abstract;
using CoderBlog.DataAccess.Concrete;
using CoderBlog.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Business.Concrete
{
    public class BegeniManager : IBegeniService
    {
        private IBegeniDal _begeniDal;
        public BegeniManager(IBegeniDal begeniDal)
        {
            _begeniDal = begeniDal;
        }
        //BegeniDal bDal = new BegeniDal();
        public void Add(Begeni begeni)
        {
            _begeniDal.Add(begeni);
        }

        public void Delete(Begeni begeni)
        {
            _begeniDal.Delete(begeni);
        }

        public Begeni GetById(int begeniId)
        {
            return _begeniDal.Get(x => x.Id == begeniId);
        }

        public IList<Begeni> GetList(int kullaniciId)
        {
            return _begeniDal.GetList(x => x.KullaniciId == kullaniciId);
        }

        public Begeni GetYaziBegeni(int yaziId, int kulId)
        {
          return _begeniDal.Get(x => x.YaziId == yaziId && x.KullaniciId==kulId);
        }

        public void Update(Begeni begeni)
        {
            _begeniDal.Update(begeni);
        }
    }
}
