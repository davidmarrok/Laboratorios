using System;

// ============================================================
// CLASE PARCELA
// ============================================================
class Parcela
{
    // 0 = nada, 1 = papa, 2 = tomate, 3 = fresa
    private int tipoCultivo;

    private int mesesCrecimiento;

    private int mesesNecesarios;

    private bool regadaEsteMes;

    private int ingresoAlCosechar;

    public int TipoCultivo { get { return tipoCultivo; } }
    public int MesesCrecimiento { get { return mesesCrecimiento; } }
    public int MesesNecesarios { get { return mesesNecesarios; } }
    public bool RegadaEsteMes { get { return regadaEsteMes; } }
    public int IngresoAlCosechar { get { return ingresoAlCosechar; } }

    // Constructor
    public Parcela()
    {
        Limpiar();
    }

    // Guarda los datos de un cultivo nuevo
    public void Sembrar(int tipo, int mesesNecesarios, int ingreso)
    {
        tipoCultivo = tipo;
        this.mesesNecesarios = mesesNecesarios;
        ingresoAlCosechar = ingreso;

        // El cultivo inicia desde 0 meses de crecimiento
        mesesCrecimiento = 0;

        // Al sembrarse todavía no ha sido regado
        regadaEsteMes = false;
    }

    // Aumenta el crecimiento del cultivo
    public void AumentarCrecimiento(int meses)
    {
        mesesCrecimiento += meses;
    }

    // Marca la parcela como regada
    public void MarcarRegada()
    {
        regadaEsteMes = true;
    }

    // Reinicia el estado de riego
    // Se usa al cambiar de mes
    public void QuitarRiego()
    {
        regadaEsteMes = false;
    }

    // Limpia la parcela después de cosechar
    public void Limpiar()
    {
        tipoCultivo = 0;
        mesesCrecimiento = 0;
        mesesNecesarios = 0;
        regadaEsteMes = false;
        ingresoAlCosechar = 0;
    }

    // Devuelve el nombre del cultivo
    public string ObtenerNombreCultivo()
    {
        if (tipoCultivo == 1) return "Papa";
        if (tipoCultivo == 2) return "Tomate";
        if (tipoCultivo == 3) return "Fresa";

        return "Vacía";
    }
}







// ============================================================
// CLASE GRANJA
// ============================================================
class Granja
{
    // Matriz que representa todas las parcelas
    private Parcela[,] parcelas;

    private int filas;
    private int columnas;

    // Recursos de la granja
    private double dinero;
    private int empleados;
    private double sueldoEmpleado;

    // Control del tiempo
    private int mesesRestantes;
    private int mesActual;

    // Variables para el reporte final
    private double totalIngresos;
    private double totalEgresos;
    private int mesesSimulados;

    private int papasSembradas;
    private int tomatesSembrados;
    private int fresasSembradas;

    private int cosechasPapa;
    private int cosechasTomate;
    private int cosechasFresa;

    private int totalRiegos;

    // Constructor de la granja
    public Granja(double dineroInicial, int numEmpleados, double sueldo, int meses, int numFilas, int numColumnas)
    {
        dinero = dineroInicial;
        empleados = numEmpleados;
        sueldoEmpleado = sueldo;

        mesesRestantes = meses;

        filas = numFilas;
        columnas = numColumnas;

        mesActual = 0;

        // Inicializar contadores
        totalIngresos = 0;
        totalEgresos = 0;
        mesesSimulados = 0;

        papasSembradas = 0;
        tomatesSembrados = 0;
        fresasSembradas = 0;

        cosechasPapa = 0;
        cosechasTomate = 0;
        cosechasFresa = 0;

        totalRiegos = 0;

        // Crear matriz de parcelas
        parcelas = new Parcela[filas, columnas];

        // Crear cada objeto Parcela dentro de la matriz
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                parcelas[i, j] = new Parcela();
            }
        }
    }

    // Pide una fila o columna válida
    private int PedirIndice(string mensaje, int limite)
    {
        int valor;

        while (true)
        {
            Console.Write(mensaje);

            // TryParse evita errores si el usuario escribe texto
            if (int.TryParse(Console.ReadLine(), out valor) &&
                valor >= 0 &&
                valor < limite)
            {
                return valor;
            }

            Console.WriteLine("Entrada inválida. Debe estar entre 0 y " + (limite - 1) + ".");
        }
    }

    private int PedirOpcion(string mensaje, int min, int max)
    {
        int valor;
        while (true)
        {
            Console.Write(mensaje);

            if (int.TryParse(Console.ReadLine(), out valor) &&
                valor >= min &&
                valor <= max)
            {
                return valor;
            }

            Console.WriteLine("Opción inválida.");
        }
    }

    // Muestra la cuadrícula de parcelas
    public void MostrarCuadricula()
    {
        Console.WriteLine("------ Cuadrícula de la Granja ------");

        // Recorrer filas y columnas de la matriz
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                string simbolo = "[ - ]";

                // Mostrar símbolo según cultivo
                if (parcelas[i, j].TipoCultivo == 1)
                    simbolo = "[ P ]";

                else if (parcelas[i, j].TipoCultivo == 2)
                    simbolo = "[ T ]";

                else if (parcelas[i, j].TipoCultivo == 3)
                    simbolo = "[ F ]";

                Console.Write(simbolo);
            }

            Console.WriteLine();
        }

        Console.WriteLine("Leyenda: [ - ] Vacía  [ P ] Papa  [ T ] Tomate  [ F ] Fresa");
        Console.WriteLine("--------------------------------------");
    }

    // Muestra datos rápidos antes del menú
    public void MostrarResumenRapido()
    {
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("Mes actual: " + mesActual);
        Console.WriteLine("Meses restantes: " + mesesRestantes);
        Console.WriteLine("Dinero disponible: Q" + dinero);
        Console.WriteLine("------------------------------------------");
    }

    // ============================================================
    // OPCIÓN 1 - SEMBRAR
    // ============================================================
    public void Sembrar()
    {
        Console.WriteLine();
        Console.WriteLine("------------ SEMBRAR --------------");

        MostrarCuadricula();

        // Pedir ubicación
        int fila = PedirIndice("Ingrese la fila: ", filas);
        int columna = PedirIndice("Ingrese la columna: ", columnas);

        // Verificar que la parcela esté vacía
        if (parcelas[fila, columna].TipoCultivo != 0)
        {
            Console.WriteLine("Esa parcela ya tiene cultivo.");
            return;
        }

        Console.WriteLine("1. Papa   (2 meses | Q450)");
        Console.WriteLine("2. Tomate (3 meses | Q650)");
        Console.WriteLine("3. Fresa  (4 meses | Q900)");

        int tipoCultivo = PedirOpcion("Seleccione una opción: ", 1, 3);

        // Dependiendo del cultivo se asignan datos distintos
        if (tipoCultivo == 1)
        {
            parcelas[fila, columna].Sembrar(1, 2, 450);
            papasSembradas++;
        }
        else if (tipoCultivo == 2)
        {
            parcelas[fila, columna].Sembrar(2, 3, 650);
            tomatesSembrados++;
        }
        else
        {
            parcelas[fila, columna].Sembrar(3, 4, 900);
            fresasSembradas++;
        }

        Console.WriteLine("Cultivo sembrado correctamente.");
    }

    // ============================================================
    // OPCIÓN 2 - REGAR
    // ============================================================
    public void RegarParcela()
    {
        Console.WriteLine();
        Console.WriteLine("------------- REGAR PARCELA --------------");

        MostrarCuadricula();

        // Regar cuesta Q40
        if (dinero < 40)
        {
            Console.WriteLine("No tiene suficiente dinero.");
            return;
        }

        int fila = PedirIndice("Ingrese la fila: ", filas);
        int columna = PedirIndice("Ingrese la columna: ", columnas);

        // No se puede regar una parcela vacía
        if (parcelas[fila, columna].TipoCultivo == 0)
        {
            Console.WriteLine("La parcela está vacía.");
            return;
        }

        // Solo se puede regar una vez por mes
        if (parcelas[fila, columna].RegadaEsteMes)
        {
            Console.WriteLine("La parcela ya fue regada.");
            return;
        }

        // Descontar dinero y marcar la parcela como regada
        dinero -= 40;
        totalEgresos += 40;

        parcelas[fila, columna].MarcarRegada();

        totalRiegos++;

        Console.WriteLine("Parcela regada correctamente.");
    }

    // ============================================================
    // OPCIÓN 3 - CONSULTAR PARCELA
    // ============================================================
    public void ConsultarParcela()
    {
        Console.WriteLine();
        Console.WriteLine("========== CONSULTAR PARCELA ==========");

        int fila = PedirIndice("Ingrese la fila: ", filas);
        int columna = PedirIndice("Ingrese la columna: ", columnas);

        // Guardar la parcela en una variable para trabajar más cómodo
        Parcela p = parcelas[fila, columna];

        Console.WriteLine("------ Información de la parcela ------");

        if (p.TipoCultivo == 0)
        {
            Console.WriteLine("La parcela está vacía.");
        }
        else
        {
            Console.WriteLine("Tipo de cultivo: " + p.ObtenerNombreCultivo());

            Console.WriteLine("Crecimiento: " +
                              p.MesesCrecimiento +
                              "/" +
                              p.MesesNecesarios);

            Console.WriteLine("Regada este mes: " +
                              (p.RegadaEsteMes ? "Sí" : "No"));

            Console.WriteLine("Ingreso al cosechar: Q" +
                              p.IngresoAlCosechar);
        }
    }

    // ============================================================
    // OPCIÓN 4 - AVANZAR MES
    // ============================================================
    public void AvanzarMes()
    {
        Console.WriteLine();
        Console.WriteLine("--------- AVANZANDO MES ---------");

        // Calcular cuánto se pagará a empleados
        double pagoTotal = empleados * sueldoEmpleado;

        // Si no alcanza el dinero termina la simulación
        if (dinero < pagoTotal)
        {
            Console.WriteLine("No hay suficiente dinero para pagar empleados.");
            dinero = 0;
            return;
        }

        // Descontar sueldo
        dinero -= pagoTotal;
        totalEgresos += pagoTotal;

        Console.WriteLine("Pago de empleados: Q" + pagoTotal);

        // Recorrer toda la matriz
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                Parcela p = parcelas[i, j];

                // Solo trabajar parcelas con cultivo
                if (p.TipoCultivo != 0)
                {
                    // Si fue regada avanza 2 meses
                    // Si no, solo avanza 1
                    int avance = p.RegadaEsteMes ? 2 : 1;

                    p.AumentarCrecimiento(avance);

                    Console.WriteLine("[" + i + "][" + j + "] avanzó " +
                                      avance + " mes(es).");

                    // Verificar si ya se puede cosechar
                    if (p.MesesCrecimiento >= p.MesesNecesarios)
                    {
                        // Sumar ganancias
                        dinero += p.IngresoAlCosechar;
                        totalIngresos += p.IngresoAlCosechar;

                        // Registrar tipo de cosecha
                        if (p.TipoCultivo == 1)
                            cosechasPapa++;

                        else if (p.TipoCultivo == 2)
                            cosechasTomate++;

                        else
                            cosechasFresa++;

                        Console.WriteLine("Se cosechó " +
                                          p.ObtenerNombreCultivo());

                        // Vaciar parcela después de cosechar
                        p.Limpiar();
                    }
                    else
                    {
                        // Reiniciar riego para el siguiente mes
                        p.QuitarRiego();
                    }
                }
            }
        }

        // Actualizar tiempo
        mesesRestantes--;
        mesActual++;
        mesesSimulados++;

        Console.WriteLine("Mes completado.");
    }

    // ============================================================
    // REPORTE FINAL
    // ============================================================
    public void MostrarReporte()
    {
        int parcelasVacias = 0;

        // Contar parcelas vacías
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                if (parcelas[i, j].TipoCultivo == 0)
                    parcelasVacias++;
            }
        }

        Console.WriteLine();
        Console.WriteLine("========== REPORTE FINAL ==========");

        Console.WriteLine("Dinero final: Q" + dinero);

        Console.WriteLine("Total ingresos: Q" + totalIngresos);
        Console.WriteLine("Total egresos: Q" + totalEgresos);

        Console.WriteLine("Meses simulados: " + mesesSimulados);

        Console.WriteLine("Papas sembradas: " + papasSembradas);
        Console.WriteLine("Tomates sembrados: " + tomatesSembrados);
        Console.WriteLine("Fresas sembradas: " + fresasSembradas);

        Console.WriteLine("Cosechas papa: " + cosechasPapa);
        Console.WriteLine("Cosechas tomate: " + cosechasTomate);
        Console.WriteLine("Cosechas fresa: " + cosechasFresa);

        Console.WriteLine("Total de riegos: " + totalRiegos);

        Console.WriteLine("Parcelas vacías: " + parcelasVacias);
    }

    // Métodos para consultar datos desde Main
    public double ObtenerDinero()
    {
        return dinero;
    }

    public int ObtenerMesesRestantes()
    {
        return mesesRestantes;
    }
}

// ============================================================
// CLASE PROGRAM
// ============================================================
class Program
{
    // Pide un entero positivo
    static int LeerEnteroPositivo(string mensaje)
    {
        int valor;

        while (true)
        {
            Console.Write(mensaje);

            if (int.TryParse(Console.ReadLine(), out valor) && valor > 0)
            {
                return valor;
            }

            Console.WriteLine("Entrada inválida.");
        }
    }

    // Pide un número decimal positivo
    static double LeerDoublePositivo(string mensaje)
    {
        double valor;

        while (true)
        {
            Console.Write(mensaje);

            if (double.TryParse(Console.ReadLine(), out valor) && valor > 0)
            {
                return valor;
            }

            Console.WriteLine("Entrada inválida.");
        }
    }

    static void Main()
    {
        Console.WriteLine("====== SIMULADOR DE GRANJA ======");
        Console.WriteLine();

        // Configuración inicial
        double dineroInicial = LeerDoublePositivo("Dinero inicial: ");

        int numEmpleados = LeerEnteroPositivo("Número de empleados: ");

        double sueldoEmpleado = LeerDoublePositivo("Sueldo por empleado: ");

        int mesesSimular =LeerEnteroPositivo("Meses a simular: ");

        int numFilas = LeerEnteroPositivo("Cantidad de filas: ");

        int numColumnas = LeerEnteroPositivo("Cantidad de columnas: ");

        // Crear objeto granja
        Granja granja = new Granja(
            dineroInicial,
            numEmpleados,
            sueldoEmpleado,
            mesesSimular,
            numFilas,
            numColumnas
        );

        bool continuar = true;

        // Ciclo principal del programa
        while (continuar &&  granja.ObtenerMesesRestantes() > 0 && granja.ObtenerDinero() > 0)
        {
            granja.MostrarResumenRapido();

            Console.WriteLine("1. Sembrar");
            Console.WriteLine("2. Regar parcela");
            Console.WriteLine("3. Consultar parcela");
            Console.WriteLine("4. Avanzar mes");
            Console.WriteLine("5. Salir");

            int opcion;

            // Validar opción del menú
            while (true)
            {
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion) && opcion >= 1 && opcion <= 5)
                {
                    break;
                }

                Console.WriteLine("Opción inválida.");
            }

            // Ejecutar opción seleccionada
            if (opcion == 1)
                granja.Sembrar();

            else if (opcion == 2)
                granja.RegarParcela();

            else if (opcion == 3)
                granja.ConsultarParcela();

            else if (opcion == 4)
                granja.AvanzarMes();

            else
                continuar = false;
        }

        // Mostrar motivo del final
        Console.WriteLine();

        if (granja.ObtenerDinero() <= 0)
            Console.WriteLine("La granja quedó sin dinero.");

        else if (granja.ObtenerMesesRestantes() <= 0)
            Console.WriteLine("Se completaron todos los meses.");

        else
            Console.WriteLine("Simulación finalizada por el usuario.");

        // Mostrar reporte final
        granja.MostrarReporte();

        Console.WriteLine("Presione una tecla para cerrar...");
        Console.ReadKey();
    }
}