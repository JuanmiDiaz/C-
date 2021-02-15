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
    public partial class EliminarAutor : Form
    {
        private ArrayList mis_autores;
        
        /// <summary>
        /// constructor
        /// </summary>
        public EliminarAutor()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// contructor para inicializar variables
        /// </summary>
        /// <param name="a"></param>
        public EliminarAutor(ArrayList a)
        {
            InitializeComponent();
            mis_autores = a;

        }

        private void EliminarAutor_Load(object sender, EventArgs e)
        {
            //los textbox que no hacen falta estarán inhabilitados
            textBox4.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            dateTimePicker1.Enabled = false;
            pictureBox1.Enabled = false;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*
            //buscaremos el autor con el id introducido
            bool encontrado = false;
            int contador = 0;
            int indice = 0;
            if (textBox1.Text.Length != 0) //para asegurarnos que ha introducido un id
                foreach (Autor a in mis_autores)
                {
                    if (a.obtenerId() == Convert.ToInt32(textBox1.Text))
                    {
                        encontrado = true;
                        indice = contador;
                    }
                    contador++;
                }
            if (encontrado)
            {
                Autor a = (Autor)mis_autores[indice];
                textBox2.Text = a.obtenerNombre();
                textBox2.Enabled = true;
                textBox3.Text = a.obtenerApellidos();
                textBox3.Enabled = true;
                textBox4.Text = a.obtenerNacionalidad();
                textBox4.Enabled = true;
                dateTimePicker1.Value = Convert.ToDateTime(a.obtenerFNacimiento());
                dateTimePicker1.Enabled = true;
                pictureBox1.Image = a.obtenerImagen();
                pictureBox1.Enabled = true;
            }
            */
            //HASTA AQUI ERA PARA BUSCAR EL ID EN EL PROGRAMA
            //AHORA VAMOS A BUSCAR EL ID EN LA BASE DE DATOS

            if (textBox1.Text.Length != 0)  //siempre que el textbox no este vacio, haremos la busqueda
            {
                Base_de_datos bd = new Base_de_datos();

                bd.abrir_Conexion();

                bool existe = bd.existe_id_autor(Convert.ToInt32(textBox1.Text));

                if (existe == true)
                {
                    ArrayList modificar = new ArrayList();
                    modificar = bd.obtener_Autores_Para_Modificar(Convert.ToInt32(textBox1.Text));
                    Autor a;
                    a = (Autor)modificar[0];
                    textBox1.Enabled = false;
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                    dateTimePicker1.Enabled = true;
                    button4.Enabled = true;
                    textBox2.Text = a.obtenerNombre();
                    textBox3.Text = a.obtenerApellidos();
                    textBox4.Text = a.obtenerNacionalidad();
                    dateTimePicker1.Value = Convert.ToDateTime(a.obtenerFNacimiento());
                    pictureBox1.Image = a.obtenerImagen();
                }
                else
                {
                    MessageBox.Show("Ese Autor no existe");
                }
                bd.cerrar_Conexion();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
             //para eliminar el autor

             if (MessageBox.Show("¿Estas seguro de que quieres eliminar el Autor?", "Mensaje de Advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes)
             {
                 int contador = 0;
                 int indice = 0;
                 foreach(Autor a in mis_autores)
                 {
                     if (a.obtenerId() == Convert.ToInt32(textBox1.Text))
                     {
                         indice = contador;
                     }
                     contador++;
                 }
                 mis_autores.RemoveAt(indice);
                 MessageBox.Show("Autor eliminado correctamente");
                 this.Close();
             }

             //para borrar el autor de la base de datos
             Base_de_datos bd = new Base_de_datos();
             bd.abrir_Conexion();
             bd.eliminar_autor(Convert.ToInt32(textBox1.Text));
             bd.cerrar_Conexion();
             this.Close();
             */

            Base_de_datos bd = new Base_de_datos();
            bd.abrir_Conexion();
            bd.eliminar_autor(Convert.ToInt32(textBox1.Text));
            MessageBox.Show("Autor modificado correctamente");
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
    }


}
