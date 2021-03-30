using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedeFacilWebApp.Empresa
{
    public partial class Detalhes_RelatorioEmp : System.Web.UI.Page
    {
        dynamic relatorio = null;
        dynamic objentidade = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            objentidade = Session["Objentidade"];
            if (objentidade != null)
            {
                if (Session["Objrelatoriolucro"] != null)
                {
                    relatorio = Session["Objrelatoriolucro"];
                    Lucro(relatorio);
                }
                else if (Session["Objrelatorioproduto"] != null)
                {
                    relatorio = Session["Objrelatorioproduto"];
                    Produtos(relatorio);
                }
                else if (Session["Objrelatoriodias"] != null)
                {
                    relatorio = Session["Objrelatoriodias"];
                    Dias(relatorio);
                }
                else
                    Response.Redirect("Relatorios_Emp.aspx");
            }
            else
                Response.Redirect("../Entrada.aspx");
        }

        public void Lucro(DataTable tabela)
        {
            ContRelatorio.InnerHtml = "<table id=\"Cardapio\" runat=\"server\">";
            ContRelatorio.InnerHtml += "<tr id=Colunas>";
            ContRelatorio.InnerHtml += "<td class=\"cabe\">Mes</td>";
            ContRelatorio.InnerHtml += "<td class=\"cabe\">Valor</td>";
            ContRelatorio.InnerHtml += "</tr>";
            var c = 1;
            foreach (DataRow item in tabela.Rows)
            {
                if (c == 1)
                {
                    c++;
                    ContRelatorio.InnerHtml += "<tr id=\"Linha\" class=\"tr2\">";
                    ContRelatorio.InnerHtml += "<td>" + item["Mes"] + "</td>";
                    ContRelatorio.InnerHtml += "<td>" + string.Format("{0:C}", item["Total"]) + "</td>";
                    ContRelatorio.InnerHtml += "</tr>";
                }
                else
                {
                    c--;
                    ContRelatorio.InnerHtml += "<tr id=\"Linha\" class=\"l2\">";
                    ContRelatorio.InnerHtml += "<td>" + item["Mes"] + "</td>";
                    ContRelatorio.InnerHtml += "<td>" + string.Format("{0:C}", item["Total"]) + "</td>";
                    ContRelatorio.InnerHtml += "</tr>";
                }
            }
            ContRelatorio.InnerHtml += "</table>";
        }

        public void Produtos(DataTable tabela)
        {
            float total = 0;
            ContRelatorio.InnerHtml = "<table id=\"Cardapio\" runat=\"server\">";
            ContRelatorio.InnerHtml += "<tr id=Colunas>";
            ContRelatorio.InnerHtml += "<td class=\"cabe\">Nome</td>";
            ContRelatorio.InnerHtml += "<td class=\"cabe\">Valor</td>";
            ContRelatorio.InnerHtml += "<td class=\"cabe\">Quantidade</td>";
            ContRelatorio.InnerHtml += "<td class=\"cabe\">Total</td>";
            ContRelatorio.InnerHtml += "</tr>";
            var c = 1;
            foreach (DataRow item in tabela.Rows)
            {
                if (c == 1)
                {
                    c++;
                    total = float.Parse(item["Valor"].ToString()) * float.Parse(item["QTD"].ToString());
                    ContRelatorio.InnerHtml += "<tr id=\"Linha\" class=\"tr2\">";
                    ContRelatorio.InnerHtml += "<td>" + item["Nome"] + "</td>";
                    ContRelatorio.InnerHtml += "<td>" + string.Format("{0:C}", item["Valor"]) + "</td>";
                    ContRelatorio.InnerHtml += "<td>" + item["QTD"] + "</td>";
                    ContRelatorio.InnerHtml += "<td>" + string.Format("{0:C}", total) + "</td>";
                    ContRelatorio.InnerHtml += "</tr>";
                }
                else
                {
                    c--;
                    total = float.Parse(item["Valor"].ToString()) * float.Parse(item["QTD"].ToString());
                    ContRelatorio.InnerHtml += "<tr id=\"Linha\" class=\"l2\">";
                    ContRelatorio.InnerHtml += "<td>" + item["Nome"] + "</td>";
                    ContRelatorio.InnerHtml += "<td>" + string.Format("{0:C}", item["Valor"]) + "</td>";
                    ContRelatorio.InnerHtml += "<td>" + item["QTD"] + "</td>";
                    ContRelatorio.InnerHtml += "<td>" + string.Format("{0:C}", total) + "</td>";
                    ContRelatorio.InnerHtml += "</tr>";
                }
            }
            ContRelatorio.InnerHtml += "</table>";
        }

        public void Dias(DataTable tabela)
        {
            ContRelatorio.InnerHtml = "<table id=\"Cardapio\" runat=\"server\">";
            ContRelatorio.InnerHtml += "<tr id=Colunas>";
            ContRelatorio.InnerHtml += "<td class=\"cabe\">Dia</td>";
            ContRelatorio.InnerHtml += "<td class=\"cabe\">Quantidade</td>";
            ContRelatorio.InnerHtml += "</tr>";
            var c = 1;
            foreach (DataRow item in tabela.Rows)
            {
                if (c == 1)
                {
                    c++;
                    ContRelatorio.InnerHtml += "<tr id=\"Linha\" class=\"tr2\">";
                    ContRelatorio.InnerHtml += "<td>" + item["Dia"] + "</td>";
                    ContRelatorio.InnerHtml += "<td>" + item["qtd"] + "</td>";
                    ContRelatorio.InnerHtml += "</tr>";
                }
                else
                {
                    c--;
                    ContRelatorio.InnerHtml += "<tr id=\"Linha\" class=\"l2\">";
                    ContRelatorio.InnerHtml += "<td>" + item["Dia"] + "</td>";
                    ContRelatorio.InnerHtml += "<td>" + item["qtd"] + "</td>";
                    ContRelatorio.InnerHtml += "</tr>";
                }
            }
            ContRelatorio.InnerHtml += "</table>";
        }
    }
}