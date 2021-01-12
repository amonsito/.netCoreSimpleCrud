using PruebaNetJuanAvila.Bl.Declarations;
using PruebaNetJuanAvila.Data.Declatations;
using PruebaNetJuanAvila.Data.Implementations;
using PruebaNetJuanAvila.Dto.Data;
using PruebaNetJuanAvila.Dto.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Bl.Implementations
{
    public class LibrosBl : ILibrosBl
    {
        private readonly ILibrosData _librosDal;
        private readonly IAutoresHasLibrosData _autoresHasLibrosData;

        public LibrosBl(ILibrosData librosDal, IAutoresHasLibrosData autoresHasLibrosData)
        {
            _librosDal = librosDal;
            _autoresHasLibrosData = autoresHasLibrosData;
        }

        public async Task<List<LibrosDto>> GetLibros() =>
            await _librosDal.GetLibros();
        public async Task<LibrosDto> GetLibroById(int LibroId) =>
            await _librosDal.GetLibroById(LibroId);
        public async Task<int> InsertLibro(LibrosDto Libro)
        {
            var LibroId = await _librosDal.InsertLibro(Libro);
            foreach (var AutorId in Libro.Autores)
            {
                await _autoresHasLibrosData.InsertAutorHasLibro(new AutoresHasLibros
                {
                    AutoresId = AutorId,
                    LibrosIsbn = LibroId
                });
            }
            return LibroId;

        }


        public async Task UpdateLibro(LibrosDto Libro) 
        {
            try
            {
                await _librosDal.UpdateAutor(Libro);
                await _autoresHasLibrosData.DeleteAutorHasLibroByLibro(Libro.Isbn);
                foreach (var AutorId in Libro.Autores)
                {
                    await _autoresHasLibrosData.InsertAutorHasLibro(new AutoresHasLibros
                    {
                        AutoresId = AutorId,
                        LibrosIsbn = Libro.Isbn
                    });
                }
            }
            catch (System.Exception e)
            {

            }
            
        }
            

    }
}
