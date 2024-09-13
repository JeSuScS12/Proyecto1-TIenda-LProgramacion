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
    public partial class frmBuscar : Form
    {
        public frmBuscar()
        {
            InitializeComponent();
        }

        //Instanciar la conexion
        conexion nuevo = new conexion();

        private void frmBuscar_Load(object sender, EventArgs e)
        {
            nuevo.LlenarTabla(dgvTabla);
            nuevo.CargarCombo(cmbCatBusca);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string item;
            item = txtBuscar.Text;
            nuevo.LlenarTabla3(dgvTabla, item);

            cmbCatBusca.Text = "";
            item = "";
            Contar(dgvTabla);

        }

        public void Contar(DataGridView tab)
        {
            int X = tab.RowCount;

            lblCatPro.Text = $"{X} productos";
        }

        private void cmbCatBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBuscar.Text = "";

            string item;
            item = cmbCatBusca.Text;
            nuevo.LlenarTabla2(dgvTabla, item);
            Contar(dgvTabla);

            txtBuscar.Clear();
        }
    }
}
