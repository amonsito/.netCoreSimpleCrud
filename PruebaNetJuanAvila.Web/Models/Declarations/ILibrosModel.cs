using PruebaNetJuanAvila.Dto.Data;
using PruebaNetJuanAvila.Dto.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Web.Models.Declarations
{
    public interface ILibrosModel
    {
        Task<List<LibrosDto>> GetLibros();
        Task<LibrosDto> GetLibroById(int LibroId);
        Task<int> InsertLibro(LibrosDto Libro);
        Task UpdateLibro(Libros Libro);
    }
}