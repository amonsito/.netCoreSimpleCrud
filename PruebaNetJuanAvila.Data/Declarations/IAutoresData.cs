using PruebaNetJuanAvila.Dto.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Data.Declatations
{
    public interface IAutoresData
    {
        Task<List<Autores>> GetAutors(int? EditorialId);
        Task<Autores> GetAutorById(int AutorId);
        Task<int> InsertAutor(Autores Autor);
        Task UpdateAutor(Autores Autor);
    }
}