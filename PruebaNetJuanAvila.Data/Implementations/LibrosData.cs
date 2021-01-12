using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaNetJuanAvila.Data.Common;
using PruebaNetJuanAvila.Data.Declatations;
using PruebaNetJuanAvila.Dto.Data;
using PruebaNetJuanAvila.Dto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Data.Implementations
{
    public class LibrosData : BaseData, ILibrosData
    {
        public LibrosData(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<List<LibrosDto>> GetLibros()
        {
            var result = await (from x in Context.Set<Libros>()
                                join E in Context.Set<Editoriales>() on x.EditorialesId equals E.Id
                                select new LibrosDto
                                {
                                    Isbn = x.Isbn,
                                    Titulo = x.Titulo,
                                    NPaginas = x.NPaginas,
                                    Sinopsis = x.Sinopsis,
                                    EditorialName = $"{E.Nombre} [{E.Sede}]",
                                }).ToListAsync();
            result.ForEach(x =>
            {
                x.AutoresName = GetAutorsName(x.Isbn);
            });
            return result;
        }

        public async Task<LibrosDto> GetLibroById(int LibroId)
        {
            var libro = await Context.Set<Libros>().Where(x => x.Isbn == LibroId).FirstOrDefaultAsync();
            return new LibrosDto
            {
                Isbn = libro.Isbn,
                EditorialesId = libro.EditorialesId,
                NPaginas = libro.NPaginas,
                Sinopsis = libro.Sinopsis,
                Titulo = libro.Titulo,
                Autores = GetAutorByBook(libro.Isbn),
                AutoresName = GetAutorsName(libro.Isbn),
            };
        }

        public async Task<int> InsertLibro(Libros Libro)
        {
            Context.Libros.Add(Libro);
            await Context.SaveChangesAsync();
            return Libro.Isbn;
        }
        public async Task UpdateAutor(Libros Libro)
        {
            Context.Libros.Update(Libro);
            await Context.SaveChangesAsync();
        }
        #region Private Methods

        private List<int> GetAutorByBook(int isbn)
        {
            return (from AHL in Context.Set<AutoresHasLibros>()
                    join A in Context.Set<Autores>() on AHL.LibrosIsbn equals A.Id
                    where AHL.LibrosIsbn == isbn
                    select A.Id).ToList();
        }

        private string GetAutorsName(int isbn)
        {
            var Autors = (from AHL in Context.Set<AutoresHasLibros>()
                          join A in Context.Set<Autores>() on AHL.AutoresId equals A.Id
                          where AHL.LibrosIsbn == isbn
                          select $"{A.Nombre} {A.Apellidos}").ToList();
            return string.Join(", ", Autors);
        }
        #endregion
    }
}
