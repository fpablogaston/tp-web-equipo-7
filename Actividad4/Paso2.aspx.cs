using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoADatos;
using System.Runtime.InteropServices;
using System.Web.UI.WebControls.WebParts;

namespace Actividad4
{
    public partial class Paso2 : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulos = negocio.listar();
            if (!IsPostBack)
            {
                rptArticulos.DataSource = ListaArticulos;
                rptArticulos.DataBind();
            }
        }

        protected void rptArticulos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                dominio.Articulo articulo = (dominio.Articulo)e.Item.DataItem;
                Repeater rptImagenes = (Repeater)e.Item.FindControl("rptImagenes");
                rptImagenes.DataSource = articulo.Imagenes;
                rptImagenes.DataBind();
            }
        }

        protected void rptArticulos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Reclamar")
            {
                int idArticuloSeleccionado = int.Parse(e.CommandArgument.ToString());
                Session["IdArticuloSeleccionado"] = idArticuloSeleccionado;
                Response.Redirect("Paso3.aspx");
            }
        }
    }
}
    
