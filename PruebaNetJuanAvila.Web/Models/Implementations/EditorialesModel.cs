using PruebaNetJuanAvila.Dto.Data;
using PruebaNetJuanAvila.Web.Models.Declarations;
using PruebaNetJuanAvila.Web.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Web.Models.Implementations
{
    public class EditorialesModel : IEditorialesModel
    {
        private readonly IApiServices _apiServices;

        public EditorialesModel(IApiServices apiServices)
        {
            _apiServices = apiServices;
        }

        public async Task<List<Editoriales>> GetEditorials() =>
        await _apiServices.GetAsync<List<Editoriales>>($"Editorial/{nameof(GetEditorials)}");
        public async Task<Editoriales> GetEditorialById(int EditorialId) =>
            await _apiServices.GetAsync<Editoriales>($"Editorial/{nameof(GetEditorialById)}?EditorialId={EditorialId}");

        public async Task<int> InsertEditorial(Editoriales Editorial) =>
            await _apiServices.PostAsync<int, Editoriales>(Editorial, $"Editorial/{nameof(InsertEditorial)}");

        public async Task UpdateEditorial(Editoriales Editorial) =>
            await _apiServices.PutAsync<int?, Editoriales>(Editorial, $"Editorial/{nameof(UpdateEditorial)}");
    }
}
