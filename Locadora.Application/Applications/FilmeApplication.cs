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
    public class FilmeApplication : IFilmeApplication
    {
        IFilmeRepository _filmeRepository;
        public FilmeApplication(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository; 
        }

        public void Atualizar(FilmeViewModel filmeViewModel)
        {
            var filme = _filmeRepository.BuscarPorId(filmeViewModel.Id);
            filme.Titulo = filmeViewModel.Titulo;
            filme.Descricao = filmeViewModel.Descricao;
            filme.CategoriaId = filmeViewModel.CategoriaId;

            _filmeRepository.Atualizar(filme);
        }

        public FilmeViewModel BuscarPorId(int id)
        {
            var filme = _filmeRepository.BuscarPorId(id);
            var filmeModel = new FilmeViewModel
            {
                Titulo = filme.Titulo,
                Descricao = filme.Descricao,
                CategoriaId= filme.CategoriaId,
                Categoria = filme.Categoria,
                Id = id
            };

            return filmeModel;
        }

        public IEnumerable<FilmeViewModel> BuscarTodos()
        {
            var filmes = _filmeRepository.BuscarTodos();
            var filmesViewModel = filmes.Select(filme => new FilmeViewModel
            {
                Id = filme.Id,
                Titulo= filme.Titulo,
                Descricao= filme.Descricao,
                Categoria = filme.Categoria,
                CategoriaId = filme.CategoriaId
            });

            return filmesViewModel;
        }

        public void Cadastrar(FilmeViewModel filmeViewModel)
        {
            var filme = new Filmes
            {
                Titulo = filmeViewModel.Titulo,
                Descricao = filmeViewModel.Descricao,
                CategoriaId = filmeViewModel.CategoriaId
            };

            _filmeRepository.Cadastrar(filme);
        }

        public void Deletar(int id)
        {
            var filme = _filmeRepository.BuscarPorId(id);
            filme.Deletado = true;

            _filmeRepository.Atualizar(filme);
        }
    }
}
