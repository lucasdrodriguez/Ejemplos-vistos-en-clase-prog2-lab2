using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estacionamiento_Forms
{
    public partial class Login : Form
    {
        ConfigurarEstacionamiento config_estacionamiento;
        public Login()
        {
            InitializeComponent();

        }

        private void bt_login_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(tb_usuario.Text)) && !(string.IsNullOrEmpty(tb_contraseña.Text)))
            {
                if (tb_usuario.Text == "Admin" && tb_contraseña.Text == "admin123")
                {
                    lb_error.Text = "";
                    config_estacionamiento = new ConfigurarEstacionamiento();
                    config_estacionamiento.Show();
                    this.Hide();
                }
                else
                {
                    lb_error.Text = "Acceso denegado. Almenos uno de los datos es incorrecto";
                    lb_error.ForeColor = Color.DarkRed;
                }
            }
            else
            {
                lb_error.Visible = true;
                lb_error.Text = "Campos no pueden ser vacios";
                lb_error.ForeColor = Color.DarkRed;
            }
        }

  
    }
}

