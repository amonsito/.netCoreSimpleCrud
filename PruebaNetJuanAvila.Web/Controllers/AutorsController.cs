using Microsoft.AspNetCore.Mvc;
using PruebaNetJuanAvila.Dto.Data;
using PruebaNetJuanAvila.Web.Models.Declarations;
using System;
using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Web.Controllers
{
    public class AutorsController : Controller
    {
        private readonly IAutorsModel _autorsModel;

        public AutorsController(IAutorsModel autorsModel)
        {
            _autorsModel = autorsModel;
        }

        public async Task<IActionResult> Index(int? EditorialId)
        {
            return View(await _autorsModel.GetAutors(EditorialId));
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Autores collection)
        {
            try
            {
                await _autorsModel.InsertAutor(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _autorsModel.GetAutorById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Autores collection)
        {
            try
            {
                await _autorsModel.UpdateAutor(collection);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View(collection);
            }
        }
    }
}
