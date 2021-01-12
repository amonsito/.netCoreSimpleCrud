using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaNetJuanAvila.Data.Common;
using PruebaNetJuanAvila.Data.Declatations;
using PruebaNetJuanAvila.Dto.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Data.Implementations
{
    public class EditorialesData : BaseData, IEditorialesData
    {
        public EditorialesData(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<List<Editoriales>> GetEditorials() =>
            await Context.Set<Editoriales>().ToListAsync();
        public async Task<Editoriales> GetEditorialById(int EditorialId) =>
            await Context.Set<Editoriales>().Where(x => x.Id == EditorialId).FirstOrDefaultAsync();
        public async Task<int> InsertEditorial(Editoriales Editorial)
        {
            Context.Editoriales.Add(Editorial);
            await Context.SaveChangesAsync();
            return Editorial.Id;
        }
        public async Task UpdateEditorial(Editoriales Editorial)
        {
            Context.Editoriales.Update(Editorial);
            await Context.SaveChangesAsync();
        }
    }
}
