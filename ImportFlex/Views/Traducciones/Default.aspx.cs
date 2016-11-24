using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImportFlex.Controllers;

namespace ImportFlex.Views.Traducciones
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTraducciones();
            }

        }

        private void CargarTraducciones()
        {
            var data = new TraduccionController();
            var response = data.GetAllTraducciones();
            if (response.Success)
            {
                gvTraducciones.DataSource = response.Traducciones;
                gvTraducciones.DataBind();
            }
        }

        protected void btnFiltrar_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}