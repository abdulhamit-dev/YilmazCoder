using YilmazCoder.Core.DataAccess;
using YilmazCoder.Entities;
using YilmazCoder.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace YilmazCoder.DataAccess.Abstract
{
    public interface IKategoriDal:IEntityRepository<Kategori>
    {
        List<KategoriYaziDto> GetKategoriYaziList();
    }
}
