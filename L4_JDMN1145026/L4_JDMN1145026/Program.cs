// See https://aka.ms/new-console-template for more information
using System;
using System.Xml;
class Program{
    static void Main()
    {
        //Variables ejercicio 1
        string modelo;
        int ccarga;
        float combustible;
        bool mtsalto;

        //Variables ejercico 2
        short sensoresActivos;
        int registroProcesador;
        double precisionTotal;

        //Variables ejercicio 3
        double energiaGenerada;
        int energiaLimitada;

        //Variables ejercicio 4
        string entradaRadar;

        //Variables ejercicio 5
        string señalOxigeno;
        string temperaturaCabina;

        //Variables ejercicio 6
        double velocidadLuz;

        //Variables ejercicio 7
        string galonLitio;

        // Entrada de usuario
        Console.Write("¿Cómo te llamas? ");//Mensaje para el usuario
        string nombre = Console.ReadLine();
        // Salida de datos
        Console.WriteLine("Hola, " + nombre + " ¡Bienvenido a C#!");//Mensaje para el usuario

        //Ejercicio 1
        modelo = "fx-550LA";
        ccarga = 55;
        combustible = 55.42F;
        mtsalto = true;

        Console.WriteLine("Ejercicio 1: Registro de nave Espacial ");
        Console.WriteLine("El modelo de la nave es: " + modelo);
        Console.WriteLine("La capacidad de carga es de: " + ccarga);
        Console.WriteLine("El combustible disponible es: " + combustible);


        //Ejercicio 2
        Console.WriteLine("Ejercicio 2: Expansión de Memoria (Conversión Implícita)");
        sensoresActivos = 128;
        registroProcesador = sensoresActivos;
        precisionTotal = registroProcesador;
        Console.WriteLine("Precisión total: " + precisionTotal);


        //Ejercicio 3
        Console.WriteLine("Ejercicio 3: Ajuste de Energía (Casting Explícito)");
        energiaGenerada = 987.65;
        energiaLimitada = (int)energiaGenerada;
        Console.WriteLine("La energía generada es: " + energiaGenerada);
        Console.WriteLine("La energía Limitada es: " + energiaLimitada);

        //Ejercicio 4
        Console.WriteLine("Ejercicio 4: Recepción de Coordenadas (Parse)");
        Console.WriteLine("Ingrese la distancia al planeta más cercano");//Mensaje para el usuario
        entradaRadar = Console.ReadLine();
        int distancia = int.Parse(entradaRadar);
        distancia = distancia+100;
        Console.WriteLine("La distancia al planeta más cercano es: " + distancia);

        //Ejercicio 5
        Console.WriteLine("Ejercicio 5: Panel de Control (Clase Convert)"); 
        señalOxigeno = "true";
        bool señalOxigeno2;
        señalOxigeno2=Convert.ToBoolean(señalOxigeno);
        temperaturaCabina = "22.8";
        double temperaturaCabina2;
        temperaturaCabina2 =Convert.ToDouble(temperaturaCabina);
        Console.WriteLine("Oxígeno: " + señalOxigeno2);
        Console.WriteLine("temperatura: " + temperaturaCabina2);

        //Ejercico 6
        Console.WriteLine("Ejercicio 6: Reporte de Misión (ToString y Formato)"); 
        velocidadLuz = 299792.458;
        string velocidadLuz2;
        velocidadLuz2 = velocidadLuz.ToString("N3");
        Console.WriteLine("Velocidad de la Luz: " + velocidadLuz2);

        //Ejercicio 7
        Console.WriteLine("Ejercicio 7: Reto Final - Calculadora de Suministros"); 
        Console.WriteLine("Ingrese el precio del Galón de Litio");//Mensaje para el usuario
        galonLitio= Console.ReadLine();//El usario ingresa el valor del litio
        double galonLitio2;//creamos una variable tipo doubble
        galonLitio2= Convert.ToDouble(galonLitio);//convertimos el valor de la variable galonLitio a dobble en galonLitio2
        double impuesto;//variable para calcular el impuesto
        impuesto = galonLitio2 * 0.12;//Se calcula el impuesto
        double costoTotal;//declaramos una variable para calcular el costo total
        costoTotal = galonLitio2 + impuesto; //Calculamos el valor de galon de litio con el impuesto
        int costoRedondeado;//declaramos una variable tipo int para el costo redondeado
        costoRedondeado = (int)costoTotal;//convertimos el valor de costoTotal de doubble a int
        Console.WriteLine("El costo total es de: " + costoRedondeado);//Mostramos el valor del costo total ya redondeado


    }

}
