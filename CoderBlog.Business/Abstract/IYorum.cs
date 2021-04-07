using CoderBlog.Entities;
using CoderBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Business.Abstract
{
    public interface IYorum
    {
        Yorum GetById(int yorumId);
        IList<YorumDto> GetList(int yaziId);
        void Add(Yorum yorum);
        void Delete(Yorum yorum);
        void Update(Yorum yorum);
    }
}
