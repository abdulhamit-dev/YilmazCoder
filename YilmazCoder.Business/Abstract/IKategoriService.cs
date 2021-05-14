using YilmazCoder.Entities;
using YilmazCoder.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace YilmazCoder.Business.Abstract
{
    public interface IKategoriService
    {
        Kategori GetById(int yaziId);
        IList<Kategori> GetList();
        IList<KategoriYaziDto> GetListKategoriYazi();
        void Add(Kategori yazi);
        void Delete(Kategori yazi);
        void Update(Kategori yazi);
    }
}
