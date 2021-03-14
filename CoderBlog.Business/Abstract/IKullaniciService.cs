using CoderBlog.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Business.Abstract
{
    public interface IKullaniciService
    {
        Kullanici GetById(int kulId);
        Kullanici GetById(string kulAdi,string sifre);
        IList<Kullanici> GetList();
        void Add(Kullanici kullanici);
        void Delete(Kullanici kullanici);
        void Update(Kullanici kullanici);
    }
}
