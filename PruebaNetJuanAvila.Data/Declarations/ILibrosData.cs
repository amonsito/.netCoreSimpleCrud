using PruebaNetJuanAvila.Dto.Data;
using PruebaNetJuanAvila.Dto.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Data.Declatations
{
    public interface ILibrosData
    {
        Task<List<LibrosDto>> GetLibros();
        Task<LibrosDto> GetLibroById(int LibroId);
        Task<int> InsertLibro(Libros Libro);
        Task UpdateAutor(Libros Libro);
    }
}