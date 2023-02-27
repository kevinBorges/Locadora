using Locadora.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Filmes> Filmes { get; set; }

        public DbSet<Categorias> Categoria { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Locacao> Locacao { get; set; }
    }
}