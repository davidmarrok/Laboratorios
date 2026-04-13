using System;

class Program
{
    static void Main()
    {
        //Ejercicio 1
        Console.WriteLine("Ejercicio 1: Suma de Dígitos");
        Console.Write("Ingrese un número entero positivo: ");
        int num1 = int.Parse(Console.ReadLine());
        int sumaDigitos = SumarDigitos(num1);
        Console.WriteLine("La suma de los dígitos de " + num1 +" es: " + sumaDigitos);




        //Ejercicio 2

        Console.WriteLine("\n Ejercicio 2: Parámetros por Referencia");
        Console.Write("Ingrese un número para elevar al cuadrado: ");
        int num2 = int.Parse(Console.ReadLine());
        string mensajeCuadrado = ElevarAlCuadrado(ref num2);
        Console.WriteLine(mensajeCuadrado + ". Nuevo valor: " + num2);




        //Ejercicio 3: Descuento Dinámico
        Console.WriteLine("\nEjercicio 3: Integración (Valor y Referencia)");
        double precio = 200;
        double descPorcentaje = 0.25;
        Console.WriteLine("Precio original: " + precio + ", Descuento: " + (descPorcentaje * 100) + "%");
        double montoDescontado = AplicarDescuento(descPorcentaje, ref precio);
        Console.WriteLine("Monto descontado: " + montoDescontado + ", Precio final: " + precio);

        //Ejercicio 4
        Console.WriteLine("\nEjercicio 4: Funciones del Videojuego");
        int energiaJugador = 10;
        Console.WriteLine("Energía inicial: " + energiaJugador);

        recargarEnergia(ref energiaJugador);
        Console.WriteLine("Tras recargar (+6): " + energiaJugador + " - Estado: " + obtenerEstado(energiaJugador));

        consumirEnergia(ref energiaJugador);
        Console.WriteLine("Tras consumir (-4): " + energiaJugador + " - Rendimiento: " + calcularRendimiento(energiaJugador));
    }



    // 1. Suma de dígitos
    static int SumarDigitos(int n)
    {
        int suma = 0;
        int digito;
        while (n > 0)
        {
            digito = n % 10;      // Obtenemos el último número
            suma = suma + digito; // Lo sumamos
            n = n / 10;           // Quitamos el último número del original
        }
        return suma;
    }


    // 2. Elevar al cuadrado
    static string ElevarAlCuadrado(ref int n)
    {
        n = n * n;
        return "Operación realizada con éxito";
    }



    // 3. Aplicar descuento
    static double AplicarDescuento(double porcentaje, ref double precio)
    {
        double descuento = precio * porcentaje;
        precio = precio - descuento; // Restamos
        return descuento;
    }


    // 4.1 Consumir Energía
    static int consumirEnergia(ref int energia)
    {
        energia = energia - 4;
        if (energia < 0)
        {
            energia = 0;
        }
        return energia;
    }



    // 4.2 Recargar Energía
    static int recargarEnergia(ref int energia)
    {
        energia = energia + 6;
        if (energia > 20)
        {
            energia = 20;
        }
        return energia;
    }

    // 4.3 Obtener Estado
    static string obtenerEstado(int energia)
    {
        if (energia >= 15) { return "Alta"; }
        if (energia >= 8) { return "Media"; }
        return "Baja";
    }

    // 4.4 Calcular Rendimiento
    static string calcularRendimiento(int energia)
    {
        if (energia == 20) { return "S"; }
        if (energia >= 15) { return "A"; }
        if (energia >= 8) { return "B"; }
        if (energia >= 1) { return "C"; }
        return "C"; // Caso por defecto
    }
}