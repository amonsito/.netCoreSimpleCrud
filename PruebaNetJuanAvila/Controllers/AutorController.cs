using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaNetJuanAvila.Bl.Declarations;
using PruebaNetJuanAvila.Dto.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Controllers
{
    [Route("api/Autor")]
    [ApiController]
    public class AutorController : Controller
    {
        private readonly IAutoresBl _autoresBl;

        public AutorController(IAutoresBl autoresBl)
        {
            _autoresBl = autoresBl;
        }

        
        [HttpGet, Route(nameof(GetAutors))]
        public async Task<IActionResult> GetAutors(int? EditorialId)
        {
            try
            {
                return Ok(await _autoresBl.GetAutors(EditorialId));
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpGet, Route(nameof(GetAutorById))]
        public async Task<IActionResult> GetAutorById(int AutorId)
        {
            try
            {
                return Ok(await _autoresBl.GetAutorById(AutorId));
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }
        [HttpPost, Route(nameof(InsertAutor))]
        public async Task<IActionResult> InsertAutor(Autores Autor)
        {
            try
            {
                return Ok(await _autoresBl.InsertAutor(Autor));
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }
        [HttpPut,Route(nameof(UpdateAutor))]
        public async Task<IActionResult> UpdateAutor(Autores Autor)
        {
            try
            {
                await _autoresBl.UpdateAutor(Autor);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }
    }
}
