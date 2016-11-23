using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public  class DalCategoria
    {
        public List<Categoria> LIstarCategorias(Boolean? Estado)
        {
            List<Categoria> lista = new List<Categoria>();

            SqlConnection cnn = new SqlConnection(DalConexion.ObtenerConexion());
            cnn.Open();

            SqlCommand objComm = new SqlCommand("sp_ObtenerListadoCategoriaPorEstado",cnn);
            objComm.CommandType= CommandType.StoredProcedure;

            SqlParameter pEstado = new SqlParameter("@Estado", Estado);
            objComm.Parameters.Add(pEstado);

            SqlDataReader dr = objComm.ExecuteReader();


            while (dr.Read())
            {
                Categoria obj = new Categoria();
                obj.IdCategoria = Convert.ToInt32(dr["IdCategoria"]);
                obj.Codigo = (dr["Codigo"]).ToString();
                obj.Descripcion=(dr["Descripcion"]).ToString();
                obj.Estado = Convert.ToBoolean(dr["Estado"]);


                lista.Add(obj);
            }
            cnn.Close();
            return lista;
        }
       
        public Categoria ObtenerCategorias(Int32 IdCategoria)
        {
            Categoria obj = null;

            SqlConnection cnn = new SqlConnection(DalConexion.ObtenerConexion());
            cnn.Open();
          
            SqlCommand objComm = new SqlCommand("sp_ObtenerCategoriaPorId", cnn);
            objComm.CommandType = CommandType.StoredProcedure;

            SqlParameter pEstado = new SqlParameter("@IdCategoria", IdCategoria);
            objComm.Parameters.Add(pEstado);

            SqlDataReader dr = objComm.ExecuteReader();


           if  (dr.Read())
            {
                obj = new Categoria();
                obj.IdCategoria = Convert.ToInt32(dr["IdCategoria"]);
                obj.Codigo = (dr["Codigo"]).ToString();
                obj.Descripcion = (dr["Descripcion"]).ToString();
                obj.Estado = Convert.ToBoolean(dr["Estado"]);
                
            }
            cnn.Close();
            return obj;
        }

        public Boolean InsertarCategoria(Categoria obj)
        {
            Boolean exito = false;
            SqlConnection cnn= new SqlConnection(DalConexion.ObtenerConexion());
            cnn.Open();


            SqlCommand objComm = new SqlCommand("sp_insertarCategoria", cnn);
            objComm.CommandType = CommandType.StoredProcedure;

            SqlParameter pCodigo= new SqlParameter("@Codigo", obj.Codigo);
            SqlParameter pDescripcion = new SqlParameter("@Descripcion", obj.Descripcion);

            objComm.Parameters.Add(pCodigo);
            objComm.Parameters.Add(pDescripcion);

            exito=  Convert.ToBoolean(  objComm.ExecuteNonQuery());


            return exito;


        }
    }

}
