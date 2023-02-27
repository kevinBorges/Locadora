using Locadora.Application.Applications;
using Locadora.Application.Interfaces;
using Locadora.Application.ViewModels;
using Locadora.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;

namespace Locadora.Web.Controllers
{
    [Authorize]
    public class LocacaoController : Controller
    {
        private readonly ILocacaoApplication _locacaoApplication;
        private readonly IFilmeApplication _filmeApplication;
        private readonly IClienteApplication _clienteApplication;

        public LocacaoController(ILocacaoApplication locacaoApplication, 
                                 IFilmeApplication filmeApplication, 
                                 IClienteApplication clienteApplication
            )
        {
            _locacaoApplication = locacaoApplication;
            _filmeApplication = filmeApplication;
            _clienteApplication = clienteApplication;
        }

        public ActionResult Index()
        {
            return View(_locacaoApplication.BuscarTodos());
        }

        public ActionResult Create()
        {
            ViewData["FilmeId"] = new SelectList(_filmeApplication.BuscarTodos(), "Id", "Titulo");
            ViewData["ClienteId"] = new SelectList(_clienteApplication.BuscarTodos(), "Id", "Nome");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocacaoViewModel model)
        {
            _locacaoApplication.Cadastrar(model);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            var locacao = _locacaoApplication.BuscarPorId(id);
            ViewData["FilmeId"] = new SelectList(_filmeApplication.BuscarTodos(), "Id", "Titulo",locacao.FilmeId);
            ViewData["ClienteId"] = new SelectList(_clienteApplication.BuscarTodos(), "Id", "Nome",locacao.ClienteId);
            return View(locacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LocacaoViewModel model)
        {
            _locacaoApplication.Atualizar(model);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            return View(_locacaoApplication.BuscarPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _locacaoApplication.Deletar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
