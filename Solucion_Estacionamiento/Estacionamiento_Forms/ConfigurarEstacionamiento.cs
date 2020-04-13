using System;
using System.Drawing;
using System.Windows.Forms;
using Entidades;

namespace Estacionamiento_Forms
{
    public partial class ConfigurarEstacionamiento : Form
    {
        bool primeraCarga;
        MenuPrincipal menuPrincipal;
        Estacionamiento estacionamiento;
        public ConfigurarEstacionamiento()
        {
            primeraCarga = true;
            InitializeComponent();
        }
        public ConfigurarEstacionamiento(Estacionamiento estacionamiento)
        {
            this.estacionamiento = estacionamiento;
            primeraCarga = false;
            InitializeComponent();
        }


        private void ConfigurarEstacionamiento_Load(object sender, EventArgs e)
        {

            if (!primeraCarga)
            {

                lbl_informacion.Text = "Modifique la información que necesite de su estacionamiento";
                bt_aceptar.Text = "Modificar";
                bt_cancelar.Enabled = true;
                txt_nombre.Text = estacionamiento.RetornarNombre();
                txt_capacidad.Text = estacionamiento.RetornarCapacidad().ToString();
                txt_capacidad.Enabled = false;
                txt_precio.Text = estacionamiento.RetornarPrecio().ToString();
            }
            else
            {
                lbl_informacion.Text = "Ingrese la información de su estacionamiento";
            }

        }

        private void Aceptar_Modificar_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txt_nombre.Text)) && Validaciones.ValidarCargaDoubleForms(txt_precio.Text, double.MaxValue, 0) && Validaciones.ValidarCargaEnteroForms(txt_capacidad.Text, int.MaxValue, 0))
            {
                lb_error.Text = "";
                if (primeraCarga)
                {
                    menuPrincipal = new MenuPrincipal(txt_nombre.Text, int.Parse(txt_capacidad.Text), double.Parse(txt_precio.Text));
                }
                else
                {
                    estacionamiento.SetearNombre(txt_nombre.Text);
                    estacionamiento.SetearPrecio(double.Parse(txt_precio.Text));
                    menuPrincipal = new MenuPrincipal(estacionamiento);
                }
                menuPrincipal.Show();
                this.Hide();
            }
            else
            {
                lb_error.ForeColor = Color.DarkRed;
                lb_error.Text = "Al menos uno de los datos es invalido";
            }

        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.VolverAlMenuPrincipal();
        }

        private void ConfigurarEstacionamiento_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!primeraCarga)
            {
                e.Cancel = true;
                this.VolverAlMenuPrincipal();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void VolverAlMenuPrincipal()
        {
            menuPrincipal = new MenuPrincipal(estacionamiento);
            menuPrincipal.Show();
            this.Hide();
        }
    }
}
