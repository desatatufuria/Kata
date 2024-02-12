using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifradoCesar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mensaje Recibido:");
            string mensaje = Console.ReadLine();


            Console.WriteLine("Clave Usada:");
            int clave = Convert.ToInt32(Console.ReadLine());


            string msgCifrado = encriptarCesar(mensaje, clave);
            Console.WriteLine("Mensaje cifrado: " + msgCifrado);
            Console.ReadKey();

            string mensajeDescifrado = desencriptarCesar(msgCifrado, clave);
            Console.WriteLine("Mensaje descifrado: " + mensajeDescifrado);
            Console.ReadKey();
        }


        private static string encriptarCesar(string mensaje, int clave)
        {
            string msg = "";

            foreach (char c in mensaje)
            {
                if (char.IsLetter(c))
                {
                    char charCodificado = (char)(c + clave);
                    msg += (!char.IsLetter(charCodificado)) ? (char)(c - (26 - clave)) : charCodificado;
                }
                else
                    msg += c;
            }

            return msg;
        }

        private static string desencriptarCesar(string msgCifrado, int clave)
        {
            return encriptarCesar(msgCifrado, clave * (-1));
        }


       
    }


}
