using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Domain.Entities
{
    public class Clientes : EntityBase
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
    }
}
