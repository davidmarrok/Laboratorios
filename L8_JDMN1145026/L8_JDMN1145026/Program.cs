// See https://aka.ms/new-console-template for more information
using System;
using System.Data.Common;
class Program
{
    static void Main()
    {
        // Entrada de usuario
        Console.Write("¿Cómo te llamas? ");
        string nombre = Console.ReadLine();
        // Salida de datos
        Console.WriteLine("Hola, " + nombre + " ¡Bienvenido a C#!");
        Console.WriteLine("");

        //Ejercicio 1
        double nota;
        double acumulado;
        int aprobado;
        int reprobado;
        string snota;
        aprobado = 0;
        reprobado=0;
        acumulado = 0;
        Console.WriteLine("Ejercicio 1");
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine("Ingrese la nota del estudiante numero " + i);
            snota = Console.ReadLine();
            nota = double.Parse(snota);
            if (nota >= 61)
            {
                aprobado = aprobado + 1;
                Console.WriteLine("Estudiante APROBADO");
            }
            else
            {
                reprobado = reprobado + 1;
                Console.WriteLine("Estudiante REPROBADO");
            }
            acumulado = acumulado + nota;
        }
        acumulado = acumulado / 10;
        Console.WriteLine("El promedio de la clase es: " + acumulado.ToString("F2"));
        Console.WriteLine("La cantidad de aprobados es: " + aprobado);
        Console.WriteLine("La cantidad de reprobados es: " + reprobado);
        Console.WriteLine("");


        //Ejercicio 2
        Console.WriteLine("Ejercicio 2");
        Console.WriteLine("Ingrese un numero entero para ver la suma de todos los numeros enteros desde el 1 hasta su numero");
        int num2;
        string snum2;
        int contador2 = 1;
        int suma = 0;
        int npares = 0;
        int nimpares = 0;

        snum2=Console.ReadLine();
        num2=int.Parse(snum2);
        while (contador2 <= num2)
        {
            suma=contador2 + suma;
            if (contador2 % 2 == 0)
            {
                npares++;
            }
            else
            {
                nimpares++;
            }
            contador2++;
        }
        Console.WriteLine("El resultado de la suma es: " + suma);
        Console.WriteLine("La cantidad de numeros pares en el rango es: " + npares);
        Console.WriteLine("La cantidad de numeros impares en el rango es: " + nimpares);
        Console.WriteLine("");

        //Ejercicio 3
        int opcion;
        string sopcion;
        double monto3;
        string smonto3;
        double tventas;
        int clientes;
        bool salir=false;
        clientes = 0;
        tventas = 0;
        Console.WriteLine("Ejercicio 3");
        do
        {
            Console.WriteLine("");
            Console.WriteLine("Escriba el numero de la opcion que desea.");
            Console.WriteLine("1) Registrar compra 2) Mostrar total de ventas 3) Mostrar cantidad de clientes atendidos 4) Salir");
            Console.WriteLine("");
            sopcion = Console.ReadLine();
            opcion = int.Parse(sopcion);
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Registro de compras");
                    Console.WriteLine("Ingrese el monto de la compra.");
                    smonto3=Console.ReadLine();
                    monto3=double.Parse(smonto3);
                    tventas=tventas+monto3;
                    clientes++;
                    Console.WriteLine("Compra registrada");
                    break;

                case 2:
                    Console.WriteLine("Mostrar total de ventas");
                    Console.WriteLine("El total de ventas este dia es: "+tventas);
                    break;

                case 3:
                    Console.WriteLine("Mostrar cantidad de clientes atendidos");
                    Console.WriteLine("Hoy se han atendido " + clientes+" clientes");
                    break;

                case 4:
                    Console.WriteLine("Salir");
                    Console.WriteLine("");
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Ingrese una opcion valida.");
                    break;
            }
        } while (salir != true);



        //Ejercicio 4
        double numero4;
        string snumero4;
        int contador4=0;
        int npositivo = 0;
        int nnegativo = 0;
        double suma4 = 0; ;
        Console.WriteLine("Ejercicio 4");
        do
        {
            Console.WriteLine("Ingrese un numero");
            contador4++;
            snumero4= Console.ReadLine();
            numero4=double.Parse(snumero4);
            suma4 = suma4 + numero4;
            if (numero4 > 0)
            {
                npositivo++;
            }
            if (numero4 < 0)
            {
                nnegativo++;
            }
        } while (numero4 != 0);
        Console.WriteLine("Se ingresaron "+contador4+" numeros.");
        Console.WriteLine( npositivo + " eran numeros positivos.");
        Console.WriteLine(nnegativo + " eran numeros negativos.");
        Console.WriteLine("La suma de todos los numeros ingresados es: " + suma4.ToString("F2"));
        Console.WriteLine("");


        //Ejercicio5
        int numero5;
        string snumero5;
        Console.WriteLine("Ejercicio 5");
        Console.WriteLine("Ingrese un numero");
        snumero5= Console.ReadLine();
        numero5=int.Parse(snumero5);
        for(int i = 0; i <= numero5; i++)
        {
            for (int p = 1; p <= i; p++)
            {
                Console.Write(p);
            }
            Console.WriteLine();
        }
    }
}