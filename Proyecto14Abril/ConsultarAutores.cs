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
    public partial class ConsultarAutores : Form
    {
        //array para los autoores
        private ArrayList autores;
        private int contador;

        /// <summary>
        /// constructor
        /// </summary>
        public ConsultarAutores()
        {
            InitializeComponent();
        }
        /// <summary>
        /// constructor  para iicializar las variables
        /// </summary>
        /// <param name="a"></param>
        public ConsultarAutores(ArrayList a)
        {
            InitializeComponent();
            autores = a;
            contador = 0;
        }

        private void ConsultarAutores_Load(object sender, EventArgs e)
        {
            /*
            //consulta donde se rellenan los textbox con los datos
            Autor a;
            a = (Autor)los_autores[contador];
            textBox1.Text = a.obtenerId().ToString();
            textBox2.Text = a.obtenerNombre();
            textBox3.Text = a.obtenerApellidos();
            textBox4.Text = a.obtenerNacionalidad();
            dateTimePicker1.Value = Convert.ToDateTime(a.obtenerFNacimiento());
            pictureBox1.Image = a.obtenerImagen();

            //Lista los autores de la base de datos

            ArrayList los_autores_bd = new ArrayList();
            Base_de_datos bd = new Base_de_datos();
            bd.abrir_Conexion();
            los_autores_bd = bd.obtener_Autores();
            bd.cerrar_Conexion();
            foreach(Autor a1 in los_autores_bd)
            {
                MessageBox.Show(a1.obtenerId().ToString() + " " + a1.obtenerNombre() + " " + a1.obtenerApellidos() + " " + a1.obtenerNacionalidad());

            }
            */
            Base_de_datos bd = new Base_de_datos();


            Autor a;
            a = (Autor)autores[0];
            textBox1.Text = a.obtenerId().ToString();
            textBox2.Text = a.obtenerNombre();
            textBox3.Text = a.obtenerApellidos();
            textBox4.Text = a.obtenerNacionalidad();
            dateTimePicker1.Value = Convert.ToDateTime(a.obtenerFNacimiento());
            pictureBox1.Image = a.obtenerImagen();


            bd.cerrar_Conexion();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // al pulsar el boton carga el siguiente autor y si es el ultimo saca el mensaje
            contador++;
            if (contador < autores.Count)
            {
                Autor a;
                a = (Autor)autores[contador];
                textBox1.Text = a.obtenerId().ToString();
                textBox2.Text = a.obtenerNombre();
                textBox3.Text = a.obtenerApellidos();
                textBox4.Text = a.obtenerNacionalidad();
                dateTimePicker1.Value = Convert.ToDateTime(a.obtenerFNacimiento());
                pictureBox1.Image = a.obtenerImagen();
            }
            else
            {
                MessageBox.Show("No hay mas autores en la base de datos");
                contador--;
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            //al pulsar el boton saca el autor anterior y si no hay saca el mensaje
            contador--;
            if (contador < 0)
            {
                MessageBox.Show("No hay mas autores en la base de datos");
                contador++;

            }

            else
            {
                Autor a;
                a = (Autor)autores[contador];
                textBox1.Text = a.obtenerId().ToString();
                textBox2.Text = a.obtenerNombre();
                textBox3.Text = a.obtenerApellidos();
                textBox4.Text = a.obtenerNacionalidad();
                dateTimePicker1.Value = Convert.ToDateTime(a.obtenerFNacimiento());
                pictureBox1.Image = a.obtenerImagen();

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
