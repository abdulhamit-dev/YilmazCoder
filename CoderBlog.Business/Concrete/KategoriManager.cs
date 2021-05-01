using CoderBlog.Business.Abstract;
using CoderBlog.DataAccess.Abstract;
using CoderBlog.DataAccess.Concrete;
using CoderBlog.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CoderBlog.Business.Concrete
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

        public void Update(Kategori kategori)
        {
            _kategoriDal.Update(kategori);
        }
    }
}
