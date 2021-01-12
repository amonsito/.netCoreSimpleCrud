using PruebaNetJuanAvila.Bl.Declarations;
using PruebaNetJuanAvila.Data.Declatations;
using PruebaNetJuanAvila.Dto.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Bl.Implementations
{
    public class AutoresBl : IAutoresBl
    {
        private readonly IAutoresData _autoresDal;

        public AutoresBl(IAutoresData autoresDal)
        {
            _autoresDal = autoresDal;
        }

        public async Task<List<Autores>> GetAutors(int? EditorialId) =>
            await _autoresDal.GetAutors(EditorialId);
        public async Task<Autores> GetAutorById(int AutorId) =>
            await _autoresDal.GetAutorById(AutorId);
        public async Task<int> InsertAutor(Autores Autor) =>
            await _autoresDal.InsertAutor(Autor);

        public async Task UpdateAutor(Autores Autor) =>
            await _autoresDal.UpdateAutor(Autor);
    }
}
