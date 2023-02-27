using Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.Interfaces
{
    public interface ILocacaoRepository
    {
        void Atualizar(Locacao categoria);
        Locacao BuscarPorId(int id);
        IEnumerable<Locacao> BuscarTodos();
        void Cadastrar(Locacao categoria);
    }
}
