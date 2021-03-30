using PedeFacilLibrary.Models;
using PedeFacilLibrary.Repository;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedeFacilWebApp.WebPages.WebPage.Cliente
{
    public partial class Historico_Cli : System.Web.UI.Page
    {
        dynamic entidade = null;
        dynamic estabelecimento = null;
        dynamic objcomanda = null;
        private RepComanda repComanda = new RepComanda();

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
            entidade = Session["Objentidade"];
            if (entidade != null)
            {
                estabelecimento = Session["Objestabelecimento"];
                DataTable Comandas = new DataTable();
                Comandas = repComanda.Select_Cliente(entidade, estabelecimento);
                ListarComandas(Comandas);
            }
            else
                Response.Redirect("../Entrada.aspx");
        }
        private void ListarComandas(DataTable tabela)
        {
            Conteudo.InnerHtml = "<div id=\"Tipo\">Historico<div id=\"textinho\">Histórico de comandas.</div></div>";
            Conteudo.InnerHtml += "<table id=\"Comandas\" runat=\"server\">";

            foreach (DataRow item in tabela.Rows)
            {
                Conteudo.InnerHtml += "<tr class=\"Linha1\" class=\"tr2\">";
                Conteudo.InnerHtml += "<td  class=\"ProdNome\"><div id=\"bordnome\">" + item["nm_Comanda"] + "</div></td>";
                Conteudo.InnerHtml += "<td class=\"ProdPreco\">" + item["DataHora"] + "</td>";
                Conteudo.InnerHtml += "</tr>";
                Conteudo.InnerHtml += "<tr class=\"Linha2\">";
                if (Convert.ToByte(item["ic_Status"]) == 1)
                    Conteudo.InnerHtml += "<td class=\"ProdQuantidade\" id=\"plus\" >Aberta</td>";
                else
                    Conteudo.InnerHtml += "<td class=\"ProdQuantidade\" id=\"plus\" >Fechada</td>";
                Conteudo.InnerHtml += "<td><a class=\"Pedir\" href=\"javascript: Detalhes_Comanda('" + item["id_Comanda"] + "', '" + item["nm_Comanda"] + "');\">Detalhes</td>";
                Conteudo.InnerHtml += "</tr>";
            }
            Conteudo.InnerHtml += "</table>";
        }

        [WebMethod]
        public static string Detalhes(string id, string nome)
        {
            Comanda comanda = new Comanda();
            RepComanda repComanda = new RepComanda();
            comanda.id_Comanda = Convert.ToInt32(id);
            comanda.nm_Comanda = nome;
            var detalhecomanda = repComanda.Select_Comanda_Cliente(comanda);
            if (detalhecomanda.Rows.Count > 0)
            {
                HttpContext.Current.Session["Objhistoricocomanda"] = detalhecomanda;
                return "";
            }
            else
                return "Comanda vazia";
        }
    }
}