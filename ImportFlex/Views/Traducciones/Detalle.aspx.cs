using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImportFlex.Account;
using ImportFlex.Controllers;

namespace ImportFlex.Views.Traducciones
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTraduccion();
            }
        }

        private void CargarTraduccion()
        {
            var data = new TraduccionController();
            var response = data.GetTraduccionPorId(Convert.ToInt32(Request.Params["ID"]));

            if (response.Success)
            {
                lblTitulo.Text = response.Traduccion.tradIdTraduccion + " - " + response.Traduccion.tradTraduccion;
                tbxTraduccion.Text = response.Traduccion.tradTraduccion;
            }
        }

        protected void btnGuardar_OnClick(object sender, EventArgs e)
        {
            var data = new TraduccionController();
            var response = data.GetTraduccionPorId(Convert.ToInt32(Request.Params["ID"]));

            if (response.Success)
            {
                var t = response.Traduccion;
                t.tradTraduccion = tbxTraduccion.Text;
                t.tradFechaUltimaModificacion = DateTime.Now;
                t.tradIdUsuarioUltimaModificacion = Sesiones.UsuarioID.Value;

                var _traduccion = data.UpdateTraduccion(t);

                if (_traduccion.Success)
                    Response.Redirect($"~/Views/Traducciones/Detalle.aspx?ID={Request.Params["ID"]}");
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertSuccess",
                        $"alert('Ha ocurrido un error. {_traduccion.Message}');", true);
            }


        }
    }
}