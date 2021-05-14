using YilmazCoder.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace YilmazCoder.Entities
{
    public class Yorum:IEntity
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public int YaziId { get; set; }
        public string Aciklama { get; set; }
        public DateTime KayitTarihi { get; set; }
    }
}
