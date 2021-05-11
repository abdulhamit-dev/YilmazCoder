using CoderBlog.Core.DataAccess.EntityFramework;
using CoderBlog.Core.Entities.Concrete;
using CoderBlog.DataAccess.Abstract;
using CoderBlog.DataAccess.Concrete.EntityFramework.Context;
using CoderBlog.Entities;
using CoderBlog.Entities.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace CoderBlog.DataAccess.Concrete.EntityFramework
{
    public class YaziDal : EfRepositoryBase<Yazi, CoderBlogContext>, IYaziDal
    {
        public YaziDto GetById(int yaziId)
        {
            using (CoderBlogContext context =new CoderBlogContext())
            {
                YaziDto yaziDto = new YaziDto();


                var yaziRep = new EfRepositoryBase<Yazi, CoderBlogContext>();
                var kullaniciRep = new EfRepositoryBase<Kullanici, CoderBlogContext>();
                var yorumRep = new EfRepositoryBase<Yorum, CoderBlogContext>();
                var begeniRep = new EfRepositoryBase<Begeni, CoderBlogContext>();
                var kategoriRep = new EfRepositoryBase<Kategori, CoderBlogContext>();


                var yazilist = (from yazi in context.Yazi.Where(x => x.Id == yaziId)
                                join kullanici in context.Kullanici on yazi.KullaniciId equals kullanici.Id
                                select new YaziDto
                                {

                                    Id=yazi.Id,
                                    KategoriId=yazi.KategoriId,
                                    KategoriAdi= context.Kategori.Where(x => x.Id == yazi.KategoriId).FirstOrDefault().Adi,
                                    KullaniciAdi=kullanici.KullaniciAdi,
                                    KullaniciId=kullanici.Id,
                                    KullaniciResmi=kullanici.Resim,
                                    YaziBaslik=yazi.YaziBaslik,
                                    YaziIcerik=yazi.YaziIcerik,
                                    YaziTarih=yazi.YaziTarih,
                                    YaziKapakResim=yazi.YaziKapakResim,
                                    BegeniSayisi=context.Begeni.Where(x=>x.YaziId==yazi.Id).Count(),
                                    YorumSayisi=context.Yorum.Where(x=>x.YaziId==yazi.Id).Count(),
                                }).FirstOrDefault();


                //foreach (var item in yazilist)
                //{
                //    YaziDto y = new YaziDto();
                //    y.Id = item.yazi.Id;
                //    y.KategoriId = item.yazi.KategoriId;
                //    y.KategoriAdi = kategoriRep.Get(x => x.Id == item.yazi.KategoriId).Adi;
                //    y.KullaniciAdi = item.kullanici.KullaniciAdi;
                //    y.KullaniciId = item.kullanici.Id;
                //    y.KullaniciResmi = item.kullanici.Resim;
                //    y.YaziBaslik = item.yazi.YaziBaslik;
                //    y.YaziIcerik = item.yazi.YaziIcerik;
                //    y.YaziTarih = item.yazi.YaziTarih;
                //    y.YaziKapakResim = item.yazi.YaziKapakResim;
                //    y.BegeniSayisi = begeniRep.GetList(x => x.YaziId == y.Id).Count();
                //    y.YorumSayisi = yorumRep.GetList(x => x.YaziId == y.Id).Count();
                //    yaziDto = y;
                //}


                return yazilist;
            }
        }

        public List<YaziDto> GetListKategoriYazi(string kategoriAdi)
        {
            List<YaziDto> ylist = new List<YaziDto>();

            using (CoderBlogContext context = new CoderBlogContext())
            {
                var yaziList = (from yazi in context.Yazi
                                join kategori in context.Kategori.Where(x => x.Adi == kategoriAdi) on yazi.KategoriId equals kategori.Id
                                select new YaziDto
                                {
                                    Id = yazi.Id,
                                    KategoriId = kategori.Id,
                                    KategoriAdi = kategori.Adi,
                                    KullaniciAdi = context.Kullanici.Where(x=>x.Id== yazi.KullaniciId).FirstOrDefault().KullaniciAdi,
                                    KullaniciResmi = context.Kullanici.Where(x=>x.Id==yazi.KullaniciId).FirstOrDefault().Resim,
                                    YaziBaslik = yazi.YaziBaslik,
                                    YaziIcerik = yazi.YaziIcerik,
                                    YaziTarih = yazi.YaziTarih,
                                    YaziKapakResim = yazi.YaziKapakResim,
                                    BegeniSayisi = context.Begeni.Where(x => x.YaziId == yazi.Id).Count(),
                                    YorumSayisi = context.Yorum.Where(x => x.YaziId == yazi.Id).Count(),
                                }).ToList();
                return yaziList;
            }


            //var yaziRep = new EfRepositoryBase<Yazi, CoderBlogContext>();
            //var kullaniciRep = new EfRepositoryBase<Kullanici, CoderBlogContext>();
            //var yorumRep = new EfRepositoryBase<Yorum, CoderBlogContext>();
            //var begeniRep = new EfRepositoryBase<Begeni, CoderBlogContext>();
            //var kategoriRep = new EfRepositoryBase<Kategori, CoderBlogContext>();



            //var yazilist = (from yazi in yaziRep.GetList()
            //                join kategori in kategoriRep.GetList(x => x.Adi == kategoriAdi) on yazi.KategoriId equals kategori.Id
            //                select new YaziDto
            //                {
            //                    yazi = yazi,
            //                    kategori = kategori
            //                }
            //                  ).ToList();

            //foreach (var item in yazilist)
            //{
            //    YaziDto y = new YaziDto();
            //    y.Id = item.yazi.Id;
            //    y.KategoriId = item.yazi.KategoriId;
            //    y.KategoriAdi = kategoriRep.Get(x => x.Id == item.yazi.KategoriId).Adi;
            //    y.KullaniciAdi = kullaniciRep.Get(x => x.Id == item.yazi.KullaniciId).KullaniciAdi;
            //    y.KullaniciResmi = kullaniciRep.Get(x => x.Id == item.yazi.KullaniciId).Resim;
            //    y.YaziBaslik = item.yazi.YaziBaslik;
            //    y.YaziIcerik = item.yazi.YaziIcerik;
            //    y.YaziTarih = item.yazi.YaziTarih;
            //    y.YaziKapakResim = item.yazi.YaziKapakResim;
            //    y.BegeniSayisi = begeniRep.GetList(x => x.YaziId == y.Id).Count();
            //    y.YorumSayisi = yorumRep.GetList(x => x.YaziId == y.Id).Count();
            //    ylist.Add(y);
            //}


            //return ylist;
        }

        public List<YaziDto> GetYaziDtoList()
        {
            using (CoderBlogContext context = new CoderBlogContext())
            {
                var yazilist = (from yazi in context.Yazi
                                join kullanici in context.Kullanici on yazi.KullaniciId equals kullanici.Id
                                join kategori in context.Kategori on yazi.KategoriId equals kategori.Id
                                select new YaziDto
                                {
                                    Id = yazi.Id,
                                    KategoriId = yazi.KategoriId,
                                    KategoriAdi = kategori.Adi,
                                    KullaniciAdi = kullanici.Ad,
                                    KullaniciResmi = kullanici.Resim,
                                    YaziBaslik = yazi.YaziBaslik,
                                    YaziIcerik = yazi.YaziIcerik,
                                    YaziTarih = yazi.YaziTarih,
                                    YaziKapakResim = yazi.YaziKapakResim
                                }
                              ).ToList();
                return yazilist;
            }
        }
    }
}
