using Locadora.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Application.Interfaces
{
    public interface ICategoriaApplication
    {
        CategoriaViewModel BuscarPorId(int id);
        IEnumerable<CategoriaViewModel> BuscarTodos();
        void Atualizar(CategoriaViewModel categoriaViewModel);
        void Cadastrar(CategoriaViewModel categoriaViewModel);
        void Deletar(int id);
    }
}
