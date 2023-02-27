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
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ClienteRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Clientes> BuscarTodos()
        {
            return _applicationDbContext.Clientes.Where(x => !x.Deletado).ToList();
        }

        public void Cadastrar(Clientes cliente)
        {
            cliente.InserirDadosPadrao();
            _applicationDbContext.Add(cliente);
            _applicationDbContext.SaveChanges();
        }

        public Clientes BuscarPorId(int id)
        {
            return _applicationDbContext.Clientes.Find(id);
        }

        public void Atualizar(Clientes clientes)
        {
            _applicationDbContext.Clientes.Update(clientes);
            _applicationDbContext.SaveChanges();
        }


    }
}
