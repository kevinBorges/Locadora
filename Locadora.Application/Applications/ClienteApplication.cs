using Locadora.Application.Interfaces;
using Locadora.Application.ViewModels;
using Locadora.Domain.Entities;
using Locadora.Infra.Interfaces;
using Locadora.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Application.Applications
{
    public class ClienteApplication : IClienteApplication
    {
        IClienteRepository _clienteRepository;

        public ClienteApplication(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void Atualizar(ClienteViewModel clienteModel)
        {
            var cliente = _clienteRepository.BuscarPorId(clienteModel.Id);
            cliente.Nome = clienteModel.Nome;
            cliente.Documento = clienteModel.Documento;

            _clienteRepository.Atualizar(cliente);
        }

        public ClienteViewModel BuscarPorId(int id)
        {
            var cliente = _clienteRepository.BuscarPorId(id);
            var clienteViewModel = new ClienteViewModel
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Documento = cliente.Documento
            };
            return clienteViewModel;
        }

        public IEnumerable<ClienteViewModel> BuscarTodos()
        {
            var clientes = _clienteRepository.BuscarTodos();
            var filmesViewModel = clientes.Select(cliente => new ClienteViewModel
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Documento = cliente.Documento
            });

            return filmesViewModel;
        }

        public void Cadastrar(ClienteViewModel clienteViewModel)
        {
            var cliente = new Clientes
            {
                Nome = clienteViewModel.Nome,
                Documento = clienteViewModel.Documento
            };
            _clienteRepository.Cadastrar(cliente);
        }

        public void Deletar(int id)
        {
            var cliente = _clienteRepository.BuscarPorId(id);
            cliente.Deletado = true;

            _clienteRepository.Atualizar(cliente);
        }
    }
}
