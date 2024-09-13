using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_TIenda_LProgramacion
{
    public partial class frmPrim : Form
    {
        public frmPrim()
        {
            InitializeComponent();
        }    


        //Instanciar la conexion
        conexion nuevo = new conexion();

        private void frmPrim_Load(object sender, EventArgs e)
        {
            AbrirFrm(new frmInicio());
        }

        //Funcion para abrir formulario en el principal
        private void AbrirFrm(object frmHijo)
        {
            if(this.panelConte.Controls.Count > 0)
            {
                this.panelConte.Controls.RemoveAt(0);
            }

            Form frm = frmHijo as Form;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            this.panelConte.Controls.Add(frm);
            this.panelConte.Tag = frm;
            frm.Show();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            AbrirFrm(new frmInicio());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            AbrirFrm(new frmBuscar());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirFrm(new frmAgregar());
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            AbrirFrm(new frmModificar());
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Te lo devo","😊");
        }
    }
}
