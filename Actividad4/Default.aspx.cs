using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;  

namespace Actividad4
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               TextCodigo.Text = "XXXXXX";
            }
        }

        protected void btnCanjear_Click(object sender, EventArgs e)
        {
            string codigoIngresado = TextCodigo.Text;
            pnlResultado.Controls.Clear();
            pnlResultado.Visible = true;

            VoucherNegocio negocio = new VoucherNegocio();


            if (string.IsNullOrEmpty(codigoIngresado) || codigoIngresado == "XXXXXX")
            {
                pnlResultado.CssClass = "alert alert-warning mt-2";
                pnlResultado.Controls.Add(new LiteralControl("Por favor, ingrese un código válido."));
            }
            else if (negocio.codigoValido(codigoIngresado))
            {
                pnlResultado.CssClass = "alert alert-success mt-2";
                Session["CodigoIngresado"] = codigoIngresado;
                Response.Redirect("Paso2.aspx");
            }
            else
            {
                pnlResultado.CssClass = "alert alert-danger mt-2";
                pnlResultado.Controls.Add(new LiteralControl("El código ingresado no es válido o ya fue canjeado."));
            }
        }
    }
}