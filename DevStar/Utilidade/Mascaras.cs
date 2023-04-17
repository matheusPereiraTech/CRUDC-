using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStar.Utilidade
{
    internal class Mascaras
    {
        public static string mascaraTelefone(string telefone)
        {
            string strMascara = "{0:(00)0000-0000}";

            long lngNumero = Convert.ToInt64(telefone);

            if (telefone.Length == 11)
                strMascara = "{0:(00)00000-0000}";

            return string.Format(strMascara, lngNumero);
        }
    }
}
