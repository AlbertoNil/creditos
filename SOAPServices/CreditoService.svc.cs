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
            //if (creditoDAO.ObtenerPregunta(creditoACrear.CodDescripcion) != null) // si ya existe
            Credito varpreg = creditoDAO.ObtenerPregunta(creditoACrear.CodDescripcion);
            if (varpreg != null) // si ya existe
                {
                throw new FaultException<PreguntaExistenteError>(
                    new PreguntaExistenteError()
                    {
                        CodigoError = "101",
                        MensajeError = "La Pregunta con codigo " + varpreg.CodDescripcion + " ya existe."
                    },
                new FaultReason("Error al intentar creación")
                );
            }
            string xTipo = creditoACrear.Tipo;
            if (xTipo.Trim() != "P") // si ya existe
            {
                if (xTipo.Trim() != "R")
                {
                    throw new FaultException<TipoPreguntaError>(
                        new TipoPreguntaError()
                        {
                            CodigoError = "102",
                            MensajeError = "El tipo de pregunta ingresado " + creditoACrear.Tipo + ", no Es valido. Favor de Ingresar P si es pregunta y R si es respuesta."
                        },
                    new FaultReason("Error al insertar tipo pregunta")
                    );
                }
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

        

        /*****************************************************************/
    }
}
