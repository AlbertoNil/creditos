using SOAPServices.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SOAPServices.Persistencia
{
    public class ContadorDAO
    {
        private string cadenaconexion = @"Data Source=234b518e-d93b-4e69-bc80-a9dd00675f56.sqlserver.sequelizer.com; Initial Catalog=db234b518ed93b4e69bc80a9dd00675f56; User Id=qypbnacapqayhgfc;Pwd=hYzC8vwEpnxeGpnqP7UK446kw7gmGVnmK2udwEwqHfWsKaBvzSqtBJjn3pgbpj6A";
        public Contador ObtenerAlumno(string codalumno)
        {
            Contador alumnoEncontrado = null;
            string sql = "select * from contador where codalumno=@codalumno";
            using (SqlConnection conexion = new SqlConnection(cadenaconexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codalumno", codalumno));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            alumnoEncontrado = new Contador()
                            {
                                IdContador = (int)resultado["idcontador"],
                                CodAlumno = (string)resultado["codalumno"],
                                Contar = (int)resultado["contador"]
                            };
                        }
                    }
                }
            }
            return alumnoEncontrado;
        }
    }
}



