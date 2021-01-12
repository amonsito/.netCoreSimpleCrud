using Autofac;
using PruebaNetJuanAvila.Bl.Declarations;
using PruebaNetJuanAvila.Bl.Implementations;

namespace PruebaNetJuanAvila.Bl.IoC
{
    public class BlModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LibrosBl>().As<ILibrosBl>();
            builder.RegisterType<EditorialesBl>().As<IEditorialesBl>();
            builder.RegisterType<AutoresBl>().As<IAutoresBl>();
        }
    }
}
