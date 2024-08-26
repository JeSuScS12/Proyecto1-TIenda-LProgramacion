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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        conexion nuevo = new conexion();

        private void Form1_Load(object sender, EventArgs e)
        {
            nuevo.Conect();
            nuevo.LlenarTabla(dgvTabla);
            nuevo.CargarCombo(cmbCategoria);
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string item;
            item = txtBuscar.Text;
            nuevo.LlenarTabla3(dgvBusca, item);
            
            cmbCatBusca.Text = "";
            item = "";

            Contar(dgvBusca);
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            nuevo.CargarCombo(cmbCatBusca);
        }

        private void cmbCatBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item;
           
            item = cmbCatBusca.Text;
            nuevo.LlenarTabla2(dgvBusca, item);
            Contar(dgvBusca);

            txtBuscar.Clear();
        }

        public void Contar(DataGridView tab )
        {
            int X = tab.RowCount;

            lblCantPro.Text = $"{X-1} productos encontrados";
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            int cod = Convert.ToInt32(txtCod.Text);
            string nom = txtNom.Text;
            string desc = txtDesc.Text;
            int precio = Convert.ToInt32(txtPrecio.Text);
            int cant = Convert.ToInt32(txtCant.Text);
            string categ = cmbCategoria.Text;

            nuevo.CargaProducto(cod, nom, desc, precio, cant, categ);
            nuevo.LlenarTabla(dgvTabla);

        }
    }
}
