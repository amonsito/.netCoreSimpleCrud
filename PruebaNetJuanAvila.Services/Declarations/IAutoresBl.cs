using PruebaNetJuanAvila.Dto.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Bl.Declarations
{
    public interface IAutoresBl
    {
        Task<List<Autores>> GetAutors(int? EditorialId);
        Task<Autores> GetAutorById(int AutorId);
        Task<int> InsertAutor(Autores Autor);
        Task UpdateAutor(Autores Autor);
    }
}