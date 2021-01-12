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
    public class AutoresData : BaseData, IAutoresData
    {
        public AutoresData(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<List<Autores>> GetAutors(int? EditorialId)
        {
            if (EditorialId is null)
                return await Context.Set<Autores>().ToListAsync();

            return await (from ed in Context.Set<Editoriales>()
                          join lib in Context.Set<Libros>() on ed.Id equals lib.EditorialesId
                          join aut_lib in Context.Set<AutoresHasLibros>() on lib.Isbn equals aut_lib.LibrosIsbn
                          join aut in Context.Set<Autores>() on aut_lib.AutoresId equals aut.Id
                          where ed.Id == EditorialId
                          select aut).Distinct().ToListAsync();
        }

        public async Task<Autores> GetAutorById(int AutorId) =>
            await Context.Set<Autores>().Where(x => x.Id == AutorId).FirstOrDefaultAsync();
        public async Task<int> InsertAutor(Autores Autor)
        {
            Context.Autores.Add(Autor);
            await Context.SaveChangesAsync();
            return Autor.Id;
        }
        public async Task UpdateAutor(Autores Autor)
        {
            Context.Autores.Update(Autor);
            await Context.SaveChangesAsync();
        }
    }
}