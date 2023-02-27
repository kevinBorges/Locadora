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
    public class CategoriaApplication : ICategoriaApplication
    {
        ICategoriaRepository _categoriaRepository;

        public CategoriaApplication(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public void Atualizar(CategoriaViewModel categoriaViewModel)
        {
            var categoria = _categoriaRepository.BuscarPorId(categoriaViewModel.Id);
            categoria.Nome = categoriaViewModel.Nome;

            _categoriaRepository.Atualizar(categoria);

    }

        public CategoriaViewModel BuscarPorId(int id)
        {
            var categoria = _categoriaRepository.BuscarPorId(id);
            var categoriaModel = new CategoriaViewModel { 
                Nome = categoria.Nome,
                Id = id
            };

            return categoriaModel;
        }

        public IEnumerable<CategoriaViewModel> BuscarTodos()
        {
            var categorias = _categoriaRepository.BuscarTodos();
            var categoriaViewModel = categorias.Select(categoria => new CategoriaViewModel
            {
                Id = categoria.Id,
                Nome = categoria.Nome
            });

            return categoriaViewModel;
        }

        public void Cadastrar(CategoriaViewModel categoriaViewModel)
        {
            var categoria = new Categorias
            {
                Nome = categoriaViewModel.Nome
            };

            _categoriaRepository.Cadastrar(categoria);
        }

        public void Deletar(int id)
        {
            var categoria = _categoriaRepository.BuscarPorId(id);
            categoria.Deletado = true;

            _categoriaRepository.Atualizar(categoria);
        }
    }
}
