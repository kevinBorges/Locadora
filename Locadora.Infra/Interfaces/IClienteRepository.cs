using Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.Interfaces
{
    public interface IClienteRepository
    {
        void Atualizar(Clientes categoria);
        Clientes BuscarPorId(int id);
        IEnumerable<Clientes> BuscarTodos();
        void Cadastrar(Clientes categoria);

    }
}
