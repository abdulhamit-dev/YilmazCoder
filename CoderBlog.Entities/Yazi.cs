using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.Entities
{
    public class Yazi
    {
        public int Id { get; set; }
        public int KategoriId { get; set; }
        public int KullaniciId { get; set; }
        public string YaziBaslik { get; set; }
        public string YaziIcerik { get; set; }
        public DateTime YaziTarih { get; set; }

    }
}
