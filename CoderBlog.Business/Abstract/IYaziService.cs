using CoderBlog.Entities;
using CoderBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Business.Abstract
{
    public interface IYaziService
    {
        Yazi GetById(int yaziId);
        IList<Yazi> GetList(int KullaniciId = 0, int KategoriId = 0);
        IList<YaziKullaniciDto> GetListYeniler();
        IList<YaziKullaniciDto> GetListTrendler();
        void Add(Yazi yazi);
        void Delete(Yazi yazi);
        void Update(Yazi yazi);
    }
}
