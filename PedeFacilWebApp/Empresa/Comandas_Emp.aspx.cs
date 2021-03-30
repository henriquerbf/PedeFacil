using System;
using PedeFacilLibrary.Models;
using PedeFacilLibrary.Repository;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using System.Web;

namespace PedeFacilWebApp.WebPages.WebPage.Empresa
{
    public partial class Comandas_Emp : System.Web.UI.Page
    {
        dynamic objentidade = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            objentidade = Session["Objentidade"];
            if (objentidade != null)
            {
                RepComanda RepComanda = new RepComanda();
                DataTable Comandas = new DataTable();

                Comandas = RepComanda.Select_Comanda_Entidade(objentidade);
                ListarComandas(Comandas);
            }
            else
                Response.Redirect("../Entrada.aspx");
        }
        private void ListarComandas(DataTable tabela)
        {
            ListaComandas.InnerHtml = "<table id=\"Comandas\" runat=\"server\">";
            ListaComandas.InnerHtml += "<tr id=Colunas>";
            ListaComandas.InnerHtml += "<td class=\"cabe\">Comanda</td>";
            ListaComandas.InnerHtml += "<td class=\"cabe\">Nome</td>";
            ListaComandas.InnerHtml += "<td class=\"cabe\">Mesa</td>";
            ListaComandas.InnerHtml += "<td class=\"cabe\">Data</td>";
            ListaComandas.InnerHtml += "<td class=\"cabe\">Detalhes</td>";
            ListaComandas.InnerHtml += "<td class=\"cabe\">Fechar</td>";
            ListaComandas.InnerHtml += "</tr>";
            var c = 1;
            foreach (DataRow item in tabela.Rows)
            {
                if (c == 1)
                {
                    c++;
                    ListaComandas.InnerHtml += "<tr id=\"Linha\" class=\"tr2\">";
                    ListaComandas.InnerHtml += "<td>" + item["nm_Comanda"] + "</td>";
                    ListaComandas.InnerHtml += "<td id=\"nome\">" + item["Nome"] + "</td>";
                    ListaComandas.InnerHtml += "<td>" + item["ds_Mesa"] + "</td>";
                    ListaComandas.InnerHtml += "<td>" + item["DataHora"] + "</td>";
                    ListaComandas.InnerHtml += "<td><a href=\"javascript: Detalhes_Comanda('" + item["id_Comanda"] + "');\" class=\"info\">Detalhes</td>";
                    if (item["ic_Status"].ToString() == "True")
                        ListaComandas.InnerHtml += "<td><a href=\"javascript: Fechar_Comanda('" + item["id_Comanda"] + "', '" + item["ic_Status"] + "');\" class=\"info\">Fechar</td>";
                    else
                        ListaComandas.InnerHtml += "<td>Fechada</td>";
                    ListaComandas.InnerHtml += "</tr>";
                }
                else
                {
                    c--;
                    ListaComandas.InnerHtml += "<tr id=\"Linha\" class=\"l2\">";
                    ListaComandas.InnerHtml += "<td>" + item["nm_Comanda"] + "</td>";
                    ListaComandas.InnerHtml += "<td id=\"nome\">" + item["Nome"] + "</td>";
                    ListaComandas.InnerHtml += "<td>" + item["ds_Mesa"] + "</td>";
                    ListaComandas.InnerHtml += "<td>" + item["DataHora"] + "</td>";
                    ListaComandas.InnerHtml += "<td><a href=\"javascript: Detalhes_Comanda('" + item["id_Comanda"] + "');\" class=\"info\">Detalhes</td>";
                    if (item["ic_Status"].ToString() == "True")
                        ListaComandas.InnerHtml += "<td><a href=\"javascript: Fechar_Comanda('" + item["id_Comanda"] + "', '" + item["ic_Status"] + "');\" class=\"info\">Fechar</td>";
                    else
                        ListaComandas.InnerHtml += "<td>Fechada</td>";
                    ListaComandas.InnerHtml += "</tr>";
                }
            }
            ListaComandas.InnerHtml += "</table>";
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

        [WebMethod]
        public static string Fechar(string id, string status)
        {
            RepComanda repComanda = new RepComanda();
            Comanda comanda = new Comanda();
            comanda.id_Comanda = Convert.ToInt32(id);
            if (status == "True")
                comanda.ic_Status = 0;
            else
                comanda.ic_Status = 1;
            var result = repComanda.Update(comanda);
            if (result == true)
                return "Comanda fechada com sucesso!";
            else
                return "Erro ao fechar comanda";
        }
    }
}