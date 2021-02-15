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
    public partial class AgregarAutor : Form
    {
        private ArrayList los_autores;


        /// <summary>
        /// constructor
        /// </summary>
        public AgregarAutor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// constructor para inicializar variables
        /// </summary>
        /// <param name="a"></param>
        public AgregarAutor(ArrayList a)
        {
            InitializeComponent();
            los_autores = a;
        }


        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void Agregar_Autor_Load(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //aqui iremos añadiendo los datos de cada textbox al autor creado
            Autor un_autor = new Autor();
            un_autor.establecerId(Convert.ToInt32(textBox1.Text));
            un_autor.establecerNombre(textBox2.Text);
            un_autor.establecerApellidos(textBox3.Text);
            un_autor.establecerNacionalidad(textBox4.Text);
            un_autor.establecerFNacimiento(dateTimePicker1.Value);
            un_autor.establecerFoto(pictureBox1.Image);

    

            //vamos a insertar  al autor en la base de datos
            Base_de_datos bd = new Base_de_datos();
            bd.abrir_Conexion();

            //primero llamamos a la funcion para comprobar si existe el autor
            
            if (bd.existe_id_autor(Convert.ToInt32(textBox1.Text)))
            {
                //si existe no dejaría insertarlo
                MessageBox.Show("Ese autor ya esta insertado en la base de datos");
            }
            else
            {
                //si no esta insertado, se insertaria en la base de datos
                if (pictureBox1.Image != null)
                {
                    if (bd.Insertar_Autor(un_autor, pictureBox1))
                    {
                        MessageBox.Show("Autor insertado correctamente en la base de datos");
                        //y se insertaria en el programa tambien
                        //los_autores.Add(un_autor); //para añadirlo al arraylist
                        //MessageBox.Show("Autor insertado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Problemas con la insercion en la base de datos");
                    }
                }
                else
                {
                    //si no introduce una imagen tambien guardaremos el autor tanto en el programa como en la base de datos
                    bd.Insertar_Autor(un_autor);
                    MessageBox.Show("Autor insertado correctamente en la base de datos sin imagen");
                    //los_autores.Add(autores); //para añadirlo al arraylist
                    //MessageBox.Show("Autor insertado correctamente");

                }
            }


            bd.cerrar_Conexion();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //aqui introducimos la foto del autor
                //Filtro para que solo se puedan subir imagenes
                openFileDialog1.Filter = "Imagen|*.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                openFileDialog1.ShowDialog(); //para abrir el buscador de archivos
                pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //para cerrar la ventana
            this.Close();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
            }else
            {
                e.Handled=true;
            }
        }
    }
}
