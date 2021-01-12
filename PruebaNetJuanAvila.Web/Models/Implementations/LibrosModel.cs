using PruebaNetJuanAvila.Dto.Data;
using PruebaNetJuanAvila.Dto.Dto;
using PruebaNetJuanAvila.Web.Models.Declarations;
using PruebaNetJuanAvila.Web.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Web.Models.Implementations
{
    public class LibrosModel : ILibrosModel
    {
        private readonly IApiServices _apiServices;

        public LibrosModel(IApiServices apiServices)
        {
            _apiServices = apiServices;
        }

        public async Task<List<LibrosDto>> GetLibros() =>
           await _apiServices.GetAsync<List<LibrosDto>>($"Libro/{nameof(GetLibros)}");
        public async Task<LibrosDto> GetLibroById(int LibroId) =>
            await _apiServices.GetAsync<LibrosDto>($"Libro/{nameof(GetLibroById)}?LibroId={LibroId}");

        public async Task<int> InsertLibro(LibrosDto Libro) =>
            await _apiServices.PostAsync<int, LibrosDto>(Libro, $"Libro/{nameof(InsertLibro)}");

        public async Task UpdateLibro(Libros Libro) =>
            await _apiServices.PutAsync<int?, Libros>(Libro, $"Libro/{nameof(UpdateLibro)}");
    }
}
