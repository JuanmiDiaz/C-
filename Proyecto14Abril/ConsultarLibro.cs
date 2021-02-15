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
    public partial class ConsultarLibro : Form
    {
        //array para los libros
        private ArrayList libros;
        private int contador;
       
        /// <summary>
        /// constructor
        /// </summary>
        public ConsultarLibro()
        {
            InitializeComponent();
        }

        /// <summary>
        /// constructor para inicializar las variables
        /// </summary>
        /// <param name="a"></param>
       public ConsultarLibro(ArrayList l)
        {
            InitializeComponent();
            libros = l;
            contador = 0;
        }

        private void ConsultarLibro_Load(object sender, EventArgs e)
        {
            //consulta donde se rellenan los textbox con los datos
            /*
            Libro l;
            l = (Libro)los_libros[contador];
            textBox1.Text = l.obtenerIdLibro().ToString();
            textBox2.Text = l.obtenerIdAutor().ToString();
            textBox3.Text = l.obtenerIdEditorial().ToString();
            textBox4.Text = l.obtenerTituloLibro();
            textBox5.Text = l.obtenerISBNLibro();
            textBox6.Text = l.obtenerPaginasLibro().ToString();
            pictureBox1.Image = l.obtenerPortadaLibro();
            */

            Base_de_datos bd = new Base_de_datos();


            Libro l;
            l = (Libro)libros[0];
            textBox1.Text = l.obtenerIdLibro().ToString();
            textBox2.Text = l.obtenerIdAutor().ToString();
            textBox3.Text = l.obtenerIdEditorial().ToString();
            textBox4.Text = l.obtenerTituloLibro();
            textBox5.Text = l.obtenerISBNLibro();
            textBox6.Text = l.obtenerPaginasLibro().ToString();
            pictureBox1.Image = l.obtenerPortadaLibro();


            bd.cerrar_Conexion();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            //boton para cerrar
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //al pulsar el boton saca los datos del siguiente libro y si no hay
            //saca un mensaje de error
            contador++;
            if (contador < libros.Count)
            {
                Libro l;
                l = (Libro)libros[contador];
                textBox1.Text = l.obtenerIdLibro().ToString();
                textBox2.Text = l.obtenerIdAutor().ToString();
                textBox3.Text = l.obtenerIdEditorial().ToString();
                textBox4.Text = l.obtenerTituloLibro();
                textBox5.Text = l.obtenerISBNLibro();
                textBox6.Text = l.obtenerPaginasLibro().ToString();
                pictureBox1.Image = l.obtenerPortadaLibro();
            }
            else
            {
                MessageBox.Show("No hay mas libros en la base de datos");
                contador--;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //al pulsar el boton saca los datos del anterior libro y si no hay
            //saca un mensaje de error
            contador--;
            if (contador < 0)
            {
                MessageBox.Show("No hay mas libros en la base de datos");
                contador--;
            }
            else
            {
                Libro l;
                l = (Libro)libros[contador];
                textBox1.Text = l.obtenerIdLibro().ToString();
                textBox2.Text = l.obtenerIdAutor().ToString();
                textBox3.Text = l.obtenerIdEditorial().ToString();
                textBox4.Text = l.obtenerTituloLibro();
                textBox5.Text = l.obtenerISBNLibro();
                textBox6.Text = l.obtenerPaginasLibro().ToString();
                pictureBox1.Image = l.obtenerPortadaLibro();
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
