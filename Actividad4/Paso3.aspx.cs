using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
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

        protected void btnDni_Click(object sender, EventArgs e)
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

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            Response.Redirect("paginaExito.aspx");
        }
    }
}