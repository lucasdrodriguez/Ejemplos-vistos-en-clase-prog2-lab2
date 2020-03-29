using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EJEMPLO2
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Explicacion Metodo ESTATICO o DE CLASE MostrarNivel()
            /*Mediante un metodo ESTATICO o DE CLASE, muestro el nivel que esta cargado 
           en la variable estatica "escenarioActual"  en la clase Personaje

         Como nuestro atributo "escenarioActual" es privado ( PRIVATE static string escenarioActual)
         necesitamos acceder a el a traves de una funcion ESTATICA o de CLASE.
         En este caso lo vamos a hacer a traves de la funcion ESTATICA MostrarNivel()

          */
            #endregion

            Personaje.MostrarNivel();


            #region Explicacion Instancia Objetos
            /*
              INSTANCIANDO OBJETOS: Objeto es la instancia de una clase. 
              Considerando que una Clase puede definirse como un MOLDE, podemos entender que un objeto sería 
              cada  "objeto" justamente creado a partir de ese molde.
              Aquí, utilizando el "molde"  Personaje , creo 2 objetos de la clase Personaje. 
              Es decir: DOS INSTANCIAS DE LA CLASE PERSONAJE
           */
            #endregion


            Personaje jugador1 = new Personaje();
            Personaje jugador2 = new Personaje();


            #region Explicacion Carga de valores en las variables de los objetos
            /*
                Ahora voy a cargarle datos a los atributos PUBLICOS de cada objeto.
                Pueden accederse de esta forma porque son PUBLICOS. Es decir, pueden leer (get) y escribir (set) desde otras
                partes del codigo.
                 public class Personaje
                        {

                            PUBLIC int vida;
                            PUBLIC string nombre;
                            PUBLIC bool tieneArmadura;
                            PUBLIC bool esHeroe;
                        }
            
            
            Los atributos publicos pueden leerse y modificarse 
            haciendo "NOMBRE DE LA ISTANCIA DEL OBJETO"."EL ATRIBUTO" ej:  Jugador1.vida
            */

            #endregion

            jugador1.vida = 13;
            jugador1.tieneArmadura = true;
            jugador1.nombre = "El bonachon";
            jugador1.esHeroe = true;

            jugador2.vida = 91;
            jugador2.tieneArmadura = false;
            jugador2.nombre = "El Malote";
            jugador2.esHeroe = false;


           //Hasta acá solo cargamos data. Ahora vamos a empezar a operar con ella.

            Console.WriteLine("INFORMACION JUGADOR 1 \n______________________________________\n");

            #region Explicacion metodo de INSTANCIA MostrarInformacion()
            /*
                Es de INSTANCIA porque necesitamos que su ejecución esté asociada a un determinado JUGADOR.
                Es decir, conceptualmente, jugador1.MostrarInformacion() lo que hará será mostrar la info de ESE jugador
                que está LLAMANDO al metodo
            */

            #endregion
            jugador1.MostrarInformacionPersonaje();


            Console.WriteLine("\n"); // el \n  hace un salto de linea además del propio del WriteLine


            Console.WriteLine("INFORMACION JUGADOR 2 \n______________________________________\n");
            jugador2.MostrarInformacionPersonaje();


            #region Explicacion Metodo ESTATICO o DE CLASE CambiarNivel(string)
            /*
             Nuevamente,mediante un metodo ESTATICO o DE CLASE, procedemos a acceder a la variable
             "escenarioActual" que al igual que antes para leerla en el metodo MostrarNivel(),
             es INACCESIBLE desde esta clase PROGRAM. Por lo cual,necesitamos un metodo SETER
             para poder modificarla. Este metodo será el metodo Estatico    CambiarNivel quien recibe como parametro
             el nombre del nivel al cual se quiere cambiar.

             */
            #endregion

            Personaje.CambiarNivel(" BATALLA FINAL ");


            jugador2.Sanar(100);


            /*
             
             Simulando que el jugador 1 peleo contra el jugador 2 y  gano este ultimo,
             se muestra lo siguiente.
             
             */

           jugador1.msjDerrota();
           jugador2.msjVictoria();



            //muestro la constante PUBLICA. Se muestra IGUAL que un atributo  ESTATICO. Pero recordar que nunca puede modificarse
            // en cambio, si fuera un atributo static, podriamos haberlo modificado como mostramos antes .

            Console.WriteLine("\n \n Mensaje final: " + Personaje.mensajeFinal);  
                                                                                        




            Console.ReadKey(); // pongo esto para que la consola no se cierre. 
        }
    }
}
