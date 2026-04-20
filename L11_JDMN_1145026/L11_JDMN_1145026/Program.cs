using System;
class Program
{
    static void Main()
    {
        // Entrada de usuario
        Console.Write("¿Cómo te llamas? ");
        string nombre = Console.ReadLine();
        // Salida de datos
        Console.WriteLine("Hola, " + nombre + " ¡Bienvenido a C#!");

        //Ejercicio 1

        bool mayus;
        bool minus;
        bool largo;
        bool caracter;

        do
        {
            mayus = false;
            minus = false;
            largo = false;
            caracter = false;
            Console.WriteLine("Ingrese una contraseña debe tener al menos 1 mayúscula, 1 minúscula, 8 caracteres y un caracter especial [@, #, $, %");
            string contraseña = Console.ReadLine();
            if (contraseña.Length >= 8)
            {
                largo = true;
            }

            for (int i = 0; i < contraseña.Length; i++)
            {
                if (char.IsUpper(contraseña[i]))
                {
                    mayus = true;
                }
                if (char.IsLower(contraseña[i]))
                {
                    minus = true;
                }
                if (contraseña[i] == '@' || contraseña[i] == '$' || contraseña[i] == '#' || contraseña[i] == '%')
                {
                    caracter = true;
                }
            }
            if (mayus == false)
            {
                Console.WriteLine("Error, no hay letra mayuscula");
            }
            if (minus == false)
            {
                Console.WriteLine("Error, no hay letra minuscula");
            }
            if (caracter == false)
            {
                Console.WriteLine("Error, no hay caracter especial");
            }
            if (largo == false)
            {
                Console.WriteLine("Error, debe contener al menos 8 caracteres.");
            }
        } while (mayus==false || minus ==false || caracter == false || largo ==false);
        Console.WriteLine("Contraseña Válida");


        //Ejercicio 2
        Console.Write("Ingrese una cadena: ");
        string entrada = Console.ReadLine();
        string inversor = "";

        for (int i = entrada.Length - 1; i >= 0; i--)
        {
            inversor+= entrada[i];
        }

        Console.WriteLine(inversor);


        //Ejercicio 3
        Console.WriteLine("Cantidad de números: ");
        int n = int.Parse(Console.ReadLine());
        int[] numeros = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Número "+i + 1+" ");
            numeros[i] = int.Parse(Console.ReadLine());
        }

        double suma = 0;
        int mayor = numeros[0];
        int menor = numeros[0];

        for (int i = 0; i < numeros.Length; i++)
        {
            suma += numeros[i];
            if (numeros[i] > mayor) mayor = numeros[i];
            if (numeros[i] < menor) menor = numeros[i];
        }
        double promedio = suma/n;
        Console.WriteLine("Suma ="+suma+ "  Promedio = "+promedio+ "  Mayor = "+mayor+ "  Menor = "+menor);




        // Ejercico 4
        int[] arreglo = new int[8];
        for (int i = 0; i < 8; i++)
        {
            Console.WriteLine($"Ingrese número"+i+": ");
            arreglo[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Número a buscar: ");
        int buscar = int.Parse(Console.ReadLine());

        int posicion = -1;
        for (int i = 0; i < arreglo.Length; i++)
        {
            if (arreglo[i] == buscar)
            {
                posicion = i;
                break;
            }
        }

        if (posicion != -1)
            Console.WriteLine("El número sí existe en la posición"+posicion);
        else
            Console.WriteLine("El número no existe");







        //Ejercico 5
        string[] nombres = new string[5];
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Nombre {i + 1}: ");
            nombres[i] = Console.ReadLine();
        }

        int masDeCinco = 0;
        string nombreLargo = nombres[0];
        string listaNombres = "";

        for (int i = 0; i < nombres.Length; i++)
        {
            if (nombres[i].Length > 5) masDeCinco++;
            if (nombres[i].Length > nombreLargo.Length) nombreLargo = nombres[i];

            // Construimos la cadena de salida manualmente
            listaNombres += nombres[i] + (i < nombres.Length - 1 ? ", " : "");
        }

        Console.WriteLine("Nombres ingresados: "+listaNombres);
        Console.WriteLine("Más de 5 letras: "+masDeCinco);
        Console.WriteLine("Nombre más largo:"+nombreLargo);
    }
}
