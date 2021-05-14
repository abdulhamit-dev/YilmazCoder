using YilmazCoder.Entities;
using YilmazCoder.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YilmazCoder.UI.Models.Yazi
{
    public class YaziVM
    {
        public int Id { get; set; }
        public int KategoriId { get; set; }
        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciResmi { get; set; }
        public string YaziBaslik { get; set; }
        public string YaziIcerik { get; set; }
        public string ResimBase64 { get; set; }
        public bool ResimSecimi { get; set; }
        public string YaziKapakResim { get; set; }
        public DateTime YaziTarih { get; set; }
        public int BegeniSayisi { get; set; }
        public int YorumSayisi { get; set; }
        public List<YorumDto> YorumList { get; set; }
    }
}
