using CoderBlog.Entities;
using CoderBlog.Entities.Dtos;
using System.Collections.Generic;

namespace CoderBlog.Business.Abstract
{
    public interface IYaziService
    {
        Yazi Get(int Id);
        YaziDto GetById(int yaziId);
        IList<Yazi> GetList(int KullaniciId = 0, int KategoriId = 0);
        IList<YaziDto> GetListYeniler();
        IList<YaziDto> GetListTrendler();
        IList<YaziDto> GetListKategoriYazi(string kategoriAdi);
        void Add(Yazi yazi);
        void Delete(Yazi yazi);
        void Update(Yazi yazi);
    }
}
