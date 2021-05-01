using CoderBlog.Business.Abstract;
using CoderBlog.Core.DataAccess.EntityFramework;
using CoderBlog.Core.Entities.Concrete;
using CoderBlog.DataAccess.Abstract;
using CoderBlog.DataAccess.Concrete.EntityFramework.Context;
using CoderBlog.Entities;
using CoderBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoderBlog.Business.Concrete
{
    public class YaziManager : IYaziService
    {

        private IYaziDal _yaziDal;
        public YaziManager(IYaziDal yaziDal)
        {
            _yaziDal = yaziDal;
        }
        public void Add(Yazi yazi)
        {
            _yaziDal.Add(yazi);
        }

        public void Delete(Yazi yazi)
        {
            _yaziDal.Delete(yazi);
        }

        public YaziDto GetById(int yaziId)
        {
            YaziDto yaziDto = new YaziDto();


            var yaziRep = new EfRepositoryBase<Yazi, CoderBlogContext>();
            var kullaniciRep = new EfRepositoryBase<Kullanici, CoderBlogContext>();
            var yorumRep = new EfRepositoryBase<Yorum, CoderBlogContext>();
            var begeniRep = new EfRepositoryBase<Begeni, CoderBlogContext>();
            var kategoriRep = new EfRepositoryBase<Kategori, CoderBlogContext>();


            var yazilist = (from yazi in yaziRep.GetList(x => x.Id == yaziId)
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
                y.KategoriAdi = kategoriRep.Get(x => x.Id == item.yazi.KategoriId).Adi;
                y.KullaniciAdi = item.kullanici.KullaniciAdi;
                y.KullaniciId = item.kullanici.Id;
                y.KullaniciResmi = item.kullanici.Resim;
                y.YaziBaslik = item.yazi.YaziBaslik;
                y.YaziIcerik = item.yazi.YaziIcerik;
                y.YaziTarih = item.yazi.YaziTarih;
                y.YaziKapakResim = item.yazi.YaziKapakResim;
                y.BegeniSayisi = begeniRep.GetList(x => x.YaziId == y.Id).Count();
                y.YorumSayisi = yorumRep.GetList(x => x.YaziId == y.Id).Count();
                yaziDto = y;
            }


            return yaziDto;
            //return yDal.Get(x => x.Id == yaziId);
        }

        public IList<Yazi> GetList(int KullaniciId = 0, int KategoriId = 0)
        {
            if (KullaniciId > 0 && KategoriId == 0)
                return _yaziDal.GetList(x => x.KullaniciId == KullaniciId);
            else if (KullaniciId == 0 && KategoriId > 0)
                return _yaziDal.GetList(x => x.KategoriId == KategoriId);
            else if (KullaniciId > 0 && KategoriId > 0)
                return _yaziDal.GetList(x => x.KategoriId == KategoriId && x.KullaniciId == KullaniciId);
            else
                return _yaziDal.GetList();
        }

        public IList<YaziDto> GetListTrendler()
        {
            List<YaziDto> ylist = new List<YaziDto>();

            var yaziRep = new EfRepositoryBase<Yazi, CoderBlogContext>();
            var kullaniciRep = new EfRepositoryBase<Kullanici, CoderBlogContext>();
            var kategoriRep = new EfRepositoryBase<Kategori, CoderBlogContext>();
            var yazilist = yaziRep.GetList().Join(kullaniciRep.GetList(),
                                  yazi => yazi.KullaniciId,
                                  kul => kul.Id,
                                  (yazi, kullanici) => new { Yazi = yazi, Kullanici = kullanici }).ToList();


            foreach (var item in yazilist)
            {
                YaziDto y = new YaziDto();
                y.Id = item.Yazi.Id;
                y.KullaniciAdi = item.Kullanici.KullaniciAdi;
                y.KategoriAdi = kategoriRep.Get(x => x.Id == item.Yazi.KategoriId).Adi;
                y.KullaniciResmi = kullaniciRep.Get(x => x.Id == item.Yazi.KullaniciId).Resim;
                y.KategoriId = item.Yazi.KategoriId;
                y.YaziBaslik = item.Yazi.YaziBaslik;
                y.YaziIcerik = item.Yazi.YaziIcerik;
                y.YaziTarih = item.Yazi.YaziTarih;
                y.YaziKapakResim = item.Yazi.YaziKapakResim;
                ylist.Add(y);
            }


            return ylist;
        }

        public IList<YaziDto> GetListYeniler()
        {
            List<YaziDto> ylist = new List<YaziDto>();

            var yaziRep = new EfRepositoryBase<Yazi, CoderBlogContext>();
            var kullaniciRep = new EfRepositoryBase<Kullanici, CoderBlogContext>();
            var yorumRep = new EfRepositoryBase<Yorum, CoderBlogContext>();
            var begeniRep = new EfRepositoryBase<Begeni, CoderBlogContext>();
            var kategoriRep = new EfRepositoryBase<Kategori, CoderBlogContext>();

            var yazilist = (from yazi in yaziRep.GetList()
                                //join yorum in yorumRep.GetList() on yazi.Id equals yorum.YaziId
                            join kullanici in kullaniciRep.GetList() on yazi.KullaniciId equals kullanici.Id
                            select new
                            {
                                yazi = yazi,
                                //yorum=yorum,
                                kullanici = kullanici
                            }
                              ).ToList();

            foreach (var item in yazilist)
            {
                YaziDto y = new YaziDto();
                y.Id = item.yazi.Id;
                y.KategoriId = item.yazi.KategoriId;
                y.KategoriAdi = kategoriRep.Get(x => x.Id == item.yazi.KategoriId).Adi;
                y.KullaniciAdi = item.kullanici.KullaniciAdi;
                y.KullaniciResmi = kullaniciRep.Get(x => x.Id == item.yazi.KullaniciId).Resim;
                y.YaziBaslik = item.yazi.YaziBaslik;
                y.YaziIcerik = item.yazi.YaziIcerik;
                y.YaziTarih = item.yazi.YaziTarih;
                y.YaziKapakResim = item.yazi.YaziKapakResim;
                y.BegeniSayisi = begeniRep.GetList(x => x.YaziId == y.Id).Count();
                y.YorumSayisi = yorumRep.GetList(x => x.YaziId == y.Id).Count();
                ylist.Add(y);
            }


            return ylist;
        }

        public IList<YaziDto> GetListKategoriYazi(string kategoriAdi)
        {
            List<YaziDto> ylist = new List<YaziDto>();

            var yaziRep = new EfRepositoryBase<Yazi, CoderBlogContext>();
            var kullaniciRep = new EfRepositoryBase<Kullanici, CoderBlogContext>();
            var yorumRep = new EfRepositoryBase<Yorum, CoderBlogContext>();
            var begeniRep = new EfRepositoryBase<Begeni, CoderBlogContext>();
            var kategoriRep = new EfRepositoryBase<Kategori, CoderBlogContext>();
            


            var yazilist = (from yazi in yaziRep.GetList()
                            join kategori in kategoriRep.GetList(x => x.Adi == kategoriAdi) on yazi.KategoriId equals kategori.Id
                            select new
                            {
                                yazi = yazi,
                                kategori = kategori
                            }
                              ).ToList();

            foreach (var item in yazilist)
            {
                YaziDto y = new YaziDto();
                y.Id = item.yazi.Id;
                y.KategoriId = item.yazi.KategoriId;
                y.KategoriAdi = kategoriRep.Get(x => x.Id == item.yazi.KategoriId).Adi;
                y.KullaniciAdi = kullaniciRep.Get(x => x.Id == item.yazi.KullaniciId).KullaniciAdi;
                y.KullaniciResmi = kullaniciRep.Get(x => x.Id == item.yazi.KullaniciId).Resim;
                y.YaziBaslik = item.yazi.YaziBaslik;
                y.YaziIcerik = item.yazi.YaziIcerik;
                y.YaziTarih = item.yazi.YaziTarih;
                y.YaziKapakResim = item.yazi.YaziKapakResim;
                y.BegeniSayisi = begeniRep.GetList(x => x.YaziId == y.Id).Count();
                y.YorumSayisi = yorumRep.GetList(x => x.YaziId == y.Id).Count();
                ylist.Add(y);
            }


            return ylist;
        }
        public void Update(Yazi yazi)
        {
            Yazi uYazi = new Yazi();
            uYazi = _yaziDal.Get(x => x.Id == yazi.Id);
            uYazi.KategoriId = yazi.KategoriId;
            uYazi.KullaniciId = yazi.KullaniciId;
            uYazi.YaziBaslik = yazi.YaziBaslik;
            uYazi.YaziIcerik = yazi.YaziIcerik;
            uYazi.YaziTarih = DateTime.Now;

            _yaziDal.Update(uYazi);
        }

    }
}
