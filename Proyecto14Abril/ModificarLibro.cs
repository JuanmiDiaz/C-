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
    public partial class ModificarLibro : Form
    {
        //variabbles y array
        private ArrayList lista_libros;
        private bool modificado;
        private ArrayList autores; // creamos un arrayList para autores
        private ArrayList editoriales; //arraylist para editoriales

        /// <summary>
        /// constructor
        /// </summary>
        public ModificarLibro()
        {
            InitializeComponent();
        }

        /// <summary>
        /// constructor para inicializar variables
        /// </summary>
        /// <param name="l"></param>
        public ModificarLibro(ArrayList l)
        {
            InitializeComponent();
            lista_libros = l;
            modificado = false;
        }



        private void ModificarLibro_Load(object sender, EventArgs e)
        {
            //hace que al abrir la venana los textbox esten deshabilitados
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*
            //boton para buscar el id del libro que queremos encontrar
            bool encontrado = false;
            int contador = 0;
            int indice = 0;

            if (textBox1.Text.Length != 0)
            {
                foreach (Libro l in lista_libros)
                {
                    if (l.obtenerIdLibro() == Convert.ToInt32(textBox1.Text))
                    {
                        encontrado = true;
                        indice = contador;
                    }
                    else
                    {
                        contador++;
                    }

                }
                if (encontrado)
                {
                    //eliminaremos el boton de busqueda
                    button4.Visible = false;
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                    textBox5.Enabled = true;
                    textBox6.Enabled = true;
                    Libro l;
                    l = (Libro)lista_libros[indice];
                    textBox2.Text = l.obtenerIdAutor().ToString();
                    textBox3.Text = l.obtenerIdEditorial().ToString();
                    textBox4.Text = l.obtenerTituloLibro();
                    textBox5.Text = l.obtenerISBNLibro();
                    textBox6.Text = l.obtenerPaginasLibro().ToString();
                    textBox1.Enabled = false;
                    pictureBox1.Image = l.obtenerPortadaLibro();
                    //el campo de id lo dejaremos bloqueado para no poder modificarlo

                }
            }
            else
            {
                MessageBox.Show("Debes introducir un id");
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
            //una vez introducidos los nuevos datos se guardan donde estaban los anteriores
            if (!modificado)
            {
                this.Close();
            }
            else
            {
                //buscamos el elemento y lo eliminamos
                int contador = 0;
                int indice = 0;
                foreach (Libro l in lista_libros)
                {
                    if (l.obtenerIdLibro() == Convert.ToInt32(textBox1.Text))
                    {
                        indice = contador;
                    }
                    else
                    {
                        contador++;
                    }
                }
                lista_libros.RemoveAt(indice);
                Libro un_libro_modificado = new Libro(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), textBox4.Text, textBox5.Text, Convert.ToInt32(textBox6.Text), pictureBox1.Image);
                lista_libros.Insert(indice, un_libro_modificado);
                MessageBox.Show("Autor modificado correctamente");
                this.Close();
            }
            */


            //PRIMERO COMPROBAMOS SI EL AUTOR EXISTE Y SI NO SE AGREGA
            Base_de_datos bd = new Base_de_datos();

            bd.abrir_Conexion();

            bool existe = bd.existe_id_autor(Convert.ToInt32(textBox1.Text));

            if (existe == true)
            {

            }
            else
            {
                MessageBox.Show("Ese Autor no existe, debe registrarlo en la base de datos");
                AgregarAutor aa = new AgregarAutor(autores); // para agregar los autores
                aa.ShowDialog();
            }

            bd.cerrar_Conexion();
            //LUEGO COMPROBAMOS SI LA EDITORIAL EXISTE Y SINO, SE AGREGA
            bd.abrir_Conexion();

            bool existe2 = bd.existe_id_editorial(Convert.ToInt32(textBox1.Text));

            if (existe2 == true)
            {

            }
            else
            {
                MessageBox.Show("Esa Editorial no existe, debe registrarla en la base de datos");
                AgregarEditorial ae = new AgregarEditorial(editoriales); // para agregar las editoriales
                ae.ShowDialog();
            }

            bd.cerrar_Conexion();

            //AHORA SI, SE AÑADE EL LIBRO

            bd.abrir_Conexion();
            bd.modificar_Libro(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), textBox4.Text, textBox5.Text, Convert.ToInt32(textBox6.Text), pictureBox1);
            MessageBox.Show("Libro modificado correctamente");
            bd.cerrar_Conexion();
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            modificado = true;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            modificado = true;

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            modificado = true;

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            modificado = true;

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            modificado = true;

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

        private void button2_Click(object sender, EventArgs e)
        {
            //aqui introducimos la foto
            //Filtro para que solo se puedan subir imagenes
            openFileDialog1.Filter = "Imagen|*.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }
    }
}
