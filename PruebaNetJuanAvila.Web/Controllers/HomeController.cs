using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PruebaNetJuanAvila.Web.Models;
using PruebaNetJuanAvila.Web.Models.Declarations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNetJuanAvila.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEditorialesModel _editorialesModel;

        public HomeController(ILogger<HomeController> logger, IEditorialesModel editorialesModel)
        {
            _logger = logger;
            _editorialesModel = editorialesModel;


        }

        public async Task<IActionResult> Index()
        {
            var Editoriales = await _editorialesModel.GetEditorials();
            ViewBag.Editoriales = new SelectList(Editoriales, "Id", "Nombre");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
