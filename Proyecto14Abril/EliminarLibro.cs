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
    public partial class EliminarLibro : Form
    {
        private ArrayList mis_libros;

        /// <summary>
        /// constructor
        /// </summary>
        public EliminarLibro()
        {
            InitializeComponent();
        }

        /// <summary>
        /// constructor para inicializar variables
        /// </summary>
        /// <param name="l"></param>
        public EliminarLibro(ArrayList l)
        {
            InitializeComponent();
            mis_libros = l;
        }

        private void EliminarLibro_Load(object sender, EventArgs e)
        {
            //los textbox que no hacen falta estaran inhabilitados
            textBox4.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            pictureBox1.Enabled = false;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cerrar ventana
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*
            
            //buscaremos el libro que coincida con el id introducido
            bool encontrado = false;
            int contador = 0;
            int indice = 0;
            if (textBox1.Text.Length != 0) //para asegurarnos que ha introducido un id
                foreach (Libro l in mis_libros)
                {
                    if (l.obtenerIdLibro() == Convert.ToInt32(textBox1.Text))
                    {
                        encontrado = true;
                        indice = contador;
                    }
                    contador++;
                }
            if (encontrado)
            {
                Libro l = (Libro)mis_libros[indice];
                textBox2.Text = l.obtenerIdAutor().ToString();
                textBox2.Enabled = true;
                textBox3.Text = l.obtenerIdEditorial().ToString();
                textBox3.Enabled = true;
                textBox4.Text = l.obtenerTituloLibro();
                textBox4.Enabled = true;
                textBox5.Text = l.obtenerISBNLibro();
                textBox5.Enabled = true;
                textBox6.Text = l.obtenerPaginasLibro().ToString();
                textBox6.Enabled = true;
                pictureBox1.Image = l.obtenerPortadaLibro();
                pictureBox1.Enabled = true;
            }
*/
            //HASTA AQUI ERA PARA BUSCAR EL ID EN EL PROGRAMA
            //AHORA VAMOS A BUSCAR EL ID EN LA BASE DE DATOS

            if (textBox1.Text.Length != 0)  //siempre que el textbox no este vacio, haremos la busqueda
            {
                Base_de_datos bd = new Base_de_datos();

                bd.abrir_Conexion();

                bool existe = bd.existe_id_libro(Convert.ToInt32(textBox1.Text));

                if (existe == true)
                {
                    ArrayList modificar = new ArrayList();
                    modificar = bd.obtener_Libros_Para_Modificar(Convert.ToInt32(textBox1.Text));
                    Libro l;
                    l = (Libro)modificar[0];
                    textBox1.Enabled = false;
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                    textBox5.Enabled = true;
                    textBox6.Enabled = true;
                    button1.Enabled = true;
                    textBox2.Text = l.obtenerIdAutor().ToString();
                    textBox3.Text = l.obtenerIdEditorial().ToString();
                    textBox4.Text = l.obtenerTituloLibro();
                    textBox5.Text = l.obtenerISBNLibro();
                    textBox6.Text = l.obtenerPaginasLibro().ToString();
                    pictureBox1.Image = l.obtenerPortadaLibro();

                }
                else
                {
                    MessageBox.Show("Ese Libro no existe");

                }

                bd.cerrar_Conexion();

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
            //con este boton eliminaremos el libro en pantalla
            if (MessageBox.Show("¿Estas seguro de que quieres eliminar el Libro?", "Mensaje de Advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int contador = 0;
                int indice = 0;
                foreach (Libro l in mis_libros)
                {
                    if (l.obtenerIdLibro() == Convert.ToInt32(textBox1.Text))
                    {
                        indice = contador;
                    }
                    contador++;
                }
                mis_libros.RemoveAt(indice);
                MessageBox.Show("Libro eliminado correctamente");
                this.Close();
            }
            */
            Base_de_datos bd = new Base_de_datos();
            bd.abrir_Conexion();
            bd.eliminar_libro(Convert.ToInt32(textBox1.Text));
            MessageBox.Show("Libro eliminado correctamente");
            bd.cerrar_Conexion();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
