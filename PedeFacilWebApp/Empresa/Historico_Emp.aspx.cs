using System;
using PedeFacilLibrary.Models;
using PedeFacilLibrary.Repository;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using System.Web;

namespace PedeFacilWebApp.WebPages.WebPage.Empresa
{
    public partial class Historico_Emp : System.Web.UI.Page
    {
        dynamic objentidade = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            objentidade = Session["Objentidade"];
            if (objentidade != null)
            {
                RepComanda RepComanda = new RepComanda();
                DataTable Comandas = new DataTable();

                Comandas = RepComanda.Select_Entidade(objentidade);
                ListarComandas(Comandas);
            }
            else
                Response.Redirect("../Entrada.aspx");
        }
        private void ListarComandas(DataTable tabela)
        {
            ListaHistorico.InnerHtml = "<table id=\"Comandas\" runat=\"server\">";
            ListaHistorico.InnerHtml += "<tr id=Colunas>";
            ListaHistorico.InnerHtml += "<td class=\"cabe\">Comanda</td>";
            ListaHistorico.InnerHtml += "<td class=\"cabe\">Nome</td>";
            ListaHistorico.InnerHtml += "<td class=\"cabe\">Mesa</td>";
            ListaHistorico.InnerHtml += "<td class=\"cabe\">Data</td>";
            ListaHistorico.InnerHtml += "<td class=\"cabe\">Detalhes</td>";
            ListaHistorico.InnerHtml += "</tr>";
            var c = 1;
            foreach (DataRow item in tabela.Rows)
            {
                if (c == 1)
                {
                    c++;
                    ListaHistorico.InnerHtml += "<tr id=\"Linha\" class=\"tr2\">";
                    ListaHistorico.InnerHtml += "<td>" + item["nm_Comanda"] + "</td>";
                    ListaHistorico.InnerHtml += "<td id=\"nome\">" + item["Nome"] + "</td>";
                    ListaHistorico.InnerHtml += "<td>" + item["ds_Mesa"] + "</td>";
                    ListaHistorico.InnerHtml += "<td>" + item["DataHora"] + "</td>";
                    ListaHistorico.InnerHtml += "<td><a href=\"javascript: Detalhes_Comanda('" + item["id_Comanda"] + "');\" class=\"info\">Detalhes</td>";
                    ListaHistorico.InnerHtml += "</tr>";
                }
                else
                {
                    c--;
                    ListaHistorico.InnerHtml += "<tr id=\"Linha\" class=\"l2\">";
                    ListaHistorico.InnerHtml += "<td>" + item["nm_Comanda"] + "</td>";
                    ListaHistorico.InnerHtml += "<td id=\"nome\">" + item["Nome"] + "</td>";
                    ListaHistorico.InnerHtml += "<td>" + item["ds_Mesa"] + "</td>";
                    ListaHistorico.InnerHtml += "<td>" + item["DataHora"] + "</td>";
                    ListaHistorico.InnerHtml += "<td><a href=\"javascript: Detalhes_Comanda('" + item["id_Comanda"] + "');\" class=\"info\">Detalhes</td>";
                    ListaHistorico.InnerHtml += "</tr>";
                }
            }
            ListaHistorico.InnerHtml += "</table>";
        }

        [WebMethod]
        public static string Detalhes(string id)
        {
            RepComanda repComanda = new RepComanda();
            Comandas_Emp comandas_Emp = new Comandas_Emp();
            Comanda comanda = new Comanda();
            comanda.id_Comanda = Convert.ToInt32(id);
            var result = repComanda.Select_Comanda(comanda);
            if (result.Rows.Count > 0)
            {
                HttpContext.Current.Session["Objhistoricocomandaempresa"] = result;
                return "";
            }
            else
                return "Comanda vazia";
        }
    }
}