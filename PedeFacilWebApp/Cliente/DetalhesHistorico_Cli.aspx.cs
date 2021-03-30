using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Repository;
using System;
using System.Data;

namespace PedeFacilWebApp.WebPages.WebPage.Cliente
{
    public partial class DetalhesHistorico_Cli : System.Web.UI.Page
    {
        dynamic objusuario = null;
        dynamic comanda = null;
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
            objusuario = Session["Objentidade"];
            if (objusuario != null)
            {
                comanda = Session["Objhistoricocomanda"];
                ListarComandas(comanda);
            }
            else
                Response.Redirect("../Entrada.aspx");

        }

        private void ListarComandas(DataTable tabela)
        {
            Conteudo.InnerHtml = "<div id=\"Tipo\">Detalhes<div id=\"textinho\">Detalhes da comanda: " + comanda.Rows[0]["nm_Comanda"] + ".</div></div>";
            Conteudo.InnerHtml += "<table id=\"Comanda\" runat=\"server\">";
            double valor = 0;
            foreach (DataRow item in tabela.Rows)
            {
                Conteudo.InnerHtml += "<tr  class=\"Linha1\">";
                Conteudo.InnerHtml += "<td  class=\"ProdNome\"><div id=\"bordnome\">" + item["Nome"] + "</div></td>";
                Conteudo.InnerHtml += "<td class=\"ProdPreco\">" + item["qtd_Cardapio_Item"] + "x  " + string.Format("{0:C}", item["vl_Cardapio_Item"]) + "</td>";
                Conteudo.InnerHtml += "</tr>";
                valor += Convert.ToDouble(item["vl_Cardapio_Item"]) * Convert.ToInt32(item["qtd_Cardapio_Item"]);
            }
            Conteudo.InnerHtml += "<tr class=\"Linha3\"><td><div id=\"tot\">Total: </div></td><td class=\"PrecoTot\">" + string.Format("{0:C}", valor) + "</td></tr>";
            Conteudo.InnerHtml += "</table>";
        }
    }
}