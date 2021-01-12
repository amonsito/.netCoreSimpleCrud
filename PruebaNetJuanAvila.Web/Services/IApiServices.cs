using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Web.Services
{
    public interface IApiServices
    {
        Task<T> GetAsync<T>(string uri);
        Task<TOut> PostAsync<TOut, TIn>(TIn entity, string requestUri);
        Task<TOut> PutAsync<TOut, TIn>(TIn entity, string requestUri);
    }
}