using Locadora.Domain.Entities;
using Locadora.Infra.Context;
using Locadora.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CategoriaRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Categorias> BuscarTodos()
        {
            return _applicationDbContext.Categoria.Where(x=>!x.Deletado).ToList();
        }

        public void Cadastrar(Categorias categoria)
        {
            categoria.InserirDadosPadrao();
            _applicationDbContext.Add(categoria);
            _applicationDbContext.SaveChanges();
        }

        public Categorias BuscarPorId(int id)
        {
            return _applicationDbContext.Categoria.Find(id);
        }

        public void Atualizar(Categorias categoria)
        {
            _applicationDbContext.Categoria.Update(categoria);
            _applicationDbContext.SaveChanges();
        }
    }
}
