using PruebaNetJuanAvila.Dto.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Web.Models.Declarations
{
    public interface IAutorsModel
    {
        Task<List<Autores>> GetAutors(int? EditorialId);
        Task<Autores> GetAutorById(int AutorId);
        Task<int> InsertAutor(Autores Autor);
        Task UpdateAutor(Autores Autor);
    }
}