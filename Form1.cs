using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1

{
    public partial class CRUD : Form
    {

        private int rowSelect;

        public CRUD()
        {
            InitializeComponent();
        }

        private void CRUD_Load(object sender, EventArgs e)
        {

            cargaProductos();

        }

        private void cargaProductos()
        {

            int contador = 0;
            string line;
            System.IO.StreamReader file =
            new System.IO.StreamReader(@"C:\Users\Adrian\source\repos\WindowsFormsApp1\Practica Sistemas.csv");

            while ((line = file.ReadLine()) != null)

            {

                richTextBox1.Text += line + Environment.NewLine;
                dataGridView1.Rows.Add(line.Split(','));
                dataGridView1.Rows[contador].HeaderCell.Value = (contador + 1).ToString();
                contador++;
                MessageBox.Show("entra al wile" + contador);
            }

             file.Close();
         }


        private void buttonagregar_Click(object sender, EventArgs e)
        {
            //Primero compara el codigo del producto, si no esta lo agrega.
            bool esta = false;
            for (int i = 0; i<dataGridView1.Rows.Count; i++)
            {

                if (dataGridView1[0,i].Value.ToString() == richTextBox2.Text)
                {
                    esta = true;

                }
                
            }

            if (!esta)
            {
                dataGridView1.Rows.Add(richTextBox2.Text, richTextBox3.Text, richTextBox4.Text);
                numerar();

            }

            else
            {
                MessageBox.Show("Esta cargado");
            }
                      
        }


        private void buttoneliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {

                if (MessageBox.Show("Desea eliminar" + dataGridView1[1, rowSelect].Value.ToString()
        + " con el precio de :" + dataGridView1[2, rowSelect].Value.ToString(), "Titulo de la ventana",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                {
                    dataGridView1.Rows.RemoveAt(rowSelect);
                }
            }
            else
            {
                MessageBox.Show(" Ya no hay datos para eliminar ");

            }

            limpiar();
            }

        private void limpiar()
        {
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            richTextBox2.Enabled = true;
            richTextBox2.Focus();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex !=-1)
            {
                richTextBox2.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                richTextBox3.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                richTextBox4.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                rowSelect = e.RowIndex;
                richTextBox2.Enabled = false;
            }

        }

        private void numerar()
        {
          for (int i = 0; i < dataGridView1.Rows.Count; i ++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();

            }

        }

        private void buttonmodificar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Desea Modificar " +
                dataGridView1[1, rowSelect].Value.ToString()
                      + " con el precio de :" +
                      dataGridView1[2, rowSelect].Value.ToString(), "Titulo de la ventana",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {
                dataGridView1[1, rowSelect].Value = richTextBox3.Text;
                dataGridView1[2, rowSelect].Value = richTextBox4.Text;
            }
            limpiar();


        }


        private void buttonlimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show(" Ya guardaste estas seguro ");
            dataGridView1.SelectAll();
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            DataObject dataObject = dataGridView1.GetClipboardContent();
           // File.WriteAllText("Practica Sistemas.csv", dataObject.GetText(TextDataFormat.CommaSeparatedValue));
            MessageBox.Show(" Se guarda el archivo ");
        }

        private void CRUD_Load_1(object sender, EventArgs e)
        {

        }
    }
}
            
    

