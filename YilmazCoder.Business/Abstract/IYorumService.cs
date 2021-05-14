using YilmazCoder.Entities;
using YilmazCoder.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace YilmazCoder.Business.Abstract
{
    public interface IYorumService
    {
        Yorum GetById(int yorumId);
        IList<YorumDto> GetList(int yaziId);
        void Add(Yorum yorum);
        void Delete(Yorum yorum);
        void Update(Yorum yorum);
    }
}
