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

            txtCod.Clear();
            txtNom.Clear();
            txtCant.Clear();
            txtDesc.Clear();
            txtPrecio.Clear();
            cmbCatBusca.Text = "";

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nuevo.CargarCombo(cmbCatMod);
        }

        private void cmbCatMod_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemM;

            itemM = cmbCatMod.Text;
            nuevo.LlenarTabla2(dgvTablaMod, itemM);
            Contar(dgvBusca);

            txtBuscar.Clear();
        }

        private void btnBuscaM_Click(object sender, EventArgs e)
        {
            string item;
            item = txtNomM.Text;
            nuevo.LlenarTabla3(dgvTablaMod, item);

        }


        private void dgvTablaMod_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTablaMod.CurrentRow != null) // Verifica si hay una fila seleccionada
            {
                // Obtener la fila seleccionada actualmente
                DataGridViewRow fila = dgvTablaMod.CurrentRow;

                // Obtener los valores de las celdas de la fila seleccionada
                int cod = Convert.ToInt32(fila.Cells["Codigo"].Value); // Cambia "ID" por el nombre de tu columna
                string nombre = fila.Cells["Nombre"].Value.ToString(); // Cambia "Nombre" por el nombre de tu columna
                string desc = fila.Cells["Descripcion"].Value.ToString();
                int precio = Convert.ToInt32(fila.Cells["Precio"].Value); // Cambia "Precio" por el nombre de tu columna
                int cant = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                string cat = fila.Cells["Categoria"].Value.ToString();

                // Mostrar los valores en la consola o utilizarlos según sea necesario
                txtCodM.Text = cod.ToString();
                txtNomM.Text = nombre;
                txtDescM.Text = desc;
                txtPreM.Text = precio.ToString();
                txtCantM.Text = cant.ToString();
                cmbCatMod.Text = cat;
            }
        }
    }
}
