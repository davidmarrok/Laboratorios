using System;
class Program
{
    static void Main()
    {
        string nombre;
        Console.WriteLine("Laboratorio 9 - Procedimientos");
        Console.WriteLine("Ingrese su nombre");
        nombre = Console.ReadLine();
        Saludando(nombre);
        Curso();
        Ejercicio2();
        Ejercicio3();
        Ejercicio4();
        Ejercicio5();
    }
    static void Curso()
    {
        Console.Write("Esto es pensamiento computacional Sección 19");
        Console.Write("Este es el laboratorio 9");
    }
    static void Saludando(string nombre)
    {
        Console.WriteLine("Bienvenido " + nombre);
    }
    static void Ejercicio2()
    {
        Console.Write("Ingrese la dimension del lado del cuadrado");
        double lado = double.Parse(Console.ReadLine());
        AreaCuadrado(lado);

        Console.Write("Ingrese la dimension de la base del rectángulo: ");
        double baseR = double.Parse(Console.ReadLine());
        Console.Write("Ingrese la dimension de la altura del rectángulo: ");
        double alturaR = double.Parse(Console.ReadLine());
        AreaRectangulo(baseR, alturaR);

        Console.Write("Ingrese la dimension de la base del triángulo: ");
        double baseT = double.Parse(Console.ReadLine());
        Console.Write("Ingrese la dimension de la altura del triángulo: ");
        double alturaT = double.Parse(Console.ReadLine());
        AreaTriangulo(baseT, alturaT);
    }
    static void AreaCuadrado(double lado)
    {
        double area;
        area= lado * lado;
        Console.WriteLine("El área del cuadrado es: " + area);
    }

    static void AreaRectangulo(double b, double h)
    {
        double area;
        area= b * h;
        Console.WriteLine("El área del rectángulo es: " + area);
    }

    static void AreaTriangulo(double b, double h)
    {
        double area;
        area= (b * h) / 2;
        Console.WriteLine("El área del triángulo es: " + area);
    }
    static void Ejercicio3()
    {
        int opcion;
        do
        {
            Console.WriteLine("");
            Console.WriteLine("1. Cuadrado");
            Console.WriteLine("2. Triángulo");
            Console.WriteLine("3. Línea");
            Console.WriteLine("4. Salir");
            Console.Write("Opción: ");
            opcion = int.Parse(Console.ReadLine());

            Console.Write("Ingrese N: ");
            int n = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Cuadrado(n);
                    break;
                case 2:
                    Triangulo(n);
                    break;
                case 3:
                    Linea(n);
                    break;

                default:
                    Console.WriteLine("Ingrese una opción válida");
                    break;
            }

        } while (opcion != 4);
    }

    static void Cuadrado(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                Console.Write("*");
            Console.WriteLine();
        }
    }

    static void Triangulo(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j < i; j++)
                Console.Write("*");
            Console.WriteLine();
        }
    }

    static void Linea(int n)
    {
        for (int i = 0; i < n; i++)
            Console.Write("*");
        Console.WriteLine();
    }
    static void Ejercicio4()
    {
        int aprobados = 0;
        int reprobados = 0;
        double suma = 0;

        for (int i = 1; i <= 5; i++)
        {
            Console.Write("Nota " + i + ": ");
            double nota = double.Parse(Console.ReadLine());

            Nota(nota, ref aprobados, ref reprobados);
            suma += nota;
        }

        MostrarResumen(suma, aprobados, reprobados);
    }

    static void Nota(double nota, ref int aprobados, ref int reprobados)
    {
        if (nota >= 61)
        {
            Console.WriteLine("Aprobado");
            aprobados++;
        }
        else
        {
            Console.WriteLine("Reprobado");
            reprobados++;
        }
    }

    static void MostrarResumen(double suma, int aprobados, int reprobados)
    {
        double promedio = suma / 5;
        Console.WriteLine("");
        Console.WriteLine("Promedio: " + promedio);
        Console.WriteLine("Aprobados: " + aprobados);
        Console.WriteLine("Reprobados: " + reprobados);
    }
    static void Ejercicio5()
    {
        Console.Write("Ingrese número 1: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Ingrese número 2: ");
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine("Antes: " + a + ", " + b);

        Intercambiar(ref a, ref b);

        Console.WriteLine("Después: " + a + ", " + b);
    }

    static void Intercambiar(ref int x, ref int y)
    {
        int temp = x;
        x = y;
        y = temp;
    }
}