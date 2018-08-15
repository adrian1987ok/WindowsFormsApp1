using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHECADOR
{
    public partial class CHECADOR : Form
    {
        string ruta = Application.StartupPath;
        private bool Existe = false;
        string Empleado = "";
        int Contador = 0;


        public CHECADOR ()
        {
            InitializeComponent();
        }

        private void CHECADOR_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(this.Width / 2 - label1.Width / 2, 5);
            label2.Location = new Point(this.Width / 2 - label2.Width / 2, label1.Height + 20);
            label3.Text = DateTime.Now.ToString();
            label3.Location = new Point(this.Width / 2 - label3.Width / 2, label1.Height + 20);
            pictureBox1.Location = new Point(250 , 250 );
            
            label4.Location = new Point(500, 250);
            label5.Location = new Point(500, 300);
            label6.Location = new Point(500, 350);
            label7.Location = new Point(500, 400);
            label12.Location = new Point(500, 450);
            
            label8.Location = new Point(500, 250);
            label9.Location = new Point(500, 300);
            label10.Location = new Point(500, 350);
            label11.Location = new Point(500, 400);
            label13.Location = new Point(500, 450);
            label14.Location = new Point(400, 500);
            textBox1.Location = new Point(600, 550);
            // textBox1.Hide();
            // MessageBox.Show(ruta);
            textBox1.Clear();
            textBox1.Focus();
            ocultar();

        }

        private void BuscarEmpleado(string Empleado)
        {

            String[] InfoEmpleado;
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader("Empleados.csv");
            Existe = false;
            Contador = 0;
            while ((line = file.ReadLine()) != null)

            {


                //  MessageBox.Show(" Entro EL WILE pero no lozalizo el usuario ");
                InfoEmpleado = line.Split(',');


                // Se compara el texto introducido con el del archivo y si concuerda , se agregan los datos a las columnas 
              //  MessageBox.Show(Empleado.Trim() + "==" + InfoEmpleado[0]);
                if (Empleado.Trim() == InfoEmpleado[0])
                {

                    mostrar();
                    ruta = ruta.Replace("bin\\Debug", "");

                    label8.Text = ("ID Empledo :" + InfoEmpleado[0]);
                    label9.Text = ("Nombre :" + InfoEmpleado[1]);
                    label10.Text = ("Url Foto :" + InfoEmpleado[2]);
                    label11.Text = ("E-Mail :" + InfoEmpleado[3]);
                    label13.Text = ("Hora y Fecha : " + DateTime.Now.ToString());
                    pictureBox1.Image = Image.FromFile(ruta + "img\\" + InfoEmpleado[2]);
                    file.Close();

                    

                    if (InfoEmpleado[4] == "Salida")
                    {
                        
                        lineChanger(InfoEmpleado[0] + "," + InfoEmpleado[1] + "," + InfoEmpleado[2] + "," + InfoEmpleado[3] + ",Entrada", Contador);
                        label14.Text = ("Bienvenido : " + InfoEmpleado[1]);
                      //  MessageBox.Show("Mandar Correo Entrada ");
                     //   MandarCorreo(label4.Text, InfoEmpleado[3]);
                    }
                    else
                    {
                        
                        lineChanger(InfoEmpleado[0] + "," + InfoEmpleado[1] + "," + InfoEmpleado[2] + "," + InfoEmpleado[3] + ",Salida", Contador);
                        label14.Text = ("Esta checando salida : " + InfoEmpleado[1]);
                      // MessageBox.Show("Mandar Correo Salida ");
                    //    MandarCorreo(label4.Text, InfoEmpleado[3]);
                    }

                    

                    entrada();
                    subir();
                    Limpiar();
                    ocultar();
                    Existe = true;
                    break;

                }
                Contador++;
            }
                if (Existe == false)

                {
                   //MessageBox.Show("  EMPLEADO.TRIM " + Empleado + " Informacion empleado " + InfoEmpleado[0]);
                    MessageBox.Show(" Empleado no encontrado , favor de revisar , o agregar ");
                  
                }

                
            file.Close();

        }

        private void MandarCorreo(string Mensaje, string correo)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            try
            {
                //msg.To.Add(correo);
                msg.To.Add("adrian1987ok@gmail.com");
                msg.DeliveryNotificationOptions =
               DeliveryNotificationOptions.OnSuccess;
                msg.Priority = MailPriority.High;
                msg.From = new MailAddress("adrian1987ok@gmail.com","Adrian Leon",
               System.Text.Encoding.UTF8);
                msg.Subject = " ASUNTO ("+ DateTime.Now.ToString("dd/MMM/yyy hh:mm:ss")+")";
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                msg.Body = "HOLA BUEN DIA";
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.IsBodyHtml = true;
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 25;
                client.UseDefaultCredentials = false;
                client.EnableSsl = false;
                client.Credentials = new
               System.Net.NetworkCredential("adrian1987ok@gmail.com","sup3rac10n");
                client.Send(msg);
                MessageBox.Show("ya mande el correo!!!");
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK,
               MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK,
               MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        static void lineChanger(string newText, int line_to_edit)
        {
          //  MessageBox.Show(line_to_edit.ToString());
            string[] arrLine = File.ReadAllLines("Empleados.csv");
            arrLine[line_to_edit] = newText;
            File.WriteAllLines("Empleados.csv", arrLine);
            
        }

        private void subir()
        {

            label8.Update();
            label9.Update();
            label10.Update();
            label11.Update();
            label13.Update();
            label14.Update();
            pictureBox1.Update();
            
        }

        private void entrada()
        {
          //  MessageBox.Show(" Entrada ");
               
         

        }
        private void ocultar ()
        {
           // pictureBox1.Hide();
            
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            label12.Hide();
            
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label13.Hide();
            label14.Hide();


        }
        private void mostrar()
        {
            // MessageBox.Show(" Mostrar ");
            pictureBox1.Show();
            label8.Show();
            label9.Show();
            label10.Show();
            label11.Show();
            label13.Show();
            label14.Show();
         //   System.Threading.Thread.Sleep(1500); // medio segundo

        }

        private void Limpiar()
        {
            System.Threading.Thread.Sleep(1500); // 1.5 Segundos

            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label13.Text = "";
            //pictureBox1.Image = Image.FromFile(ruta + "img\\" + "ECLOUD.jpeg");
            //pictureBox1.Image = Image.FromFile(ruta + "img\\" + "dots-2.gif");
            pictureBox1.Image = Image.FromFile(ruta + "img\\" + "Circuito.gif");
            textBox1.Clear();
            textBox1.Focus();

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /*

        private void CHECADOR_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            Empleado += e.KeyChar;
            if (e.KeyChar == 13)

            {
                //MessageBox.Show(" INICIO DE CHECADOR " + Empleado);
                BuscarEmpleado(Empleado);
                Empleado = "";
                Contador = 0;
            }

            

        }
    
        */

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            Empleado += e.KeyChar;
            if (e.KeyChar == 13)

            {
               // MessageBox.Show(" INICIO DE CHECADOR " + Empleado);
                BuscarEmpleado(textBox1.Text);
                Empleado ="";
                Contador = 0;
            }

        }



        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
