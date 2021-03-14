using CoderBlog.Business.Abstract;
using CoderBlog.DataAccess.Concrete;
using CoderBlog.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Business.Concrete
{
    public class KullaniciManager : IKullaniciService
    {
        KullaniciDal kDal = new KullaniciDal();
        public void Add(Kullanici kullanici)
        {
            kDal.Add(kullanici);
        }

        public void Delete(Kullanici kullanici)
        {
            kDal.Delete(kullanici);
        }

        public Kullanici GetById(int kulId)
        {
           return kDal.Get(x=>x.Id== kulId);
        }

        public Kullanici GetById(string kulAdi, string sifre)
        {
            return kDal.Get(x => x.KullaniciAdi == kulAdi && x.Sifre==sifre);
        }

        public IList<Kullanici> GetList()
        {
            return kDal.GetList();
        }

        public void Update(Kullanici kullanici)
        {
            kDal.Update(kullanici);
        }
    }
}
