using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace Proyecto1_TIenda_LProgramacion
{
    internal class conexion
    {
        OleDbCommand comando;
        OleDbConnection conectar;
        OleDbDataAdapter adaptador;

        string cadena;

        public conexion()
        {
            cadena = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=./Pyt1-Tienda.accdb";
        }

        public void Conect()
        {
            try
            {
                conectar = new OleDbConnection(cadena);
                conectar.Open();
                MessageBox.Show("Se conecto a BD");
            }
            catch (Exception x)
            {
                MessageBox.Show("Error" + x, "😒");
            }
        }

        public void LlenarTabla(DataGridView tab)
        {
            conectar = new OleDbConnection(cadena);
            try
            {
                conectar.Open();
                string consulta = "SELECT * FROM Productos";

                adaptador = new OleDbDataAdapter(consulta, conectar);
                DataTable dataTable = new DataTable();

                adaptador.Fill(dataTable);
                tab.DataSource = dataTable;

            }
            catch(Exception error)
            {
                MessageBox.Show("Error"+error);
            }
        }

    }
}
