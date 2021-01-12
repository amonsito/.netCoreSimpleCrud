using PruebaNetJuanAvila.Dto.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Data.Declatations
{
    public interface IEditorialesData
    {
        Task<List<Editoriales>> GetEditorials();
        Task<Editoriales> GetEditorialById(int EditorialId);
        Task<int> InsertEditorial(Editoriales Editorial);
        Task UpdateEditorial(Editoriales Editorial);
    }
}