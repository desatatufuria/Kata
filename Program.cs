using ChipherCesar; // Importamos la clase CesarCipher
using System;


/* Challenge 1 (23/24) - Cifrado Cesar
 * 
 * Crea un programa que realize el cifrado Cesar de un texto y lo imprima.
 * Tambien debe ser capaz de descifrarlo cuando asi se lo indiquemos.
 *
 * Te recomiendo que busques informacion para conocer en profundidad como
 * realizar el cifrado. Esto tambien forma parte del reto.
 * 
 * 
 * La metodologia que he seguido ha sido crear una clase [CesarCipher] que contiene dos metodos: [encrypt] y [decrypt]
 * 
 * Para controlar las excepciones he creado un array de caracteres [excludedChars] que contiene las letras que no se cifraran.
 * incluyendo las letras con tilde y la letra n tanto en mayusculas como en minusculas.
 * 
 * Se puede probar el codigo introduciendo una mensaje y una clave de desplazamiento para cifrarlo y descifrarlo.
 * o bien se puede probar el test unitario basico que he creado para comprobar que el cifrado y descifrado funciona correctamente.
 * 
 * EJEMPLOS DE USO:
 *       
 * Como Clase en un proyecto:
 * 
 *       Cipher.encrypt("zizu", 2); // se espera [bkxb]
 *       Cipher.decrypt("bkxb", 2); // se espera [zizu]
 *       
 * Como comando en linea de Consola (CLI):
 * 
 *       CipherCesar.exe [sin argumentos] // se muestra el menu
 *       
 *       CipherCesar.exe encrypt zizu, 2  // se espera [bkxb]
 *       
 *       CipherCesar.exe decrypt bkxb, 2  // se espera [zizu]
 *
 * 
 */

class Program

{
    static void Main(string[] args)
    {
        CesarCipher Cipher = new CesarCipher();

        if (args.Length == 0) showMenu();

        if (!(int.TryParse(args[2], out int key) && key >= 0))
            Console.WriteLine($"La clave: {args[2]}, debe ser un número entero positivo");

            switch (args[0])
        {

            case "encrypt":
                    Cipher.encrypt(args[1], key); // ciframos el mensaje
                break;

            case "decrypt":
                    Cipher.decrypt(args[1], key); // desciframos el mensaje
                break;
            case "?":
            case "help":
                help();
                break;
            default:
                // Si args[0] no coincide con ninguno de los casos anteriores, se muestra la ayuda
                help();
                break;
        }
    }
    public static void help()
    {
        string instructions = string.Format("\n\nInstrucciones: " +
            "\n--------------\n" +
            "Para encriptar: {0} encrypt [texto] [clave]" +
            "\nPara desencriptar: {0} decrypt [textoEncriptado] [clave]" +
            "\nSi quieres ver el menu: {0}" +
            "\nSi quieres ver esta ayuda: {0} [?] | [help]" +
            "\n-- Enter para salir.", "CipherCesar.exe");
        Console.WriteLine(instructions);
        Console.ReadKey();

    }

    public static void showMenu()
    {

        CesarCipher Cipher = new CesarCipher();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n\n Seleccione una opción:");
            Console.WriteLine("\r\r 1. Cifrar mensaje");
            Console.WriteLine("\r\r 2. Descifrar mensaje");
            Console.WriteLine("\r\r 3. Test Unitario Básico");
            Console.WriteLine("\r\r x. Salir");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Clear();
                    // Introducir mensaje [sin cifrar]
                    Console.Write("Ingrese el mensaje a cifrar:");
                    string msg = Console.ReadLine();

                    // Introducir clave de desplazamiento
                    Console.Write("Ingrese la clave:");
                    int keyEncrypt = int.Parse(Console.ReadLine());

                    // cifrar mensaje
                    Console.Write("Mensaje cifrado: ");
                    Cipher.encrypt(msg, keyEncrypt);
                    Console.ReadKey();
                    break;
                case "2":
                    Console.Clear();
                    // Introducir mensaje [cifrado]
                    Console.WriteLine("Ingrese el mensaje a descifrar:");
                    string msgDecrypt = Console.ReadLine();

                    // Introducir clave de desplazamiento
                    Console.WriteLine("Ingrese la clave:");
                    int keyDecrypt = int.Parse(Console.ReadLine());

                    // descifrar mensaje
                    Console.Write("Mensaje descifrado: ");
                    Cipher.decrypt(msgDecrypt, keyDecrypt);
                    Console.ReadKey();
                    break;
                case "3":
                    Console.Clear();
                    string msgTest = "En criptografía, el cifrado Cesar, tambien conocido como cifrado por desplazamiento," +
                                   " código de Cesar o desplazamiento de Cesar, es una de las técnicas de cifrado mas simples y mas usadas";

                    string msgTestEncrypt = "Hq fulswrjudild, ho fliudgr Fhvdu, wdpelhq frqrflgr frpr fliudgr sru ghvsodcdplhqwr, frgljr gh " +
                        "Fhvdu r ghvsodcdplhqwr gh Fhvdu, hv xqd gh odv whfqlfdv gh fliudgr pdv vlpsohv b pdv xvdgdv";


                    int keyUnitTest = 3;
                    // Mensaje original
                    Console.WriteLine($"\n\n Mensaje original:\n\n {msgTest}");

                    // Mensaje cifrado
                    Console.WriteLine($"\n\n Mensaje cifrado con desplazamiento {keyUnitTest} :\n\n");
                    Cipher.encrypt(msgTest, keyUnitTest);

                    // Mensaje descifrado
                    Console.WriteLine($"\n\n Mensaje descifrado con desplazamiento {keyUnitTest} :\n\n");
                    Cipher.decrypt(msgTestEncrypt, keyUnitTest);
                    Console.ReadKey();
                    break;
                case "x":
                case "X":
                    // Salir
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Por favor, seleccione una opción válida.");
                    break;
            }
        }
    }



}
