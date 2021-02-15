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
    public partial class EliminarEditorial : Form
    {
        private ArrayList mis_editoriales;

        /// <summary>
        /// constructor
        /// </summary>
        public EliminarEditorial()
        {
            InitializeComponent();
        }

        /// <summary>
        /// constructor para inicializar variables
        /// </summary>
        /// <param name="ed"></param>
        public EliminarEditorial(ArrayList ed)
        {
            InitializeComponent();
            mis_editoriales = ed;
        }

        private void EliminarEditorial_Load(object sender, EventArgs e)
        { //los textbox que no hacen falta estarán inhabilitados
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            pictureBox1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*
            //buscaremos la editorial con el id introducido
            bool encontrado = false;
            int contador = 0;
            int indice = 0;
            if (textBox1.Text.Length != 0) //para asegurarnos que ha introducido un id
                foreach (Editorial ed in mis_editoriales)
                {
                    if (ed.obtenerIdEditorial() == Convert.ToInt32(textBox1.Text))
                    {
                        encontrado = true;
                        indice = contador;
                    }
                    contador++;
                }
            if (encontrado)
            {
                Editorial ed = (Editorial)mis_editoriales[indice];
                textBox2.Text = ed.obtenerNombreEditorial();
                textBox2.Enabled = true;
                textBox3.Text = ed.obtenerNacionalidadEditorial();
                textBox3.Enabled = true;
                pictureBox1.Image = ed.obtenerImagenEditorial();
                pictureBox1.Enabled = true;
            }
            */

            //HASTA AQUI ERA PARA BUSCAR EL ID EN EL PROGRAMA
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

                    button4.Enabled = true;
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
            //para eliminar la editorial
            if (MessageBox.Show("¿Estas seguro de que quieres eliminar la editorial?", "Mensaje de Advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int contador = 0;
                int indice = 0;
                foreach (Editorial ed in mis_editoriales)
                {
                    if (ed.obtenerIdEditorial() == Convert.ToInt32(textBox1.Text))
                    {
                        indice = contador;
                    }
                    contador++;
                }
                mis_editoriales.RemoveAt(indice);
                MessageBox.Show("Editorial eliminada correctamente");
                this.Close();
            }
            */
            Base_de_datos bd = new Base_de_datos();
            bd.abrir_Conexion();
            bd.eliminar_editorial(Convert.ToInt32(textBox1.Text));
            MessageBox.Show("Editorial modificada correctamente");
            bd.cerrar_Conexion();
            this.Close();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
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
