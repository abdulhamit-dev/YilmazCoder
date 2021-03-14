using CoderBlog.Business.Abstract;
using CoderBlog.DataAccess.Concrete;
using CoderBlog.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Business.Concrete
{
    public class YaziManager : IYaziService
    {
        YaziDal yDal = new YaziDal();
        public void Add(Yazi yazi)
        {
            yDal.Add(yazi);
        }

        public void Delete(Yazi yazi)
        {
            yDal.Delete(yazi);
        }

        public Yazi GetById(int yaziId)
        {
            return yDal.Get(x => x.Id == yaziId);
        }

        public IList<Yazi> GetList()
        {
            return yDal.GetList();
        }

        public void Update(Yazi yazi)
        {
            yDal.Update(yazi);
        }
    }
}
