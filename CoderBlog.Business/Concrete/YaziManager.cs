using CoderBlog.Business.Abstract;
using CoderBlog.DataAccess.Concrete;
using CoderBlog.Entities;
using System;
using System.Collections.Generic;

namespace CoderBlog.Business.Concrete
{
    public class YaziManager : IYaziService
    {
        YaziDal yDal = new YaziDal();
        public void Add(Yazi yazi)
        {
            yDal.Add(yazi);
        }

        public void Delete(Yazi yazi)
        {
            yDal.Delete(yazi);
        }

        public Yazi GetById(int yaziId)
        {
            return yDal.Get(x => x.Id == yaziId);
        }

        public IList<Yazi> GetList(int KullaniciId=0,int KategoriId=0)
        {
            if (KullaniciId > 0 && KategoriId == 0)
                return yDal.GetList(x => x.KullaniciId == KullaniciId);
            else if (KullaniciId == 0 && KategoriId > 0)
                return yDal.GetList(x => x.KategoriId == KategoriId);
            else if (KullaniciId > 0 && KategoriId > 0)
                return yDal.GetList(x => x.KategoriId == KategoriId && x.KullaniciId == KullaniciId);
            else
                return yDal.GetList();
        }

        public IList<Yazi> GetListYeniler()
        {
                return yDal.GetList(x=>x.YaziTarih>=DateTime.Now.Date.AddDays(-1));
        }

        public void Update(Yazi yazi)
        {
            yDal.Update(yazi);
        }
    }
}
