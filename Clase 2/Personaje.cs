using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJEMPLO2
{
    public class Personaje
    {
        private const string mensajeDerrota = "Claramente te deje ganar. La próxima, no vas a tener chances";   //variables constantes. Nunca cambian
        private const string mensajeVictoria = "Che que faaaaaaaaaaacil ganar,facilito eh";                    //variables constantes. Nunca cambian
        public const string mensajeFinal = "Gracias por jugar ;)";                                     //variables constantes. Nunca cambian

        public int vida;                         //atributos de instancia
        public string nombre;                    //atributos de instancia
        public bool tieneArmadura;              //atributos de instancia
        public bool esHeroe;                    //atributos de instancia


        private static string escenarioActual = " Primera Batalla";       // atributo ESTATICO


        /// En este metodo, se mostrará la infomacion por consola del jugador que haya LLAMADO a este metodo.
        /// RECUERDEN: Metodo o funcion ,es la misma cosa. 
        public void MostrarInformacionPersonaje() // metodo de instancia
        {
            #region Explicacion palabra THIS
            /*
               La palabra reservada THIS hace referencia al OBJETO que llamo la funcion.
                por lo tanto, si la llamo jugador1, el "this" es como si hubieramos escrito jugador1.
               Cuando escribimos this.vida  hacemos referencia a la variable VIDA del jugador 1. 
             
             */
            #endregion

            Console.WriteLine("Vida: " + this.vida);
            Console.WriteLine("Nombre: " + this.nombre);

            if (this.tieneArmadura)
                Console.WriteLine("Tiene armadura");
            else
                Console.WriteLine(" No tiene armadura");


            if (this.esHeroe)
                Console.WriteLine("SALVANOS!! SOS NUESTRO HEROE");
            else
                Console.WriteLine(" JUIIRA VILLANO! FUCHI");

            Console.WriteLine(""); //hago una linea en blanco
        }


        /// le recargo vida al jugador que llamo a este metodo
        public void Sanar(int vida) // metodo de instancia
        {
            #region Explicacion palabra THIS
            /*
                  Como dije en el metodo MostrarInformacion(), cuando usamos THIS estamos haciendo referencia
                  a la informacion del OBJETO que llamo al metodo
                  En este caso, this.vida es lo que contenia  el atributo  VIDA del objeto,  mientras que VIDA sin THIS es el parametro.
     
                 Aclaracion:    this.vida += vida;              es igual a escribir          this.vida = this.vida + vida;
            */

            #endregion

            this.vida += vida;
            Console.WriteLine("Nueva vida del jugador que se curo: " + this.vida);
        }


        /// Muestra el nivel actual. Es un metodo GETTER
        public static void MostrarNivel()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("Nivel actual " + Personaje.escenarioActual);
            Console.WriteLine("*****************************************");

        }

        /// cambio de nivel. Es un metodo SETTER
        public static void CambiarNivel(string nuevoNivel)
        {
            Personaje.escenarioActual = nuevoNivel;  // modifico el atributo ESTATICO escenarioActual para cargar uno nuevo.
            Personaje.MostrarNivel();
        }

        public void msjVictoria()
        {
            Console.WriteLine("\n El nuevo campeón es  " + this.nombre + " y declara: " + Personaje.mensajeVictoria);
        }

        public void msjDerrota() 
        {
            Console.WriteLine("\n El derrotado es  " + this.nombre + " y declara: " + Personaje.mensajeDerrota);
        }


    }
}
