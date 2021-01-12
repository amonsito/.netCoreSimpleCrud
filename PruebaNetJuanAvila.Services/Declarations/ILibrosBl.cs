using PruebaNetJuanAvila.Dto.Data;
using PruebaNetJuanAvila.Dto.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Bl.Declarations
{
    public interface ILibrosBl
    {
        Task<List<LibrosDto>> GetLibros();
        Task<LibrosDto> GetLibroById(int LibroId);
        Task<int> InsertLibro(LibrosDto Libro);
        Task UpdateLibro(LibrosDto Libro);
    }
}