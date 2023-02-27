using Locadora.Application.Applications;
using Locadora.Application.Interfaces;
using Locadora.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Web.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly IClienteApplication _clienteApplication;
        public ClienteController(IClienteApplication clienteApplication)
        {
            _clienteApplication = clienteApplication;
        }
        public ActionResult Index()
        {
            return View(_clienteApplication.BuscarTodos());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel model)
        {
            _clienteApplication.Cadastrar(model);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            return View(_clienteApplication.BuscarPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClienteViewModel model)
        {
            _clienteApplication.Atualizar(model);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            return View(_clienteApplication.BuscarPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _clienteApplication.Deletar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
