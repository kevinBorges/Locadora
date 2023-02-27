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
    public class LocacaoApplication : ILocacaoApplication
    {
        ILocacaoRepository _locacaoRepository;
        public LocacaoApplication(ILocacaoRepository locacaoRepository)
        {
            _locacaoRepository = locacaoRepository;
        }

        public void Atualizar(LocacaoViewModel locacaoViewModel)
        {
            var locacao = _locacaoRepository.BuscarPorId(locacaoViewModel.Id);
            locacao.Devolucao = locacaoViewModel.Devolucao;
            locacao.ClienteId = locacaoViewModel.ClienteId;
            locacao.FilmeId = locacaoViewModel.FilmeId;

            _locacaoRepository.Atualizar(locacao);
        }

        public LocacaoViewModel BuscarPorId(int id)
        {
            var locacao = _locacaoRepository.BuscarPorId(id);
            var locacaoViewModel = new LocacaoViewModel
            {
                Id = locacao.Id,
                Devolucao = locacao.Devolucao,
                ClienteId = locacao.ClienteId,  
                Cliente = locacao.Cliente,
                FilmeId = locacao.FilmeId,
                Filme = locacao.Filme
            };
            return locacaoViewModel;
        }

        public IEnumerable<LocacaoViewModel> BuscarTodos()
        {
            var locacoes = _locacaoRepository.BuscarTodos();
            var locacoesViewModel = locacoes.Select(locacao => new LocacaoViewModel
            {
                Id = locacao.Id,
                Devolucao = locacao.Devolucao,
                Cliente = locacao.Cliente,
                ClienteId = locacao.ClienteId,
                Filme = locacao.Filme,
                FilmeId = locacao.FilmeId
            });

            return locacoesViewModel;
        }

        public void Cadastrar(LocacaoViewModel locacaoViewModel)
        {
            var locacao = new Locacao
            {
                ClienteId = locacaoViewModel.ClienteId,
                FilmeId = locacaoViewModel.FilmeId,
                Devolucao = locacaoViewModel.Devolucao
            };
            _locacaoRepository.Cadastrar(locacao);
        }

        public void Deletar(int id)
        {
            var locacao = _locacaoRepository.BuscarPorId(id);
            locacao.Deletado = true;

            _locacaoRepository.Atualizar(locacao);
        }
    }
}
