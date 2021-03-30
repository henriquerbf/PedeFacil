using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using PedeFacilLibrary.Repository;
using System;
using System.Web;
using System.Web.Services;
using System.Web.UI;

namespace PedeFacilWebApp.WebPages.WebPage.Cliente
{
    public partial class SAC_Cli : System.Web.UI.Page
    {
        dynamic objentidade = null;
        dynamic objcomanda = null;        

        protected void Page_PreInit(object sender, EventArgs e)
        {
            objcomanda = Session["Objcomanda"];
            if (objcomanda != null)
                this.MasterPageFile = "~/WebPages/MasterPage/Cliente/Master_Cli.Master";
            else
                this.MasterPageFile = "~/WebPages/MasterPage/Cliente/Master_Cli_Inicio.Master";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            objentidade = Session["Objentidade"];
            if (objentidade != null)
            {
                
            }
            else
                Response.Redirect("../Entrada.aspx");

        }

        [WebMethod]
        public static string Enviar(string assunto, string mensagem)
        {
            dynamic ent = HttpContext.Current.Session["Objentidade"];
            SAC_Cli saccli = new SAC_Cli();
            RepSacLog repSacLog = new RepSacLog();
            EmailTools emailTools = new EmailTools();
            SAC_Log sac = new SAC_Log();
            Entidade entidade = new Entidade();
            entidade.Email = ent.Email;
            entidade.Nome = ent.Nome;
            entidade.id_Entidade = ent.id_Entidade;

            sac.ds_Mensagem = mensagem;
            sac.DataHora = DateTime.Now;
            sac.id_Entidade = entidade.id_Entidade;
            if (assunto == "1")
                sac.ds_Assunto = "Problemas";
            else if (assunto == "2")
                sac.ds_Assunto = "Sugestões";
            else
                sac.ds_Assunto = "Contato";
            repSacLog.Enviar(sac);

            var result = emailTools.sendEmailSAC(entidade, sac);
            if (result == true)
                return "Mensagem enviada com sucesso!";
            else
                return "Erro ao enviar mensagem";
        }
    }
}