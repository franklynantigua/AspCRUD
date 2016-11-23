namespace Datos
{
    public  class DalConexion
    {
        public static string ObtenerConexion()
        {
            string conexion = "Data Source=ALBERT\\ALBERT;Initial Catalog=AspCRUD;Integrated Security=True";

            return conexion;
        }
    }
}
