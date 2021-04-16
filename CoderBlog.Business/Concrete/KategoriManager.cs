using CoderBlog.Business.Abstract;
using CoderBlog.DataAccess.Concrete;
using CoderBlog.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CoderBlog.Business.Concrete
{
    public class KategoriManager : IKategori
    {
        KategoriDal kDal = new KategoriDal();
        public void Add(Kategori kategori)
        {
            kDal.Add(kategori);
        }

        public void Delete(Kategori kategori)
        {
            kDal.Delete(kategori);
        }

        public Kategori GetById(int kategoriId)
        {
            return kDal.Get(x => x.Id == kategoriId);
        }

        public IList<Kategori> GetList()
        {
            return kDal.GetList().OrderBy(x=>x.Adi).ToList();
        }

        public void Update(Kategori kategori)
        {
            kDal.Update(kategori);
        }
    }
}
