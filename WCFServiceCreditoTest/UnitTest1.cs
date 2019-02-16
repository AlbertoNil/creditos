using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;

namespace WCFServiceCreditoTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1CrearCreditoOK2()
        {
            CreditosTestWS.CreditoServiceClient proxy = new CreditosTestWS.CreditoServiceClient();
            CreditosTestWS.Credito creditoCreado = proxy.CrearCredito(
            new CreditosTestWS.Credito()
            {
                CodCredito = 97,
                CodAlumno = "A091",
                CodCurso = "C09",
                CodDescripcion = "P541",
                Tipo = "R",
                FechaIng = DateTime.Now
            });
            DateTime F1 = DateTime.Now;
            DateTime F2 = creditoCreado.FechaIng;

            Assert.AreEqual(51, creditoCreado.CodCredito);
            Assert.AreEqual("A09", creditoCreado.CodAlumno);
            Assert.AreEqual("C09", creditoCreado.CodCurso);
            Assert.AreEqual("P51", creditoCreado.CodDescripcion);
            Assert.AreEqual("R", creditoCreado.Tipo);
            Assert.AreEqual(F1.ToString("dd/MM/yyyy"), F2.ToString("dd/MM/yyyy"));
        }


        
       


    }
}
