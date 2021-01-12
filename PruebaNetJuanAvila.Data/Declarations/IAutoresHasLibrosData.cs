using PruebaNetJuanAvila.Dto.Data;
using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Data.Implementations
{
    public interface IAutoresHasLibrosData
    {
        Task DeleteAutorHasLibroByLibro(int LibroId);
        Task InsertAutorHasLibro(AutoresHasLibros autorHasLibro);
    }
}