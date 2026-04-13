using System;

class Program
{
    static void Main()
    {
        // Mensaje de bienvenida
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("¡Bienvenido a SmartPark!");
        Console.ResetColor();

        // Registro inicial del sistema
        Console.Write("Ingrese nombre del operador: ");
        string operador = Console.ReadLine();

        Console.Write("Código de turno: ");
        string turno = Console.ReadLine();

        // Validación de código de turno (exactamente 4 caracteres)
        while (turno.Length != 4)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Código inválido, intenta otra vez");
            Console.ResetColor();
            turno = Console.ReadLine();
        }

        Console.Write("Ingrese capacidad de parqueo (Minimo 10): ");
        int capacidad;
        string capacidadValidacion=Console.ReadLine();

        // Validación de capacidad mínima
        while (!int.TryParse(capacidadValidacion, out capacidad) || capacidad < 10)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Capacidad incorrecta, minimo 10 ");
            Console.ResetColor();
            capacidadValidacion = Console.ReadLine();
        }

        // Variables del sistema
        int ticketsCreados = 0, ticketsCerrados = 0, tiempoSimulado = 0, minutoEntrada = 0;
        double dineroRecaudado = 0;
        bool ticketActivo = false;
        char opcionMenu;
        string placaActual, clienteActual;
        int tipoVehiculoActual = 0;
        int espaciosDisponibles = capacidad;
        int espaciosOcupados;

        // Ciclo principal del menú
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("======== MENU ========");
            Console.WriteLine(" A. CREAR TICKET DE ENTRADA");
            Console.WriteLine(" B. REGISTRAR SALIDA Y CALCULAR COBRO");
            Console.WriteLine(" C. VER ESTADO DE PARQUEO");
            Console.WriteLine(" D. SIMULAR PASO DEL TIEMPO");
            Console.WriteLine(" E. SALIR");
            Console.ResetColor();

            espaciosOcupados = capacidad - espaciosDisponibles;
            opcionMenu = char.Parse(Console.ReadLine().ToUpper());

            switch (opcionMenu)
            {
                case 'A':
                    // Verificar si ya existe un ticket activo
                    if (ticketActivo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ya existe un ticket activo");
                        Console.ResetColor();
                        break;
                    }

                    // Verificar si el parqueo está lleno
                    if ((espaciosOcupados) >= capacidad)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Parqueo lleno");
                        Console.ResetColor();
                        break;
                    }

                    Console.Write("Ingrese la placa del vehiculo (6-8 caracteres sin espacios): ");
                    string placa = Console.ReadLine();

                    // Validación de placa
                    if (placa.Length < 6 || placa.Length > 8 || placa.Contains(" "))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Placa inválida");
                        Console.ResetColor();
                        break;
                    }

                    Console.WriteLine("Tipo de vehiculo (1=Moto, 2=Auto, 3=Pickup/SUV): ");
                    int tipoVehiculo;
                    string tipoVehiculoValidacion=Console.ReadLine();

                    // Validación de tipo de vehículo
                    while (!int.TryParse(tipoVehiculoValidacion, out tipoVehiculo) ||tipoVehiculo  < 1 || tipoVehiculo > 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Tipo inválido");
                        Console.ResetColor();
                        tipoVehiculoValidacion = Console.ReadLine();
                    }

                    Console.Write("Nombre del cliente: ");
                    string usuario = Console.ReadLine();

                    // Guardar datos del ticket
                    placaActual = placa;
                    clienteActual = usuario;
                    tipoVehiculoActual = tipoVehiculo;
                    ticketActivo = true;
                    ticketsCreados++;
                    minutoEntrada = tiempoSimulado;
                    espaciosDisponibles = espaciosDisponibles - 1;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ticket creado");
                    Console.ResetColor();
                    break;

                case 'B':
                    // Verificar si hay ticket activo
                    if (ticketActivo == true)
                    {
                        int minutosEstacionado = tiempoSimulado - minutoEntrada;
                        double monto = 0;
                        string vip;

                        // Validación de tiempo gratis
                        if (minutosEstacionado <= 15)
                        {
                            Console.WriteLine("Su parqueo es gratis");
                        }
                        else
                        {
                            // Cálculo de tarifa según tipo de vehículo
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

                            // Multa por más de 6 horas
                            if (minutosEstacionado > 360)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Se le ha multado con Q25 por permanecer más de 6 horas en el parqueo.");
                                Console.ResetColor();
                                monto = monto + 25;
                            }

                            // Descuento VIP
                            Console.WriteLine("Escriba 'Si' si es un usuario VIP");
                            vip = Console.ReadLine();

                            if (vip == "Si")
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Se le ha aplicado un 10% de descuento por ser miembro VIP");
                                Console.ResetColor();
                                monto = monto * 0.9;
                            }

                            Console.WriteLine("Su monto a pagar es: " + monto);
                        }

                        // Actualizar sistema
                        dineroRecaudado = dineroRecaudado + monto;
                        espaciosDisponibles++;
                        ticketsCerrados++;
                        ticketActivo = false;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Salida registrada");
                        Console.ResetColor();
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No hay vehículos en el parqueo");
                        Console.ResetColor();
                    }
                    break;

                case 'C':
                    // Mostrar estado del sistema
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
                    int minutos;
                    string minutosValidacion=Console.ReadLine();

                    // Validación de rango de tiempo
                    while (!int.TryParse(minutosValidacion, out minutos) || minutos < 1 || minutos > 1440)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Valor inválido");
                        Console.ResetColor();
                        Console.Write("Ingrese minutos (1 a 1440): ");
                        minutosValidacion = Console.ReadLine();
                    }

                    tiempoSimulado += minutos;
                    Console.WriteLine("Tiempo acumulado: " + tiempoSimulado);
                    break;

                case 'E':
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Fin del programa");
                    Console.WriteLine("Al final del turno quedan:");
                    Console.WriteLine("Capacidad total: " + capacidad);
                    Console.WriteLine("Espacios ocupados: " + espaciosOcupados);
                    Console.WriteLine("Espacios libres: " + espaciosDisponibles);
                    Console.WriteLine("Tiempo simulado: " + tiempoSimulado);
                    Console.WriteLine("Dinero recaudado: Q" + dineroRecaudado);
                    Console.WriteLine("Tickets creados: " + ticketsCreados);
                    Console.WriteLine("Tickets cerrados: " + ticketsCerrados);
                    Console.ResetColor();
                    return;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción inválida");
                    Console.ResetColor();
                    break;
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}