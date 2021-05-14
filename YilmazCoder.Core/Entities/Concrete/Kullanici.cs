using System;
using System.Collections.Generic;
using System.Text;

namespace YilmazCoder.Core.Entities.Concrete
{
    public class Kullanici : IEntity
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Sifre { get; set; }
        public string Eposta { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string Resim { get; set; }
    }
}
