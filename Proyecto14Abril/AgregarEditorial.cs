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
    public partial class AgregarEditorial : Form
    {
        private ArrayList las_editoriales;

        /// <summary>
        /// constructor
        /// </summary>
        public AgregarEditorial()
        {
            InitializeComponent();
        }

        public AgregarEditorial(ArrayList ed)
        {
            InitializeComponent();
            las_editoriales = ed;

        }

        private void AgregarEditorial_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //al hacer click se asignaran los valores de los textbox a cada editorial creada
            Editorial una_editorial = new Editorial();
            una_editorial.establecerIdEditorial(Convert.ToInt32(textBox1.Text));
            una_editorial.establecerNombreEditorial(textBox2.Text);
            una_editorial.establecerNacionalidadEditorial(textBox3.Text);
            una_editorial.establacerImagenEditorial(pictureBox1.Image);


            //vamos a insertar  la editorial en la base de datos
            Base_de_datos bd = new Base_de_datos();
            bd.abrir_Conexion();

            //primero llamamos a la funcion para comprobar si existe la editorial

            if (bd.existe_id_editorial(Convert.ToInt32(textBox1.Text)))
            {
                //si existe no dejaría insertarla
                MessageBox.Show("Esa editorial ya esta insertado en la base de datos");
            }
            else
            {
                //si no esta insertada, se insertaria en la base de datos
                if (pictureBox1.Image != null)
                {
                    if (bd.Insertar_Editorial(una_editorial, pictureBox1))
                    {
                        MessageBox.Show("Editorial insertada correctamente en la base de datos");
                        //y se insertaria en el programa tambien
                        //las_editoriales.Add(una_editorial); //para añadirla al arraylist
                        //MessageBox.Show("Editorial insertada correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Problemas con la insercion en la base de datos");
                    }
                }
                else
                {
                    //si no introduce una imagen tambien guardaremos el autor tanto en el programa como en la base de datos
                    bd.Insertar_Editorial(una_editorial);
                    MessageBox.Show("Editorial insertada correctamente en la base de datos sin imagen");
                    //las_editoriales.Add(una_editorial); //para añadirlo al arraylist
                    //MessageBox.Show("Editorial insertada correctamente");

                }
            }

            bd.cerrar_Conexion();
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

        private void button1_Click(object sender, EventArgs e)
        {
            //aqui introducimos la foto
            //Filtro para que solo se puedan subir imagenes
            openFileDialog1.Filter = "Imagen|*.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
