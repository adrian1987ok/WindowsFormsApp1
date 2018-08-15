using LibPrintTicket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApp1
{
    public partial class Textprinter : Form
    {
        public Textprinter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Ticket ticket = new Ticket();

                ticket.HeaderImage = Image.FromFile(@"C:\Users\Adrian\source\repos\DLL\Camaron 2.jpg");
                ticket.AddSubHeaderLine(DateTime.Now.ToShortDateString());
                ticket.AddSubHeaderLine(DateTime.Now.ToShortTimeString());
                ticket.AddSubHeaderLine(DateTime.Now.ToShortDateString());
                ticket.AddSubHeaderLine("Gracias por su compra");
                ticket.AddSubHeaderLine("Gracias por su preferencias");
                ticket.AddSubHeaderLine("Gracias vuelva pronto");


                ticket.PrintTicket("EC-PM-5890X");

            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
               // throw;
            }

        }
    }
}
