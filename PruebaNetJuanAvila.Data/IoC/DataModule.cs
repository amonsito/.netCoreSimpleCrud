using Autofac;
using PruebaNetJuanAvila.Data.Declatations;
using PruebaNetJuanAvila.Data.Implementations;

namespace PruebaNetJuanAvila.Data.IoC
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LibrosData>().As<ILibrosData>();
            builder.RegisterType<AutoresData>().As<IAutoresData>();
            builder.RegisterType<EditorialesData>().As<IEditorialesData>();
            builder.RegisterType<AutoresHasLibrosData>().As<IAutoresHasLibrosData>();
        }
    }
}
