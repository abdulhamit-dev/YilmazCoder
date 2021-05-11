using CoderBlog.Core.DataAccess;
using CoderBlog.Entities;
using CoderBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.DataAccess.Abstract
{
    public interface IYaziDal:IEntityRepository<Yazi>
    {
        YaziDto GetById(int yaziId);
        List<YaziDto> GetYaziDtoList();
        List<YaziDto> GetListKategoriYazi(string kategoriAdi);

    }
}
