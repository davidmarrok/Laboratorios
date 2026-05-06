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

        // ── Ejercicio 1 ──
        Console.WriteLine("=== EJERCICIO 1: Suma de fila y columna (4x4) ===");
        int[,] mat1 = new int[4, 4];
        LlenarMatriz4x4(mat1);

        Console.Write("¿Qué fila deseas sumar? (0-3): ");
        int fila = int.Parse(Console.ReadLine());
        Console.Write("¿Qué columna deseas sumar? (0-3): ");
        int col = int.Parse(Console.ReadLine());

        Console.WriteLine("Suma fila " + fila + ": " + SumaFila(mat1, fila));
        Console.WriteLine("Suma columna " + col + ": " + SumaColumna(mat1, col));

        // ── Ejercicio 2 ──
        Console.WriteLine("\n=== EJERCICIO 2: Valor mayor en matriz (3x5) ===");
        float[,] mat2 = new float[3, 5];
        CargarMatriz3x5(mat2);
        Console.WriteLine("El valor mayor es: " + MayorMatriz(mat2));

        // ── Ejercicio 3 ──
        Console.WriteLine("\n=== EJERCICIO 3: Multiplicacion de matrices ===");
        int[,] A = new int[3, 2];
        int[,] B = new int[2, 3];
        int[,] R = new int[3, 3];

        Console.WriteLine("Llenar matriz A (3x2):");
        LlenarMatriz(A, 3, 2);
        Console.WriteLine("Llenar matriz B (2x3):");
        LlenarMatriz(B, 2, 3);

        Multiplicar(A, B, R);

        Console.WriteLine("Matriz resultante R (3x3):");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
                Console.Write(R[i, j] + "\t");
            Console.WriteLine();
        }

        // ── Ejercicio 4
        Console.WriteLine("\n=== EJERCICIO 4: Diagonales de matriz (5x5) ===");
        int[,] mat4 = new int[5, 5];
        Llenar5x5(mat4);
        Console.WriteLine("Suma diagonal principal: " + SumaDiagonalPrincipal(mat4));
        Console.WriteLine("Suma diagonal secundaria: " + SumaDiagonalSecundaria(mat4));
    }

    // ─── EJERCICIO 1
    static void LlenarMatriz4x4(int[,] m)
    {
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
            {
                Console.Write("m[" + i + "][" + j + "]: ");
                m[i, j] = int.Parse(Console.ReadLine());
            }
    }

    static int SumaFila(int[,] m, int fila)
    {
        int suma = 0;
        for (int j = 0; j < 4; j++)
            suma += m[fila, j];
        return suma;
    }

    static int SumaColumna(int[,] m, int col)
    {
        int suma = 0;
        for (int i = 0; i < 4; i++)
            suma += m[i, col];
        return suma;
    }

    // ─── EJERCICIO 2
    static void CargarMatriz3x5(float[,] m)
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 5; j++)
            {
                Console.Write("m[" + i + "][" + j + "]: ");
                m[i, j] = float.Parse(Console.ReadLine());
            }
    }

    static float MayorMatriz(float[,] m)
    {
        float mayor = m[0, 0];
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 5; j++)
                if (m[i, j] > mayor)
                    mayor = m[i, j];
        return mayor;
    }

    // ─── EJERCICIO 3
    static void LlenarMatriz(int[,] m, int filas, int cols)
    {
        for (int i = 0; i < filas; i++)
            for (int j = 0; j < cols; j++)
            {
                Console.Write("m[" + i + "][" + j + "]: ");
                m[i, j] = int.Parse(Console.ReadLine());
            }
    }

    static void Multiplicar(int[,] A, int[,] B, int[,] R)
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
            {
                R[i, j] = 0;
                for (int k = 0; k < 2; k++)
                    R[i, j] += A[i, k] * B[k, j];
            }
    }

    // ─── EJERCICIO 4
    static void Llenar5x5(int[,] m)
    {
        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 5; j++)
            {
                Console.Write("m[" + i + "][" + j + "]: ");
                m[i, j] = int.Parse(Console.ReadLine());
            }
    }

    static int SumaDiagonalPrincipal(int[,] m)
    {
        int suma = 0;
        for (int i = 0; i < 5; i++)
            suma += m[i, i];
        return suma;
    }

    static int SumaDiagonalSecundaria(int[,] m)
    {
        int suma = 0;
        for (int i = 0; i < 5; i++)
            suma += m[i, 4 - i];
        return suma;
    }

}
