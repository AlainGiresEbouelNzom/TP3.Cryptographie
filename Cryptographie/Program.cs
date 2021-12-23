using System;
using System.Text;

namespace Cryptographie
{
    class Program
    {
        static void Main(string[] args)
        {

            CipherBlockChaining CBC = new CipherBlockChaining();
            string message = "", cle ="" , messageCripte ="";

            int choice = 0;

            do
            {
                Console.WriteLine("==============   MENU  ==================\n");
                Console.WriteLine("Choisissez une option :\n\t1- Crypter une message\n" +
                    "\t2- Décrypter le message précédent\n\t3- Saisir manuellement un message à décrypter\n" +
                    "\t4- Quitter");

                if (!(int.TryParse(Console.ReadLine(), out choice)))
                {
                    Console.WriteLine("Entrée invalide");
                    CBC.ConsoleReset();
                    choice = 0;
                }

                switch(choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Entrer le message à crypter :");                       
                        message = Console.ReadLine();
                        Console.Clear();

                        Console.WriteLine("Entrer la clé : ");                       
                        cle = Console.ReadLine();
                        Console.Clear();

                        messageCripte = CBC.Chiffrer(message, cle);

                        Console.WriteLine($"\nMessage : {message}\nMessage crypté :{messageCripte}");
                        CBC.ConsoleReset();
                        break;
                    case 2:
                        if (message != "" && cle != "")
                        {
                            Console.WriteLine($"\nMessage crypté : {messageCripte}\nMessage décrypté :{CBC.Dechiffrer(messageCripte, cle)}");
                            CBC.ConsoleReset();
                        }
                        else
                        {
                            Console.WriteLine("Aucun message crypté");
                            CBC.ConsoleReset();
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Entrer le message à décrypter :");
                        string messageDecr = Console.ReadLine();
                        Console.Clear();

                        Console.WriteLine("Entrer la clé : ");
                        cle = Console.ReadLine();
                        Console.Clear();

                        Console.WriteLine($"\nMessage : {messageDecr}\nMessage décrypté :{CBC.Dechiffrer(messageDecr, cle)}");                     
                        CBC.ConsoleReset();
                        break;
                    case 4:
                        choice = 4;
                        break;
                    default:
                        if (choice != 0)
                        {
                            Console.WriteLine("\nEntrée invalide\n");
                            CBC.ConsoleReset();
                        }
                        break;
                }                
            }
            while (choice != 4);


        }
    }
}
