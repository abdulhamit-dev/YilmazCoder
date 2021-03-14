using CoderBlog.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Business.Abstract
{
    public interface IYaziService
    {
        Yazi GetById(int yaziId);
        IList<Yazi> GetList();
        void Add(Yazi yazi);
        void Delete(Yazi yazi);
        void Update(Yazi yazi);
    }
}
