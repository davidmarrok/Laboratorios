using System;

class Libro
{
    //Atributos
    public string titulo;
    public string autor;
    public int anioPub;
    public bool disponible;

    //Constructor
    public Libro(string tit, string aut, int anio, bool disp)
    {
        titulo = tit;
        autor = aut;
        anioPub = anio;
        disponible = disp;
    }

    //Metodo mostrar informacion
    public void mostrarInformacion()
    {
        Console.WriteLine("Titulo: " + titulo);
        Console.WriteLine("Autor: " + autor);
        Console.WriteLine("Anio: " + anioPub);
        Console.WriteLine("Disponible: " + disponible);
        Console.WriteLine("--------------------------------");
    }

    //Metodo prestar libro
    public void prestarLibro()
    {
        if (disponible == true)
        {
            disponible = false;
            Console.WriteLine("El libro " + titulo + " fue prestado.");
        }
        else
        {
            Console.WriteLine("El libro " + titulo + " no esta disponible.");
        }
    }

    //Metodo devolver libro
    public void devolverLibro()
    {
        disponible = true;
        Console.WriteLine("El libro " + titulo + " fue devuelto.");
    }
}

class Mascota
{
    //Atributos
    public string nombre;
    public string especie;
    public int edad;
    public bool vacunado;

    //Constructor
    public Mascota(string nom, string esp, int ed, bool vac)
    {
        nombre = nom;
        especie = esp;
        edad = ed;
        vacunado = vac;
    }

    //Metodo mostrar informacion
    public void mostrarInformacion()
    {
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Especie: " + especie);
        Console.WriteLine("Edad: " + edad);
        Console.WriteLine("Vacunado: " + vacunado);
        Console.WriteLine("--------------------------------");
    }

    //Metodo vacunar
    public void vacunar()
    {
        vacunado = true;
        Console.WriteLine(nombre + " ahora esta vacunado.");
    }

    //Metodo cumplir anios
    public void cumplirAnios()
    {
        edad = edad + 1;
        Console.WriteLine(nombre + " ahora tiene " + edad + " anios.");
    }
}

class Estudiante
{
    //Atributos
    public string nombre;
    public int edad;
    public string grado;
    public double[] notas;

    //Constructor
    public Estudiante(string nom, int ed, string grad, double[] not)
    {
        nombre = nom;
        edad = ed;
        grado = grad;
        notas = not;
    }

    //Metodo calcular promedio
    public double calcularPromedio()
    {
        double suma = 0;

        for (int i = 0; i < notas.Length; i++)
        {
            suma = suma + notas[i];
        }

        double prom = suma / notas.Length;

        return prom;
    }

    //Metodo mostrar informacion
    public void mostrarInformacion()
    {
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Edad: " + edad);
        Console.WriteLine("Grado: " + grado);

        Console.WriteLine("Notas:");

        for (int i = 0; i < notas.Length; i++)
        {
            Console.WriteLine(notas[i]);
        }

        Console.WriteLine("Promedio: " + calcularPromedio());
        Console.WriteLine("--------------------------------");
    }

    //Metodo aprobar
    public void aprobar()
    {
        if (calcularPromedio() >= 61)
        {
            Console.WriteLine(nombre + " aprobo.");
        }
        else
        {
            Console.WriteLine(nombre + " reprobo.");
        }
    }

    //Metodo agregar nota
    public void agregarNota(double nuevaNota)
    {
        double[] nuevoArr = new double[notas.Length + 1];

        for (int i = 0; i < notas.Length; i++)
        {
            nuevoArr[i] = notas[i];
        }

        nuevoArr[notas.Length] = nuevaNota;

        notas = nuevoArr;

        Console.WriteLine("Nueva nota agregada.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        //========================
        //EJERCICIO 1
        //========================

        Libro lib1 = new Libro("Cien anios de soledad", "Gabriel Garcia Marquez", 1967, true);
        Libro lib2 = new Libro("Don Quijote", "Miguel de Cervantes", 1605, true);

        Console.WriteLine("INFORMACION DE LIBROS");

        lib1.mostrarInformacion();
        lib2.mostrarInformacion();

        Console.WriteLine("Prestando libro...");
        lib1.prestarLibro();

        Console.WriteLine("Estado actualizado:");
        lib1.mostrarInformacion();

        Console.WriteLine("Devolviendo libro...");
        lib1.devolverLibro();

        Console.WriteLine("Estado actualizado:");
        lib1.mostrarInformacion();

        //========================
        //EJERCICIO 2
        //========================

        Mascota mas1 = new Mascota("Max", "Perro", 3, false);
        Mascota mas2 = new Mascota("Michi", "Gato", 2, false);

        Console.WriteLine("INFORMACION DE MASCOTAS");

        mas1.mostrarInformacion();
        mas2.mostrarInformacion();

        Console.WriteLine("Vacunando mascota...");
        mas1.vacunar();

        Console.WriteLine("Informacion actualizada:");
        mas1.mostrarInformacion();

        Console.WriteLine("Cumpliendo anios...");
        mas2.cumplirAnios();

        Console.WriteLine("Informacion actualizada:");
        mas2.mostrarInformacion();

        //========================
        //EJERCICIO 3
        //========================

        double[] not1 = { 70, 80, 90 };
        double[] not2 = { 50, 55, 60 };

        Estudiante est1 = new Estudiante("David", 18, "5to Bach", not1);
        Estudiante est2 = new Estudiante("Carlos", 17, "4to Bach", not2);

        Console.WriteLine("INFORMACION DE ESTUDIANTES");

        est1.mostrarInformacion();
        est2.mostrarInformacion();

        est1.aprobar();
        est2.aprobar();

        Console.WriteLine("Agregando nueva nota...");
        est2.agregarNota(100);

        Console.WriteLine("Informacion actualizada:");
        est2.mostrarInformacion();

        est2.aprobar();
    }
}