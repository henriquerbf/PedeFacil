using PedeFacilLibrary.Models;
using PedeFacilLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedeFacilWebApp.WebPages.WebPage.Empresa
{
    public partial class Comandas_Cozinha : System.Web.UI.Page
    {
        dynamic entidade = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            entidade = Session["Objentidade"];
            if (entidade != null)
            {
                RepCozinha repComanda = new RepCozinha();
                DataTable Comandas = new DataTable();
                Comandas = repComanda.Select_Cozinha(entidade);
                ListarComandas(Comandas);
            }
            else
                Response.Redirect("../Entrada.aspx");
        }
        private void ListarComandas(DataTable tabela)
        {
            ListaComanda.InnerHtml = "<table id=\"Comandas\" runat=\"server\">";
            ListaComanda.InnerHtml += "<tr id=Colunas>";
            ListaComanda.InnerHtml += "<td class=\"cabe\">Comanda</td>";
            ListaComanda.InnerHtml += "<td class=\"cabe\">Mesa</td>";
            ListaComanda.InnerHtml += "<td class=\"cabe\">Nome</td>";
            ListaComanda.InnerHtml += "<td class=\"cabe\">Observação</td>";
            ListaComanda.InnerHtml += "<td class=\"cabe\">Quantidade</td>";
            ListaComanda.InnerHtml += "<td class=\"cabe\">Status</td>";
            ListaComanda.InnerHtml += "<td class=\"cabe\">Cancelar</td>";
            ListaComanda.InnerHtml += "</tr>";
            var c = 1;
            foreach (DataRow item in tabela.Rows)
            {
                if (c == 1)
                {
                    c++;
                    ListaComanda.InnerHtml += "<tr id=\"Linha\" class=\"tr2\">";
                    ListaComanda.InnerHtml += "<td>" + item["nm_Comanda"] + "</td>";
                    ListaComanda.InnerHtml += "<td>" + item["ds_Mesa"] + "</td>";
                    ListaComanda.InnerHtml += "<td id=\"nome\">" + item["Nome"] + "</td>";
                    ListaComanda.InnerHtml += "<td>" + item["ds_Observacao"] + "</td>";
                    ListaComanda.InnerHtml += "<td>" + item["qtd_Cardapio_Item"] + "</td>";
                    if (Convert.ToByte(item["ic_Status"]) == 0)
                        ListaComanda.InnerHtml += "<td><a href=\"javascript: Status_Comanda('" + item["id_Cozinha"] + "', '" + item["ic_Status"] + "');\" class=\"info\">Pendente</td>";
                    else
                        ListaComanda.InnerHtml += "<td>Concluido</td>";
                    ListaComanda.InnerHtml += "<td><a href=\"javascript: Cancelar_Item('" + item["id_Cozinha"] + "', '" + item["id_Comanda_Item"] + "');\" class=\"info\">Cancelar</td>";
                    ListaComanda.InnerHtml += "</tr>";
                }
                else
                {
                    c--;
                    ListaComanda.InnerHtml += "<tr id=\"Linha\" class=\"l2\">";
                    ListaComanda.InnerHtml += "<td>" + item["nm_Comanda"] + "</td>";
                    ListaComanda.InnerHtml += "<td>" + item["ds_Mesa"] + "</td>";
                    ListaComanda.InnerHtml += "<td id=\"nome\">" + item["Nome"] + "</td>";
                    ListaComanda.InnerHtml += "<td>" + item["ds_Observacao"] + "</td>";
                    ListaComanda.InnerHtml += "<td>" + item["qtd_Cardapio_Item"] + "</td>";
                    if (Convert.ToByte(item["ic_Status"]) == 0)
                        ListaComanda.InnerHtml += "<td><a href=\"javascript: Status_Comanda('" + item["id_Cozinha"] + "', '" + item["ic_Status"] + "');\" class=\"info\">Pendente</td>";
                    else
                        ListaComanda.InnerHtml += "<td>Concluido</td>";
                    ListaComanda.InnerHtml += "<td><a href=\"javascript: Cancelar_Item('" + item["id_Cozinha"] + "', '" + item["id_Comanda_Item"] + "');\" class=\"info\">Cancelar</td>";
                    ListaComanda.InnerHtml += "</tr>";
                }
            }
            ListaComanda.InnerHtml += "</table>";
        }

        [WebMethod]
        public static string Status(string id, string status)
        {
            Cozinha cozinha = new Cozinha();
            RepCozinha repCozinha = new RepCozinha();
            if (status == "True")
                cozinha.ic_Status = 0;
            else
                cozinha.ic_Status = 1;
            cozinha.id_Comanda = Convert.ToInt32(id);

            repCozinha.Update(cozinha);
            return "";
        }

        [WebMethod]
        public static string Cancelar(string idcozinha, string idcomandaitem)
        {
            Cozinha cozinha = new Cozinha();
            RepCozinha repCozinha = new RepCozinha();
            cozinha.id_Cozinha = Convert.ToInt32(idcozinha);
            repCozinha.Delete(cozinha);

            //Comanda_Item comanda_Item = new Comanda_Item();
            //RepComandaItem repComandaItem = new RepComandaItem();
            //comanda_Item.id_Comanda_Item = Convert.ToInt32(idcomandaitem);
            //repComandaItem.Delete(comanda_Item);
            return "";
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Entrada.aspx");
        }
    }
}