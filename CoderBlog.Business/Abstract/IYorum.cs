using CoderBlog.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Business.Abstract
{
    public interface IYorum
    {
        Yorum GetById(int yorumId);
        IList<Yorum> GetList(int kullaniciId);
        void Add(Yorum yorum);
        void Delete(Yorum yorum);
        void Update(Yorum yorum);
    }
}
