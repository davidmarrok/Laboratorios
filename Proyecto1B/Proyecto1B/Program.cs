using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("¡Bienvenido a SmartPark!");
        Console.Write("Ingrese nombre del operador: ");
        string operador = Console.ReadLine();

        Console.Write("Código de turno: ");
        string turno = Console.ReadLine();

        while (turno.Length != 4)
        {
            Console.WriteLine("Código inválido, intenta otra vez");
            turno = Console.ReadLine();
        }

        Console.Write("Ingrese capacidad de parqueo (Minimo 10): ");
        int capacidad = int.Parse(Console.ReadLine());

        while (capacidad < 10)
        {
            Console.WriteLine("Capacidad incorrecta, minimo 10 ");
            capacidad = int.Parse(Console.ReadLine());
        }

        int ticketsCreados = 0, ticketsCerrados = 0, tiempoSimulado = 0, minutoEntrada = 0;
        double dineroRecaudado = 0.00;
        bool ticketActivo = false;
        char opcionMenu;
        string placaActual, clienteActual;
        int tipoVehiculoActual = 0;
        int espaciosDisponibles=capacidad;
        int espaciosOcupados;

        while (true)
        {
            Console.WriteLine("======== MENU ========");
            Console.WriteLine(" A. CREAR TICKET DE ENTRADA");
            Console.WriteLine(" B. REGISTRAR SALIDA Y CALCULAR COBRO");
            Console.WriteLine(" C. VER ESTADO DE PARQUEO");
            Console.WriteLine(" D. SIMULAR PASO DEL TIEMPO");
            Console.WriteLine(" E. SALIR");


            espaciosOcupados = capacidad - espaciosDisponibles;
            opcionMenu = char.Parse(Console.ReadLine().ToUpper());

            switch (opcionMenu)
            {
                case 'A':
                    if (ticketActivo)
                    {
                        Console.WriteLine("Ya existe un ticket activo");
                        break;
                    }

                    if ((espaciosOcupados) >= capacidad)
                    {
                        Console.WriteLine("Parqueo lleno");
                        break;
                    }

                    Console.Write("Ingrese la placa del vehiculo: ");
                    string placa = Console.ReadLine();

                    if (placa.Length < 6 || placa.Length > 8 || placa.Contains(" "))
                    {
                        Console.WriteLine("Placa incorrecta");
                        break;
                    }

                    Console.WriteLine("Tipo de vehiculo (1=Moto, 2=Auto, 3=Pickup/SUV): ");
                    int tipoVehiculo = int.Parse(Console.ReadLine());

                    if (tipoVehiculo < 1 || tipoVehiculo > 3)
                    {
                        Console.WriteLine("Tipo inválido");
                        break;
                    }

                    Console.Write("Nombre del cliente: ");
                    string usuario = Console.ReadLine();

                    placaActual = placa;
                    clienteActual = usuario;
                    tipoVehiculoActual = tipoVehiculo;
                    ticketActivo = true;
                    ticketsCreados++;
                    minutoEntrada = tiempoSimulado;
                    espaciosDisponibles = espaciosDisponibles - 1;

                    Console.WriteLine("Ticket creado");
                    break;

                case 'B':
                    if (ticketActivo == true)
                    {
                        int minutosEstacionado = tiempoSimulado - minutoEntrada;
                        double monto = 0;
                        string vip;
                        if (minutosEstacionado <= 15)
                        {
                            Console.WriteLine("Su parqueo es gratis");
                        }
                        else
                        {
                            switch (tipoVehiculoActual)
                            {
                                case 1:
                                    monto = ((minutosEstacionado + 59) / 60) * 5;
                                    break;
                                case 2:
                                    monto = ((minutosEstacionado + 59) / 60) * 10;
                                    break;
                                case 3:
                                    monto = ((minutosEstacionado + 59) / 60) * 15;
                                    break;
                            }
                            Console.WriteLine("Tiempo de estadía: " + minutosEstacionado + " minutos");
                            if (minutosEstacionado > 360)
                            {
                                Console.WriteLine("Se le ha multado con Q25 por permanecer más de 360 minutos parqueado.");
                                monto = monto + 25;
                            }
                            Console.WriteLine("Es usted un usuario VIP?");
                            Console.WriteLine("Si/No");
                            vip=Console.ReadLine();
                            if (vip == "Si")
                            {
                                Console.WriteLine("Se le ha aplicado un 10% de descuento por ser miembro VIP");
                                monto = monto * 0.9;
                            }
                            Console.WriteLine("Su monto a pagar es: "+monto);

                        }
                        dineroRecaudado = dineroRecaudado + monto;
                        espaciosDisponibles++;
                        ticketsCerrados++;
                        ticketActivo = false;
                        Console.WriteLine("Salida registrada");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("No hay vehículos en el parqueo");
                    }
                    break;

                case 'C':

                    Console.WriteLine("Capacidad total: " + capacidad);
                    Console.WriteLine("Espacios ocupados: " + espaciosOcupados);
                    Console.WriteLine("Espacios libres: " + espaciosDisponibles);
                    Console.WriteLine("Tiempo simulado: " + tiempoSimulado);
                    Console.WriteLine("Dinero recaudado: Q" + dineroRecaudado);
                    Console.WriteLine("Tickets creados: " + ticketsCreados);
                    Console.WriteLine("Tickets cerrados: " + ticketsCerrados);
                    break;

                case 'D':
                    Console.Write("Ingrese minutos (1 a 1440): ");
                    int minutos = int.Parse(Console.ReadLine());

                    while (minutos < 1 || minutos > 1440)
                    {
                        Console.WriteLine("Valor inválido");
                        minutos = int.Parse(Console.ReadLine());
                    }

                    tiempoSimulado += minutos;
                    Console.WriteLine("Tiempo acumulado: " + tiempoSimulado);
                    break;

                case 'E':
                    Console.WriteLine("Fin del programa");
                    return;

                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}