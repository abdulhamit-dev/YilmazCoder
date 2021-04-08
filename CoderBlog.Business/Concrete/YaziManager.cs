using CoderBlog.Business.Abstract;
using CoderBlog.Core.Entities.Concrete;
using CoderBlog.DataAccess.Abstract;
using CoderBlog.DataAccess.Concrete;
using CoderBlog.Entities;
using CoderBlog.Entities.Dtos;
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

        public YaziDto GetById(int yaziId)
        {
            YaziDto yaziDto = new YaziDto();

            using (CoderBlogContext ctx = new CoderBlogContext())
            {
                var yaziRep = new RepositoryBaseV2<Yazi>(ctx);
                var kullaniciRep = new RepositoryBaseV2<Kullanici>(ctx);
                var yorumRep = new RepositoryBaseV2<Yorum>(ctx);
                var begeniRep = new RepositoryBaseV2<Begeni>(ctx);


                var yazilist = (from yazi in yaziRep.GetList(x=>x.Id==yaziId)
                                join kullanici in kullaniciRep.GetList() on yazi.KullaniciId equals kullanici.Id
                                select new
                                {
                                    yazi = yazi,
                                    kullanici = kullanici
                                }).ToList();


                foreach (var item in yazilist)
                {
                    YaziDto y = new YaziDto();
                    y.Id = item.yazi.Id;
                    y.KategoriId = item.yazi.KategoriId;
                    y.KullaniciAdi = item.kullanici.KullaniciAdi;
                    y.KullaniciId = item.kullanici.Id;
                    y.YaziBaslik = item.yazi.YaziBaslik;
                    y.YaziIcerik = item.yazi.YaziIcerik;
                    y.YaziTarih = item.yazi.YaziTarih;
                    y.YaziKapakResim = item.yazi.YaziKapakResim;
                    y.BegeniSayisi = begeniRep.GetList(x => x.YaziId == y.Id).Count();
                    y.YorumSayisi = yorumRep.GetList(x => x.YaziId == y.Id).Count();
                    yaziDto = y;
                }
            }

            return yaziDto;
            //return yDal.Get(x => x.Id == yaziId);
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

        public IList<YaziDto> GetListTrendler()
        {
            List<YaziDto> ylist = new List<YaziDto>();
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
                    YaziDto y = new YaziDto();
                    y.Id = item.Yazi.Id;
                    y.KullaniciAdi = item.Kullanici.KullaniciAdi;
                    y.KategoriId = item.Yazi.KategoriId;
                    y.YaziBaslik = item.Yazi.YaziBaslik;
                    y.YaziIcerik = item.Yazi.YaziIcerik;
                    y.YaziTarih = item.Yazi.YaziTarih;
                    ylist.Add(y);
                }
            }

            return ylist;
        }

        public IList<YaziDto> GetListYeniler()
        {
            List<YaziDto> ylist = new List<YaziDto>();
            using (CoderBlogContext ctx = new CoderBlogContext())
            {
                var yaziRep = new RepositoryBaseV2<Yazi>(ctx);
                var kullaniciRep = new RepositoryBaseV2<Kullanici>(ctx);
                var yorumRep = new RepositoryBaseV2<Yorum>(ctx);
                var begeniRep = new RepositoryBaseV2<Begeni>(ctx);


                var yazilist = (from yazi in yaziRep.GetList()
                                    //join yorum in yorumRep.GetList() on yazi.Id equals yorum.YaziId
                                    join kullanici in kullaniciRep.GetList() on yazi.KullaniciId equals kullanici.Id
                                    select new
                                    {
                                       yazi=yazi,
                                       //yorum=yorum,
                                       kullanici=kullanici
                                    }
                                  ).ToList();

                foreach (var item in yazilist)
                {
                    YaziDto y = new YaziDto();
                    y.Id =item.yazi.Id;
                    y.KategoriId = item.yazi.KategoriId;
                    y.KullaniciAdi = item.kullanici.KullaniciAdi;
                    y.YaziBaslik = item.yazi.YaziBaslik;
                    y.YaziIcerik = item.yazi.YaziIcerik;
                    y.YaziTarih = item.yazi.YaziTarih;
                    y.YaziKapakResim = item.yazi.YaziKapakResim;
                    y.BegeniSayisi = begeniRep.GetList(x=>x.YaziId==y.Id).Count();
                    y.YorumSayisi = yorumRep.GetList(x => x.YaziId == y.Id).Count();
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
