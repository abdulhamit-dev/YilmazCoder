using Autofac;
using YilmazCoder.Business.Abstract;
using YilmazCoder.Business.Concrete;
using YilmazCoder.DataAccess.Abstract;
using YilmazCoder.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace YilmazCoder.Business.Dependency.Autofac
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<YaziManager>().As<IYaziService>();
            builder.RegisterType<YaziDal>().As<IYaziDal>();

            builder.RegisterType<KullaniciManager>().As<IKullaniciService>();
            builder.RegisterType<KullaniciDal>().As<IKullaniciDal>();

            builder.RegisterType<KategoriManager>().As<IKategoriService>();
            builder.RegisterType<KategoriDal>().As<IKategoriDal>();

            builder.RegisterType<YorumManager>().As<IYorumService>();
            builder.RegisterType<YorumDal>().As<IYorumDal>();

            builder.RegisterType<BegeniManager>().As<IBegeniService>();
            builder.RegisterType<BegeniDal>().As<IBegeniDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            
        }
    }
}
