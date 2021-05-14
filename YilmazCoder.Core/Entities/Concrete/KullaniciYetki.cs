using System;
using System.Collections.Generic;
using System.Text;

namespace YilmazCoder.Core.Entities.Concrete
{
    public class KullaniciYetki:IEntity
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public int YetkiId { get; set; }
    }
}
