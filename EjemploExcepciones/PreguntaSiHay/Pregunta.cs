using System;

namespace PreguntaSiHay
{
    class Pregunta
    {

        static bool noHayTe;

        static Pregunta()
        {
            Console.WriteLine("Lucas entra a un café con ganas de tomar un tecito. \n");
            noHayTe = false;
        }

        public static bool LucasPreguntaAlMozoSiHayTeDeVainilla()
        {
            try
            {
                Console.WriteLine("Lucas pregunta si hay té al mozo uno \n");
               
                Pregunta.PreguntaAlMozoSiHayTeDeVainilla();
                return true;
            }
            catch (Exception Ex_3)
            {
                // Exception es la Ex_3 es la que falló en el catch de PreguntaAlMozoSiHayTeDeVainilla() 
                // Aquí estoy creando una excepcion personalizada enviando por parametro la excepcion anterior

                throw new NoHayTeException("Lucas recibe la noticia. Es una noche dificil", Ex_3);
            }

        }
        public static bool PreguntaAlMozoSiHayTeDeVainilla()
        {
            try
            {
                Console.WriteLine("Mozo uno no sabe si hay. Pregunta al mozo dos \n");
           
                return Pregunta.MozoPreguntaAlOtroMozoSiHayTeDeVainilla();
            }
            catch (Exception Ex_2)
            {

                // Exception es la Ex_2 es la que falló en el catch de MozoPreguntaAlOtroMozoSiHayTeDeVainilla()
                // Aquí creando una excepcion personalizada enviando por parametro la excepcion anterior
                throw new NoHayTeException("Mozo uno dijo que el mozo dos dijo que no hay", Ex_2);
            }
        }
    

        public static bool MozoPreguntaAlOtroMozoSiHayTeDeVainilla()
        {

            try
            {
                Console.WriteLine("Mozo dos no se acuerda, así que corre desesperado a preguntarle al cheff. \n");
              
                return Pregunta.SegundoMozoPreguntaAlCheffSiHayTeDeVainilla(); 
            }
            catch (Exception Ex_1)
            {

                // Exception es la Ex_1 es la que falló  en el metodo SegundoMozoPreguntaAlCheffSiHayTeDeVainilla.
                // Estoy creando una excepcion personalizada enviando por parametro la excepcion anterior

                throw new NoHayTeException("El mozo dos dijo que el cheff dijo que no hay ", Ex_1); // 
            }
        }

        public static bool SegundoMozoPreguntaAlCheffSiHayTeDeVainilla()
        {
            Console.WriteLine("El mozo dos pregunta al cheff si hay \n");
            if(Pregunta.noHayTe == false)
            {
                Console.WriteLine("Parece que comienza la debacle de Lucas... NO HAY! ");
                
                // Lanzo mi excepcion personalizada. 
                throw new NoHayTeException("Cheff: No hay. Justo ese no. Hay 30 diferentes, pero justo ese no...");
            }
            return true;
        }

      


    }
}
