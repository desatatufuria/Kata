using System;
using System.Linq;

namespace ChipherCesar
{

    public class CesarCipher
    {
        public void encrypt(string msg, int key)
        {
            // variable para almacenar el mensaje cifrado
            string result = "";

            // reemplazar caracteres especiales
            msg = replaceChars(msg);

            // caracteres que no se cifran
            char[] excludedChars = { 'ñ', 'Ñ' };

            // recorremos cada letra del mensaje
            foreach (char c in msg)
            {
                // si no es una letra o es una de las letras '<ñ> o <Ñ>' se devuelve tal cual
                if (!char.IsLetter(c) || excludedChars.Contains(c))
                {
                    result += c;
                    continue;
                }
                // obtener si es mayuscula o minuscula para obtener el indice del codigo ASCII desde donde desplazaremos cada letra 
                char CharInit = char.IsUpper(c) ? 'A' : 'a';

                // indice de la letra [c] restando el codigo ASCII desde [A] o [a] 
                int Index = (int)c - (int)CharInit;
                /* 
                 * Formula aplicada por el metodo Cesar.(extraida de Wikipedia)  
                 * el modulo 26 es para que si [index] se pasa de la 'z' o 'Z' vuelva a empezar desde la 'a' o 'A' segun sea el caso
                 */
                int newIndex = (Index + key + 26) % 26;

                // obtenemos el nuevo codigo ASCII ya convertido de la letra desplazada [c]
                char AsciiChar = (char)(newIndex + CharInit);
                result += AsciiChar;
            }
            Console.WriteLine(result);
        }

        // El metodo [decrypt] es simplemente el metodo [encrypt] pero con la clave negativa
        public void decrypt(string msg, int key)
        {
            encrypt(msg, -key);
        }

        private string replaceChars(string msg)
        {
            return msg
                  .Replace('á', 'a').Replace('Á', 'A')
                  .Replace('é', 'e').Replace('É', 'E')
                  .Replace('í', 'i').Replace('Í', 'I')
                  .Replace('ó', 'o').Replace('Ó', 'O')
                  .Replace('ú', 'u').Replace('Ú', 'U');
        }

    }




}
