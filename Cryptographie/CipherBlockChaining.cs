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
            string[] splitedKey = cle.Split(' ');

            int[] dimensions = GetDimensions(message, splitedKey);         

            int line = dimensions[0];
            int col = dimensions[1];            

            byte[] byteArray1 = new ASCIIEncoding().GetBytes(message);
            byte[,] byteArray2 = new byte[line, col];

            int counter = 0;

            /*Copie du contenu du tableau à 1 dimension dans un tableau à 2 dimensions*/
            for (int i = 0; i < line; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    byteArray2[i, j] = byteArray1[counter++];

                    if (counter == byteArray1.Length)
                        break;
                }
            }
           
            byteArray2 = Transposition(splitedKey, byteArray2, true);
           
            byteArray1 =  XOR_Chiffrer(byteArray2);     
            

            return new ASCIIEncoding().GetString(byteArray1);
        }

        public string Dechiffrer(string message, string cle)
        {
            string[] splitedKey = cle.Split(' ');

            int[] dimensions = GetDimensions(message, splitedKey);

            int line = dimensions[0];
            int col = dimensions[1];

            byte[,] byteArray2 = new byte[line, col];

            byte[] byteArray1 = new ASCIIEncoding().GetBytes(message);

           


            byteArray1 =  XOR_Dechiffrer(byteArray1);

            /*Copie du contenu du tableau à 1 dimension dans un tableau à 2 dimensions*/
            int counter = 0;
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    byteArray2[i, j] = byteArray1[counter++];

                    if (counter == byteArray1.Length)
                        break;
                }
            }
            
            byteArray2 = Transposition(splitedKey, byteArray2, false);

            string s = "";
            foreach (var b in byteArray2)
                s += ((char)b);

            return s;

        }

        private int[] GetDimensions(string message, string[] splitedKey)
        {
            int[] dimensions = new int[2];

            double line = (double)message.Length / splitedKey.Length;

            if (line - (int)line > 0)
            {
                dimensions[0] = (int)line + 1;
                dimensions[1] = splitedKey.Length;
            }
            else
            {
                dimensions[0] = (int)line;
                dimensions[1] = splitedKey.Length;
            }

            return dimensions;
                
        }

        private byte[,] Transposition(string []keys, byte [,] byteArray, bool vector)
        {
            byte[,] transposedArray = new byte[byteArray.GetLength(0), byteArray.GetLength(1)];

            int col;
            for (int k = 0; k < keys.Length; k++)
            {
                col = int.Parse(keys[k]) - 1;
                

                if (vector)
                {
                    for (int i = 0; i < byteArray.GetLength(0); i++)
                    {
                        transposedArray[i, col] = byteArray[i, k];
                    }
                }
                else
                {
                    for (int i = 0; i < byteArray.GetLength(0); i++)
                    {
                        transposedArray[i, k] = byteArray[i, col];
                    }
                }
            }
           
            return transposedArray;
        }

        private byte[] XOR_Chiffrer(byte[,] byteArray)
        {
            byte VI = 100; // On fixe un vecteur initial           
            byte[] XOR_Array = new byte[byteArray.Length];
            int counter = 0;
            
            for (int i = 0; i < byteArray.GetLength(0); i++)
            {
                for(int j = 0; j < byteArray.GetLength(1); j++)
                {
                    if (i == 0 && j == 0)
                    {
                        XOR_Array[counter++] = ((byte)(byteArray[0, 0] ^ VI));                        
                    }
                    else
                    {
                        XOR_Array[counter++] = ((byte)(byteArray[i, j] ^ XOR_Array[counter - 2]));                       
                    }
                }
            }

            return XOR_Array;
        }

        private byte[] XOR_Dechiffrer(byte[] byteArray)
        {
            byte VI = 100; // On fixe un vecteur initial           
            byte[] XOR_Array = new byte[byteArray.Length];
            int counter = 0;

            byte previous = byteArray[0]; 

            for (int i = 0; i < byteArray.GetLength(0); i++)
            {                
                if (i == 0)
                {
                    XOR_Array[counter++] = (byte)(previous ^ VI);   
                }
                else
                {                    
                    XOR_Array[counter++] = ((byte)(byteArray[i] ^ previous));
                    previous = byteArray[i];
                }                
            }           

            return XOR_Array;
        }

        public void ConsoleReset()
        {
            Console.WriteLine("\nAppuyez sur n'importe quelle touche pour continuer\n");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

