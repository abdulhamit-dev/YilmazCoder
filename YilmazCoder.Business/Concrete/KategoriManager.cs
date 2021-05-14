using YilmazCoder.Business.Abstract;
using YilmazCoder.Core.DataAccess.EntityFramework;
using YilmazCoder.DataAccess.Abstract;
using YilmazCoder.DataAccess.Concrete;
using YilmazCoder.DataAccess.Concrete.EntityFramework.Context;
using YilmazCoder.Entities;
using YilmazCoder.Entities.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace YilmazCoder.Business.Concrete
{
    public class KategoriManager : IKategoriService
    {
        private IKategoriDal _kategoriDal;
        public KategoriManager(IKategoriDal kategoriDal)
        {
            _kategoriDal = kategoriDal;
        }
        public void Add(Kategori kategori)
        {
            _kategoriDal.Add(kategori);
        }

        public void Delete(Kategori kategori)
        {
            _kategoriDal.Delete(kategori);
        }

        public Kategori GetById(int kategoriId)
        {
            return _kategoriDal.Get(x => x.Id == kategoriId);
        }

        public IList<Kategori> GetList()
        {
            return _kategoriDal.GetList().OrderBy(x=>x.Adi).ToList();
        }

        public IList<KategoriYaziDto> GetListKategoriYazi()
        {
            return _kategoriDal.GetKategoriYaziList();
        }

        public void Update(Kategori kategori)
        {
            _kategoriDal.Update(kategori);
        }
    }
}
