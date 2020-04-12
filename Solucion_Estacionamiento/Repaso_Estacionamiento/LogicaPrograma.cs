using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Repaso_Estacionamiento
{
    public static class LogicaPrograma
    {

        private static Estacionamiento instanciaEstacionamiento;

        static LogicaPrograma()
        {
            instanciaEstacionamiento = LogicaPrograma.CrearEstacionamiento();
        }

        public static void Iniciar()
        {
            do
            {
                Console.Clear();
                MostrarMenu();

            } while (!seleccionarOpcion());

            LogicaPrograma.Continuar("Nos vemos pronto!! \n Presione una tecla para finalizar");
        }

        public static Estacionamiento CrearEstacionamiento()
        {
            string nombre = string.Empty;
            int capacidad = 0;
            double precio = 0;

            Menues.MostrarCabecera("**Alta inicial Estacionamiento **", '*');

            Console.WriteLine("\nIngresar nombre estacionamiento");
            nombre = Validaciones.ValidarCargaString(Console.ReadLine(), "Error,reingrese un nombre valido para su estacionamiento");

            Console.WriteLine("\ningresar capacidad del estacionamiento");
            capacidad = Validaciones.ValidarCargaEntero(Console.ReadLine(), "Error,capacidad no valida.Maximo 100 ", 100, 1);

            Console.WriteLine("\ningresar precio del estacionamiento");
            precio = Validaciones.ValidarCargaDouble(Console.ReadLine(), "Error,numero no valido");

            return new Estacionamiento(nombre, capacidad, precio);

        }

        public static void MostrarMenu()
        {
           Console.ForegroundColor = ConsoleColor.;
           Console.WriteLine("******************************************************************************");
           Console.WriteLine($"BIENVENIDOS AL ESTACIONAMIENTO : {instanciaEstacionamiento.RetornarNombre().ToUpper()}");
           Console.WriteLine("******************************************************************************");
           Console.ResetColor();
           Console.WriteLine($"\nSeleccione una opcion para continuar\n");
           Console.WriteLine(" 1. Ver informacion total del estacionamiento");
           Console.WriteLine(" 2. Agregar nuevo auto");
           Console.WriteLine(" 3. Salir");
        }

        public static void Continuar(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.ReadKey();
            Console.Clear();
        }

        public static bool seleccionarOpcion()
        {
            bool salir = false;
            bool opcionIncorrecta = false;
            do
            {
                switch (Console.ReadLine().Trim())
                {
                    case "1":
                        Console.Clear();
                        Menues.MostrarCabecera("1. informacion total del estacionamiento ", '*');
                        Console.WriteLine(instanciaEstacionamiento.MostrarEstacionamiento());
                        LogicaPrograma.Continuar("Presione una tecla para continuar");
                        opcionIncorrecta = false;
                        break;
                    case "2":
                        Console.Clear();
                        Menues.MostrarCabecera("2. Agregar auto ", '*');
                        LogicaPrograma.AgregarAutoAlEstacionamiento();
                        LogicaPrograma.Continuar("Presione una tecla para continuar");
                        opcionIncorrecta = false;
                        break;

                    case "3":
                        salir = LogicaPrograma.Salir("Desea salir del programa?");
                        opcionIncorrecta = false;
                        break;
                    default:
                        Console.WriteLine("opcion incorrecta, por favor reingrese");
                        opcionIncorrecta = true;
                        break;
                }
            } while (opcionIncorrecta);

            return salir;
        }

        private static bool Salir(string mensaje)
        {
            if (Validaciones.ValidarSioNo(mensaje))
            {
                return true;
            }
            return false;
        }

        private static Auto CrearAuto()
        {
            string patente = string.Empty;
            string marca = string.Empty;
            int cantidadPuertas = 0;
            int dniDueño = 0;

            Console.WriteLine("Ingresar patente auto");
            patente = Validaciones.ValidarCargaString(Console.ReadLine(), "Error,reingrese un nombre valido para la patente");

            Console.WriteLine("ingresar DNI dueño ");
            dniDueño = Validaciones.ValidarCargaEntero(Console.ReadLine(), "Error,dni no valido. Debe estar entre 999.999.999 y 1.000.000 ", 999999999, 1000000);

            if (LogicaPrograma.Salir("\n\n ¿Desea ingresar marca y cantidad de puertas?"))
            {
                Console.WriteLine("\nIngresar marca auto");
                marca = Validaciones.ValidarCargaString(Console.ReadLine(), "Error,reingrese un nombre valido para la marca");

                Console.WriteLine("ingresar cantidad de puertas del estacionamiento");
                cantidadPuertas = Validaciones.ValidarCargaEntero(Console.ReadLine(), "Error,cantidad de puertas no valida", 5, 2);

                return new Auto(patente, marca, cantidadPuertas, dniDueño);
            }

            return new Auto(patente, dniDueño);
        }

        private static void AgregarAutoAlEstacionamiento()
        {
            if (instanciaEstacionamiento.tieneCapacidadLibre() > 0)
            {
                if (instanciaEstacionamiento + LogicaPrograma.CrearAuto())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nAuto agregado perfectamente!\n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nEl auto no ha podido ser agregado porque ya existe\n");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nEl auto no ha podido ser agregado porque no hay capacidad en el Estacionamiento\n");
            }

            Console.ResetColor();
        }

    }
}
