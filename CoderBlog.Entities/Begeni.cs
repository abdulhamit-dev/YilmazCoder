using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Entities
{
    public class Begeni
    {
        public int Id { get; set; }
        public int YaziId { get; set; }
        public int KullaniciId { get; set; }
        public DateTime KayitTarihi { get; set; }
    }
}
