using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poo_2

{
    public partial class Form1 : Form
    {

        private List<Productos> listaProductos = new List<Productos>();

    
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


        }

        private void cargaProductos()
        { 
            // Propiedades
            

        }

        class Productos
        {
            // Propiedades

            public long producto_codigo = 0;
            public String producto_nombre = "";
            public float producto_precio = 0.00f;


            public Productos()
            {
                MessageBox.Show("Me llamaron");
            }

            public Productos(long producto_codigo)
            {
                this.producto_codigo = producto_codigo;

            }

        }



    

 


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
