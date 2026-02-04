using System.Collections.Generic;
using System.Linq;
using DEV0102.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DEV0102.Tests
{
    [TestClass]
    public class UsuarioDalTests
    {
        [TestMethod]
        public void FiltrarUsuariosComCodigoMaiorQueUm_RetornaSomenteCodigoMaiorQueUm()
        {
            var usuarios = new List<tabUsuario>
            {
                new tabUsuario { codigo = 0, nome = "Zero" },
                new tabUsuario { codigo = 1, nome = "Um" },
                new tabUsuario { codigo = 2, nome = "Dois" }
            };

            var resultado = usuarioDAL.FiltrarUsuariosComCodigoMaiorQueUm(usuarios).ToList();

            Assert.AreEqual(1, resultado.Count);
            Assert.AreEqual(2, resultado[0].codigo);
        }
    }
}
