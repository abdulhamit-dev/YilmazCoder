using YilmazCoder.Core.Entities.Concrete;
using YilmazCoder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace YilmazCoder.Business.Abstract
{
    public interface IKullaniciService
    {
        Kullanici GetById(int kulId);
        Kullanici GetById(string kulAdi,string sifre);
        Kullanici GetKullaniciKontrol(string kulAdi,string ePosta);
        IList<Kullanici> GetList();
        void Add(Kullanici kullanici);
        void Delete(Kullanici kullanici);
        void Update(Kullanici kullanici);
        List<Yetki> YetkiList(Kullanici kullanici);
    }
}
