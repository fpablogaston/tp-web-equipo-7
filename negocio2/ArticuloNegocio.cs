using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Runtime.CompilerServices;
using System.Globalization;
using AccesoADatos;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
          
 

            try
            {
                datos.setQuery("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion AS Marca, M.Id AS IdMarca, C.Descripcion AS Categoria, C.Id AS IdCategoria, A.Precio, I.ImagenUrl FROM ARTICULOS A JOIN MARCAS M ON M.Id = A.IdMarca JOIN CATEGORIAS C ON C.Id = A.IdCategoria LEFT JOIN IMAGENES I ON I.IdArticulo = A.Id\r\n");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    int IdArticulo = (int)datos.Lector["Id"];

                    Articulo aux = lista.FirstOrDefault(a => a.IdArticulo == IdArticulo);
                    if (aux == null)
                    {
                        aux = new Articulo();
                        {
                            aux.IdArticulo = IdArticulo;
                            aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                            aux.Nombre = (string)datos.Lector["Nombre"];
                            aux.Descripcion = (string)datos.Lector["Descripcion"];
                            aux.Marca = new Marca();
                            aux.Marca.IdMarca = (int)datos.Lector["IdMarca"];
                            aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                            aux.Categoria = new Categoria();
                            aux.Categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                            aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                            aux.Precio = (decimal)datos.Lector["Precio"];
                            aux.Imagenes = new List<string>();
                        }

                        lista.Add(aux);
                    }

                    if(!(datos.Lector["ImagenUrl"] is DBNull))
                    aux.Imagenes.Add((string)datos.Lector["ImagenUrl"]);
                    
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
               datos.cerrarConexion();
            }
        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setQuery("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)");
                datos.setearParametro("@Codigo", nuevo.CodigoArticulo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IdMarca", nuevo.Marca.IdMarca);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.IdCategoria);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setQuery("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio WHERE Id = @Id");
                datos.setearParametro("@Codigo", articulo.CodigoArticulo);
                datos.setearParametro("@Nombre", articulo.Nombre);
                datos.setearParametro("@Descripcion", articulo.Descripcion);
                datos.setearParametro("@IdMarca", articulo.Marca.IdMarca);
                datos.setearParametro("@IdCategoria", articulo.Categoria.IdCategoria);
                datos.setearParametro("@Precio", articulo.Precio);
                datos.setearParametro("@Id", articulo.IdArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificarImagen(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setQuery("UPDATE IMAGENES SET ImagenUrl = @ImagenUrl WHERE IdArticulo = @IdArticulo");
                datos.setearParametro("@ImagenUrl", articulo.Imagenes);
                datos.setearParametro("@IdArticulo", articulo.IdArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminarFisica(int id) // No pude resolver una eliminacion logica sin una columna de estado y no queria modificar la base de datos o generar problemas con otros registros.
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setQuery("DELETE FROM ARTICULOS WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
