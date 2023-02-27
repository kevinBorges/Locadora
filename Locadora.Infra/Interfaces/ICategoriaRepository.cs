﻿using Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.Interfaces
{
    public interface ICategoriaRepository
    {
        void Atualizar(Categorias categoria);
        Categorias BuscarPorId(int id);
        IEnumerable<Categorias> BuscarTodos();
        void Cadastrar(Categorias categoria);
    }
}
