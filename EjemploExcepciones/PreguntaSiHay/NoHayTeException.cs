using System;


namespace PreguntaSiHay
{
    class NoHayTeException : Exception   // heredo de Exception para usar sus constructores
    {

        /// <summary>
        ///  Constructor de mi clase NoHayTeException
        /// </summary>
        /// <param name="mensaje"> paso por constructor, el mensaje personalizado que creé antes.  </param>
        /// <param name="e">      tambien le paso parametrizado el objeto Exception.   </param>
        public NoHayTeException(string mensaje, Exception e) : base(mensaje, e)
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensaje"> paso por constructor, el mensaje personalizado que creé antes.  </param>
        public NoHayTeException(string mensaje) : base(mensaje)
        {

        }
    }
}

