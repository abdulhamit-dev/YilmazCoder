using AutoMapper;
using CoderBlog.Entities;
using CoderBlog.UI.Models.Yazi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderBlog.UI.AutoMapper
{
    public class MappingProfil:Profile
    {
        public MappingProfil()
        {
            CreateMap<Yazi, YaziVM>();
            CreateMap<YaziVM, Yazi>();


        }
    }
}
