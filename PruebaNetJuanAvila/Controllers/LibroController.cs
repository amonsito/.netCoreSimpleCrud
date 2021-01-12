using Microsoft.AspNetCore.Mvc;
using PruebaNetJuanAvila.Bl.Declarations;
using PruebaNetJuanAvila.Dto.Data;
using PruebaNetJuanAvila.Dto.Dto;
using System;
using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Controllers
{
    [Route("api/Libro")]
    [ApiController]
    public class LibroController : Controller
    {
        private readonly ILibrosBl _LibroesBl;

        public LibroController(ILibrosBl LibroesBl)
        {
            _LibroesBl = LibroesBl;
        }

        [HttpGet, Route(nameof(GetLibros))]
        public async Task<IActionResult> GetLibros()
        {
            try
            {
                return Ok(await _LibroesBl.GetLibros());
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpGet, Route(nameof(GetLibroById))]
        public async Task<IActionResult> GetLibroById(int LibroId)
        {
            try
            {
                return Ok(await _LibroesBl.GetLibroById(LibroId));
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }
        [HttpPost, Route(nameof(InsertLibro))]
        public async Task<IActionResult> InsertLibro(LibrosDto Libro)
        {
            try
            {
                return Ok(await _LibroesBl.InsertLibro(Libro));
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }
        [HttpPut, Route(nameof(UpdateLibro))]
        public async Task<IActionResult> UpdateLibro(LibrosDto Libro)
        {
            try
            {
                await _LibroesBl.UpdateLibro(Libro);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }
    }
}
