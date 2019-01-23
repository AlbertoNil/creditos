using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SOAPServices.Dominio;
using SOAPServices.Persistencia;

namespace SOAPServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "CreditoService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione CreditoService.svc o CreditoService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class CreditoService : ICreditoService
    {
        /*****************************************************************/

        private CreditoDAO creditoDAO = new CreditoDAO();

        public Credito CrearCredito(Credito creditoACrear)
        {
            if (creditoDAO.ObtenerPregunta(creditoACrear.CodDescripcion) != null) // si ya existe
            {
                throw new FaultException<PreguntaExistenteError>(
                    new PreguntaExistenteError()
                    {
                        CodigoError = "101",
                        MensajeError = "La Pregunta con codigo " + creditoACrear.CodDescripcion + " ya existe."
                    }
                //new FaultReason("Error al intentar creación")
                );
            }
            return creditoDAO.Crear(creditoACrear);
        }

        public void EliminarCredito(int codcredito)
        {
            creditoDAO.Eliminar(codcredito);
        }

        public List<Credito> ListarCreditos()
        {
            return creditoDAO.Listar();
        }

        public Credito ObtenerCredito(int codcredito)
        {
            //return asesorDAO.Listar();
            return creditoDAO.Obtener(codcredito);
        }

        public Credito ObtenerPregunta(string coddescripcion)
        {
            //return asesorDAO.Listar();
            return creditoDAO.ObtenerPregunta(coddescripcion);
        }



        /*
        //private ClienteDAO clienteDAO = new ClienteDAO();
        //private ProductoDAO productoDAO = new ProductoDAO();
        //private FacturaDAO creditoDAO = new FacturaDAO();
        //private FacturaDetalleDAO facturaDetalleDAO = new FacturaDetalleDAO();

        private CreditoDAO creditoDAO = new CreditoDAO();

        public Credito CrearCredito(Credito creditoACrear)
        {
            //ICollection<Credito> creditopregunta = creditoDAO.ObtenerPregunta(creditoACrear.CodDescripcion);
            //if (creditopregunta != null) // // si ya existe
            if (creditoDAO.ObtenerPregunta(creditoACrear.CodDescripcion) != null) // si ya existe
            { 
                throw new FaultException<PreguntaExistenteError>(
                    new PreguntaExistenteError()
                    {
                        CodigoError = 10,
                        MensajeError = "La Pregunta con codigo " + creditoACrear.CodDescripcion + " ya existe."
                    },
                new FaultReason("Error al intentar creación"));
            }
            Credito credito = new Credito()
            {
                CodAlumno = creditoACrear.CodAlumno,
                CodCurso = creditoACrear.CodCurso,
                CodDescripcion = creditoACrear.CodDescripcion,
                Tipo = creditoACrear.Tipo,
                FechaIng = DateTime.Now
            };
            credito = creditoDAO.Crear(credito);
            return creditoDAO.Crear(creditoACrear);
        }
        
        public ICollection<Credito> ListarCreditos()
        {
            return creditoDAO.ListarTodos();
        }
        */

        /*public void EliminarCredito(int codcredito)
        {
            creditoDAO.Eliminar(codcredito);
        }*/

        /*****************************************************************/
    }
}
