using Locadora.Domain.Entities;
using Locadora.Infra.Context;
using Locadora.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.Repositories
{
    public class LocacaoRepository : ILocacaoRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public LocacaoRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Locacao> BuscarTodos()
        {
            return _applicationDbContext.Locacao
                .Include(x=>x.Cliente)
                .Include(x => x.Filme)
                .Where(x => !x.Deletado).ToList();
        }

        public void Cadastrar(Locacao locacao)
        {
            locacao.InserirDadosPadrao();
            _applicationDbContext.Add(locacao);
            _applicationDbContext.SaveChanges();
        }

        public Locacao BuscarPorId(int id)
        {
            return _applicationDbContext.Locacao.Include(x => x.Cliente)
                .Include(x => x.Filme).Where(x=>x.Id == id).FirstOrDefault();
        }

        public void Atualizar(Locacao locacao)
        {
            _applicationDbContext.Locacao.Update(locacao);
            _applicationDbContext.SaveChanges();
        }


    }
}
