using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptographie
{
    public class CipherBlockChaining
    {   
        public string Chiffrer(string message, string cle)
        {
            int[] dimensions = GetDimensions(cle);

            int line = dimensions[0];
            int col = dimensions[1];

            byte[] byteArray = new byte[line * col];

            /*Not implemented*/

            return new ASCIIEncoding().GetString(byteArray);
        }

        public string Dechiffrer(string message, string cle)
        {
            throw new NotImplementedException();
        }

        private int [] GetDimensions( string cle)
        {
            int[] dimensions = new int[2];

            /*Not implemented*/

            return dimensions;
        }


    }
}

