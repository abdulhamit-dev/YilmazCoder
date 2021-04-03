using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Core.Entities.Concrete
{
    public class KullaniciYetki
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public int YetkiId { get; set; }
    }
}
