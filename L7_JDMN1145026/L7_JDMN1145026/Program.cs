// See https://aka.ms/new-console-template for more information
using System;
class Program
{
    static void Main()
    {
        // Ejercicio 1
        // pide y muestra el nombre
        Console.Write("Ingrese su nombre: ");
        string nombre = Console.ReadLine();
        Console.WriteLine("Hola, " + nombre + ". ¡Bienvenido/a al Laboratorio7!");

        Console.WriteLine("");
        string num;
        int num1;
        double num31;
        string num3;
        // pregunta cuantos numeros se van a sumar
        Console.WriteLine("Ingrese la cantidad de números que desea sumar");
        num = Console.ReadLine();
        num1 = int.Parse(num);

        int num2 = 0;
        double suma = 0;
        // valida que no sea cero
        while (num1 == 0)
        {
            Console.WriteLine("Ingrese un numero diferente a 0");
            num = Console.ReadLine();
            num1 = int.Parse(num);
        }

        // pide los numeros uno por uno y los suma
        while (num2 < num1)
        {
            num2++;
            Console.WriteLine("Ingrese un numero a sumar");
            num3 = Console.ReadLine();
            num31 = double.Parse(num3);
            suma = num31 + suma;
        }

        // muestra el resultado total
        Console.Write("El total de la suma es: ");
        Console.WriteLine(suma);

        // saca el promedio
        suma = suma / num1;
        Console.Write("El promedio es: ");
        Console.WriteLine(suma);






        // Ejercicio 2
        string celcius;
        string farenheith;
        string Km;
        double celcius1;
        double farenheith1;
        double Km1;
        string opcion;
        int opcion1;

        // menu de conversiones
        do
        {
            Console.WriteLine("Ingrese el numero de la opcion que desea");
            Console.Write("1:Convertir Celsius a Fahrenheit    2:Convertir Fahrenheit a Celsius ");
            Console.WriteLine("3:Convertir Kilómetros a Millas   4:Salir");
            Console.WriteLine("");
            opcion = Console.ReadLine();
            opcion1 = int.Parse(opcion);

            switch (opcion1)
            {
                case 1: // de celsius a fahrenheit
                    Console.WriteLine("Convertir Celsius a Fahrenheit");
                    Console.WriteLine("Ingrese grados celcius:");
                    celcius = Console.ReadLine();
                    celcius1 = double.Parse(celcius);
                    celcius1 = (celcius1 * 9 / 5) + 32;
                    Console.WriteLine("Es igual a:" + celcius1.ToString("N2") + " grados fahrenheit");
                    break;
                case 2: // de fahrenheit a celsius
                    Console.WriteLine("Convertir de Fahrenheit a Celsius");
                    Console.WriteLine("Ingrese grados Fahrenheit:");
                    farenheith = Console.ReadLine();
                    farenheith1 = double.Parse(farenheith);
                    farenheith1 = (farenheith1 - 32) * 5 / 9;
                    Console.WriteLine("Es igual a:" + farenheith1.ToString("N2") + " grados Celsius");
                    break;
                case 3: // de km a millas
                    Console.WriteLine("Convertir Kilómetros a Millas");
                    Console.WriteLine("Ingrese la distancia en Kilómetros:");
                    Km = Console.ReadLine();
                    Km1 = double.Parse(Km);
                    Km1 = (Km1 / 1.609);
                    Console.WriteLine("Es igual a:" + Km1.ToString("N2") + " millas");
                    break;
                case 4: // opcion para terminar
                    Console.WriteLine("Salir...");
                    opcion1 = 0;
                    break;
                default:
                    Console.WriteLine("Opción Inválida");
                    break;
            }
        }
        while (opcion1 != 0);








        // Ejercicio 3
        Random random = new Random();
        int numeroX;
        string entrada;
        int numeroUsuario;
        int nintentos = 0;
        // crea el numero secreto al azar
        numeroX = random.Next(1, 101);

        Console.WriteLine("");
        Console.WriteLine("Juego: Adivina el numero");

        // ciclo para intentar adivinar
        do
        {
            Console.WriteLine("Ingrese un número entre 1 y 100:");
            entrada = Console.ReadLine();
            numeroUsuario = int.Parse(entrada);

            // revisa si el numero es valido
            if (numeroUsuario < 1 || numeroUsuario > 100)
            {
                Console.WriteLine("Número fuera de rango");
            }
            else
            {
                nintentos = nintentos + 1; // suma un intento
                if (numeroUsuario < numeroX)
                {
                    Console.WriteLine("Más alto");
                }
                if (numeroUsuario > numeroX)
                {
                    Console.WriteLine("Más bajo");
                }
            }
        } while (numeroUsuario != numeroX);

        // aviso de victoria
        Console.WriteLine("Correcto! Hiciste " + nintentos + " intentos.");








        // Ejercicio 4
        string pin;
        int inten = 0;

        // ciclo para pedir el pin maximo 3 veces
        do
        {
            Console.WriteLine("");
            Console.WriteLine("Ingrese su PIN:");
            pin = Console.ReadLine();
            inten = inten + 1;

            // revisa si el pin es el correcto
            if (pin == "1234")
            {
                Console.WriteLine("Acceso concedido");
                inten = 3; // termina el ciclo
            }
            else
            {
                if (inten < 3)
                {
                    Console.WriteLine("PIN incorrecto");
                }
                else
                {
                    Console.WriteLine("Cuenta bloqueada");
                }
            }
        } while (inten < 3);
    }
}