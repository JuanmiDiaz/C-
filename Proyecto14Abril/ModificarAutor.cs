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
    public partial class ModificarAutor : Form
    {
        //variabbles y array
        private ArrayList lista_autores;
        private bool modificado;
        /// <summary>
        /// constructor
        /// </summary>
        public ModificarAutor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// constructor para inicializar variables
        /// </summary>
        /// <param name="a"></param>
        public ModificarAutor(ArrayList a)
        {
            InitializeComponent();
            lista_autores = a;
            modificado = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //para cerrar 
            this.Close();
        }

        private void ModificarAutor_Load(object sender, EventArgs e)
        {
          

        }

 
        private void button4_Click(object sender, EventArgs e)
        {
            /*
                        //boton para buscar el id del autor que queremos encontrar  
                        bool encontrado = false;
                        int contador = 0;
                        int indice = 0;

                        if(textBox1.Text.Length != 0)
                        {
                            foreach(Autor a in lista_autores)
                            {
                                if (a.obtenerId() == Convert.ToInt32(textBox1.Text))
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
                                dateTimePicker1.Enabled = true;
                                Autor a;
                                a = (Autor)lista_autores[indice];
                                textBox2.Text = a.obtenerNombre();
                                textBox3.Text = a.obtenerApellidos();
                                textBox4.Text = a.obtenerNacionalidad();
                                dateTimePicker1.Value = Convert.ToDateTime(a.obtenerFNacimiento());
                                pictureBox1.Image = a.obtenerImagen();
                                textBox1.Enabled = false; 
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

               bool existe= bd.existe_id_autor(Convert.ToInt32(textBox1.Text));

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
                    button1.Enabled = true;
                    textBox2.Text = a.obtenerNombre();
                    textBox3.Text = a.obtenerApellidos();
                    textBox4.Text = a.obtenerNacionalidad();
                    dateTimePicker1.Value = Convert.ToDateTime(a.obtenerFNacimiento());
                    pictureBox1.Image = a.obtenerImagen();
                   
            }else{
                    MessageBox.Show("Ese Autor no existe");

                }
               
                bd.cerrar_Conexion();

            }
        }



        private void ModificarAutor_Load_1(object sender, EventArgs e)
        {
            //hace que al abrir la venana los textbox esten deshabilitados
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            dateTimePicker1.Enabled = false;
            button1.Enabled = false;
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
                foreach(Autor a in lista_autores)
                {
                    if (a.obtenerId() == Convert.ToInt32(textBox1.Text))
                    {
                        indice = contador; //se le asigna el valor al indice
                    }
                    else
                    {
                        contador++;
                    }
                }
                lista_autores.RemoveAt(indice);
                Autor un_autor_modificado = new Autor(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Value, pictureBox1.Image);
                lista_autores.Insert(indice, un_autor_modificado);
                MessageBox.Show("Autor modificado correctamente");
                this.Close();
            }
            */
            Base_de_datos bd = new Base_de_datos();
            bd.abrir_Conexion();
            bd.modificar_Autor(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Value, pictureBox1);
            MessageBox.Show("Autor modificado correctamente");
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            modificado = true;

        }
    }
}
