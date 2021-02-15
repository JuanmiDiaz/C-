using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Proyecto14Abril
{
    [Serializable]
    class Libro
    {
        //Definimos los atributos de la clase Libro
        private int id_libro; //atributo para el id del libro
        private int id_autor; //atributo para el id del autor
        private int id_editorial; //atributo para la editorial del libro
        private string titulo_libro; //atributo para el titulo del libro
        private string isbn_libro; // atributo para el isbn del libro
        private int paginas_libro; //atributo para las paginas del libro
        private Image portada_libro; //atributo para la portada del libro

        /// <summary>
        /// Constructor para inicializar los atributos
        /// </summary>
        public Libro()
        {
            id_libro = 0;
            id_autor = 0;
            id_editorial = 0;
            titulo_libro = null;
            isbn_libro = null;
            paginas_libro = 0;
            portada_libro = null;
        }

        /// <summary>
        /// Constructor de la clase Libro
        /// </summary>
        /// <param name="id_libro"> Establece el id del libro</param>
        /// <param name="id_autor"> Establece el id del autor del libro</param>
        /// <param name="id_editorial">Establece el id de la editorial del libro</param>
        /// <param name="titulo_libro"> Establece el titulo del libro</param>
        /// <param name="isbn_libro"> Establece el ISBN del libro</param>
        /// <param name="paginas_libro"> Establece el numero de paginas del libro</param>
        /// <param name="portada_libro"> Establece la portada del libro</param>
        public Libro(int id_libro, int id_autor, int id_editorial, string titulo_libro, string isbn_libro, int paginas_libro, Image portada_libro)
        {
            this.id_libro = id_libro;
            this.id_autor = id_autor;
            this.id_editorial = id_editorial;
            this.titulo_libro = titulo_libro;
            this.isbn_libro = isbn_libro;
            this.paginas_libro = paginas_libro;
            this.portada_libro = portada_libro;
        }

        /// <summary>
        /// metodo para establecer el id del libro
        /// </summary>
        /// <param name="id_libro"> id del libro</param>
        public void establecerIdLibro(int id_libro)
        {
            this.id_libro = id_libro;
        }

        /// <summary>
        /// metodo para obtener el id del libro
        /// </summary>
        /// <returns></returns>
        public int obtenerIdLibro()
        {
            return this.id_libro;
        }

        /// <summary>
        /// metodo para establecer el id del autor del libro
        /// </summary>
        /// <param name="id_autor"> id del autor del libro</param>
        public void establecerIdAutor(int id_autor)
        {
            this.id_autor = id_autor;
        }

        /// <summary>
        /// metodo para obtener el id del autor del libro
        /// </summary>
        /// <param name="id_autor"></param>
        /// <returns></returns>
        public int obtenerIdAutor()
        {
            return this.id_autor;
        }

        /// <summary>
        /// metodo para establecer el id de la editorial
        /// </summary>
        /// <param name="id_editorial">id de la editorial</param>
        public void establecerIdEditorial(int id_editorial)
        {
            this.id_editorial = id_editorial;
        }

        /// <summary>
        /// metodo para obtener el id de la editorial del libro
        /// </summary>
        /// <returns></returns>
        public int obtenerIdEditorial()
        {
            return this.id_editorial;
        }

        /// <summary>
        /// metodo para establecer el titulo del libro
        /// </summary>
        /// <param name="titulo_libro"> titulo del libro</param>
        public void establecerTituloLibro(string titulo_libro)
        {
            this.titulo_libro = titulo_libro;
        }

        /// <summary>
        /// metodo para obtener titulo del libro
        /// </summary>
        /// <returns></returns>
        public string obtenerTituloLibro()
        {
            return this.titulo_libro;
        }

        /// <summary>
        /// metodo para establecer el ISBN del libro
        /// </summary>
        /// <param name="isbn_libro"> codigo ISBN del libro</param>
        public void establecerISBNLibro(string isbn_libro)
        {
            this.isbn_libro = isbn_libro;
        }

        /// <summary>
        /// metodo para obtener el ISBN del libro
        /// </summary>
        /// <returns></returns>
        public string obtenerISBNLibro()
        {
            return this.isbn_libro;
        }

        /// <summary>
        /// metodo para establecer las paginas del libro
        /// </summary>
        /// <param name="paginas_libro">numero de paginas del libro</param>
        public void establecerPaginasLibro(int paginas_libro)
        {
            this.paginas_libro = paginas_libro;
        }

        /// <summary>
        /// metodo para obtener el numero de paginas del libro
        /// </summary>
        /// <returns></returns>
        public int obtenerPaginasLibro()
        {
            return this.paginas_libro;
        }

        /// <summary>
        /// metodo para establacer la foto de la portada del libro
        /// </summary>
        /// <param name="portada_libro"></param>
        public void establecerPortadaLibro(Image portada_libro)
        {
            this.portada_libro = portada_libro;
        }

        /// <summary>
        /// metodo para obtener la portada del libro
        /// </summary>
        /// <returns></returns>
        public Image obtenerPortadaLibro()
        {
            return this.portada_libro;
        }

        /// <summary>
        /// metodo para obtener todos los datos del libro menos la imagen
        /// </summary>
        /// <returns></returns>
        public string obtenerDatosLibro()
        {
            string info_libro;
            info_libro = this.id_libro + " " + this.id_autor + " " + this.id_editorial + " " + this.titulo_libro + " " + this.isbn_libro + " " + this.paginas_libro;
            return info_libro;
        }
    }
    
}
