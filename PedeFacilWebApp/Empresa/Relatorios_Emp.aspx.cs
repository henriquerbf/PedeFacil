using PedeFacilLibrary.Models;
using PedeFacilLibrary.Repository;
using System;
using System.Data;
using System.Web.UI;

namespace PedeFacilWebApp.WebPages.WebPage.Empresa
{
    public partial class Relatorios_Emp : System.Web.UI.Page
    {
        dynamic objentidade = null;
        private Relatorios relatorios = new Relatorios();
        protected void Page_Load(object sender, EventArgs e)
        {
            objentidade = Session["Objentidade"];
            if (objentidade != null)
            {
                Session["Objrelatoriolucro"] = null;
                Session["Objrelatorioproduto"] = null;
                Session["Objrelatoriodias"] = null;
            }
            else
                Response.Redirect("../Entrada.aspx");

        }

        protected void btnLucro_Click(object sender, EventArgs e)
        {
            Entidade empresa = new Entidade();
            empresa.id_Entidade = objentidade.id_Entidade;
            string ano = ddlAnoLucro.SelectedValue;
            var relatorio = relatorios.Select_Lucro(ano, empresa);
            if (relatorio.Rows.Count > 0)
            {
                Session["Objrelatoriolucro"] = relatorio;
                Response.Redirect("Detalhes_RelatorioEmp.aspx");
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Não há itens a serem mostrados');", true);
        }

        protected void btnProdutos_Click(object sender, EventArgs e)
        {
            Entidade empresa = new Entidade();
            empresa.id_Entidade = objentidade.id_Entidade;
            var relatorio = relatorios.Select_Produtos_Mais_Vendidos(empresa);
            if (relatorio.Rows.Count > 0)
            {
                Session["Objrelatorioproduto"] = relatorio;
                Response.Redirect("../Empresa/Detalhes_RelatorioEmp.aspx");
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Não há itens a serem mostrados');", true);
        }

        protected void btnDias_Click(object sender, EventArgs e)
        {
            Entidade empresa = new Entidade();
            empresa.id_Entidade = objentidade.id_Entidade;
            string ano = ddlAno.SelectedValue;
            string mes = ddlMes.SelectedIndex.ToString();
            var relatorio = relatorios.Select_Maior_Movimento(mes, ano, empresa);
            if (relatorio.Rows.Count > 0)
            {
                Session["Objrelatoriodias"] = relatorio;
                Response.Redirect("Detalhes_RelatorioEmp.aspx");
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Não há itens a serem mostrados');", true);
        }
    }
}