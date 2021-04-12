using CoderBlog.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Business.Abstract
{
    public interface IBegeni
    {
        Begeni GetById(int begeniId);
        Begeni GetYaziBegeni(int yaziId, int kulId);
        IList<Begeni> GetList(int kullaniciId);
        void Add(Begeni begeni);
        void Delete(Begeni begeni);
        void Update(Begeni begeni);
    }
}
