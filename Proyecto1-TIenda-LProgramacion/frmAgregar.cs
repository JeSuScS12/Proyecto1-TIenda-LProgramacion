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
    public partial class frmAgregar : Form
    {
        public frmAgregar()
        {
            InitializeComponent();
            nuevo.CargarCombo(cmbCategoria);
        }

        //Instanciar la conexion
        conexion nuevo = new conexion();

        private void frmAgregar_Load(object sender, EventArgs e)
        {
            nuevo.LlenarTabla(dgvTabla);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int cod = Convert.ToInt32(txtCod.Text);
            string nom = txtNom.Text;
            string desc = txtDesc.Text;
            int precio = Convert.ToInt32(txtPrecio.Text);
            int cant = Convert.ToInt32(txtCant.Text);
            string categ = cmbCategoria.Text;

            nuevo.CargaProducto(cod, nom, desc, precio, cant, categ);
            nuevo.LlenarTabla(dgvTabla);

            txtCod.Clear();
            txtNom.Clear();
            txtCant.Clear();
            txtDesc.Clear();
            txtPrecio.Clear();
            cmbCategoria.Text = "";
        }
    }
}
