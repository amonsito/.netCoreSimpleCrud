using Microsoft.Extensions.Configuration;
using PruebaNetJuanAvila.Data.Implementations.DataContex;

namespace PruebaNetJuanAvila.Data.Common
{
    public class BaseData
    {
        public DB_JuanAvilaContext Context;
        public BaseData(IConfiguration configuration)
        {
            var conString = configuration.GetConnectionString("DB_JuanAvila");
            Context = new DB_JuanAvilaContext(conString);
        }   
    }
}
