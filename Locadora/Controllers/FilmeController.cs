using Locadora.Application.Applications;
using Locadora.Application.Interfaces;
using Locadora.Application.ViewModels;
using Locadora.Infra.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Web.Controllers
{
    [Authorize]
    public class FilmeController : Controller
    {
        private readonly IFilmeApplication _filmeApplication;
        private readonly ICategoriaRepository _categoriaRepository;

        public FilmeController(IFilmeApplication filmeApplication,
                                ICategoriaRepository categoriaRepository)
        {
            _filmeApplication = filmeApplication;
            _categoriaRepository = categoriaRepository;
        }

        public ActionResult Index()
        {
            return View(_filmeApplication.BuscarTodos());
        }

        public ActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_categoriaRepository.BuscarTodos(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FilmeViewModel model)
        {
            _filmeApplication.Cadastrar(model);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            var filme = _filmeApplication.BuscarPorId(id);
            ViewData["CategoriaId"] = new SelectList(_categoriaRepository.BuscarTodos(), "Id", "Nome", filme.CategoriaId);
            return View(filme);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FilmeViewModel model)
        {
            _filmeApplication.Atualizar(model);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            return View(_filmeApplication.BuscarPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _filmeApplication.Deletar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
