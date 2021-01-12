using Microsoft.AspNetCore.Mvc;
using PruebaNetJuanAvila.Bl.Declarations;
using PruebaNetJuanAvila.Dto.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Controllers
{
    [Route("api/Editorial")]
    [ApiController]
    public class EditorialController : Controller
    {
        private readonly IEditorialesBl _EditorialesBl;

        public EditorialController(IEditorialesBl EditorialesBl)
        {
            _EditorialesBl = EditorialesBl;
        }


        [HttpGet, Route(nameof(GetEditorials))]
        public async Task<IActionResult> GetEditorials()
        {
            try
            {
                return Ok(await _EditorialesBl.GetEditorials());
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpGet, Route(nameof(GetEditorialById))]
        public async Task<IActionResult> GetEditorialById(int EditorialId)
        {
            try
            {
                return Ok(await _EditorialesBl.GetEditorialById(EditorialId));
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }
        [HttpPost, Route(nameof(InsertEditorial))]
        public async Task<IActionResult> InsertEditorial(Editoriales Editorial)
        {
            try
            {
                return Ok(await _EditorialesBl.InsertEditorial(Editorial));
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }
        [HttpPut, Route(nameof(UpdateEditorial))]
        public async Task<IActionResult> UpdateEditorial(Editoriales Editorial)
        {
            try
            {
                await _EditorialesBl.UpdateEditorial(Editorial);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }
    }
}
