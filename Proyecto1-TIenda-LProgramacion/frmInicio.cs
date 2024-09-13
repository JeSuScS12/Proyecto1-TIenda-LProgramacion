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
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        //Instanciar la conexion
        conexion nuevo = new conexion();

        private void frmInicio_Load(object sender, EventArgs e)
        {
            nuevo.LlenarTablaControlStock(dgvTabla);
        }

        private void dgvTabla_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvTabla.Columns[e.ColumnIndex].Name == "Cantidad")
            {
                if (Convert.ToInt32(e.Value) <= 20)
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.Orange;

                    if (Convert.ToInt32(e.Value) <= 10)
                    {
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.BackColor = Color.Red;
                    }
                }

            }
        }
    }
}
