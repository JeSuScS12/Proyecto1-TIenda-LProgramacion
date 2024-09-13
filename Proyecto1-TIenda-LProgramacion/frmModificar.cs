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
    public partial class frmModificar : Form
    {
        public frmModificar()
        {
            InitializeComponent();
            nuevo.LlenarTabla(dgvTabla);
            nuevo.CargarCombo(cmbCategoria);
        }

        //Instanciar la conexion
        conexion nuevo = new conexion();

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemM;

            itemM = cmbCategoria.Text;
            nuevo.LlenarTabla2(dgvTabla, itemM);

            txtNom.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string item;
            item = txtNom.Text;
            nuevo.LlenarTabla3(dgvTabla, item);
        }


        private void dgvTabla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTabla.CurrentRow != null) // Verifica si hay una fila seleccionada
            {
                // Obtener la fila seleccionada actualmente
                DataGridViewRow fila = dgvTabla.CurrentRow;

                // Obtener los valores de las celdas de la fila seleccionada
                int cod = Convert.ToInt32(fila.Cells["Codigo"].Value); // Cambia "ID" por el nombre de tu columna
                string nombre = fila.Cells["Nombre"].Value.ToString(); // Cambia "Nombre" por el nombre de tu columna
                string desc = fila.Cells["Descripcion"].Value.ToString();
                int precio = Convert.ToInt32(fila.Cells["Precio"].Value); // Cambia "Precio" por el nombre de tu columna
                int cant = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                string cat = fila.Cells["Categoria"].Value.ToString();

                aux = Convert.ToInt32(fila.Cells["Codigo"].Value);

                // Mostrar los valores en la consola o utilizarlos según sea necesario
                txtCod.Text = cod.ToString();
                txtNom.Text = nombre;
                txtDesc.Text = desc;
                txtPrecio.Text = precio.ToString();
                txtCant.Text = cant.ToString();
                cmbCategoria.Text = cat;
            }
        }

        int aux;

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int cod = Convert.ToInt32(txtCod.Text);
            string nom = txtNom.Text;
            string des = txtDesc.Text;
            int cant = Convert.ToInt32(txtCant.Text);
            int stock = Convert.ToInt32(txtCant.Text);
            string cat = cmbCategoria.Text;

            //Limpiar aux
            

            nuevo.Modificar(cod, nom, des, cant, stock, cat,aux);
            nuevo.LlenarTabla(dgvTabla);
            aux = 0;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //-----
            int cod = Convert.ToInt32(txtCod.Text);
            //---

            nuevo.Eliminar(cod);
            nuevo.LlenarTabla(dgvTabla);

        }
    }
}
