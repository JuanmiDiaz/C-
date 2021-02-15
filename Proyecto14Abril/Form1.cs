using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto14Abril
{
    public partial class Form1 : Form
    {

        private ArrayList autores; // creamos un arrayList para autores
        private ArrayList libros; //creamos un arrayList para libros
        private ArrayList editoriales; //creamos un arrayList para las editoriales

        public Form1()
        {
            InitializeComponent();
            autores = new ArrayList();
            libros = new ArrayList();
            editoriales = new ArrayList();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarAutor aa = new AgregarAutor(autores); // para agregar los autores
            aa.ShowDialog();
        
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // consulta de autores ya creados
            //haremos una consulta para sacar un mensaje de error si no hay ningun autor aun

            Base_de_datos bd = new Base_de_datos();

            bd.abrir_Conexion();

            autores = bd.obtener_Autores();

            if ( autores.Count == 0)
            {
                MessageBox.Show("No hay autores en la base de datos");
            }
            else
            {
                ConsultarAutores ca = new ConsultarAutores(autores);
                ca.ShowDialog();
            }

        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //modificar autores
            ModificarAutor ma = new ModificarAutor(autores);
            ma.ShowDialog();

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //eliminar autores
            EliminarAutor ea = new EliminarAutor(autores);
            ea.ShowDialog();

        }

        private void agregarLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarLibro al = new AgregarLibro(libros, autores, editoriales); // para agregar los libros
            al.ShowDialog();
        }

        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // consulta de libros ya creados
            //haremos una consulta para sacar un mensaje de error si no hay ningun libro aun
            Base_de_datos bd = new Base_de_datos();

            bd.abrir_Conexion();

            libros = bd.obtener_Libros();

            if (libros.Count == 0)
            {
                MessageBox.Show("No hay libros en la base de datos");
            }
            else
            {
                ConsultarLibro cl = new ConsultarLibro(libros);
                cl.ShowDialog();
            }


        }

        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //modificar autores
            ModificarLibro ml = new ModificarLibro(libros);
            ml.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            


        }

        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //eliminar libros
            EliminarLibro el = new EliminarLibro(libros);
            el.ShowDialog();


        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AgregarEditorial ae = new AgregarEditorial(editoriales); // para agregar los editoriales
            ae.ShowDialog();

        }

        private void consultarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            

        // consulta de editoriales ya creadas
        //haremos una consulta para sacar un mensaje de error si no hay ninguna editorial aun

            Base_de_datos bd = new Base_de_datos();

             bd.abrir_Conexion();

            editoriales = bd.obtener_Editoriales();
            if (editoriales.Count == 0)
            {
                MessageBox.Show("No hay editoriales en la base de datos");
            }
            else
            {
                ConsultarEditorial ce = new ConsultarEditorial(editoriales);
                ce.ShowDialog();
            }

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Almacenamos los autores en un fichero binario
            if (autores.Count != 0)
            {
                //Como tiene datos almacenamos los datos en un fichero
                IFormatter formato = new BinaryFormatter();
                FileStream fs = new FileStream("Autor", FileMode.Create);
                formato.Serialize(fs, autores);
                fs.Close();
            }

            if (libros.Count != 0)
            {
                //Como tiene datos almacenamos los datos en un fichero
                IFormatter formato = new BinaryFormatter();
                FileStream fs = new FileStream("Libro", FileMode.Create);
                formato.Serialize(fs, libros);
                fs.Close();
            }

            if (editoriales.Count != 0)
            {
                //Como tiene datos almacenamos los datos en un fichero
                IFormatter formato = new BinaryFormatter();
                FileStream fs = new FileStream("Editorial", FileMode.Create);
                formato.Serialize(fs, editoriales);
                fs.Close();
            }
            Application.Exit();
        }

        private void modificarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //modificar autores
            ModificarEditorial me = new ModificarEditorial(editoriales);
            me.ShowDialog();

        }

        private void eliminarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //eliminar libros
            EliminarEditorial ed = new EliminarEditorial(editoriales);
            ed.ShowDialog();
        }
    }
}
