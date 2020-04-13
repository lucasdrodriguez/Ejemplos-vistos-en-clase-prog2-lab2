using Entidades;
using System;

using System.Drawing;
using System.Windows.Forms;

namespace Estacionamiento_Forms
{
    public partial class FormAuto : Form
    {
        MenuPrincipal menuPrincipal;
        Estacionamiento estacionamiento;

        public FormAuto()
        {
            InitializeComponent();
        }

        public FormAuto(Estacionamiento estacionamiento) : this()
        {
            this.estacionamiento = estacionamiento;
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            if (Validaciones.ValidarCargaEnteroForms(txt_Dni.Text,999999999,1000000) 
                                    && Validaciones.ValidarCargaStringForms(txt_patente.Text)
                                    && Validaciones.ValidarCargaStringForms(txt_marca.Text)
                                    && Validaciones.ValidarCargaEnteroForms(txt_cantpuertas.Text,5,1))
            {
                if (estacionamiento.tieneCapacidadLibre() > 0)
                {
                    if (estacionamiento + Auto.CrearAuto(txt_patente.Text, txt_marca.Text, int.Parse(txt_cantpuertas.Text), int.Parse(txt_Dni.Text)))
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.No;
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.Abort;
                }

            }
            else
            {
                lb_error.ForeColor = Color.DarkRed;
                lb_error.Text = "Al menos uno de los datos es invalido";
            }

        }

     

        private void VolverAlMenuPrincipal()
        {
            menuPrincipal = new MenuPrincipal(estacionamiento);
            menuPrincipal.Show();
            this.Hide();
        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.VolverAlMenuPrincipal();
        }
    }
}
