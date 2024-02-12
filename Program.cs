using System;

class Program
{
    static void Main(string[] args)
    {
        string msg = "bkbw";
        int key = 2;

        string decryptMsg = decrypt(msg, key);
        Console.WriteLine("Mensaje descifrado: " + decryptMsg);

        Console.ReadKey();
    }

    private static string encrypt(string msg, int key)

    {
        string result = "";
        int Index;
        int newIndex;
        int intAscii;

        foreach (char c in msg)
        {
            
            if (char.IsLetter(c))


            {
                // si  el caracter es una ñ
                if (c == 'ñ')
                {
                    intAscii = c;
                    continue;
                }
                
                
                if (char.IsUpper(c))
                {
                    Index = (c - (int)'A') + key;  // Índice de la letra en el alfabeto
                    newIndex = ((Index + key) + 26) % 26;  // Nuevo índice después del desplazamiento, asegurándose de que esté dentro del rango [0, 25]
                    intAscii = newIndex + (int)'A';  // Convertir el nuevo índice a código ASCII
                }
                else if (char.IsLower(c))
                {
                    Index = (c - (int)'a');  // Índice de la letra en el alfabeto
                    newIndex = ((Index + key) + 26) % 26;  // Nuevo índice después del desplazamiento, asegurándose de que esté dentro del rango [0, 25]
                    intAscii = newIndex + (int)'a';  // Convertir el nuevo índice a código ASCII
                }
                else
                {
                    intAscii = c;  // Mantener caracteres que no son letras sin cambios
                }
          
                result += (char)intAscii;
            }
            else
            {
                result += c;
            }
            Console.WriteLine("result: " + (int)'A');
        }

        return result;
    }

    private static string decrypt(string msg, int key)
    {
        return encrypt(msg, -key);
    }
}
