using CoderBlog.Business.Abstract;
using CoderBlog.Core.Entities.Concrete;
using CoderBlog.DataAccess.Abstract;
using CoderBlog.DataAccess.Concrete;
using CoderBlog.Entities;
using System.Collections.Generic;
using System.Linq;

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
            return kDal.Get(x => x.Id == kulId);
        }

        public Kullanici GetById(string kulAdi, string sifre)
        {
            return kDal.Get(x => x.KullaniciAdi == kulAdi && x.Sifre == sifre);
        }

        public IList<Kullanici> GetList()
        {
            return kDal.GetList();
        }

        public void Update(Kullanici kullanici)
        {
            kDal.Update(kullanici);
        }

        public List<Yetki> YetkiList(Kullanici kullanici)
        {
            List<Yetki> ylist = new List<Yetki>();
            using (CoderBlogContext ctx = new CoderBlogContext())
            {
                var yetkiRep = new RepositoryBaseV2<Yetki>(ctx);
                var kullaniciYetkiRep = new RepositoryBaseV2<KullaniciYetki>(ctx);
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
            }

            return ylist;
        }
        //public List<Yetki> GetClaims(Kullanici kullanici)
        //{
        //    return kDal.GetClaims(user);
        //}
    }
}
