using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Application.ViewModels
{
    public class EntityBaseViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        public bool Deletado { get; set; }
        public DateTime CriadoEm { get; set; }

    }
}
