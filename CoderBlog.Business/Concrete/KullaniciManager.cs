using CoderBlog.Business.Abstract;
using CoderBlog.Core.DataAccess.EntityFramework;
using CoderBlog.Core.Entities.Concrete;
using CoderBlog.DataAccess.Abstract;
using CoderBlog.DataAccess.Concrete;
using CoderBlog.DataAccess.Concrete.EntityFramework.Context;
using CoderBlog.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CoderBlog.Business.Concrete
{
    public class KullaniciManager : IKullaniciService
    {
        private IKullaniciDal _kullaniciDal;
        public KullaniciManager(IKullaniciDal kullaniciDal)
        {
            _kullaniciDal = kullaniciDal;
        }
        public void Add(Kullanici kullanici)
        {
            _kullaniciDal.Add(kullanici);
        }

        public void Delete(Kullanici kullanici)
        {
            _kullaniciDal.Delete(kullanici);
        }

        public Kullanici GetById(int kulId)
        {
            return _kullaniciDal.Get(x => x.Id == kulId);
        }

        public Kullanici GetById(string kulAdi, string sifre)
        {
            return _kullaniciDal.Get(x => x.KullaniciAdi == kulAdi && x.Sifre == sifre);
        }

        public Kullanici GetKullaniciKontrol(string kulAdi, string ePosta)
        {
            Kullanici kul = _kullaniciDal.Get(x => x.KullaniciAdi == kulAdi);
            if (kul == null)
                kul = _kullaniciDal.Get(x => x.Eposta == ePosta);

            return kul;
        }

        public IList<Kullanici> GetList()
        {
            return _kullaniciDal.GetList();
        }

        public void Update(Kullanici kullanici)
        {
            _kullaniciDal.Update(kullanici);
        }

        public List<Yetki> YetkiList(Kullanici kullanici)
        {
            List<Yetki> ylist = new List<Yetki>();
           
                var yetkiRep = new EfRepositoryBase<Yetki,CoderBlogContext>();
                var kullaniciYetkiRep = new EfRepositoryBase<KullaniciYetki,CoderBlogContext>();
                var yazilist = yetkiRep.GetList().Join(kullaniciYetkiRep.GetList(x=>x.KullaniciId==kullanici.Id),
                                      yetki => yetki.Id,
                                      kullaniciYetki => kullaniciYetki.KullaniciId,
                                      (yetki, kullaniciYetki) => new { Yetki = yetki, KullaniciYetki = kullaniciYetki }).ToList();


                foreach (var item in yazilist)
                {
                    Yetki y = new Yetki();
                    y.Id = item.Yetki.Id;
                    y.Adi = item.Yetki.Adi;
                    ylist.Add(y);
                }
            

            return ylist;
        }
    }
}
