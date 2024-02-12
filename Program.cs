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
            //Console.WriteLine("Mensaje Recibido:");
            //string mensaje = Console.ReadLine();


            //Console.WriteLine("Clave Usada:");
            //int clave = Convert.ToInt32(Console.ReadLine());

            string mensaje = "Zizu patatas PaTatas";
            int clave = 3;

            string msgCifrado = encriptarCesar(mensaje, clave);
            Console.WriteLine("Mensaje cifrado: " + msgCifrado);
            

            string mensajeDescifrado = desencriptarCesar(msgCifrado, clave);
            Console.WriteLine("Mensaje descifrado: " + mensajeDescifrado);
            Console.ReadKey();
        }


        private static string encriptarCesar(string mensaje, int clave)

        {
            

            string resultado = "";

            foreach (char c in mensaje) // Recorremos todos los ces del mensaje
            {
                if (char.IsLetter(c)) // Si es una letra
                {
                    char codificacion = Convert.ToChar(c + clave); 

                    if ((char.IsLower(c) && codificacion > 'z') || (char.IsUpper(c) && codificacion > 'Z'))
                    {
                        resultado += Convert.ToChar(c - (26 - clave));
                    }
                    else
                    {
                        resultado += codificacion;
                    }
                }
                else // No es una letra. (no hacer nada)
                    resultado += c;

            }

            return resultado;
        }

        private static string desencriptarCesar(string mensajeCifrado, int clave)
        {

            string resultado = "";

            foreach (char c in mensajeCifrado) // Recorremos todos los ces del mensaje
            {
                if (char.IsLetter(c)) // Si es una letra
                {
                    char codificacion = Convert.ToChar(c - clave);

                    if ((char.IsLower(c) && codificacion < 'a') || (char.IsUpper(c) && codificacion < 'a'))
                    {
                        resultado += Convert.ToChar(c + (26 - clave));
                    }
                    else
                    {
                        resultado += codificacion;
                    }
                }
                else // No es una letra. (no hacer nada)
                    resultado += c;

            }
            return resultado;

        }


        private static bool letraOCaracter(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }
    }


}
