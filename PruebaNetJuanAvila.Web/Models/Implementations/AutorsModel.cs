using PruebaNetJuanAvila.Dto.Data;
using PruebaNetJuanAvila.Web.Models.Declarations;
using PruebaNetJuanAvila.Web.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Web.Models.Implementations
{
    public class AutorsModel : IAutorsModel
    {
        private readonly IApiServices _apiServices;

        public AutorsModel(IApiServices apiServices)
        {
            _apiServices = apiServices;
        }


        public async Task<List<Autores>> GetAutors(int? EditorialId) =>
        await _apiServices.GetAsync<List<Autores>>($"Autor/{nameof(GetAutors)}?EditorialId={EditorialId}");

        public async Task<Autores> GetAutorById(int AutorId) =>
            await _apiServices.GetAsync<Autores>($"Autor/{nameof(GetAutorById)}?AutorId={AutorId}");

        public async Task<int> InsertAutor(Autores Autor) =>
            await _apiServices.PostAsync<int, Autores>(Autor, $"Autor/{nameof(InsertAutor)}");

        public async Task UpdateAutor(Autores Autor) =>
            await _apiServices.PutAsync<int?, Autores>(Autor, $"Autor/{nameof(UpdateAutor)}");
    }
}
