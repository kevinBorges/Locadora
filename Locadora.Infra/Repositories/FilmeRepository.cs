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
    public class FilmeRepository : IFilmeRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public FilmeRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Filmes> BuscarTodos()
        {
            return _applicationDbContext.Filmes.Include(x=>x.Categoria).Where(x => !x.Deletado).ToList();
        }

        public void Cadastrar(Filmes filmes)
        {
            filmes.InserirDadosPadrao();
            _applicationDbContext.Add(filmes);
            _applicationDbContext.SaveChanges();
        }

        public Filmes BuscarPorId(int id)
        {
            return _applicationDbContext.Filmes.Include(x => x.Categoria).Where(c => c.Id == id).FirstOrDefault();
        }

        public void Atualizar(Filmes filmes)
        {
            _applicationDbContext.Filmes.Update(filmes);
            _applicationDbContext.SaveChanges();
        }
    }
}
