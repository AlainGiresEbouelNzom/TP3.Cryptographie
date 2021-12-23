using System;
using System.Text;

namespace Cryptographie
{
    class Program
    {
        static void Main(string[] args)
        {

            CipherBlockChaining CBC = new CipherBlockChaining();


            string SE = CBC.Chiffrer("bonjour la maisonnée", "1 2");
            string t = "♠im☻w♣%Ie♦m▲q▼rM(";
            Console.WriteLine(SE); 
           // Console.WriteLine(t); 
          

             // new CipherBlockChaining().Chiffrer("bonjour c'est bon. Les mathematiques sont tres sucrees", "3 1 2 4");

            Console.WriteLine(CBC.Dechiffrer(t,"1 2"));

             //te []B = new ASCIIEncoding().GetBytes(t);


           

            Console.WriteLine();

        }
    }
}
