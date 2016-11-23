using Datos;
using Entidades;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public  class Gestor
    {
        public List<Categoria> LIstarCategorias(Boolean? Estado)
        {
             return  new DalCategoria().LIstarCategorias(Estado);
        }

        public Categoria ObtenerCategorias(Int32 IdCategoria)
        {
            return  new DalCategoria().ObtenerCategorias(IdCategoria);
        }

        public Boolean InsertarCategoria(Categoria obj)
        {
            return new DalCategoria().InsertarCategoria(obj);
        }
    }
}
