using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Proyecto14Abril
{
    [Serializable]
    class Autor
    {
        //establecemos los atributos de la clase Autor
        private int id; //atributo para el id del autor
        private string nombre; // atributo para el nombre del autor
        private string apellidos; //atributo para los apellidos del autor
        private string nacionalidad; //atributo para la nacionalidad del autor
        private DateTime f_nacimiento; //atributo para la fecha de nacimiento del autor
        private Image imagen_autor; //atributo para la foto del autor

        /// <summary>
        /// Constructor para inicializar los atributos de la clase
        /// </summary>
        public Autor()
        {
            id = 0;
            nombre = null;
            apellidos = null;
            nacionalidad = null;
            f_nacimiento = Convert.ToDateTime("01/01/2020");
            imagen_autor = null;
        }


        /// <summary>
        /// Constructor de la clase autor con todos los parametros
        /// </summary>
        /// <param name="id">Establece el id para el autor</param>
        /// <param name="nombre"> Establece el nombre del autor </param>
        /// <param name="apellidos"> Establece los apellidos del autor</param>
        /// <param name="nacionalidad"> Establece la nacionalidad del autor</param>
        /// <param name="f_nacimiento"> Establece la fecha de nacimiento del autor</param>
        /// <param name="imagen"> Estatablece la foto del autor</param>
        public Autor(int id, string nombre, string apellidos, string nacionalidad, DateTime f_nacimiento, Image imagen)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.nacionalidad = nacionalidad;
            this.f_nacimiento = f_nacimiento;
            this.imagen_autor = imagen;
        }

        /// <summary>
        /// Metoto para cambiar el id
        /// </summary>
        /// <param name="id"> id para asociar al autor</param>
        public void establecerId(int id)
        {
            this.id = id;
        }
        /// <summary>
        /// metodo para que nos devuelta el id del autor
        /// </summary>
        /// <returns></returns>
        public int obtenerId()
        {
            return this.id;
        }

        /// <summary>
        /// metodo para cambiar el nombre
        /// </summary>
        /// <param name="nombre">nombre que se le da al autor</param>
        public void establecerNombre(string nombre) 
        {
            this.nombre = nombre;
        }

        /// <summary>
        /// metodo para obtener el nombre del autor
        /// </summary>
        /// <returns></returns>
        public string obtenerNombre()
        {
            return this.nombre;
        }

        /// <summary>
        /// metodo para cambiar apellidos
        /// </summary>
        /// <param name="apellidos">apellidos del autor</param>
        public void establecerApellidos(string apellidos)
        {
            this.apellidos = apellidos;
        }

        /// <summary>
        /// metodo para mostrar el apellido del autor
        /// </summary>
        /// <returns></returns>
        public string obtenerApellidos()
        {
            return this.apellidos;
        }

        /// <summary>
        /// metodo para cambiar la nacionalidad
        /// </summary>
        /// <param name="nacionalidad"> nacionalidad del autor</param>
        public void establecerNacionalidad(string nacionalidad)
        {
            this.nacionalidad = nacionalidad;
        }
        /// <summary>
        /// metodo para obtener la nacionalidad del autor
        /// </summary>
        /// <returns></returns>
        public string obtenerNacionalidad()
        {
            return this.nacionalidad;
        }

        /// <summary>
        /// metodo para cambiar fecha de nacimiento del autor
        /// </summary>
        /// <param name="f_nacimiento"> fecha de nacimiento del autor</param>
        public void establecerFNacimiento(DateTime f_nacimiento)
        {
            this.f_nacimiento = f_nacimiento;
        }

        /// <summary>
        /// metodo para obtener la fecha de nacimiento del autor
        /// </summary>
        /// <returns></returns>
        public DateTime obtenerFNacimiento()
        {
            return this.f_nacimiento;
        }

        /// <summary>
        /// metodo para cambiar la imagen del autor
        /// </summary>
        /// <param name="imagen_autor"> imagen del autor</param>
        public void establecerFoto(Image imagen_autor)
        {
            this.imagen_autor = imagen_autor;

        }

        /// <summary>
        /// metodo para obtener la imagen del autor
        /// </summary>
        /// <returns></returns>
        public Image obtenerImagen()
        {
            return this.imagen_autor;
        }

        /// <summary>
        /// metodo para obtener los datos del autor sin la imagen
        /// </summary>
        /// <returns></returns>
        public string obtener_datos_autor()
        {
            string info_autor;
            info_autor = this.id + " " + this.nombre + " " + this.apellidos + " " + this.nacionalidad + " " + this.f_nacimiento;
            return info_autor;
        }


    }
}
