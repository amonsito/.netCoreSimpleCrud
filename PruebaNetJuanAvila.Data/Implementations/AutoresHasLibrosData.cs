using Microsoft.Data.SqlClient;
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
    public class AutoresHasLibrosData : BaseData, IAutoresHasLibrosData
    {
        public AutoresHasLibrosData(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task InsertAutorHasLibro(AutoresHasLibros autorHasLibro)
        {

            try
            {
                _ = await Context.AutoresHasLibros
                .FromSqlInterpolated<AutoresHasLibros>($"INSERT INTO [dbo].[autores_has_libros] ([autores_id],[libros_ISBN]) VALUES ({autorHasLibro.AutoresId},{autorHasLibro.LibrosIsbn})").ToListAsync();
            }
            catch (Exception e)
            {

            }
        }



        public async Task DeleteAutorHasLibroByLibro(int LibroId)
        {
            try
            {
                _ = await Context.AutoresHasLibros
                .FromSqlInterpolated<AutoresHasLibros>($" DELETE FROM [dbo].[autores_has_libros] WHERE [libros_ISBN] ={LibroId}").ToListAsync();
            }
            catch (Exception E)
            {

            }
            
        }
    }
}
