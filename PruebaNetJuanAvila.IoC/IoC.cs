using Autofac;
using PruebaNetJuanAvila.Bl.IoC;
using PruebaNetJuanAvila.Data.IoC;

namespace PruebaNetJuanAvila.IoC
{
    public static class IoC
    {
        public static void RegisterModulesIoC(this ContainerBuilder builder)
        {
            builder.RegisterModule(new BlModule());
            builder.RegisterModule(new DataModule());
        }
    }
}
