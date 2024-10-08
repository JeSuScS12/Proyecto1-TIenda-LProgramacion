﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;
using System.Collections;

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
             cadena = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../BD/Pyt1-Tienda.accdb";
        }

        public void Conect()
        {
            try
            {
                conectar = new OleDbConnection(cadena);
                conectar.Open();
            }
            catch (Exception x)
            {
                MessageBox.Show("Error" + x, "😒");
            }
        }

        //Llena la tabla con todos los datos de la BD
        public void LlenarTabla(DataGridView tab)
        {
            conectar = new OleDbConnection(cadena);
            try
            {
                conectar.Open();
                string consulta = "SELECT * FROM Inventario order by Codigo";

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

        public void LlenarTablaControlStock(DataGridView tab)
        {
            conectar = new OleDbConnection(cadena);
            try
            {
                conectar.Open();
                string consulta = "SELECT * FROM Inventario where Cantidad <= 20 order by Categoria";

                adaptador = new OleDbDataAdapter(consulta, conectar);
                DataTable dataTable = new DataTable();

                adaptador.Fill(dataTable);
                tab.DataSource = dataTable;

            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }
        }


        //Ingresar Productos nuevos a la lista   ---- Por hacer
        public void CargaProducto(int cod, string nom, string desc, int precio,int cant, string categ)
        {
            string consulta = $"insert into Inventario values({cod},'{nom}','{desc}',{precio},{cant},'{categ}')";
            conectar = new OleDbConnection(cadena);

            comando = new OleDbCommand(consulta, conectar);
            try
            {
                conectar.Open();

                int result = comando.ExecuteNonQuery();
                // Comprobar si se Agrego
                if (result > 0)
                {
                    MessageBox.Show("¡Producto agregado con éxito!");
                }
                else
                {
                    MessageBox.Show("No se agregó el producto.");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }

        }

        //CArgar comboBox ----> Ahora
        public void CargarCombo(ComboBox comboBox)
        {
            conectar = new OleDbConnection(cadena);
            try
            {
                conectar.Open();
                string consulta = "SELECT DISTINCT Categoria FROM Inventario";

                comando = new OleDbCommand(consulta, conectar);
                OleDbDataReader reader = comando.ExecuteReader();

                // Limpia los items del ComboBox antes de agregar nuevos datos
                comboBox.Items.Clear();

                // Agrega los datos al ComboBox
                while (reader.Read())
                {
                    comboBox.Items.Add(reader["Categoria"].ToString());
                }

                reader.Close();

            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }
        }

        //Llena la tabla por categorias
        public void LlenarTabla2(DataGridView tab,string item)
        {
            conectar = new OleDbConnection(cadena);
            try
            {
                conectar.Open();
                string consulta = $"SELECT * from Inventario where Categoria = '{item}'";

                adaptador = new OleDbDataAdapter(consulta, conectar);
                DataTable dataTable = new DataTable();


                adaptador.Fill(dataTable);
                tab.DataSource = dataTable;

            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }
        }

        //Llena la tabla por busqueda de palabra
        public void LlenarTabla3(DataGridView tab, string item)
        {
            conectar = new OleDbConnection(cadena);
            try
            {
                conectar.Open();
                string consulta = $"SELECT * from Inventario where Nombre like '{item}%'";

                adaptador = new OleDbDataAdapter(consulta, conectar);
                DataTable dataTable = new DataTable();


                adaptador.Fill(dataTable);
                tab.DataSource = dataTable;

            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }
        }

        //Eliminar
        public void Eliminar(int aux)
        {
            string consulta = $"delete from Inventario  where Codigo = {aux}";  // <--- Cambiar numero
            conectar = new OleDbConnection(cadena);

            comando = new OleDbCommand(consulta, conectar);
            try
            {
                conectar.Open();

                int result = comando.ExecuteNonQuery();
                // Comprobar si se Agrego
                if (result > 0)
                {

                    MessageBox.Show("¡Articulo Eliminado con éxito!", "Notificacion");
                    conectar.Close();
                }

                else
                {
                    MessageBox.Show("No se Elimino el Articulo.");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }
        }

        //Modificar
        public void Modificar(int cod, string nom, string des, int precio, int stock, string cat, int aux)
        {


            string consulta = $"update Inventario set Codigo = {cod} , Nombre ='{nom}' ,Descripcion='{des}',Precio='{precio}' , Cantidad ={stock} ,Categoria='{cat}'  where Codigo = {aux}";  // <--- Cambiar numero
            conectar = new OleDbConnection(cadena);

            comando = new OleDbCommand(consulta, conectar);
            try
            {
                conectar.Open();

                int result = comando.ExecuteNonQuery();
                // Comprobar si se Agrego
                if (result > 0)
                {
                    MessageBox.Show("¡Articulo modificado con éxito!", "Notificacion");
                    conectar.Close();
                }
                else
                {
                    MessageBox.Show("No se modifico el Contacto.");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }
        }
    }
}
