using CoderBlog.Core.DataAccess;
using CoderBlog.Entities;
using CoderBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.DataAccess.Abstract
{
    public interface IKategoriDal:IEntityRepository<Kategori>
    {
        List<KategoriYaziDto> GetKategoriYaziList();
    }
}
