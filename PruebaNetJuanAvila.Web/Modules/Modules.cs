using Autofac;
using PruebaNetJuanAvila.Web.Models.Declarations;
using PruebaNetJuanAvila.Web.Models.Implementations;
using PruebaNetJuanAvila.Web.Services;

namespace PruebaNetJuanAvila.Web.Modules
{
    public class Modules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApiServices>().As<IApiServices>();
            builder.RegisterType<AutorsModel>().As<IAutorsModel>();
            builder.RegisterType<EditorialesModel>().As<IEditorialesModel>();
            builder.RegisterType<LibrosModel>().As<ILibrosModel>();
        }
    }
}
