using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto14Abril
{
    public partial class ConsultarEditorial : Form
    {
        //array para las editoriales
        private ArrayList editoriales;
        private int contador;
        
        /// <summary>
        /// constructor
        /// </summary>
        public ConsultarEditorial()
        {
            InitializeComponent();
        }

        public ConsultarEditorial(ArrayList ed)
        {
            InitializeComponent();
            editoriales = ed;
            contador = 0;
        }

        private void ConsultarEditorial_Load(object sender, EventArgs e)
        {
            /*
             //consulta donde se rellenan los textbox con los datos
             Editorial ed;
             ed = (Editorial)las_editoriales[contador];
             textBox1.Text = ed.obtenerIdEditorial().ToString();
             textBox2.Text = ed.obtenerNombreEditorial();
             textBox3.Text = ed.obtenerNacionalidadEditorial();
             pictureBox1.Image = ed.obtenerImagenEditorial();
         
         */
            Base_de_datos bd = new Base_de_datos();


            Editorial ed;
            ed = (Editorial)editoriales[0];
            textBox1.Text = ed.obtenerIdEditorial().ToString();
            textBox2.Text = ed.obtenerNombreEditorial();
            textBox3.Text = ed.obtenerNacionalidadEditorial();
            pictureBox1.Image = ed.obtenerImagenEditorial();


            bd.cerrar_Conexion();



        }
         private void button2_Click(object sender, EventArgs e)
         {
             this.Close();
         }

         private void button1_Click(object sender, EventArgs e)
         {
             // al pulsar el boton carga la siguiente editorial y si es la ultimo saca el mensaje
             contador++;
             if (contador < editoriales.Count)
             {
                 Editorial ed;
                 ed = (Editorial)editoriales[contador];
                 textBox1.Text = ed.obtenerIdEditorial().ToString();
                 textBox2.Text =ed.obtenerNombreEditorial();
                 textBox3.Text = ed.obtenerNacionalidadEditorial();
                 pictureBox1.Image = ed.obtenerImagenEditorial();
             }
             else
             {
                 MessageBox.Show("No hay mas editoriales en la base de datos");
                 contador--;
             }
             

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //al pulsar el boton saca la editorial anterior y si no hay saca el mensaje
            contador--;
            if (contador < 0)
            {
                MessageBox.Show("No hay mas editoriales en la base de datos");
                contador++;
            }
            else
            {
                Editorial ed;
                ed = (Editorial)editoriales[contador];
                textBox1.Text = ed.obtenerIdEditorial().ToString();
                textBox2.Text = ed.obtenerNombreEditorial();
                textBox3.Text = ed.obtenerNacionalidadEditorial();
                pictureBox1.Image = ed.obtenerImagenEditorial();

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //con este if nos aseguramos que sólo sean números los que se inserten

            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
