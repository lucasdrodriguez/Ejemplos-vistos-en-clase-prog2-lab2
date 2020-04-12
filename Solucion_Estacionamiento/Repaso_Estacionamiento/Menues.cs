using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_Estacionamiento
{
   public static class Menues
    {
        public static void MostrarCabecera(string mensaje,char caracter)
        {
            Console.WriteLine(Menues.DibujarSeparador(caracter,mensaje.Length));
            Console.WriteLine(mensaje);
            Console.WriteLine(Menues.DibujarSeparador(caracter, mensaje.Length));
        }
        private static string DibujarSeparador(char caracter,int tamaño)
        {
            string separador = "";
            for (int i = 0; i <=tamaño; i++)
            {
                separador += caracter;
            }
            return separador;

        }
    }
}
