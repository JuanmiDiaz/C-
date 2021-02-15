using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Proyecto14Abril
{
    [Serializable]
    class Editorial
    {
        //establecemos los atributos de la clase Editorial
        private int id_editorial; //atributo para el id de la editorial
        private string nombre_editorial; // atributo para el nombre de la editorial
        private string nacionalidad_editorial; //atributo para la nacionalidad de la editorial
        private Image imagen_editorial; //atributo para la foto de la editorial

        /// <summary>
        /// constructor para inicializar los atributos de la clase
        /// </summary>
        public Editorial()
        {
            id_editorial = 0;
            nombre_editorial = null;
            nacionalidad_editorial = null;
            imagen_editorial = null;
        }

        /// <summary>
        /// constructor con los parametros de la clase
        /// </summary>
        /// <param name="id_editorial"></param>
        /// <param name="nombre_editorial"></param>
        /// <param name="nacionalidad_editorial"></param>
        /// <param name="imagen_editorial"></param>
        public Editorial(int id_editorial, string nombre_editorial, string nacionalidad_editorial, Image imagen_editorial)
        {
            this.id_editorial = id_editorial;
            this.nombre_editorial = nombre_editorial;
            this.nacionalidad_editorial = nacionalidad_editorial;
            this.imagen_editorial = imagen_editorial;
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
        /// metodo para obtener el id de la editorial
        /// </summary>
        /// <returns></returns>
        public int obtenerIdEditorial()
        {
            return this.id_editorial;
        }

        /// <summary>
        /// metodo para estbablecer el nombre de la editorial
        /// </summary>
        /// <param name="nombre_editorial"> nombre de la editorial</param>
        public void establecerNombreEditorial(string nombre_editorial)
        {
            this.nombre_editorial = nombre_editorial;
        }

        /// <summary>
        /// metodo para obtener el nombre de la editorial
        /// </summary>
        /// <returns></returns>
        public string obtenerNombreEditorial()
        {
            return this.nombre_editorial;
        }

        /// <summary>
        /// metodo para establecer la nacionalidad de la editorial
        /// </summary>
        /// <param name="nacionalidad_editorial"> nacionalidad de la editorial</param>
        public void establecerNacionalidadEditorial(string nacionalidad_editorial)
        {
            this.nacionalidad_editorial = nacionalidad_editorial;
        }

        /// <summary>
        /// metodo para obtener la nacionalidad de la editorial
        /// </summary>
        /// <returns></returns>
        public string obtenerNacionalidadEditorial()
        {
            return this.nacionalidad_editorial;
        }

        /// <summary>
        /// metodo para establecer una imagen de la editorial
        /// </summary>
        /// <param name="imagen_editorial"> imagen de la editorial</param>
        public void establacerImagenEditorial(Image imagen_editorial)
        {
            this.imagen_editorial = imagen_editorial;
        }

        /// <summary>
        /// metodo para obtener la imagen de la editorial
        /// </summary>
        /// <returns></returns>
        public Image obtenerImagenEditorial()
        {
            return this.imagen_editorial;
        }

        /// <summary>
        /// metodo que devuelve los datos de la editorial
        /// </summary>
        /// <returns></returns>
        public string obtener_datos_editorial()
        {
            string info_editorial;
            info_editorial = this.id_editorial + " " + this.nombre_editorial + " " + this.nacionalidad_editorial;
            return info_editorial;
        }
    }
}
