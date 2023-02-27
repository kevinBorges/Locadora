using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Domain.Entities
{
    public class Locacao : EntityBase
    {
        public int ClienteId { get; set; }
        public int FilmeId { get; set; }
        public DateTime Devolucao { get; set; }
        public Clientes Cliente { get; set; }
        public Filmes Filme { get; set; }
    }
}
