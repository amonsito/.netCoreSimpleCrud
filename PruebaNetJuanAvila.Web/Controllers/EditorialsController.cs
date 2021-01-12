using Microsoft.AspNetCore.Mvc;
using PruebaNetJuanAvila.Dto.Data;
using PruebaNetJuanAvila.Web.Models.Declarations;
using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Web.Controllers
{
    public class EditorialsController : Controller
    {
        public readonly IEditorialesModel _editorialesModel;

        public EditorialsController(IEditorialesModel editorialesModel)
        {
            _editorialesModel = editorialesModel;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _editorialesModel.GetEditorials());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Editoriales collection)
        {
            try
            {
                await _editorialesModel.InsertEditorial(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(collection);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _editorialesModel.GetEditorialById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Editoriales collection)
        {
            try
            {
                await _editorialesModel.UpdateEditorial(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
