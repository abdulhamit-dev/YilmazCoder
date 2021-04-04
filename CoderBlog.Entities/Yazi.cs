using CoderBlog.Core.Entities;
using System;

namespace CoderBlog.Entities
{
    public class Yazi : IEntity
    {
        public int Id { get; set; }
        public int KategoriId { get; set; }
        public int KullaniciId { get; set; }
        public string YaziBaslik { get; set; }
        public string YaziIcerik { get; set; }
        public DateTime YaziTarih { get; set; }
        public string YaziKapakResim { get; set; }
        //[NotMapped]
        //public string KullaniciAdi { get; set; }

    }
}
