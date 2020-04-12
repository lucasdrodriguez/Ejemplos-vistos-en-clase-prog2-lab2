using System.Linq;
using System.Text;

namespace Entidades
{
    public class Estacionamiento
    {
        private string nombreEstacionamiento;
        private Auto[] arrayDeAuto;
        private double precioXAuto;
    
        public Estacionamiento(string estacionamiento, int capacidadEstacionamiento, double precioXAuto) : this(capacidadEstacionamiento)
        {
            this.nombreEstacionamiento = estacionamiento;
            this.precioXAuto = precioXAuto;
        }
        private Estacionamiento(int capacidadEstacionamiento)
        {
            this.arrayDeAuto = new Auto[capacidadEstacionamiento];
        }


        public string RetornarNombre()
        {
            return this.nombreEstacionamiento;
        }

        public int tieneCapacidadLibre()
        {
            int contador = 0;
            for (int i = 0; i < this.arrayDeAuto.Length; i++)
            {
                if (this.arrayDeAuto[i] is null)
                { 
                    contador++;
                  
                }
            }
            return contador;
        }

        public string MostrarEstacionamiento()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"\nNombre estacionamineto: {this.nombreEstacionamiento}");
            sb.AppendLine($"Capacidad estacionamineto: {this.tieneCapacidadLibre()} lugares libres de {this.arrayDeAuto.Length}");
            sb.AppendLine($"Precio por auto: {this.precioXAuto}");
            sb.AppendLine($"\nInformacion de los autos:");
            foreach (Auto item in this.arrayDeAuto)
            {
                if(!(item is null))
                {
                    sb.AppendLine($"**************************");
                    sb.AppendLine($" {item.GetInformacion()}");
                    sb.AppendLine($"**************************\n");
                }
            }
           

            return sb.ToString();
        }

        public static bool operator ==(Estacionamiento estacionamiento, Auto auto)
        {
            bool existe = false;

                for (int i = 0; i < estacionamiento.arrayDeAuto.Length; i++)
                {
                    if (!(estacionamiento.arrayDeAuto[i] is null))
                    {
                        if (estacionamiento.arrayDeAuto[i] == auto)
                        {
                            existe = true;//
                            break;
                        }
                    }
                }
       
            return existe;
        }
        public static bool operator !=(Estacionamiento estacionamiento, Auto auto)
        {
            return ! (estacionamiento == auto);
        }
        public static bool operator +(Estacionamiento estacionamiento, Auto auto)
        {
            bool agrego = false;

            if(estacionamiento != auto)
            {
                for (int i = 0; i < estacionamiento.arrayDeAuto.Length; i++)
                {
                    if(estacionamiento.arrayDeAuto[i] is null)//si no hay ningún auto.
                    {
                        estacionamiento.arrayDeAuto[i] = auto;//agrego el auto al array.
                        agrego = true;//pudo agregarlo.
                        break;
                    }
                }   
            }
            return agrego;
        }
        public static implicit operator Estacionamiento(int capacidad)
        {
            return new Estacionamiento(capacidad);
        }

        //crear metodo capacidad libre

    }
}
