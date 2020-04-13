using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auto
    {
        private string patente;
        private string marca;
        private int cantidadPuertas;
        private int dniDueño;

        #region Constructores
        //con el this le damos prioridad
        public Auto(string pPatente, string pMarca, int pCantidadPuertas, int pDniDueño) : this(pPatente, pDniDueño)
        {
            this.marca = pMarca;
            this.cantidadPuertas = pCantidadPuertas;
        }

        public Auto(string pPatente, int pDniDueño) : this()
        {
            this.patente = pPatente;
            this.dniDueño = pDniDueño;
        }

        private Auto()
        {
            this.marca = "Dato no ingresado";
            this.cantidadPuertas = -1;
        }
        #endregion

        #region Métodos
        public string GetInformacion()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Patente: " + this.patente);
            sb.AppendLine("Marca: " + this.marca);
            sb.AppendLine("Cantidad de puertas: " + this.cantidadPuertas);
            sb.AppendLine("Dni del dueño: " + this.dniDueño);

            return sb.ToString();
        }
        public string GetPatente()
        {
            return this.patente;
        }
        public string GetMarca()
        {
            return this.marca;
        }
        public int GetCantidadPuertas()
        {
            return this.cantidadPuertas;
        }
        public int GetDniDueño()
        {
            return this.dniDueño;
        }


        public void SetInformacion(int pCantidadPuertas)
        {
            this.cantidadPuertas = pCantidadPuertas;
        }

        public void SetInformacion(string pMarca)
        {
            this.marca = pMarca;
        }

     
        #endregion

        #region Operaciones
        public static bool operator ==(Auto autoA, Auto autoB)
        {
            return autoA.patente == autoB.patente;
        }

        public static bool operator !=(Auto autoA, Auto autoB)
        {
            return !(autoA == autoB);
        }
        #endregion

        public static Auto CrearAuto(string patente, string marca, int cantidadPuertas, int dniDueño)
        {
            return new Auto(patente, marca, cantidadPuertas, dniDueño);
        }

    }
}
