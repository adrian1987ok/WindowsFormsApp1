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
    public partial class Form1 : Form
    {

        private List<Productos> listaProductos = new List<Productos>();

        Productos[] miller = new Productos[10];
        private int rowSelect;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Productos productos = new Productos();
            //productos.productos_codigo = 12345698764;
            //productos.productos_nombre = "MILLER";
            //productos.productos_precio = 36.00f;

            //listaProductos.Add(productos);
            //listaProductos.Add(new Productos(1234567892589, "no se " , 36.36f));



            //Productos productos = new Productos(1, "Kawamon",36.00);
            //Productos productos1 = new Productos(1, "Kawamon", 15);
            // Productos productos2 = new Productos();


            // Productos[] miller = new Productos[10];
            miller[0] = new Productos(10, " Bote ", 25);
            miller[1] = new Productos(15, " Bote ", 25.00);
            miller[2] = new Productos(20, " Bote ", 25);
            miller[3] = new Productos();

            cargaProductos();


        }

        private void cargaProductos()
        {

            /* 
             // Propiedades

             dataGrindView1.Columns["Columm 3"].DefaultCellStyle.Format = "N2";
                 try {

                 for (int i = 0; i < 3; i++)

                 {

                    // MessageBox.Show(productos)                   
                     dataGridView1.Rows.Add(miller[i].producto_codigo)
             }

             }
             catch (Exception err)
             {
                 MessageBox.Show("no se" + err);
             }

     */

            int contador = 0;
            string line;
            System.IO.StreamReader file =
            new System.IO.StreamReader(@"C:\Users\Adrian\source\repos\WindowsFormsApp1\Practica Sistemas.csv");
            while ((line = file.ReadLine()) != null)

            {
                richTextBox1.Text += line + Environment.NewLine;
                // counter++;
                /* string[] split = line.Split(',');
                 dataGridView1.Rows.Add(split[0]);
                 dataGridView1.Rows.Add(split[1]);
                 dataGridView1.Rows.Add(split[2]);
                 */
                dataGridView1.Rows.Add(line.Split(','));
                dataGridView1.Rows[contador].HeaderCell.Value = (contador + 1).ToString();
                contador++;


            }



            file.Close();

        }

        class Productos
        {
            // Propiedades

            public long producto_codigo = 0;
            public String producto_nombre = "";
            public float producto_precio = 0.00f;


            public Productos()
            {
                //    MessageBox.Show("Me llamaron sin parametros");
            }

            public Productos(long producto_codigo, String producto_nombre, float producto_precio)
            {
                //  MessageBox.Show("Me llamaron con Long ,String , Float");
                this.producto_codigo = producto_codigo;
                this.producto_nombre = producto_nombre;

            }
            public Productos(long producto_codigo, String producto_nombre, double producto_precio)
            {
                //MessageBox.Show("Me llamaron con Long ,String , Double");
                this.producto_codigo = producto_codigo;
                this.producto_nombre = producto_nombre;
                //this.producto_precio = float.Parse(producto_precio.ToString());


            }


        }








        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
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

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea eliminar" + dataGridView1[1, rowSelect].Value.ToString()
                + " con el precio de :" + dataGridView1[2, rowSelect].Value.ToString(), "Titulo de la ventana",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {
                dataGridView1.Rows.RemoveAt(rowSelect);
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

        private void button3_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show(" Ya guardaste estas seguro ");
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            DataObject dataObject = dataGridView1.GetClipboardContent();
            File.WriteAllText("Practica Sistemas.csv", dataObject.GetText(TextDataFormat.CommaSeparatedValue));
        }
    }
}
            
    

