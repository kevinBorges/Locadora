using Locadora.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Application.Interfaces
{
    public interface IClienteApplication
    {
        ClienteViewModel BuscarPorId(int id);
        IEnumerable<ClienteViewModel> BuscarTodos();
        void Atualizar(ClienteViewModel clienteViewModel);
        void Cadastrar(ClienteViewModel clienteViewModel);
        void Deletar(int id);
    }
}
