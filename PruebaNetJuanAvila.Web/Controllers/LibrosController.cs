using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PruebaNetJuanAvila.Dto.Data;
using PruebaNetJuanAvila.Dto.Dto;
using PruebaNetJuanAvila.Web.Models.Declarations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Web.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ILibrosModel _librosModel;
        private readonly IEditorialesModel _editorialesModel;
        private readonly IAutorsModel _autorsModel;

        public LibrosController(ILibrosModel librosModel, IEditorialesModel editorialesModel, IAutorsModel autorsModel)
        {
            _librosModel = librosModel;
            _editorialesModel = editorialesModel;
            _autorsModel = autorsModel;
        }

        public async Task<IActionResult> Index() =>
            View(await _librosModel.GetLibros());

        public async Task<IActionResult> Create()
        {
            var autors = await _autorsModel.GetAutors(null);
            ViewBag.Autores = new SelectList(autors, "Id", "Nombre");

            var Editoriales = await _editorialesModel.GetEditorials();
            ViewBag.Editoriales = new SelectList(Editoriales, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LibrosDto collection)
        {
            try
            {
                await _librosModel.InsertLibro(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var Editoriales = await _editorialesModel.GetEditorials();
                ViewBag.Editoriales = new SelectList(Editoriales, "Id", "Nombre", Editoriales.Where(e => e.Id == collection.EditorialesId).FirstOrDefault());
                return View(collection);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var libro = await _librosModel.GetLibroById(id);
            var autors = await _autorsModel.GetAutors(null);
            ViewBag.Autores = new SelectList(autors, "Id", "Nombre",libro.Autores);

            var Editoriales = await _editorialesModel.GetEditorials();
            ViewBag.Editoriales = new SelectList(Editoriales, "Id", "Nombre", new SelectList(Editoriales, "Id", "Nombre", Editoriales.Where(e => e.Id == id).FirstOrDefault()));
            return View(libro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LibrosDto collection)
        {
            try
            {
                await _librosModel.UpdateLibro(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var autors = await _autorsModel.GetAutors(null);
                ViewBag.Autores = new SelectList(autors, "Id", "Nombre", collection.Autores);

                var Editoriales = await _editorialesModel.GetEditorials();
                ViewBag.Editoriales = new SelectList(Editoriales, "Id", "Nombre", new SelectList(Editoriales, "Id", "Nombre", Editoriales.Where(e => e.Id == collection.Isbn).FirstOrDefault()));
                return View(collection);
            }
        }
        public async Task<IActionResult> Detail(int id)
        {
            var libro = await _librosModel.GetLibroById(id);
            var Editoriales = (await _editorialesModel.GetEditorials()).FirstOrDefault();
            libro.EditorialName = $"{Editoriales.Nombre} [{Editoriales.Sede}]";
            return View(libro);
        }
    }
}
