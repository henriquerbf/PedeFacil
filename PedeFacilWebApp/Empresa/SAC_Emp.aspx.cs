using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using PedeFacilLibrary.Repository;
using System;
using System.Web.UI;

namespace PedeFacilWebApp.WebPages.WebPage.Empresa
{
    public partial class SAC_Emp : System.Web.UI.Page
    {
        dynamic objentidade = null;
        private SAC_Log sac = new SAC_Log();
        private Entidade entidade = new Entidade();
        protected void Page_Load(object sender, EventArgs e)
        {
            objentidade = Session["Objentidade"];
            if (objentidade != null)
            {
                entidade.Nome = objentidade.Nome;
                entidade.Email = objentidade.Email;
                entidade.id_Entidade = objentidade.id_Entidade;
            }
            else
                Response.Redirect("../Entrada.aspx");

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            RepSacLog repSacLog = new RepSacLog();
            EmailTools emailTools = new EmailTools();

            sac.ds_Mensagem = txtSAC.Text;
            sac.DataHora = DateTime.Now;
            sac.id_Entidade = entidade.id_Entidade;
            sac.ds_Assunto = ddlSAC.SelectedItem.Text;
            repSacLog.Enviar(sac);

            emailTools.sendEmailSAC(entidade, sac);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Mensagem enviada com sucesso!'); window.location='Home_Emp.aspx'", true);
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            txtSAC.Text = string.Empty;
            ddlSAC.SelectedIndex = 0;
        }
    }
}