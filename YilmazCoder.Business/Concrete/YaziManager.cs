using YilmazCoder.Business.Abstract;
using YilmazCoder.Core.DataAccess.EntityFramework;
using YilmazCoder.Core.Entities.Concrete;
using YilmazCoder.DataAccess.Abstract;
using YilmazCoder.DataAccess.Concrete.EntityFramework.Context;
using YilmazCoder.Entities;
using YilmazCoder.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace YilmazCoder.Business.Concrete
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
            yazi.YaziTarih = DateTime.Now;
            _yaziDal.Add(yazi);
        }
        public void Delete(Yazi yazi)
        {
            _yaziDal.Delete(yazi);
        }
        public YaziDto GetById(int yaziId)
        {
            return _yaziDal.GetById(yaziId);
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
        public IList<YaziDto> GetListKategoriYazi(string kategoriAdi)
        {
            return _yaziDal.GetListKategoriYazi(kategoriAdi);
        }
        public void Update(Yazi yazi)
        {
            _yaziDal.Update(yazi);
        }
        public Yazi Get(int Id)
        {
            return _yaziDal.Get(x => x.Id == Id);
        }
        public IList<YaziDto> GetYaziDtoList()
        {
            return _yaziDal.GetYaziDtoList();
        }
    }
}
