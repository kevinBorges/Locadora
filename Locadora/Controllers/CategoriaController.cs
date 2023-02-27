using Locadora.Application.Interfaces;
using Locadora.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Web.Controllers
{
    [Authorize]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaApplication _categoriaApplication;
        public CategoriaController(ICategoriaApplication categoriaApplication)
        {
            _categoriaApplication = categoriaApplication;
        }
        public ActionResult Index()
        {
            return View(_categoriaApplication.BuscarTodos());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaViewModel model)
        {
            _categoriaApplication.Cadastrar(model);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            return View(_categoriaApplication.BuscarPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoriaViewModel model)
        {
            _categoriaApplication.Atualizar(model);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            return View(_categoriaApplication.BuscarPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _categoriaApplication.Deletar(id);   
            return RedirectToAction(nameof(Index));
        }
    }
}
