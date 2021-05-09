﻿using CoderBlog.Business.Abstract;
using CoderBlog.Core.DataAccess.EntityFramework;
using CoderBlog.Core.Entities.Concrete;
using CoderBlog.DataAccess.Abstract;
using CoderBlog.DataAccess.Concrete.EntityFramework.Context;
using CoderBlog.Entities;
using CoderBlog.Entities.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace CoderBlog.Business.Concrete
{
    public class YorumManager : IYorumService
    {
        private IYorumDal _yorumDal;
        public YorumManager(IYorumDal yorumDal)
        {
            _yorumDal = yorumDal;
        }
        public void Add(Yorum yorum)
        {
            _yorumDal.Add(yorum);
        }

        public void Delete(Yorum yorum)
        {
            _yorumDal.Delete(yorum);
        }

        public Yorum GetById(int yorumId)
        {
            return _yorumDal.Get(x => x.Id == yorumId);
        }

        public IList<YorumDto> GetList(int yaziId)
        {
            List<YorumDto> yorumList = new List<YorumDto>();

            var yorumRep = new EfRepositoryBase<Yorum, CoderBlogContext>();
            var kulRep = new EfRepositoryBase<Kullanici, CoderBlogContext>();

            var yorumLst = (from yorum in yorumRep.GetList(x => x.YaziId == yaziId)
                            join kul in kulRep.GetList() on yorum.KullaniciId equals kul.Id
                            select new
                            {
                                yorum = yorum,
                                kullanici = kul
                            }).ToList();

            foreach (var item in yorumLst)
            {
                YorumDto y = new YorumDto();
                y.Id = item.yorum.Id;
                y.Aciklama = item.yorum.Aciklama;
                y.KayitTarihi = item.yorum.KayitTarihi;
                y.KullaniciAdi = item.kullanici.KullaniciAdi;
                y.KullaniciId = item.kullanici.Id;
                y.YaziId = item.yorum.YaziId;
                y.KullaniciResmi = item.kullanici.Resim;
                yorumList.Add(y);
            }
            return yorumList;
        }

        public void Update(Yorum yazi)
        {
            _yorumDal.Update(yazi);
        }
    }
}
