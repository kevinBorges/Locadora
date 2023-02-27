using Locadora.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Application.Interfaces
{
    public interface ILocacaoApplication
    {
        LocacaoViewModel BuscarPorId(int id);
        IEnumerable<LocacaoViewModel> BuscarTodos();
        void Atualizar(LocacaoViewModel locacaoViewModel);
        void Cadastrar(LocacaoViewModel locacaoViewModel);
        void Deletar(int id);
    }
}
