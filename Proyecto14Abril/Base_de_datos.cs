using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Proyecto14Abril
{
    class Base_de_datos
    {
        //Declaramos los atributos de la clase Base de Datos
        private IDbConnection conexion = null;
        private string cadena_de_conexion = "server=(local);" + "Initial Catalog=LAE;"+"Integrated Security=true";
        private IDbCommand cmd;
        private IDataReader mis_datos;
        private Boolean conectado = false;

        /// <summary>
        /// Constructor de la clase Base de datos
        /// </summary>
        public Base_de_datos()
        {
            //conectarnos a la base de datos
            conexion = new SqlConnection(cadena_de_conexion);
            //ahora estamos conectados pero no hemos abierto ninguna conexion
        }

        /// <summary>
        /// metodo para abrir la conexion con la base de datos
        /// </summary>
        /// <returns></returns>
        public bool abrir_Conexion()
        {
            Boolean f = false;
            if (!conectado)
            {
                //conectamos.
                conexion.Open();
                conectado = true;
                f = true;
            }
            return f;
        }

        /// <summary>
        /// metodo para cerrar la conexión de la base de datos
        /// </summary>
        public void cerrar_Conexion()
        {
            if (conectado)
            {
                conexion.Close();
                conectado = false;
           
            }
  
        }

        /// <summary>
        /// metodo para insertar autor sin imagen
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool Insertar_Autor(Autor a)
        {
            bool valor = false;
            cmd = conexion.CreateCommand();
            cmd.CommandText = "Insert into Autores(id_autor,nombre_autor,apellidos_autor,nacionalidad_autor" +
                ",fecha_autor) values (@id,@nombre,@apellidos,@nacionalidad,@fecha)";
            cmd.Parameters.Add(new SqlParameter("@id", a.obtenerId()));
            cmd.Parameters.Add(new SqlParameter("@nombre", a.obtenerNombre()));
            cmd.Parameters.Add(new SqlParameter("@apellidos", a.obtenerApellidos()));
            cmd.Parameters.Add(new SqlParameter("@nacionalidad", a.obtenerNacionalidad()));
            cmd.Parameters.Add(new SqlParameter("@fecha", Convert.ToDateTime(a.obtenerFNacimiento())));

            int resultado = cmd.ExecuteNonQuery();
            if (resultado != 0)
            {
                valor = true;
            }
            else
            {
                valor = false;
            }

            return valor;
        }


        /// <summary>
        /// metodo para intruducir los datos del autor en la base de datos con imagen
        /// </summary>
        /// <param name="a"></param>
        /// <param name="bd"></param>
        /// <returns></returns>
        public bool Insertar_Autor(Autor a, PictureBox pd)
        {
            bool valor = false;
            cmd = conexion.CreateCommand();
            //a continuacion insertamos los datos. Primero los campos de la tabla y luego con @ los campos de la clase
            cmd.CommandText = "Insert into Autores(id_autor, nombre_autor, apellidos_autor, nacionalidad_autor, fecha_autor, imagen) values (@id, @nombre, @apellidos, @nacionalidad, @f_nacimiento, @imagen_autor)";
            cmd.Parameters.Add(new SqlParameter("@id", a.obtenerId()));
            cmd.Parameters.Add(new SqlParameter("@nombre", a.obtenerNombre()));
            cmd.Parameters.Add(new SqlParameter("@apellidos", a.obtenerApellidos()));
            cmd.Parameters.Add(new SqlParameter("@nacionalidad", a.obtenerNacionalidad()));
            cmd.Parameters.Add(new SqlParameter("@f_nacimiento", Convert.ToDateTime(a.obtenerFNacimiento())));
            cmd.Parameters.Add(new SqlParameter("@imagen_autor",convertir_imagen(pd.ImageLocation)));

            int resultado = cmd.ExecuteNonQuery();
            if (resultado != 0)
            {
                valor = true;
            }
            else
            {
                valor = false;
            }
            return valor;

            }

        /// <summary>
        /// metodo para insertar una editorial en la base de datos sin imagen
        /// </summary>
        /// <param name="ed"></param>
        /// <param name="bd"></param>
        /// <returns></returns>
        public bool Insertar_Editorial(Editorial ed)
        {
            bool valor = false;
            cmd = conexion.CreateCommand();
            //a continuacion insertamos los datos. Primero los campos de la tabla y luego con @ los campos de la clase
            cmd.CommandText = "Insert into Editoriales(id_editorial, nombre_editorial, nacionalidad_editorial) values (@id_editorial, @nombre_editorial, @nacionalidad_editorial)";
            cmd.Parameters.Add(new SqlParameter("@id_editorial", ed.obtenerIdEditorial()));
            cmd.Parameters.Add(new SqlParameter("@nombre_editorial", ed.obtenerNombreEditorial()));
            cmd.Parameters.Add(new SqlParameter("@nacionalidad_editorial", ed.obtenerNacionalidadEditorial()));

            int resultado = cmd.ExecuteNonQuery();
            if (resultado != 0)
            {
                valor = true;
            }
            else
            {
                valor = false;
            }
            return valor;

        }

        /// <summary>
        /// metodo para introducir los datos de la editorial en la base de datos con imagen
        /// </summary>
        /// <param name="ed"></param>
        /// <param name="bd"></param>
        /// <returns></returns>
        public bool Insertar_Editorial(Editorial ed, PictureBox bd)
        {
            bool valor = false;
            cmd = conexion.CreateCommand();
            //a continuacion insertamos los datos. Primero los campos de la tabla y luego con @ los campos de la clase
            cmd.CommandText = "Insert into Editoriales(id_editorial, nombre_editorial, nacionalidad_editorial, imagen) values (@id_editorial, @nombre_editorial, @nacionalidad_editorial,  @imagen_editorial)";
            cmd.Parameters.Add(new SqlParameter("@id_editorial", ed.obtenerIdEditorial()));
            cmd.Parameters.Add(new SqlParameter("@nombre_editorial", ed.obtenerNombreEditorial()));
            cmd.Parameters.Add(new SqlParameter("@nacionalidad_editorial", ed.obtenerNacionalidadEditorial()));
            cmd.Parameters.Add(new SqlParameter("@imagen_editorial", convertir_imagen(bd.ImageLocation)));

            int resultado = cmd.ExecuteNonQuery();
            if (resultado != 0)
            {
                valor = true;
            }
            else
            {
                valor = false;
            }
            return valor;

        }

        /// <summary>
        /// metodo para insertar un libro sin imagen
        /// </summary>
        /// <param name="l"></param>
        /// <param name="bd"></param>
        /// <returns></returns>
        public bool Insertar_Libro(Libro l)
        {
            bool valor = false;
            cmd = conexion.CreateCommand();
            //a continuacion insertamos los datos. Primero los campos de la tabla y luego con @ los campos de la clase
            cmd.CommandText = "Insert into Libros(id_libro, id_autor, id_editorial, titulo_libro, isbn, paginas_libro) values (@id_libro, @id_autor, @id_editorial, @titulo_libro, @isbn, @paginas_libro)";
            cmd.Parameters.Add(new SqlParameter("@id_libro", l.obtenerIdLibro()));
            cmd.Parameters.Add(new SqlParameter("@id_autor", l.obtenerIdAutor()));
            cmd.Parameters.Add(new SqlParameter("@id_editorial", l.obtenerIdEditorial()));
            cmd.Parameters.Add(new SqlParameter("@titulo_libro", l.obtenerTituloLibro()));
            cmd.Parameters.Add(new SqlParameter("@isbn", l.obtenerISBNLibro()));
            cmd.Parameters.Add(new SqlParameter("@paginas_libro", l.obtenerPaginasLibro()));

            int resultado = cmd.ExecuteNonQuery();
            if (resultado != 0)
            {
                valor = true;
            }
            else
            {
                valor = false;
            }
            return valor;

        }

        /// <summary>
        /// metodo para introducir los datos del libro en la base de datos con imagen
        /// </summary>
        /// <param name="l"></param>
        /// <param name="bd"></param>
        /// <returns></returns>
        public bool Insertar_Libro(Libro l, PictureBox bd)
        {
            bool valor = false;
            cmd = conexion.CreateCommand();
            //a continuacion insertamos los datos. Primero los campos de la tabla y luego con @ los campos de la clase
            cmd.CommandText = "Insert into Libros(id_libro, id_autor, id_editorial, titulo_libro, isbn, paginas_libro, imagen) values (@id_libro, @id_autor, @id_editorial, @titulo_libro, @isbn, @paginas_libro, @portada_libro)";
            cmd.Parameters.Add(new SqlParameter("@id_libro", l.obtenerIdLibro()));
            cmd.Parameters.Add(new SqlParameter("@id_autor", l.obtenerIdAutor()));
            cmd.Parameters.Add(new SqlParameter("@id_editorial", l.obtenerIdEditorial()));
            cmd.Parameters.Add(new SqlParameter("@titulo_libro", l.obtenerTituloLibro()));
            cmd.Parameters.Add(new SqlParameter("@isbn", l.obtenerISBNLibro()));
            cmd.Parameters.Add(new SqlParameter("@paginas_libro", l.obtenerPaginasLibro()));
            cmd.Parameters.Add(new SqlParameter("@portada_libro", convertir_imagen(bd.ImageLocation)));

            int resultado = cmd.ExecuteNonQuery();
            if (resultado != 0)
            {
                valor = true;
            }
            else
            {
                valor = false;
            }
            return valor;

        }

        /// <summary>
        /// metodo para convertir la imagen introducida en el programa en datos para la base de datos
        /// </summary>
        /// <param name="filefoto"></param>
        /// <returns></returns>
        public byte[] convertir_imagen(string filefoto)
            {

            MemoryStream ms = new MemoryStream();
            FileStream fs = new FileStream( filefoto, FileMode.Open, FileAccess.Read, FileShare.ReadWrite );

            ms.SetLength(fs.Length);
            fs.Read(ms.GetBuffer(), 0, (int)fs.Length);

            byte[] arrImg = ms.GetBuffer();
            ms.Flush();
            fs.Close();

            return arrImg;

            }

        /// <summary>
        /// metodo para comprobar si existe ese autor en la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool existe_id_autor(int id)
        {
            bool encontrado = false;
            cmd = conexion.CreateCommand();
            cmd.CommandText = "Select * from Autores where id_autor=" + id;
            mis_datos = cmd.ExecuteReader();
            if (mis_datos.Read())
            {
                if (Convert.ToInt32(mis_datos[0]) == id)            
                {
                    encontrado = true;
                }
                else
                {
                    encontrado = false;
                }
                mis_datos.Close();
            }
            mis_datos.Close();
            return encontrado;
        }

        /// <summary>
        /// para comprobar si existe la editorial en la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool existe_id_editorial(int id)
        {
            bool encontrado = false;
            cmd = conexion.CreateCommand();
            cmd.CommandText = "Select * from Editoriales where id_editorial=" + id;
            mis_datos = cmd.ExecuteReader();
            if (mis_datos.Read())
            {
                if (Convert.ToInt32(mis_datos[0]) == id)          
                {
                    encontrado = true;
                }
                else
                {
                    encontrado = false;
                }
                mis_datos.Close();
            }
            mis_datos.Close();
            return encontrado;
        }

        /// <summary>
        /// metodo para saber si el libro ya existe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool existe_id_libro(int id)
        {
            bool encontrado = false;
            cmd = conexion.CreateCommand();
            cmd.CommandText = "Select * from Libros where id_libro=" + id;
            mis_datos = cmd.ExecuteReader();
            if (mis_datos.Read())
            {
                if (Convert.ToInt32(mis_datos[0]) == id)
                {
                    encontrado = true;
                }
                else
                {
                    encontrado = false;
                }
                mis_datos.Close();
            }
            mis_datos.Close();
            return encontrado;
        }
        /// <summary>
        /// metodo para obtener autores para la consulta
        /// </summary>
        /// <returns></returns>
        public ArrayList obtener_Autores()
        {
            ArrayList autores_bd = new ArrayList();
            Autor a;
            Image imagen;
            cmd = conexion.CreateCommand();
            cmd.CommandText ="Select * from Autores";
            mis_datos = cmd.ExecuteReader();

            //ahora vamos a comprobar que hay datos, y si hay se añaden al arraylist
            while (mis_datos.Read())
            {
                if (mis_datos[5] == DBNull.Value)
                {
                    imagen = null;

                }
                else
                {
                    imagen = extraer_Imagen((byte[])mis_datos[5]);
                }
                a = new Autor(Convert.ToInt32(mis_datos[0]), mis_datos[1].ToString(), mis_datos[2].ToString(),mis_datos[3].ToString(), (Convert.ToDateTime(mis_datos[4])), imagen);
                autores_bd.Add(a);

            }
            return autores_bd;
        }
        /// <summary>
        /// metodo para obtener editoriales para la consulta
        /// </summary>
        /// <returns></returns>
        public ArrayList obtener_Editoriales()
        {
            ArrayList editoriales_bd = new ArrayList();
            Editorial ed;
            Image imagen;
            cmd = conexion.CreateCommand();
            cmd.CommandText = "Select * from Editoriales";
            mis_datos = cmd.ExecuteReader();

            //ahora vamos a comprobar que hay datos, y si hay se añaden al arraylist
            while (mis_datos.Read())
            {
                if (mis_datos[3] == DBNull.Value)
                {
                    imagen = null;

                }
                else
                {
                    imagen = extraer_Imagen((byte[])mis_datos[3]);
                }
                ed = new Editorial(Convert.ToInt32(mis_datos[0]), mis_datos[1].ToString(), mis_datos[2].ToString(), imagen);
                editoriales_bd.Add(ed);

            }
            return editoriales_bd;
        }

        public ArrayList obtener_Libros()
        {
            ArrayList libros_bd = new ArrayList();
            Libro l;
            Image imagen;
            cmd = conexion.CreateCommand();
            cmd.CommandText = "Select * from Libros";
            mis_datos = cmd.ExecuteReader();

            //ahora vamos a comprobar que hay datos, y si hay se añaden al arraylist
            while (mis_datos.Read())
            {
                if (mis_datos[6] == DBNull.Value)
                {
                    imagen = null;

                }
                else
                {
                    imagen = extraer_Imagen((byte[])mis_datos[6]);
                }
                l = new Libro(Convert.ToInt32(mis_datos[0]), Convert.ToInt32(mis_datos[1]), Convert.ToInt32(mis_datos[2]), mis_datos[3].ToString(), mis_datos[4].ToString(), Convert.ToInt32(mis_datos[5]), imagen);
                libros_bd.Add(l);

            }
            return libros_bd;
        }



        /// <summary>
        /// metodo para obtener autores para la modificacion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ArrayList obtener_Autores_Para_Modificar(int id)
        {
            ArrayList autores_bd = new ArrayList();
            Autor a;
            Image imagen;
            cmd = conexion.CreateCommand();
            cmd.CommandText = "Select * from Autores where id_autor=" + id;
            mis_datos = cmd.ExecuteReader();

            //ahora vamos a comprobar que hay datos, y si hay se añaden al arraylist
            while (mis_datos.Read())
            {
                if (mis_datos[5] == DBNull.Value)
                {
                    imagen = null;

                }
                else
                {
                    imagen = extraer_Imagen((byte[])mis_datos[5]);
                }
                a = new Autor(Convert.ToInt32(mis_datos[0]), mis_datos[1].ToString(), mis_datos[2].ToString(), mis_datos[3].ToString(), (Convert.ToDateTime(mis_datos[4])), imagen);
                autores_bd.Add(a);

            }
            return autores_bd;
        }
        /// <summary>
        /// metodo para obtener editoriales para la modificacion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ArrayList obtener_Editoriales_Para_Modificar(int id)
        {
            ArrayList editoriales_bd = new ArrayList();
            Editorial ed;
            Image imagen;
            cmd = conexion.CreateCommand();
            cmd.CommandText = "Select * from Editoriales where id_editorial=" + id;
            mis_datos = cmd.ExecuteReader();

            //ahora vamos a comprobar que hay datos, y si hay se añaden al arraylist
            while (mis_datos.Read())
            {
                if (mis_datos[3] == DBNull.Value)
                {
                    imagen = null;
                }
                else
                {
                    imagen = extraer_Imagen((byte[])mis_datos[3]);
                }
                ed = new Editorial(Convert.ToInt32(mis_datos[0]), mis_datos[1].ToString(), mis_datos[2].ToString(), imagen);
                editoriales_bd.Add(ed);
            }
            return editoriales_bd;
        }

        public ArrayList obtener_Libros_Para_Modificar(int id)
        {
            ArrayList libros_bd = new ArrayList();
            Libro l;
            Image imagen;
            cmd = conexion.CreateCommand();
            cmd.CommandText = "Select * from Libros where id_libro=" + id;
            mis_datos = cmd.ExecuteReader();

            //ahora vamos a comprobar que hay datos, y si hay se añaden al arraylist
            while (mis_datos.Read())
            {
                if (mis_datos[6] == DBNull.Value)
                {
                    imagen = null;
                }
                else
                {
                    imagen = extraer_Imagen((byte[])mis_datos[6]);
                }
                l = new Libro(Convert.ToInt32(mis_datos[0]), Convert.ToInt32(mis_datos[1]), Convert.ToInt32(mis_datos[2]), mis_datos[3].ToString(), mis_datos[4].ToString(), Convert.ToInt32(mis_datos[5]), imagen);
                libros_bd.Add(l);
            }
            return libros_bd;
        }
        /// <summary>
        /// metodo para extraer imagen
        /// </summary>
        /// <param name="laimagen"></param>
        /// <returns></returns>
        public Image extraer_Imagen(byte[] laimagen)
        {
            Image img=null;
            try
            {
                byte[] arrImg = (byte[])laimagen;
                MemoryStream ms = new MemoryStream(laimagen);
                img = Image.FromStream(ms);
                ms.Close();
            }catch(Exception ex)
            {
                ;
            }
            return img;
        }
        /// <summary>
        /// metodo para eliminar un autor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool eliminar_autor(int id)
        {
            //metodo para eliminar un autor
            bool eliminado = false;
            cmd = conexion.CreateCommand();
            cmd.CommandText = "delete from Autores where id_autor=" + id;
            //creamos la consulta
            cmd.ExecuteNonQuery(); //y ejecutamos la consulta, y el autor quedaría eliminado
            int resultado = cmd.ExecuteNonQuery(); //cantidad de filas afectadas por el command text

            if (resultado == 0)
            {
                //no se ha eliminado ningun autor
            }
            else
            {
                //como minimo se ha eliminado una fila (un autor)
            }
            
            return eliminado;
        }

        /// <summary>
        /// metodo para eliminar una editorial
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool eliminar_editorial(int id)
        {
            //metodo para eliminar un autor
            bool eliminado = false;
            cmd = conexion.CreateCommand();
            cmd.CommandText = "delete from Editoriales where id_editorial=" + id;
            //creamos la consulta
            cmd.ExecuteNonQuery(); //y ejecutamos la consulta, y la editorial quedaría eliminada
            int resultado = cmd.ExecuteNonQuery(); //cantidad de filas afectadas por el command text

            if (resultado == 0)
            {
                //no se ha eliminado ninguna editorial
            }
            else
            {
                //como minimo se ha eliminado una fila (una editorial)
            }

            return eliminado;
        }

        /// <summary>
        /// metodo para eliminar un libro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool eliminar_libro(int id)
        {
            //metodo para eliminar un libro
            bool eliminado = false;
            cmd = conexion.CreateCommand();
            cmd.CommandText = "delete from Libros where id_libro=" + id;
            //creamos la consulta
            cmd.ExecuteNonQuery(); //y ejecutamos la consulta, y el libro quedaría eliminado
            int resultado = cmd.ExecuteNonQuery(); //cantidad de filas afectadas por el command text

            if (resultado == 0)
            {
                //no se ha eliminado ningun libro
            }
            else
            {
                //como minimo se ha eliminado una fila (un libro)
            }

            return eliminado;
        }
        /// <summary>
        /// metodo para modificar un autor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellidos"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="f_nacimiento"></param>
        /// <param name="pb"></param>
        /// <returns></returns>
        public bool modificar_Autor(int id, string nombre, string apellidos, string nacionalidad, DateTime f_nacimiento, PictureBox pb)
        {
            bool modificado = false;

            cmd = conexion.CreateCommand();
            //comando para trabajar en la base de dato
            //antes de insertar la imagen debemos saber si es nula o no
            if (pb.Image != null)
                {
                //si hay imagen
                cmd.CommandText = "update Autores set nombre_autor=@nombre, apellidos_autor=@apellidos, nacionalidad_autor=@nacionalidad, fecha_autor=@f_nacimiento,imagen=imagen where id_autor =" + id;
                cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                cmd.Parameters.Add(new SqlParameter("@apellidos", apellidos));
                cmd.Parameters.Add(new SqlParameter("@nacionalidad", nacionalidad));
                cmd.Parameters.Add(new SqlParameter("@f_nacimiento", f_nacimiento));
                //referenciamos a la imagen en memoria para poder almacenarla en la base de datos
                cmd.Parameters.Add(new SqlParameter("@imagen", convertir_imagen(pb.ImageLocation)));
                modificado = true;
                cmd.ExecuteNonQuery();  //para dejar esa consulta reflejada en la base de datos
            }
            else
            {
                //como no hay imagen tenemos que parametrizarla
                cmd.CommandText = "update Autores set nombre_autor=@nombre, apellidos_autor=@apellidos, nacionalidad_autor=@nacionalidad, fecha_autor=@f_nacimiento where id_autor="+id;
                cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                cmd.Parameters.Add(new SqlParameter("@apellidos", apellidos));
                cmd.Parameters.Add(new SqlParameter("@nacionalidad", nacionalidad));
                cmd.Parameters.Add(new SqlParameter("@f_nacimiento", f_nacimiento));
                modificado = true;
                cmd.ExecuteNonQuery(); //para dejar esa consulta reflejada en la base de datos
            }



            return modificado;

        }
        //metodo para modificar una editorial
        public bool modificar_Editorial(int id_editorial, string nombre_editorial, string nacionalidad_editorial, PictureBox pb)
        {
            bool modificado = false;

            cmd = conexion.CreateCommand();
            //comando para trabajar en la base de dato
            //antes de insertar la imagen debemos saber si es nula o no
            if (pb.Image != null)
            {
                //lo que pone delante es el nombre de la base de datos, lo que pone detras del @ es el nombre del programa
                //si hay imagen
                cmd.CommandText = "update Editoriales set nombre_editorial=@nombre_editorial, nacionalidad_Editorial=@nacionalidad_editorial,imagen=imagen where id_editorial =" + id_editorial;
                cmd.Parameters.Add(new SqlParameter("@nombre_editorial", nombre_editorial));
                cmd.Parameters.Add(new SqlParameter("@nacionalidad_editorial", nacionalidad_editorial));
                //referenciamos a la imagen en memoria para poder almacenarla en la base de datos
                cmd.Parameters.Add(new SqlParameter("@imagen", convertir_imagen(pb.ImageLocation)));
                modificado = true;
                cmd.ExecuteNonQuery();  //para dejar esa consulta reflejada en la base de datos
            }
            else
            {
                //como no hay imagen tenemos que parametrizarla
                cmd.CommandText = "update Editoriales set nombre_editorial=@nombre_editorial, nacionalidad_Editorial=@nacionalidad_editorial where id_editorial =" + id_editorial;
                cmd.Parameters.Add(new SqlParameter("@nombre_editorial", nombre_editorial));
                cmd.Parameters.Add(new SqlParameter("@nacionalidad_editorial", nacionalidad_editorial));
                modificado = true;
                cmd.ExecuteNonQuery(); //para dejar esa consulta reflejada en la base de datos
            }
            return modificado;
        }


        public bool modificar_Libro(int id_libro, int id_editorial,int id_autor, string titulo_libro, string isbn_libro,int paginas_libro, PictureBox pb)
        {
            bool modificado = false;

            cmd = conexion.CreateCommand();
            //comando para trabajar en la base de dato
            //antes de insertar la imagen debemos saber si es nula o no
            if (pb.Image != null)
            {
                //lo que pone delante es el nombre de la base de datos, lo que pone detras del @ es el nombre del programa
                //si hay imagen
                cmd.CommandText = "update Libros set id_autor=@id_autor, id_editorial=@id_editorial, titulo_libro=@titulo_libro,isbn_libro=@isbn_libro, paginas_libro=@paginas_libro,imagen=imagen where id_libro =" + id_libro;
                cmd.Parameters.Add(new SqlParameter("@id_autor", id_autor));
                cmd.Parameters.Add(new SqlParameter("@id_editorial", id_editorial));
                cmd.Parameters.Add(new SqlParameter("@titulo_libro", titulo_libro));
                cmd.Parameters.Add(new SqlParameter("@isbn_libro", isbn_libro));
                cmd.Parameters.Add(new SqlParameter("@paginas_libro", paginas_libro));
                //referenciamos a la imagen en memoria para poder almacenarla en la base de datos
                cmd.Parameters.Add(new SqlParameter("@imagen", convertir_imagen(pb.ImageLocation)));
                modificado = true;
                cmd.ExecuteNonQuery();  //para dejar esa consulta reflejada en la base de datos
            }
            else
            {
                //como no hay imagen tenemos que parametrizarla
                cmd.CommandText = "update Libros set id_autor=@id_autor, id_editorial=@id_editorial, titulo_libro=@titulo_libro,isbn=@isbn_libro, paginas_libro=@paginas_libro where id_libro =" + id_libro;
                cmd.Parameters.Add(new SqlParameter("@id_autor", id_autor));
                cmd.Parameters.Add(new SqlParameter("@id_editorial", id_editorial));
                cmd.Parameters.Add(new SqlParameter("@titulo_libro", titulo_libro));
                cmd.Parameters.Add(new SqlParameter("@isbn_libro", isbn_libro));
                cmd.Parameters.Add(new SqlParameter("@paginas_libro", paginas_libro));
                modificado = true;
                cmd.ExecuteNonQuery(); //para dejar esa consulta reflejada en la base de datos
            }
            return modificado;
        }
    }
}
