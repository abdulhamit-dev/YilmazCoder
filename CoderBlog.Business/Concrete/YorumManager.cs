using CoderBlog.Business.Abstract;
using CoderBlog.Core.Entities.Concrete;
using CoderBlog.DataAccess.Abstract;
using CoderBlog.DataAccess.Concrete;
using CoderBlog.Entities;
using CoderBlog.Entities.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CoderBlog.Business.Concrete
{
    public class YorumManager : IYorum
    {
        YorumDal yDal = new YorumDal();
        public void Add(Yorum yorum)
        {
            yDal.Add(yorum);
        }

        public void Delete(Yorum yorum)
        {
            yDal.Delete(yorum);
        }

        public Yorum GetById(int yorumId)
        {
            return yDal.Get(x => x.Id == yorumId);
        }

        public IList<YorumDto> GetList(int yaziId)
        {
            List<YorumDto> yorumList = new List<YorumDto>();
            using(CoderBlogContext context=new CoderBlogContext())
            {
                var yorumRep = new RepositoryBaseV2<Yorum>(context);
                var kulRep = new RepositoryBaseV2<Kullanici>(context);

                var yorumLst = (from yorum in yorumRep.GetList(x=>x.YaziId==yaziId)
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
                    yorumList.Add(y);
                }
            }
            return yorumList;
        }

        public void Update(Yorum yazi)
        {
            yDal.Update(yazi);
        }
    }
}
