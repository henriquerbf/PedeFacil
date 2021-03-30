using System;

namespace PedeFacilWebApp.WebPages.WebPage.Empresa
{
    public partial class Home_Emp : System.Web.UI.Page
    {
        dynamic objentidade = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            objentidade = Session["Objentidade"];
            if (objentidade != null)
            {
            }
            else
                Response.Redirect("../Entrada.aspx");

        }
    }
}