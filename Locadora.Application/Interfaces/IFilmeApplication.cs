using Locadora.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Application.Interfaces
{
    public interface IFilmeApplication
    {
        FilmeViewModel BuscarPorId(int id);
        IEnumerable<FilmeViewModel> BuscarTodos();
        void Atualizar(FilmeViewModel filmeViewModel);
        void Cadastrar(FilmeViewModel filmeViewModel);
        void Deletar(int id);
    }
}
