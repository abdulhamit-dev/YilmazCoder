using CoderBlog.Business.Abstract;
using CoderBlog.DataAccess.Abstract;
using CoderBlog.DataAccess.Concrete;
using CoderBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoderBlog.Business.Concrete
{
    public class YaziManager : IYaziService
    {
        YaziDal yDal = new YaziDal();
        //RepositoryBaseV2<Yazi> dbYazi = new RepositoryBaseV2<Yazi>();

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

        public IList<Yazi> GetListTrendler()
        {
            List<Yazi> ylist = new List<Yazi>();
            using (CoderBlogContext ctx = new CoderBlogContext())
            {
                var yaziRep = new RepositoryBaseV2<Yazi>(ctx);
                var kullaniciRep = new RepositoryBaseV2<Kullanici>(ctx);
                var yazilist = yaziRep.GetList().Join(kullaniciRep.GetList(),
                                      yazi => yazi.KullaniciId,
                                      kul => kul.Id,
                                      (yazi, kullanici) => new { Yazi = yazi, Kullanici = kullanici }).ToList();


                foreach (var item in yazilist)
                {
                    Yazi y = new Yazi();
                    y = item.Yazi;
                    y.KullaniciAdi = item.Kullanici.KullaniciAdi;
                    ylist.Add(y);
                }
            }

            return ylist;
        }

        public IList<Yazi> GetListYeniler()
        {
            List<Yazi> ylist = new List<Yazi>();
            using (CoderBlogContext ctx = new CoderBlogContext())
            {
                var yaziRep = new RepositoryBaseV2<Yazi>(ctx);
                var kullaniciRep = new RepositoryBaseV2<Kullanici>(ctx);
                var yazilist = yaziRep.GetList(x=>x.YaziTarih>DateTime.Now.AddDays(-2)).Join(kullaniciRep.GetList(),
                                      yazi => yazi.KullaniciId,
                                      kul => kul.Id,
                                      (yazi, kullanici) => new { Yazi = yazi, Kullanici = kullanici }).ToList();


                foreach (var item in yazilist)
                {
                    Yazi y = new Yazi();
                    y = item.Yazi;
                    y.KullaniciAdi = item.Kullanici.KullaniciAdi;
                    ylist.Add(y);
                }
            }

            return ylist;
        }



        public void Update(Yazi yazi)
        {
            yDal.Update(yazi);
        }

    }
}
