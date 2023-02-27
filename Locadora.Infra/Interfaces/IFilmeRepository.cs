using Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.Interfaces
{
    public interface IFilmeRepository
    {
        void Atualizar(Filmes categoria);
        Filmes BuscarPorId(int id);
        IEnumerable<Filmes> BuscarTodos();
        void Cadastrar(Filmes categoria);
    }
}
