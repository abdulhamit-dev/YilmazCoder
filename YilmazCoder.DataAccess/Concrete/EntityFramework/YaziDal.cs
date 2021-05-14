using YilmazCoder.Core.DataAccess.EntityFramework;
using YilmazCoder.Core.Entities.Concrete;
using YilmazCoder.DataAccess.Abstract;
using YilmazCoder.DataAccess.Concrete.EntityFramework.Context;
using YilmazCoder.Entities;
using YilmazCoder.Entities.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace YilmazCoder.DataAccess.Concrete.EntityFramework
{
    public class YaziDal : EfRepositoryBase<Yazi, YilmazCoderContext>, IYaziDal
    {
        public YaziDto GetById(int yaziId)
        {
            using (YilmazCoderContext context =new YilmazCoderContext())
            {
                YaziDto yaziDto = new YaziDto();


                var yaziRep = new EfRepositoryBase<Yazi, YilmazCoderContext>();
                var kullaniciRep = new EfRepositoryBase<Kullanici, YilmazCoderContext>();
                var yorumRep = new EfRepositoryBase<Yorum, YilmazCoderContext>();
                var begeniRep = new EfRepositoryBase<Begeni, YilmazCoderContext>();
                var kategoriRep = new EfRepositoryBase<Kategori, YilmazCoderContext>();


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
                return yazilist;
            }
        }
        public List<YaziDto> GetListKategoriYazi(string kategoriAdi)
        {
            List<YaziDto> ylist = new List<YaziDto>();

            using (YilmazCoderContext context = new YilmazCoderContext())
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
        }
        public List<YaziDto> GetYaziDtoList()
        {
            using (YilmazCoderContext context = new YilmazCoderContext())
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
