using YilmazCoder.Core.DataAccess;
using YilmazCoder.Entities;
using YilmazCoder.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace YilmazCoder.DataAccess.Abstract
{
    public interface IYaziDal:IEntityRepository<Yazi>
    {
        YaziDto GetById(int yaziId);
        List<YaziDto> GetYaziDtoList();
        List<YaziDto> GetListKategoriYazi(string kategoriAdi);

    }
}
