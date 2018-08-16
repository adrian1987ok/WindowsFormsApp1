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
    public partial class Verificador : Form
    {

        private string codigo = "";
        private bool codigoencontrado = false;

        public Verificador()
        {
            InitializeComponent();
        }

        private void Verificador_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(this.Width / 2 - label1.Width / 2, 5);
            label2.Location = new Point(this.Width / 2 - label2.Width / 2, label1.Height + 20);
            lblFecha.Text = DateTime.Now.ToString();
            lblFecha.Location = new Point(this.Width / 2 - lblFecha.Width / 2 ,  label1.Height + 50);



        }

        private void timer1_Tick(object sender , EventArgs e)

        {
            lblFecha.Text = DateTime.Now.ToString();
            lblFecha.Location = new Point(this.Width / 2 - lblFecha.Width / 2, label1.Height);

        }



        private void buscar (string texto)
        {
            string[] infoProducto;
            string line;
            StreamReader file = new StreamReader("Productos.csv");

            //MessageBox.Show(codigo);
          
            while ( (line = file.ReadLine()) != null)

            {

                infoProducto = line.Split(',');

                     if (texto == infoProducto[0])

                     {
                    label3.Text = "Nombre : " + infoProducto[1] + " Precio : $ " + infoProducto[2];
                    codigoencontrado = true;
                    label3.Location = new Point(this.Width / 2 - label3.Width / 2, label2.Height + label2.Height + 70);


                     }
                


            }

            if (!codigoencontrado)
            {
                label3.Text = " CODIGO NO ENCONTRADO ";
                label3.Location = new Point(this.Width / 2 - label3.Width / 2, label2.Height + label2.Height + 70);
                
            }
            
            file.Close();
                    }



        private void verificador_KeyPress(object sender , KeyPressEventArgs e)

        {
            codigo += e.KeyChar;

            if ( e.KeyChar == 13)

            {
                MessageBox.Show(codigo.Trim());
                buscar(codigo.Trim());
                codigo = "";                    

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
