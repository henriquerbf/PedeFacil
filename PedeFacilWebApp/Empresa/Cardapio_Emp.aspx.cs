using System;
using PedeFacilLibrary.Models;
using PedeFacilLibrary.Repository;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.Services;
using System.Web;

namespace PedeFacilWebApp.WebPages.WebPage.Empresa
{
    public partial class Cardapio_Emp : System.Web.UI.Page
    {
        dynamic entidade = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            entidade = Session["Objentidade"];
            if (entidade != null)
            {
                RepCardapio repCardapio = new RepCardapio();
                DataTable listaemp = new DataTable();

                listaemp = repCardapio.Select_Cardapio(entidade);
                criarCardapio(listaemp);
            }
            else
                Response.Redirect("../Entrada.aspx");
        }

        private void criarCardapio(DataTable tabela)
        {
            cardapio.InnerHtml = "<table id=\"Cardapio\" runat=\"server\">";
            cardapio.InnerHtml += "<tr id=Colunas>";
            cardapio.InnerHtml += "<td class=\"cabe\">Tipo</td>";
            cardapio.InnerHtml += "<td class=\"cabe\">Nome</td>";
            cardapio.InnerHtml += "<td class=\"cabe\">Descricao</td>";
            cardapio.InnerHtml += "<td class=\"cabe\">Valor</td>";
            cardapio.InnerHtml += "<td class=\"cabe\">Desconto</td>";
            cardapio.InnerHtml += "<td class=\"cabe\">Ativo</td>";
            cardapio.InnerHtml += "<td class=\"cabe\">Alterar</td>";
            cardapio.InnerHtml += "</tr>";
            var c = 1;
            foreach (DataRow item in tabela.Rows)
            {
                if (c == 1)
                {
                    c++;
                    cardapio.InnerHtml += "<tr id=\"Linha\" class=\"tr2\">";
                    cardapio.InnerHtml += "<td>" + item["DS"] + "</td>";
                    cardapio.InnerHtml += "<td>" + item["Nome"] + "</td>";
                    cardapio.InnerHtml += "<td>" + item["Descricao"] + "</td>";
                    cardapio.InnerHtml += "<td>" + string.Format("{0:C}", item["Valor"]) + "</td>";
                    cardapio.InnerHtml += "<td>" + string.Format("{0:C}", item["vl_Desconto"]) + "</td>";
                    if (Convert.ToByte(item["ic_Ativo"]) == 1)
                        cardapio.InnerHtml += "<td><a href=\"javascript: Status_Item('" + item["id_Cardapio_Item"] + "', '" + item["ic_Ativo"] + "');\" class=\"info\">Ativo</td>";
                    else
                        cardapio.InnerHtml += "<td><a href=\"javascript: Status_Item('" + item["id_Cardapio_Item"] + "', '" + item["ic_Ativo"] + "');\" class=\"info\">Inativo</td>";
                    cardapio.InnerHtml += "<td><a href=\"javascript: Editar_Item('" + item["DS"] + "','" + item["id_Cardapio_Item"] + "','" + item["Nome"] + "', '" + item["Descricao"] + "', '" + item["Valor"] + "', '" + item["vl_Desconto"] + "', '" + item["ic_Destaque"] + "','1');\" class=\"info\">Editar</td>";
                    cardapio.InnerHtml += "</tr>";
                }
                else
                {
                    c--;
                    cardapio.InnerHtml += "<tr id=\"Linha\" class=\"l2\">";
                    cardapio.InnerHtml += "<td>" + item["DS"] + "</td>";
                    cardapio.InnerHtml += "<td>" + item["Nome"] + "</td>";
                    cardapio.InnerHtml += "<td>" + item["Descricao"] + "</td>";
                    cardapio.InnerHtml += "<td>" + string.Format("{0:C}", item["Valor"]) + "</td>";
                    cardapio.InnerHtml += "<td>" + string.Format("{0:C}", item["vl_Desconto"]) + "</td>";
                    if (Convert.ToByte(item["ic_Ativo"]) == 1)
                        cardapio.InnerHtml += "<td><a href=\"javascript: Status_Item('" + item["id_Cardapio_Item"] + "', '" + item["ic_Ativo"] + "');\" class=\"info\">Ativo</td>";
                    else
                        cardapio.InnerHtml += "<td><a href=\"javascript: Status_Item('" + item["id_Cardapio_Item"] + "', '" + item["ic_Ativo"] + "');\" class=\"info\">Inativo</td>";
                    cardapio.InnerHtml += "<td><a href=\"javascript: Editar_Item('" + item["DS"] + "','" + item["id_Cardapio_Item"] + "','" + item["Nome"] + "', '" + item["Descricao"] + "', '" + item["Valor"] + "', '" + item["vl_Desconto"] + "', '" + item["ic_Destaque"] + "','1');\" class=\"info\">Editar</td>";
                    cardapio.InnerHtml += "</tr>";
                }
            }
            cardapio.InnerHtml += "</table>";
        }

        [WebMethod]
        public static string Alterar(string tipo, string id, string nome, string descricao, string valor, string desconto, string destaque, string ativo)
        {
            dynamic item = new
            {
                tipo = tipo,
                id = id,
                nome = nome,
                descricao = descricao,
                valor = valor,
                desconto = desconto,
                destaque = destaque,
                ativo = ativo
            };

            HttpContext.Current.Session["Item"] = item;
            return "";
        }

        [WebMethod]
        public static string Status(string id, string status)
        {
            Cardapio_Item cardapio_Item = new Cardapio_Item();
            RepCardapioItem repCardapioItem = new RepCardapioItem();
            if (status == "True")
                cardapio_Item.ic_Ativo = 0;
            else
                cardapio_Item.ic_Ativo = 1;
            cardapio_Item.id_Cardapio_Item = Convert.ToInt32(id);

            repCardapioItem.Delete(cardapio_Item);

            return "";
        }
        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Empresa/Cadastrar_Item.aspx");
        }
    }
}