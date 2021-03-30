using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedeFacilWebApp.WebPages.WebPage.Geral
{
    public partial class Entrada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Objusuario"] = null;
            Session["Objentidade"] = null;
            Session["Objestabelecimento"] = null;
            Session["Objcomanda"] = null;
            Session["Objhistoricocomanda"] = null;
            Session["Objhistoricocomandaempresa"] = null;
            Session["Objrelatoriolucro"] = null;
            Session["Objrelatorioproduto"] = null;
            Session["Objrelatoriodias"] = null;
            Session["Item"] = null;
            Session["Mesa"] = null;
        }
    }
}