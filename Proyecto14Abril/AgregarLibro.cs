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
    public partial class AgregarLibro : Form
    {
        private ArrayList los_libros;
        private ArrayList lista_autores;
        private ArrayList lista_editoriales;
        private ArrayList autores; // creamos un arrayList para autores
        private ArrayList editoriales; //arraylist para editoriales



        /// <summary>
        /// constructor
        /// </summary>
        public AgregarLibro()
        {
            InitializeComponent();

        }

        /// <summary>
        /// constructor para inicializar variables
        /// </summary>
        /// <param name="l"></param>
        public AgregarLibro(ArrayList l, ArrayList a, ArrayList ed)
        {
            InitializeComponent();
            los_libros = l;
            lista_autores = a;
            lista_editoriales = ed;

        }

        private void AgregarLibro_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            /*
            //Se comprueba si el autor existe
            bool encontrado = false;
            int contador = 0;
            int indice = 0;
                foreach (Autor a in lista_autores)
                {
                    if (a.obtenerId() == Convert.ToInt32(textBox2.Text))
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
                //significa que el autor si existe
                }else
                    {
                        MessageBox.Show("Debe registrar ese Autor");
                        AgregarAutor aa = new AgregarAutor(lista_autores); // para agregar los autores
                        aa.ShowDialog();
                }

    */
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




            //una vez comprobado que el autor existe o no comprobamos si existe la editorial
            /*
                bool encontrado2 = false;
                int contador = 0;
                int contador2 = 0;
                int indice2 = 0;
                foreach (Editorial ed in lista_editoriales)
                {
                    if (ed.obtenerIdEditorial() == Convert.ToInt32(textBox3.Text))
                    {
                        encontrado2 = true;
                        indice2 = contador;
                    }
                    else
                    {
                        contador2++;
                    }
                }
                if (encontrado2)
                {
                    //significa que el autor si existe
                }
                else
                {
                    MessageBox.Show("Debe registrar esa Editorial");
                    AgregarEditorial ae = new AgregarEditorial(lista_editoriales); // para agregar los editoriales
                    ae.ShowDialog();
                }

                */


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









            //una vez hechas las dos comprobaciones pasamos a añadir el libro
            //aqui iremos añadiendo los datos de cada textbox al libro creado
            Libro un_libro = new Libro();
            un_libro.establecerIdLibro(Convert.ToInt32(textBox1.Text));
            un_libro.establecerIdAutor(Convert.ToInt32 (textBox2.Text));
            un_libro.establecerIdEditorial(Convert.ToInt32(textBox3.Text));
            un_libro.establecerTituloLibro(textBox4.Text);
            un_libro.establecerISBNLibro(textBox5.Text);
            un_libro.establecerPaginasLibro(Convert.ToInt32(textBox6.Text));
            un_libro.establecerPortadaLibro(pictureBox1.Image);


            //vamos a insertar  el libro en la base de datos
            bd.abrir_Conexion();

            //primero llamamos a la funcion para comprobar si existe el libro

            if (bd.existe_id_libro(Convert.ToInt32(textBox1.Text)))
            {
                //si existe no dejaría insertarlo
                MessageBox.Show("Ese libro ya esta insertado en la base de datos");
            }
            else
            {
                //si no esta insertado, se insertaria en la base de datos
                if (pictureBox1.Image != null) //por aqui lo introducimos si tiene imagen
                {
                    if (bd.Insertar_Libro(un_libro, pictureBox1))
                    {
                        MessageBox.Show("Libro insertado correctamente en la base de datos");
                        //y se insertaria en el programa tambien
                        //los_libros.Add(un_libro); //para añadirlo al arraylist
                        //MessageBox.Show("Libro insertado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Problemas con la insercion en la base de datos");
                    }
                }
                else  //por aqui lo introducimos si no tiene imagen
                {
                    //si no introduce una imagen tambien guardaremos el libro tanto en el programa como en la base de datos
                    bd.Insertar_Libro(un_libro);
                    MessageBox.Show("Libro insertado correctamente en la base de datos sin imagen");
                    //los_libros.Add(un_libro); //para añadirlo al arraylist
                    // MessageBox.Show("Libro insertado correctamente");

                }
            }

            bd.cerrar_Conexion();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //aqui introducimos la foto
            //Filtro para que solo se puedan subir imagenes
            openFileDialog1.Filter = "Imagen|*.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //para cerrar
            this.Close();
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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
