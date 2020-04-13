using System;
using System.Windows.Forms;
using Entidades;
using Estacionamiento_Forms.Properties;
namespace Estacionamiento_Forms
{
    public partial class MenuPrincipal : Form
    {
        Estacionamiento instanciaEstacionamiento;

        ConfigurarEstacionamiento config_estacionamiento;
        FormAuto frm_auto;
        public MenuPrincipal()
        {
            InitializeComponent();
        }
        public MenuPrincipal(string nombre, int capacidadEstacionamiento, double precioXAuto) : this()
        {
            instanciaEstacionamiento = new Estacionamiento(nombre, capacidadEstacionamiento, precioXAuto);
        }

        public MenuPrincipal(Estacionamiento unEstacionamiento) : this()
        {
            instanciaEstacionamiento = unEstacionamiento;
        }



       

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            config_estacionamiento = new ConfigurarEstacionamiento(instanciaEstacionamiento);
            config_estacionamiento.Show();
            this.Hide();
        }

        private void agregarAutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_auto = new FormAuto(instanciaEstacionamiento);
            frm_auto.ShowDialog();

            if (frm_auto.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("El auto fue agregado satisfactoriamente",
                                             "Confirmacion",
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Information);
            }
            else if(frm_auto.DialogResult == DialogResult.No)
            {

                MessageBox.Show("Error. El auto ya existe. \nCompruebe los datos e intente nuevamente",
                                "ERROR",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            else if(frm_auto.DialogResult == DialogResult.Abort)
            {
                MessageBox.Show("Error. No hay más espacio disponible en el estacionamiento",
                                        "ERROR",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
            }
            this.CargarTabla();
        }
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Settings.Default.HiddenMessage.ToString(),
                            Settings.Default.HiddenMessage2.ToString(),
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information); 
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            this.CargarTabla();

        }

        private void CargarTabla()
        {
            dataGrid_ListaAutos.Rows.Clear();
            int fila = 0;
            foreach (Auto autoAux in instanciaEstacionamiento.RetornarArrayAutos())
            {
                if (!(autoAux is null))
                {
                    fila = dataGrid_ListaAutos.Rows.Add();
                    dataGrid_ListaAutos.Rows[fila].Cells[0].Value = autoAux.GetPatente();
                    dataGrid_ListaAutos.Rows[fila].Cells[1].Value = autoAux.GetDniDueño();
                    dataGrid_ListaAutos.Rows[fila].Cells[2].Value = autoAux.GetMarca();
                    dataGrid_ListaAutos.Rows[fila].Cells[3].Value = autoAux.GetCantidadPuertas();
                }
            }
        }
    }
}
