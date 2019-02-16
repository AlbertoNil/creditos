using SOAPServices.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SOAPServices.Persistencia
{
    //public class CreditoDAO : BaseDAO<Credito, int, string>
    public class CreditoDAO
    {
        private ContadorDAO contadorDAO = new ContadorDAO();
        private string cadenaconexion = @"Data Source=234b518e-d93b-4e69-bc80-a9dd00675f56.sqlserver.sequelizer.com; Initial Catalog=db234b518ed93b4e69bc80a9dd00675f56; User Id=qypbnacapqayhgfc;Pwd=hYzC8vwEpnxeGpnqP7UK446kw7gmGVnmK2udwEwqHfWsKaBvzSqtBJjn3pgbpj6A";

        public Credito Crear(Credito creditoACrear)
        {
            Credito creditoCreado = null;
            string SqlInsCredito = "insert into creditos values (@codalumno, @codcurso, @coddescripcion, @tipo, @fechaing)";
            string SqlInsContador = "insert into contador values (@codalumno, @contador)";
            string SqlUpdContador = "update contador set contador=contador+@contador where codalumno=@codalumno";

            Contador contadorAlumno = contadorDAO.ObtenerAlumno(creditoACrear.CodAlumno);
            if (contadorAlumno == null) // si ya existe
            { 
                using (SqlConnection conexion = new SqlConnection(cadenaconexion))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(SqlInsCredito, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@codalumno", creditoACrear.CodAlumno));
                        comando.Parameters.Add(new SqlParameter("@codcurso", creditoACrear.CodCurso));
                        comando.Parameters.Add(new SqlParameter("@coddescripcion", creditoACrear.CodDescripcion));
                        comando.Parameters.Add(new SqlParameter("@tipo", creditoACrear.Tipo));
                        comando.Parameters.Add(new SqlParameter("@fechaing", DateTime.Now));
                        comando.ExecuteNonQuery();
                    }
                    using (SqlCommand InsContador = new SqlCommand(SqlInsContador, conexion))
                    {
                        InsContador.Parameters.Add(new SqlParameter("@codalumno", creditoACrear.CodAlumno));
                        InsContador.Parameters.Add(new SqlParameter("@contador", 1));
                        InsContador.ExecuteNonQuery();
                    }
                }
            } else
            {
                using (SqlConnection conexion = new SqlConnection(cadenaconexion))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(SqlInsCredito, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@codalumno", creditoACrear.CodAlumno));
                        comando.Parameters.Add(new SqlParameter("@codcurso", creditoACrear.CodCurso));
                        comando.Parameters.Add(new SqlParameter("@coddescripcion", creditoACrear.CodDescripcion));
                        comando.Parameters.Add(new SqlParameter("@tipo", creditoACrear.Tipo));
                        comando.Parameters.Add(new SqlParameter("@fechaing", DateTime.Now));
                        comando.ExecuteNonQuery();
                    }
                    using (SqlCommand UpdContador = new SqlCommand(SqlUpdContador, conexion))
                    {
                        UpdContador.Parameters.Add(new SqlParameter("@codalumno", creditoACrear.CodAlumno));
                        UpdContador.Parameters.Add(new SqlParameter("@contador", 1));
                        UpdContador.ExecuteNonQuery();
                    }
                }
            }

            creditoCreado = Obtener(creditoACrear.CodCredito);
            return creditoCreado;
        }

        public Credito Obtener(int codcredito)
        {
            Credito creditoEncontrado = null;
            string sql = "select * from creditos where codcredito=@codcredito";
            using (SqlConnection conexion = new SqlConnection(cadenaconexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codcredito", codcredito));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            creditoEncontrado = new Credito()
                            {
                                CodCredito = (int)resultado["codcredito"],
                                CodAlumno = (string)resultado["codalumno"],
                                CodCurso = (string)resultado["codcurso"],
                                CodDescripcion = (string)resultado["coddescripcion"],
                                Tipo = (string)resultado["tipo"],
                                FechaIng = (DateTime)resultado["fechaing"],
                            };
                        }
                    }
                }
            }
            return creditoEncontrado;
        }

        public Credito ObtenerPregunta(string coddescripcion)
        {
            Credito preguntaEncontrada = null;
            string sql = "select * from creditos where coddescripcion=@coddescripcion";
            using (SqlConnection conexion = new SqlConnection(cadenaconexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@coddescripcion", coddescripcion));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            preguntaEncontrada = new Credito()
                            {
                                CodCredito = (int)resultado["codcredito"],
                                CodAlumno = (string)resultado["codalumno"],
                                CodCurso = (string)resultado["codcurso"],
                                CodDescripcion = (string)resultado["coddescripcion"],
                                Tipo = (string)resultado["tipo"],
                            };
                        }
                    }
                }
            }
            return preguntaEncontrada;
        }
        public void Eliminar(int codcredito)
        {
            string sql = "delete from creditos where codcredito=@codcredito";
            string SqlUpdContador = "update contador set contador=contador-@contador where codalumno=@codalumno";

            Credito creditoUbicado = null;
            creditoUbicado = Obtener(codcredito);
            string codalumno = creditoUbicado.CodAlumno;

            using (SqlConnection conexion = new SqlConnection(cadenaconexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codcredito", codcredito));
                    comando.ExecuteNonQuery();
                }
                using (SqlCommand UpdContador = new SqlCommand(SqlUpdContador, conexion))
                {
                    UpdContador.Parameters.Add(new SqlParameter("@codalumno", codalumno));
                    UpdContador.Parameters.Add(new SqlParameter("@contador", 1));
                    UpdContador.ExecuteNonQuery();
                }
            }
        }

        public List<Credito> Listar()
        {
            List<Credito> creditosEncontrados = new List<Credito>();
            Credito creditosEncontrado = null;
            string sql = "select * from creditos";
            using (SqlConnection conexion = new SqlConnection(cadenaconexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            creditosEncontrado = new Credito()
                            {
                                CodCredito = (int)resultado["codcredito"],
                                CodAlumno = (string)resultado["codalumno"],
                                CodCurso = (string)resultado["codcurso"],
                                CodDescripcion = (string)resultado["coddescripcion"],
                                Tipo = (string)resultado["tipo"],
                                FechaIng = (DateTime)resultado["fechaing"]
                            };
                            creditosEncontrados.Add(creditosEncontrado);
                        }
                    }
                }
            }
            return creditosEncontrados;
        }
    }
}