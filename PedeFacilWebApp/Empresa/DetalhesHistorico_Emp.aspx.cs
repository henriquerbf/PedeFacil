using System;
using System.Data;

namespace PedeFacilWebApp.WebPages.WebPage.Empresa
{
    public partial class DetalhesHistorico_Emp : System.Web.UI.Page
    {
        dynamic objentidade = null;
        dynamic comanda = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            objentidade = Session["Objentidade"];
            if (objentidade != null)
            {
                comanda = Session["Objhistoricocomandaempresa"];
                ListarComandas(comanda);
            }
            else
                Response.Redirect("../Entrada.aspx");
        }

        private void ListarComandas(DataTable tabela)
        {
            ListaComanda.InnerHtml = "<table id=\"Comanda\" runat=\"server\">";
            ListaComanda.InnerHtml += "<tr id=Colunas>";
            ListaComanda.InnerHtml += "<td class=\"cabe\">Nome</td>";
            ListaComanda.InnerHtml += "<td class=\"cabe\">Quantidade</td>";
            ListaComanda.InnerHtml += "<td class=\"cabe\">Valor</td>";
            ListaComanda.InnerHtml += "</tr>";
            double valor = 0;
            var c = 1;
            foreach (DataRow item in tabela.Rows)
            {
                if (c == 1)
                {
                    c++;
                    ListaComanda.InnerHtml += "<tr id=\"Linha\" class=\"tr2\">";
                    ListaComanda.InnerHtml += "<td id=\"nome\">" + item["Nome"] + "</td>";
                    ListaComanda.InnerHtml += "<td>" + item["qtd_Cardapio_Item"] + "</td>";
                    ListaComanda.InnerHtml += "<td>" + string.Format("{0:C}", item["vl_Cardapio_Item"]) + "</td>";
                    ListaComanda.InnerHtml += "</tr>";
                    valor += Convert.ToDouble(item["vl_Cardapio_Item"]) * Convert.ToInt32(item["qtd_Cardapio_Item"]);
                }
                else
                {
                    c--; ListaComanda.InnerHtml += "<tr id=\"Linha\" class=\"l2\">";
                    ListaComanda.InnerHtml += "<td id=\"nome\">" + item["Nome"] + "</td>";
                    ListaComanda.InnerHtml += "<td>" + item["qtd_Cardapio_Item"] + "</td>";
                    ListaComanda.InnerHtml += "<td>" + string.Format("{0:C}", item["vl_Cardapio_Item"]) + "</td>";
                    ListaComanda.InnerHtml += "</tr>";
                    valor += Convert.ToDouble(item["vl_Cardapio_Item"]) * Convert.ToInt32(item["qtd_Cardapio_Item"]);
                }
            }
            ListaComanda.InnerHtml += "<tr><td></td><td>Total: </td><td>" + string.Format("{0:C}", valor) + "</td></tr>";
            ListaComanda.InnerHtml += "</table>";
        }
    }
}