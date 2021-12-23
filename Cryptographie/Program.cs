using System;
using System.Text;

namespace Cryptographie
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "c'est bon";

            //byte [] b = { ((byte)a) };

            byte b1 = 110;
            byte b2 = 124;

            int bb = b1 ^ b2;
          

            byte[] bn = new ASCIIEncoding().GetBytes(a);

            string str = new ASCIIEncoding().GetString(bn);

           // int c = b ^ vi;

            //char final = ((char)c);



            Console.Write(str);
        }
    }
}
