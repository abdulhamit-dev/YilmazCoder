using YilmazCoder.Core.DataAccess.EntityFramework;
using YilmazCoder.DataAccess.Abstract;
using YilmazCoder.DataAccess.Concrete.EntityFramework.Context;
using YilmazCoder.Entities;
using YilmazCoder.Entities.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace YilmazCoder.DataAccess.Concrete.EntityFramework
{
    public class KategoriDal : EfRepositoryBase<Kategori,YilmazCoderContext>,IKategoriDal
    {
        public List<KategoriYaziDto> GetKategoriYaziList()
        {
            using(YilmazCoderContext context=new YilmazCoderContext())
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
