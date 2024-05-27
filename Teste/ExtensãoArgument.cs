using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    internal static class ExtensãoArgument
    {
        public static void ComMensagem( this ArgumentException excecao, string msg)
        {
            if (excecao.Message == msg)
            {
                Assert.True(true);
            } else
            {
                Assert.False(true);
            }
        }
    }
}
