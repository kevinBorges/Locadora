using Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Application.ViewModels
{
    public class LocacaoViewModel : EntityBaseViewModel
    {
        [DisplayName("Cliente")]
        public int ClienteId { get; set; }

        [DisplayName("Filme")]
        public int FilmeId { get; set; }

        [DisplayName("Devolução")]
        public DateTime Devolucao { get; set; }

        public Clientes Cliente { get; set; }
        public Filmes Filme { get; set; }
    }
}
