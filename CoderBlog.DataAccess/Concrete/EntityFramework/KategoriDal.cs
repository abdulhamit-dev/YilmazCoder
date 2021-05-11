using CoderBlog.Core.DataAccess.EntityFramework;
using CoderBlog.DataAccess.Abstract;
using CoderBlog.DataAccess.Concrete.EntityFramework.Context;
using CoderBlog.Entities;
using CoderBlog.Entities.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace CoderBlog.DataAccess.Concrete.EntityFramework
{
    public class KategoriDal : EfRepositoryBase<Kategori,CoderBlogContext>,IKategoriDal
    {
        public List<KategoriYaziDto> GetKategoriYaziList()
        {
            using(CoderBlogContext context=new CoderBlogContext())
            {
                var kategoriList = (from kategori in context.Kategori
                                    join yazi in context.Yazi on kategori.Id equals yazi.KategoriId
                                    group new { kategori, yazi } by new { kategori.Adi, kategori.Id } into kategoriYazi
                                    select new KategoriYaziDto
                                    {
                                        Adi = kategoriYazi.Key.Adi,
                                        Id = kategoriYazi.Key.Id,
                                        YaziSayisi = kategoriYazi.Count()
                                    });


                return kategoriList.ToList();
            }
        }
    }
}
