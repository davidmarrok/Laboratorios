using System;
// Ejercicio 1 – Clase Persona
    class Persona
{
    public string nombre;
    public int edad;
    public double altura;
    public bool estudiante;
}

// Ejercicio 2 – Clase Vehiculo
class Vehiculo
{
    public string marca;
    public string modelo;
    public int anio;
    public string color;
    public string placa;
}

// Ejercicio 3 – Clase Producto
class Producto
{
    public string codigo;
    public string nombre;
    public double precio;
    public int stock;
    public bool disponible;
}

// Ejercicio 4 – Clase Mascota
class Mascota
{
    public string nombre;
    public string especie;
    public int edad;
    public double peso;
    public bool vacunado;
}

class Program
{
    static void Main()
    {
        // Entrada de usuario 
        Console.Write("¿Cómo te llamas? ");
        string nombre = Console.ReadLine();
        // Salida de datos 
        Console.WriteLine("Hola, " + nombre + " ¡Bienvenido a C#!");

        // ===== Ejercicio 1 =====
        Persona persona1 = new Persona();
        persona1.nombre = "David";
        persona1.edad = 19;
        persona1.altura = 1.75;
        persona1.estudiante = true;

        Console.WriteLine("=== Persona ===");
        Console.WriteLine("Nombre: " + persona1.nombre);
        Console.WriteLine("Edad: " + persona1.edad);
        Console.WriteLine("Altura: " + persona1.altura);
        Console.WriteLine("Estudiante: " + persona1.estudiante);

        // ===== Ejercicio 2 =====
        Vehiculo vehiculo1 = new Vehiculo();
        vehiculo1.marca = "Toyota";
        vehiculo1.modelo = "Corolla";
        vehiculo1.anio = 2020;
        vehiculo1.color = "Negro";
        vehiculo1.placa = "P123ABC";

        Console.WriteLine("\n=== Vehiculo ===");
        Console.WriteLine("Marca: " + vehiculo1.marca);
        Console.WriteLine("Modelo: " + vehiculo1.modelo);
        Console.WriteLine("Año: " + vehiculo1.anio);
        Console.WriteLine("Color: " + vehiculo1.color);
        Console.WriteLine("Placa: " + vehiculo1.placa);

        // ===== Ejercicio 3 =====
        Producto producto1 = new Producto();
        producto1.codigo = "001";
        producto1.nombre = "Laptop";
        producto1.precio = 7500.50;
        producto1.stock = 10;
        producto1.disponible = true;

        Producto producto2 = new Producto();
        producto2.codigo = "002";
        producto2.nombre = "Mouse";
        producto2.precio = 150.75;
        producto2.stock = 25;
        producto2.disponible = true;

        Console.WriteLine("\n=== Producto 1 ===");
        Console.WriteLine("Código: " + producto1.codigo);
        Console.WriteLine("Nombre: " + producto1.nombre);
        Console.WriteLine("Precio: " + producto1.precio);
        Console.WriteLine("Stock: " + producto1.stock);
        Console.WriteLine("Disponible: " + producto1.disponible);

        Console.WriteLine("\n=== Producto 2 ===");
        Console.WriteLine("Código: " + producto2.codigo);
        Console.WriteLine("Nombre: " + producto2.nombre);
        Console.WriteLine("Precio: " + producto2.precio);
        Console.WriteLine("Stock: " + producto2.stock);
        Console.WriteLine("Disponible: " + producto2.disponible);

        // ===== Ejercicio 4 =====
        Mascota mascota1 = new Mascota();
        mascota1.nombre = "Firulais";
        mascota1.especie = "Perro";
        mascota1.edad = 3;
        mascota1.peso = 12.5;
        mascota1.vacunado = true;

        Console.WriteLine("\n=== Mascota ===");
        Console.WriteLine("Nombre: " + mascota1.nombre);
        Console.WriteLine("Especie: " + mascota1.especie);
        Console.WriteLine("Edad: " + mascota1.edad);
        Console.WriteLine("Peso: " + mascota1.peso);
        Console.WriteLine("Vacunado: " + mascota1.vacunado);
    }
}