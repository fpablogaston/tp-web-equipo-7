using AccesoADatos;
using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Actividad4
{
    public partial class Paso3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void textDni_TextChanged(object sender, EventArgs e)
        {

            string dni = textDni.Text;
            if(!System.Text.RegularExpressions.Regex.IsMatch(dni, @"^\d{7,8}$"))
            {
                limpiar();
                textDni.Text = "";
                return;
            }

            int documento = int.Parse(textDni.Text);
            ClienteNegocio negocio = new ClienteNegocio();
            var cliente = negocio.BuscarDocumentoCliente(documento);

            if (cliente != null)
            {
                textName.Text = cliente.Nombre;
                TextApellido.Text = cliente.Apellido;
                TextEmail.Text = cliente.Email;
                TextDireccion.Text = cliente.Direccion;
                TextCiudad.Text = cliente.Ciudad;
                TextCP.Text = cliente.CP.ToString();
            }
            else
            {
                limpiar();
            }

        }

        protected void TextEmail_TextChanged(object sender, EventArgs e)
        {
            string email = TextEmail.Text;
            if (!MailValido(email))
            {
                return;
            }
        }

        private bool MailValido(string email)
        {
            try
            {
                var mail = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected void limpiar()
        {
            textName.Text = "";
            TextApellido.Text = "";
            TextEmail.Text = "";
            TextDireccion.Text = "";
            TextCiudad.Text = "";
            TextCP.Text = "";
        }
      /*  protected void btnDni_Click(object sender, EventArgs e)
        {
            int documento = int.Parse(textDni.Text);
            ClienteNegocio negocio = new ClienteNegocio();
            var cliente = negocio.BuscarDocumentoCliente(documento);

            if (cliente != null)
            {
                textName.Text = cliente.Nombre;
                TextApellido.Text = cliente.Apellido;
                TextEmail.Text = cliente.Email;
                TextDireccion.Text = cliente.Direccion;
                TextCiudad.Text = cliente.Ciudad;
                TextCP.Text = cliente.CP.ToString();
            }
            else
            {
                textName.Text = "";
                TextApellido.Text = "";
                TextEmail.Text = "";
                TextDireccion.Text = "";
                TextCiudad.Text = "";
                TextCP.Text = "";
            }
        }
      */

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
                try
                {
                    ClienteNegocio negocio = new ClienteNegocio();
                    int dni = int.Parse(textDni.Text);

                    Cliente existente = negocio.BuscarDocumentoCliente(dni);
                    int idCliente;

                    if (existente != null)
                    {
                        idCliente = existente.Id;
                    }
                    else
                    {
                        Cliente nuevo = new Cliente();
                        nuevo.Documento = dni.ToString();
                        nuevo.Nombre = textName.Text;
                        nuevo.Apellido = TextApellido.Text;
                        nuevo.Email = TextEmail.Text;
                        nuevo.Direccion = TextDireccion.Text;
                        nuevo.Ciudad = TextCiudad.Text;
                        nuevo.CP = int.Parse(TextCP.Text);

                        idCliente = negocio.AgregarClienteYObtenerId(nuevo);
                    }

                    if (Session["CodigoIngresado"] != null)
                    {
                        string codigoVoucher = Session["CodigoIngresado"].ToString();
                        int idArticulo = (int)Session["IdArticuloSeleccionado"];
                        DateTime fechaCanje = DateTime.Now;

                    AccesoDatos datos = new AccesoDatos();
                        try
                        {
                            datos.setQuery("UPDATE VOUCHERS SET IdCliente = @IdCliente, IdArticulo = @IdArticulo, FechaCanje = @FechaCanje WHERE CodigoVoucher = @Codigo");
                            datos.setearParametro("@IdCliente", idCliente);
                            datos.setearParametro("@IdArticulo", idArticulo);
                            datos.setearParametro("@FechaCanje", fechaCanje);   
                            datos.setearParametro("@Codigo", codigoVoucher);
                            datos.ejecutarAccion();
                        }
                        finally
                        {
                            datos.cerrarConexion();
                        }
                    }

                    Response.Redirect("paginaExito.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception ex)
                {
                     throw ex;
                }

            }
    }
}