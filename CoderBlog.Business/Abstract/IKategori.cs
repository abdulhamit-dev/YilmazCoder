using CoderBlog.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Business.Abstract
{
    interface IKategori
    {
        Kategori GetById(int yaziId);
        IList<Kategori> GetList();
        void Add(Kategori yazi);
        void Delete(Kategori yazi);
        void Update(Kategori yazi);
    }
}
