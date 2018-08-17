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
    public partial class PUNTO_DE_VENTA : Form
    {
        
        
        private bool codigoencontrado = false;
        private string[] cantidadProducto;
        public double total = 0;
        private double p = 0;
        double T = 0;

        public PUNTO_DE_VENTA()
        {
            InitializeComponent();
        }

        private void PUNTO_DE_VENTA_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(this.Width / 2 - label1.Width / 2, 5);
            label2.Location = new Point(this.Width / 2 - label2.Width / 2, label1.Height + 20);
            label3.Text = DateTime.Now.ToString();
            label3.Location = new Point(this.Width / 2 - label3.Width / 2, label1.Height + 20);
            pictureBox1.Location = new Point(this.Width / 2- pictureBox1.Width /2, label1.Height + 40);
            dataGridView1.Width = this.Width - 3;
            float x = this.Height*0.75f;
            //MessageBox.Show(x.ToString());
            dataGridView1.Height = (int)Math.Round(x);
            dataGridView1.Location = new Point(0,label1.Height + label2.Height + label3.Height + 40);

            textBox1.Width = this.Width - 2;
            textBox1.Location = new Point(0, this.Height - textBox1.Height);


            dataGridView1.Columns[0].Width = Convert.ToInt32(this.Width * 0.15);
            dataGridView1.Columns[1].Width = Convert.ToInt32(this.Width * 0.300);
            dataGridView1.Columns[2].Width = Convert.ToInt32(this.Width * 0.25);
            dataGridView1.Columns[3].Width = Convert.ToInt32(this.Width * 0.25);
           

           // label4.Location = new Point((this.Width / 2 ) + 500, label1.Height + label2.Height + label3.Height + dataGridView1.Height + 50);
            label4.Location = new Point(this.Width - label4.Width + 2, this.Height - textBox1.Height - label4.Height);
             T = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
          //  if (e.KeyChar == 13)
            //{
                //MessageBox.Show("a buscar" + textBox1.Text);
                // // (e.KeyChar == 13) = enter
              //  buscarProducto(1,textBox1.Text);
                //textBox1.Text = ("");
                //textBox1.Focus();




                if (e.KeyChar == 13)
                {

                if (T >= 0)
                {

                  //  MessageBox.Show("entra al IF de resto");

                    if (textBox1.Text.Contains("p"))
                    {

                        cambio();

                    }

                    else
                    {
                        if (textBox1.Text.IndexOf("*") == -1)
                        {

                            buscarProducto(1, textBox1.Text);
                        }

                        else
                        {
                            cantidadProducto = textBox1.Text.Split('*');
                            buscarProducto(int.Parse(cantidadProducto[0]), cantidadProducto[1]);
                        }
                        textBox1.Clear();
                        textBox1.Focus();

                    }
                }

                else
                {
                    

                    if (textBox1.Text.Contains("p"))
                    {

                        cambio();

                    }
                    else
                    {
                        MessageBox.Show(" Favor de ingresar el pago para continuar con la venta");

                    }

                }

        }

        

            // (e.KeyChar == 27) = esq
            if (e.KeyChar == 27)
            {
                EliminarUltimoProducto();
                Total();
            }

            // (e.KeyChar == 33) = !
            if (e.KeyChar == 33)
            {
                MessageBox.Show(" Duplicar el producto ");
                DuplicarUltimoProd();
                Total();
            }


        }



            private void updateFontDgv()
        {
            //Change Cell Font
            foreach ( DataGridViewColumn c in dataGridView1.Columns)
                {
                c.HeaderCell.Style.Font = new Font("Arial", 20, GraphicsUnit.Pixel);

                 }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buscarProducto(int cantidad , string texto)
        {
            string[] infoProducto;
            string line;
            StreamReader file = new StreamReader("Productos.csv");

            //MessageBox.Show(codigo);

            while ((line = file.ReadLine()) != null)

            {

                infoProducto = line.Split(',');

                // Se compara el texto introducido con el del archivo y si concuerda , se agregan los datos a las columnas 
                if (texto == infoProducto[0])

                {

                    dataGridView1.Rows.Add(cantidad, infoProducto[1], infoProducto[2],cantidad * double.Parse(infoProducto[2]));

                    total = total + cantidad * Convert.ToDouble(infoProducto[2]);

                    Total();

                     codigoencontrado = true;


                }


            }
            
            if (codigoencontrado == false)
            {
                // label3.Text = " CODIGO NO ENCONTRADO ";
                //  label3.Location = new Point(this.Width / 2 - label3.Width / 2, label2.Height + label2.Height + 70);
                MessageBox.Show(" Producto no encontrado , favor de revisar , o agregar ");

            }

            
            // MessageBox.Show(" Se brinco el if a la vorgo ");
            codigoencontrado = false;
            file.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void Total()
        {
            double total = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                total += Convert.ToDouble(dataGridView1[3, i].Value.ToString());
            }
            label4.Text = "Total: $ " + total.ToString("n");

            label4.Location = new Point(this.Width - label4.Width + 2, this.Height - textBox1.Height - label4.Height);

        }

        private void cambio()
        {

           
            string pago = textBox1.Text;
            pago = pago.Replace("p", ""); 
            //  MessageBox.Show(pago);
            total = int.Parse(pago) - total;

            dataGridView1.Rows.Clear();

            if (total > 0) 
                {


              //   MessageBox.Show(" entro al if ");
                label4.Text = " Su Cambio es : $ " + total + "  ";
                label4.Location = new Point(this.Width - label4.Width + 2, this.Height - textBox1.Height - label4.Height);
                MessageBox.Show(" Muchas gracias por su compra, vuelva pronto ");
                
               

                reiniciar();

            }

            else
            {
                T = total;
                total = Math.Abs(total);
              //  MessageBox.Show(" Falta cobrar efectivo de : " + total);
                label4.Text = " Falta cobrar efectivo de : $ " + T + "  ";

                label4.Location = new Point(this.Width - label4.Width + 2, this.Height - textBox1.Height - label4.Height);
                textBox1.Text = ("");



            }

        }
        private void reiniciar()
        {

           // MessageBox.Show(" Metodo reiniciar ");

            dataGridView1.Rows.Clear();
            total = 0;
            label4.Text = "Total:  " ;
            textBox1.Text = ("");
            T = 0;
        }


        private void DuplicarUltimoProd()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Add(dataGridView1[0, dataGridView1.Rows.Count - 1].Value.ToString(),
                    dataGridView1[1, dataGridView1.Rows.Count - 1].Value.ToString(),
                    dataGridView1[2, dataGridView1.Rows.Count - 1].Value.ToString(),
                    dataGridView1[3, dataGridView1.Rows.Count - 1].Value.ToString());

                MessageBox.Show(" Si entra al metodo duplicar ");

            }
        }




        private void EliminarUltimoProducto()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString();
        }
    }
}
