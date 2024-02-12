using System;

class Program
{
    static void Main(string[] args)
    {
        string mensajeOriginal = "bkbw";
        int clave = 2;

        string mensajeDescifrado = desencriptarCesar(mensajeOriginal, clave);
        Console.WriteLine("Mensaje descifrado: " + mensajeDescifrado); 

        Console.ReadKey();
    }

    private static string encriptarCesar(string mensaje, int clave)

    {
        string resultado = "";
        int indice;
        int nuevoIndice;
        int intAscii;



        foreach (char c in mensaje)
        {
            if (char.IsLetter(c))
            {
                if (char.IsUpper(c))
                {
                    indice = c - (int)'A' + clave;  // Índice de la letra en el alfabeto
                    nuevoIndice = ((indice + clave) + 26) % 26;  // Nuevo índice después del desplazamiento, asegurándose de que esté dentro del rango [0, 25]
                    intAscii = nuevoIndice + (int)'A';  // Convertir el nuevo índice a código ASCII
                }
                else if (char.IsLower(c))
                {
                    indice = c - (int)'a';  // Índice de la letra en el alfabeto
                    nuevoIndice = ((indice + clave) + 26) % 26;  // Nuevo índice después del desplazamiento, asegurándose de que esté dentro del rango [0, 25]
                    intAscii = nuevoIndice + (int)'a';  // Convertir el nuevo índice a código ASCII
                }
                else
                {
                    intAscii = c;  // Mantener caracteres que no son letras sin cambios
                }
          
                resultado += (char)intAscii;
            }
            else
            {
                resultado += c;
            }
            Console.WriteLine("Resultado: " + (int)'A');
        }

        return resultado;
    }

    private static string desencriptarCesar(string mensajeCifrado, int clave)
    {
        return encriptarCesar(mensajeCifrado, -clave);
    }
}
