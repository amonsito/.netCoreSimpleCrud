using PruebaNetJuanAvila.Bl.Declarations;
using PruebaNetJuanAvila.Data.Declatations;
using PruebaNetJuanAvila.Dto.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Bl.Implementations
{
    public class EditorialesBl : IEditorialesBl
    {
        private readonly IEditorialesData _EditorialesDal;

        public EditorialesBl(IEditorialesData EditorialesDal)
        {
            _EditorialesDal = EditorialesDal;
        }
        public async Task<List<Editoriales>> GetEditorials() =>
            await _EditorialesDal.GetEditorials();
        

        public async Task<Editoriales> GetEditorialById(int EditorialId) =>
            await _EditorialesDal.GetEditorialById(EditorialId);
        public async Task<int> InsertEditorial(Editoriales Editorial) =>
            await _EditorialesDal.InsertEditorial(Editorial);

        public async Task UpdateEditorial(Editoriales Editorial) =>
            await _EditorialesDal.UpdateEditorial(Editorial);
    }
}
