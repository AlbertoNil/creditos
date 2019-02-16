using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WCFServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CreditosWS.CreditoServiceClient proxy = new CreditosWS.CreditoServiceClient();
            CreditosWS.Credito creditoCreado = proxy.CrearCredito(new CreditosWS.Credito()
            {
                CodCredito = 8,
                CodAlumno = "A09",
                CodCurso = "C09",
                CodDescripcion = "P30",
                Tipo = "R",
                FechaIng = DateTime.Now
        });
            Assert.AreEqual(8, creditoCreado.CodCredito);
            Assert.AreEqual("A09", creditoCreado.CodAlumno);
            Assert.AreEqual("C09", creditoCreado.CodCurso);
            Assert.AreEqual("P30", creditoCreado.CodDescripcion);
            Assert.AreEqual("R", creditoCreado.Tipo);
            Assert.AreEqual(DateTime.Now, creditoCreado.FechaIng);
        }
    }
}
