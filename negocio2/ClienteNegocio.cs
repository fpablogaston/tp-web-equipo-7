using AccesoADatos;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace negocio
{
    public class ClienteNegocio
    {
        public Cliente BuscarDocumentoCliente(int dni)
        {
            Cliente cliente = null;
            string documento = dni.ToString();

            AccesoADatos.AccesoDatos datos = new AccesoADatos.AccesoDatos();
            try
            {
                datos.setQuery("SELECT Id, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE documento = @Documento");
                datos.setearParametro("@Documento", documento);
                datos.ejecutarLectura();

                    if (datos.Lector.Read())
                    {
                        cliente = new Cliente();
                        cliente.Id = (int)datos.Lector["Id"];
                        cliente.Nombre = datos.Lector["Nombre"].ToString();
                        cliente.Apellido = datos.Lector["Apellido"].ToString();
                        cliente.Email = datos.Lector["Email"].ToString();
                        cliente.Direccion = datos.Lector["Direccion"].ToString();
                        cliente.Ciudad = datos.Lector["Ciudad"].ToString();
                        cliente.CP = int.Parse(datos.Lector["CP"].ToString());
                    }
                }
            catch (Exception ex)
            {
                throw ex; 
                
            }
            finally
            {
                datos.cerrarConexion();
            }

            return cliente;
        }

        public int AgregarClienteYObtenerId(Cliente nuevoCliente){

            int nuevoId;
            AccesoADatos.AccesoDatos datos = new AccesoADatos.AccesoDatos();
            try
            {
                datos.setQuery(@"INSERT INTO CLIENTES (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) VALUES (@Documento, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CP); SELECT SCOPE_IDENTITY();");
                datos.setearParametro("@Documento", nuevoCliente.Documento);
                datos.setearParametro("@Nombre", nuevoCliente.Nombre);
                datos.setearParametro("@Apellido", nuevoCliente.Apellido);
                datos.setearParametro("@Email", nuevoCliente.Email);
                datos.setearParametro("@Direccion", nuevoCliente.Direccion);
                datos.setearParametro("@Ciudad", nuevoCliente.Ciudad);
                datos.setearParametro("@CP", nuevoCliente.CP);
                nuevoId = Convert.ToInt32(datos.ejecutarScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return nuevoId;
        }

        public List<Cliente> listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery("SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Documento = (string)datos.Lector["Documento"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Direccion = (string)datos.Lector["Direccion"];
                    aux.Ciudad = (string)datos.Lector["Ciudad"];
                    aux.CP = (int)datos.Lector["CP"];
                    lista.Add(aux);
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
    }
}
