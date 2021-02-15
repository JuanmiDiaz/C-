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
    public partial class ModificarEditorial : Form
    {
        //variabbles y array
        private ArrayList lista_editoriales;
        private bool modificado;

        /// <summary>
        /// constructor
        /// </summary>
        public ModificarEditorial()
        {
            InitializeComponent();
        }

        /// <summary>
        /// constructor para inicializar variables
        /// </summary>
        /// <param name="ed"></param>
        public ModificarEditorial(ArrayList ed)
        {
            InitializeComponent();
            lista_editoriales = ed;
            modificado = false;
        }

        private void ModificarEditorial_Load(object sender, EventArgs e)
        {
            //hace que al abrir la venana los textbox esten deshabilitados
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*
            //boton para buscar el id de la editorial que queremos encontrar
            bool encontrado = false;
            int contador = 0;
            int indice = 0;

            if (textBox1.Text.Length != 0)
            {
                foreach (Editorial ed in lista_editoriales)
                {
                    if (ed.obtenerIdEditorial() == Convert.ToInt32(textBox1.Text))
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
                    Editorial ed;
                    ed = (Editorial)lista_editoriales[indice];
                    textBox2.Text = ed.obtenerNombreEditorial();
                    textBox3.Text = ed.obtenerNacionalidadEditorial();
                    textBox1.Enabled = false;
                    pictureBox1.Image = ed.obtenerImagenEditorial();

                    //el campo de id lo dejaremos bloqueado para no poder modificarlo
                }
            }
            else
            {
                MessageBox.Show("Debes introducir un id");
            }
*/
            // HASTA AQUI ERA PARA BUSCAR EL ID EN EL PROGRAMA
            //AHORA VAMOS A BUSCAR EL ID EN LA BASE DE DATOS

            if (textBox1.Text.Length != 0)  //siempre que el textbox no este vacio, haremos la busqueda
            {
                Base_de_datos bd = new Base_de_datos();

                bd.abrir_Conexion();

                bool existe = bd.existe_id_editorial(Convert.ToInt32(textBox1.Text));

                if (existe == true)
                {
                    ArrayList modificar = new ArrayList();
                    modificar = bd.obtener_Editoriales_Para_Modificar(Convert.ToInt32(textBox1.Text));
                    Editorial ed;
                    ed = (Editorial)modificar[0];
                    textBox1.Enabled = false;
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                   
                    button1.Enabled = true;
                    textBox2.Text = ed.obtenerNombreEditorial();
                    textBox3.Text = ed.obtenerNombreEditorial();
                    pictureBox1.Image = ed.obtenerImagenEditorial();

                }
                else
                {
                    MessageBox.Show("Esa Editorial no existe");

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
                 foreach (Editorial ed in lista_editoriales)
                 {
                     if (ed.obtenerIdEditorial() == Convert.ToInt32(textBox1.Text))
                     {
                         indice = contador;
                     }
                     else
                     {
                         contador++;
                     }
                 }
                 lista_editoriales.RemoveAt(indice);
                 Editorial una_editorial_modificado = new Editorial(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, pictureBox1.Image);
                 lista_editoriales.Insert(indice, una_editorial_modificado);
                 MessageBox.Show("Editorial modificada correctamente");
                 this.Close();
             }
             */
            Base_de_datos bd = new Base_de_datos();
            bd.abrir_Conexion();
            bd.modificar_Editorial(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, pictureBox1);
            MessageBox.Show("Editorial modificada correctamente");
            bd.cerrar_Conexion();
            this.Close();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            //aqui introducimos la foto
            //Filtro para que solo se puedan subir imagenes
            openFileDialog1.Filter = "Imagen|*.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            modificado = true;

        }
    }
}
