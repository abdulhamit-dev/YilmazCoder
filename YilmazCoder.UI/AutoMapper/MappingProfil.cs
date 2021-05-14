using AutoMapper;
using YilmazCoder.Core.Entities.Concrete;
using YilmazCoder.Entities;
using YilmazCoder.Entities.Dtos;
using YilmazCoder.UI.Models.Kullanici;
using YilmazCoder.UI.Models.Yazi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YilmazCoder.UI.AutoMapper
{
    public class MappingProfil:Profile
    {
        public MappingProfil()
        {
            CreateMap<Yazi, YaziVM>();
            CreateMap<YaziVM, Yazi>();

            CreateMap<YaziDto, YaziVM>();
            CreateMap<YaziVM, YaziDto>();

            CreateMap<Kullanici, KullaniciVM>();
            CreateMap<KullaniciVM, Kullanici>();

        }
    }
}
