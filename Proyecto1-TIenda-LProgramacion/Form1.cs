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
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
