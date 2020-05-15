using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreguntaSiHay
{
    class Program
    {
        static void Main(string[] args)
        {
            string stackTraceTotal = string.Empty;
            try
            {
              

                #region Inicio del proceso
                /*
                 
                 El orden de los metodos será

                1)  LucasPreguntaAlMozoSiHayTeDeVainilla() 
                2)      PreguntaAlMozoSiHayTeDeVainilla()
                3)               MozoPreguntaAlOtroMozoSiHayTeDeVainilla()
                4)                       SegundoMozoPreguntaAlCheffSiHayTeDeVainilla()   -> en el codigo de este metodo va a explotar.
                
                */
                #endregion

                Pregunta.LucasPreguntaAlMozoSiHayTeDeVainilla();

            }
            catch (Exception ex)
            {

                Console.WriteLine("\n\n ************************************************ \n\n");

                Console.WriteLine("Llego el mensaje a lucas ya. Será una noche dificil");


                // Va a mostrar el mensaje lanzado en el metodo anterior
                 
                Console.WriteLine(ex.Message);

                // Para poder acceder a las excepciones que vienen por Inner, hay que llamar a la misma.
                Console.WriteLine(ex.InnerException.Message);

                // aca estoy llamando al mensaje de excepcion EX de la excepcion que esta adentro de la excepcion 
                Console.WriteLine(ex.InnerException.InnerException.Message);

                // La forma correcta seria recorrer las Inner exception. Una forma seria con un while o un doWhile
                
                Console.WriteLine("\n \n Presione una tecla para continuar \n\n");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("**************************** RECORRER INNER EXCEPTION ********************************");
          
     

                while (ex.InnerException != null)
                {
                    //muestro el mensaje de mi inner exception 
                    Console.WriteLine(ex.Message);

                    //Voy concatenando los STACKTRACE para tener informacion de en que proyecto-clase-metodo-linea falló
                    stackTraceTotal += ex.StackTrace.ToString() + "\n";

                    // guardo en EX  la excepcion que tiene adentro (en su inner exception) y vuelvo a repetir el proceso.
                    ex = ex.InnerException;
                }
                Console.WriteLine("\n\n El stack trace total:");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(stackTraceTotal);
                Console.ResetColor();
                   
                // Basicamente en la propiedad InnerException se guarda el Objeto Exception que fue arrojado previamente. 
                

            }

            Console.WriteLine("Lucas se acordó que Fede le habia regalado té de vainilla, así que va a su casa a tomar su té. \n Final feliz");
            Console.ReadKey();

        }
    }
}
