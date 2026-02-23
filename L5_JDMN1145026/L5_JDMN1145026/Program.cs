// See https://aka.ms/new-console-template for more information
using System;
using System.ComponentModel.Design;
using System.Xml;
class Program
{
    static void Main()
    {
        //Ejercicio 1
        string id1;
        string pin1;
        string token1;
        string mdseguro1;
        int id11;
        Console.WriteLine("Ejercicio 1:Panel de Acceso Numérico (Usuario + PIN + Modo seguro)");

        //ID de usuario
        Console.WriteLine("Ingrese el ID de Usuario");
        id1 = Console.ReadLine();
        id11=int.Parse(id1);
        if (id11==2026)
            {
            Console.WriteLine("Usuario reconocido");

            }
        else
            {
            Console.WriteLine("Usuario no reconocido");
            }

        //Pin de usuario
        Console.WriteLine("Ingrese el pin de usuario");
        pin1 = Console.ReadLine();
        int pin11 = int.Parse(pin1);
        if (pin11 == 1234)
            {
            Console.WriteLine("PIN correcto");

            }
        else
            {
            Console.WriteLine("PIN incorrecto");
            }

        //Token de seguridad
        Console.WriteLine("Ingrese el token de seguridad");
        token1 = Console.ReadLine();
        int token11 = int.Parse(token1);
        if (token11 == 777)
            {
            Console.WriteLine("Token válido");

            }
        else
            {
            Console.WriteLine("Token Inválido");
            }

        //Modo seguro
        Console.WriteLine("Modo seguro activado?");
        bool mdseguro11;
        mdseguro1=Console.ReadLine();
        if (mdseguro1.ToLower() == "si") 
            {
            mdseguro11 = true;
            }
        else
            {
            mdseguro11 = false;
            }
        if (mdseguro11 == true)
            {
            Console.WriteLine("Modo seguro activado: se aplican reglas extra.");
            if(token11>700)
            { 
                Console.WriteLine("Regla extra aprobada");
            }
            else
            {
                Console.WriteLine("Regla extra fallida");
            }
            }
        else
            { 
            Console.WriteLine("Modo seguro desactivado.");
            }

        //Acceso
        if(id11==2026&&pin11==1234&&token11==777)
            {
            Console.WriteLine("Acceso total concedido.");
            }
        else
            {
            Console.WriteLine("Acceso denegado");
            }


        //Ejercicio 2
        string pin2;
        int pin22;
        Console.WriteLine("");
        Console.WriteLine("Ejercicio 2: Validador de PIN Inteligente (Módulos y rangos)");
        Console.WriteLine("Ingrese el PIN");
        pin2 = Console.ReadLine();
        pin22 = int.Parse(pin2);
        if (pin22 >= 1000 && pin22<=9999)
        {
            Console.WriteLine("PIN de 4 digitos: OK");
        }
        else
        {
            Console.WriteLine("PIN inválido:debe tener 4 dígitos");
        }
        if (pin22 % 2 == 0)
        {
            Console.WriteLine("PIN par.");
        }
        else
        {
            Console.WriteLine("PIN impar");
        }
        if (pin22 % 5 == 0)
        {
            Console.WriteLine("Multiplo de 5.");
        }
        else
        {
            Console.WriteLine("No es multiplo de 5");
        }
        if(pin22 >= 1000 && pin22 <= 9999 && pin22 % 5 == 0 && pin22 % 2 == 0)
        {
            Console.WriteLine("PIN aceptado por la politica.");
        }
        else
        {
            Console.WriteLine("PIN rechazado por la politica.");
        }


        //Ejercicio 3
        Console.WriteLine("");
        Console.WriteLine("Ejercicio 3: Activación de Cuenta (Booleans + decisión final)");
        string edad3;
        int edad31;
        string terminos;
        int terminos3;
        string ver2pasos;
        int ver2pasos3;
        string pjver;
        int pjver3;
        string codAc;
        int codAc3;
        Console.WriteLine("Ingrese el codigo de activacion");
        codAc =Console.ReadLine();
        codAc3 = int.Parse(codAc);
        if(codAc3 == 2026)
        {
            Console.WriteLine("Codigo correcto");
        }
        else
        {
            Console.WriteLine("Codigo incorrecto");
        }
        Console.WriteLine("Ingrese la edad");
        edad3 =Console.ReadLine();
        edad31 = int.Parse(edad3);
        if(edad31 >= 18)
        {
            Console.WriteLine("Edad valida");
        }
        else
        {
            Console.WriteLine("Edad no valida");
        }
        Console.WriteLine("Acepta los terminos y condiciones? (1/0)");
        terminos =Console.ReadLine();
        terminos3=int.Parse(terminos);
        if(terminos3 == 1)
        {
            Console.WriteLine("Terminos aceptados.");
        }
        else
        {
            Console.WriteLine("Debe aceptar terminos");
        }
        Console.WriteLine("Activar 2FA? (1/0)");
        ver2pasos =Console.ReadLine();
        ver2pasos3 =int.Parse(ver2pasos);
        if (ver2pasos3 == 1)
        {
            Console.WriteLine("2FA activado");
        }
        else
        {
            Console.WriteLine("2FA no activado");
        }
        Console.WriteLine("Ingrese su puntaje del 1-100");
        pjver =Console.ReadLine();
        pjver3 =int.Parse(pjver);
        if (pjver3 >= 70 && pjver3<=100)
        {
            Console.WriteLine("Puntaje suficiente");
        }
        else
        {
            if (pjver3 <= 100)
            {
                Console.WriteLine("Puntaje insuficiente.");
            }
            else
            {
                Console.WriteLine("Ingrese un puntaje valido");
            }
        }
        if (pjver3 >= 70 && pjver3 <= 100 && ver2pasos3 == 1 && terminos3 == 1 && edad31 >= 18 && codAc3 == 2026)
        {
            Console.WriteLine("Cuenta activada exitosamente");
        }
        else
        {
            Console.WriteLine("Cuenta NO activada");
        }


        //Ejercicio 4
        string notaPrev;
        int notaPrev4;
        string mintarde;
        int mintarde4;
        string solvencia;
        int solvencia4;
        string idf;
        int idf4;
        string calc;
        int calc4;
        Console.WriteLine("");
        Console.WriteLine("Reto Final: Acceso a Sala de Examen(Validaciones múltiples)");

        Console.WriteLine("Ingrese la nota:");
        notaPrev = Console.ReadLine();
        notaPrev4 = int.Parse(notaPrev);
        if (notaPrev4 >= 61)
        {
            Console.WriteLine("Requisito academico aprovado");
        }
        else
        {
            Console.WriteLine("Requisito academico NO aprovado");
        }

        Console.WriteLine("Ingrese los minutos de llegada tarde (puede ser cero)");
        mintarde = Console.ReadLine();
        mintarde4 = int.Parse(mintarde);
        if (mintarde4 <= 10)
        {
            Console.WriteLine("Hora valida");
        }
        else
        {
            Console.WriteLine("Llegada fuera de tiempo");
        }

        Console.WriteLine("¿Tiene solvencia de pagos? (1/0).");
        solvencia=Console.ReadLine();
        solvencia4 = int.Parse(solvencia);
        if (solvencia4 == 1)
        {
            Console.WriteLine("Solvencia Validada");
        }
        else
        {
            Console.WriteLine("Sin solvencia");
        }

        Console.WriteLine("¿Trae identificación física? (1/0).");
        idf = Console.ReadLine();
        idf4 = int.Parse(idf);
        if (idf4 == 1)
        {
            Console.WriteLine("Identificación validada");
        }
        else
        {
            Console.WriteLine("Sin identificación");
        }

        Console.WriteLine("¿Trae calculadora permitida? (1/0).");
        calc=Console.ReadLine();
        calc4 = int.Parse(calc);
        if (calc4== 1)
        {
            Console.WriteLine("Calculadora permitida: OK.");
        }
        else
        {
            Console.WriteLine("Sin calculadora permitida");
        }

        if(idf4 == 1 && solvencia4 == 1 && mintarde4 <= 10 && notaPrev4 >= 61)
        {
            Console.WriteLine("Acceso a la sala de examen permitido");
            if (mintarde4 > 0 && mintarde4 <= 10)
            {
                Console.WriteLine("Advertencia: llego tarde, pero aun puede ingresar");
            }
        }
        else
        {
            Console.WriteLine("Acceso denegado");
        }

    }
}