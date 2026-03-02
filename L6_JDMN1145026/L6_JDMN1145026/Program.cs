// See https://aka.ms/new-console-template for more information
using System;
class Program
{
    static void Main()
    {
        Console.Write("¿Cómo te llamas? ");
        string nombre = Console.ReadLine();
        Console.WriteLine("Hola, " + nombre + " ¡Bienvenido a C#!");

        //Ejercico 1
        Console.WriteLine("");
        Console.WriteLine("Por favor ingrese el tipo de vehículo del cual desea saber su clasificación");
        Console.WriteLine("Escriba");
        Console.Write("[1 para Bicicleta]   ");
        Console.Write("[2 para Motocicleta]   ");
        Console.Write("[3 para Auto]   ");
        Console.Write("[4 para Camión]   ");
        Console.WriteLine("[5 para Autobús]");
        string vehiculo; //Variable de entrada de texto
        int vehiculo1; //Variable numerica
        vehiculo = Console.ReadLine(); //Lectura de texto ingresado
        vehiculo1 = int.Parse(vehiculo); //Conversion a dato numerico
        switch (vehiculo1) //Inicio del switch
        {
            case 1:
                Console.WriteLine("No motorizado"); //En caso de que seleccionen el numero uno se muestra esto
                break;

            case 2:
                Console.WriteLine("Ligero");//En caso de que seleccionen el numero dos se muestra esto
                break;

            case 3:
                Console.WriteLine("Mediano");//En caso de que seleccionen el numero tres se muestra esto
                break;

            case 4:
                Console.WriteLine("Pesado");//En caso de que seleccionen el numero cuatro se muestra esto
                break;

            case 5:
                Console.WriteLine("Transporte público");//En caso de que seleccionen el numero cinco se muestra esto
                break;

            default:
                Console.WriteLine("Error, debe ingresar un número del 1 al 5"); //En caso de que no se sleccionen ningunos de los casos anteriores se mostrara este mensaje de error
                break;
        }


        //Ejercico 2
        Console.WriteLine("");
        string tarjeta; //Variable de entrada de texto
        int tarjeta1; //Variable numerica
        Console.WriteLine("Ingrese el número de tarjeta que tiene");
        tarjeta = Console.ReadLine(); //Lectura de texto ingresado
        tarjeta1 = int.Parse(tarjeta);

        string credito; //Variable de entrada de texto
        double credito1; //Variable numerica
        Console.WriteLine("Ingrese su límite de crédito actual");
        credito = Console.ReadLine(); //Lectura de texto ingresado
        credito1 = double.Parse(credito);

        switch (tarjeta1) //Inicio del switch
        {
            case 1:
                Console.WriteLine("Su crédito ha aumentado en un 25%"); //En caso de que seleccionen el numero uno se muestra esto
                credito1 = credito1 * 1.25;
                Console.WriteLine("Su nuevo límite de credito es: " + credito1);
                break;

            case 2:
                Console.WriteLine("Su crédito ha aumentado en un 35%");//En caso de que seleccionen el numero dos se muestra esto
                credito1 = credito1 * 1.35;
                Console.WriteLine("Su nuevo límite de credito es: " + credito1);
                break;

            case 3:
                Console.WriteLine("Su crédito ha aumentado en un 40%");//En caso de que seleccionen el numero tres se muestra esto
                credito1 = credito1 * 1.40;
                Console.WriteLine("Su nuevo límite de credito es: " + credito1);
                break;

            default:
                Console.WriteLine("Su crédito ha aumentado en un 50%"); //En caso de que no se sleccionen ningunos de los casos anteriores se mostrara este mensaje
                credito1 = credito1 * 1.50;
                Console.WriteLine("Su nuevo límite de credito es: " + credito1);
                break;
        }



        //Ejercico 3
        Console.WriteLine("");
        string clasi; //Variable de entrada de texto
        double clasi1; //Variable numerica
        Console.WriteLine("Ingrese su puntuación");
        clasi = Console.ReadLine(); //Lectura de texto ingresado
        clasi1 = double.Parse(clasi);
        int sw;

        if(clasi1==0.0)
        {
            sw = 1;
        }
        if (clasi1 == 0.4)
        {
            sw = 2;
        }
        if (clasi1 >= 0.6)
        {
            sw = 3;
        }
        else
        {
            sw = 4;
        }

        switch (sw) //Inicio del switch
        {
            case 1:
                Console.WriteLine("Su nivel de rendimiento ha sido Inaceptable");
                clasi1 = clasi1 * 2400;
                Console.WriteLine("Su beneficio será de: " + clasi1);
                break;

            case 2:
                Console.WriteLine("Su nivel de rendimiento ha sido Aceptable");
                clasi1 = clasi1 * 2400;
                Console.WriteLine("Su beneficio será de: " + clasi1);
                break;

            case 3:
                Console.WriteLine("Su nivel de rendimiento ha sido Meritorio");
                clasi1 = clasi1 * 2400;
                Console.WriteLine("Su beneficio será de: " + clasi1);
                break;

            default:
                Console.WriteLine("Ingrese una puntuacion valida"); //En caso de que no se sleccionen ningunos de los casos anteriores se mostrara este mensaje
                break;
        }



        //Ejercicio 4
        Console.WriteLine("");
        Console.WriteLine("Bienvenido a Pizza Napoli");
        string pizza;
        int pizza1;
        Console.WriteLine("Todas nuestras pizzas incluyen tomate y queso mozzarela");
        Console.WriteLine("Si desea el menú vegetariano seleccione [1]. Si desea el menú NO vegetariano seleccione [2].");
        pizza = Console.ReadLine();
        pizza1 = int.Parse(pizza);
        string nv;
        int nv1;
        string vg;
        int vg1;

        switch (pizza1) //Inicio del switch
        {
            case 1:
                Console.WriteLine("Si quiere agregar tofu presione [1]. Si quiere agregar pimiento presione [2].");
                vg = Console.ReadLine();
                vg1 = int.Parse(vg);
                switch (vg1) //Inicio del switch
                {
                    case 1:
                        Console.WriteLine("Su pizza vegetariana contiene: Tofu, Mozzarella y Tomate");
                        break;

                    case 2:
                        Console.WriteLine("Su pizza vegetariana contiene: Pimiento, Mozzarella y Tomate");
                        break;

                    default:
                        Console.WriteLine("Su pizza contiene: Mozzarella y Tomate"); //En caso de que no se sleccionen ningunos de los casos anteriores se mostrara este mensaje
                        break;
                }
                break;

            case 2:
                Console.WriteLine("Si quiere agregar Peperoni presione [1]. Si quiere agregar Jamon presione [2].");
                nv = Console.ReadLine();
                nv1 = int.Parse(nv);
                switch (nv1) //Inicio del switch
                {
                    case 1:
                        Console.WriteLine("Su pizza NO vegetariana contiene: Peperoni, Mozzarella y Tomate");
                        break;

                    case 2:
                        Console.WriteLine("Su pizza NO vegetariana contiene: Jamon, Mozzarella y Tomate");
                        break;

                    default:
                        Console.WriteLine("Su pizza contiene: Mozzarella y Tomate"); //En caso de que no se sleccionen ningunos de los casos anteriores se mostrara este mensaje
                        break;
                }
                break;

            default:
                Console.WriteLine("Ese numero no esta en el menu po lo tanto su pizza contiene: Mozzarella y Tomate"); //En caso de que no se sleccionen ningunos de los casos anteriores se mostrara este mensaje
                break;
        }

    }
}
