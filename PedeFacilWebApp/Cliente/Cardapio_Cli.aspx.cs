using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using PedeFacilLibrary.Repository;
using System;
using System.Data;
using System.Web;
using System.Web.Services;

namespace PedeFacilWebApp.WebPages.WebPage.Cliente
{
    public partial class Cardapio_Cli : System.Web.UI.Page
    {
        dynamic entidade = null;
        dynamic estabelecimento = null;
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
            entidade = Session["Objentidade"];
            estabelecimento = Session["Objestabelecimento"];
            comanda = Session["Objcomanda"];
            if (comanda != null)
            {
                if (entidade != null)
                {
                    RepCardapio repCardapio = new RepCardapio();
                    DataTable listaemp = new DataTable();

                    listaemp = repCardapio.Select_Cardapio_Cliente(estabelecimento);
                    criarCardapio(listaemp);
                }
                else
                    Response.Redirect("../Entrada.aspx");
            }
            else
                Response.Redirect("../Cliente/Home_Cli.aspx");
        }

        private void criarCardapio(DataTable tabela)
        {
            int i = 1;
            int qtd = 1;
            float valor = 0;
            Conteudo.InnerHtml = "<div id=\"Tipo\">Pratos<div id=\"textinho\">Pratos comerciais e lanches.</div></div>";
            Conteudo.InnerHtml += "<table id=\"Cardapio\" runat=\"server\">";
            foreach (DataRow item in tabela.Rows)
            {
                if (item["Tipo"].ToString() == "Comida")
                {
                    valor = float.Parse(item["Valor"].ToString()) - float.Parse(item["vl_Desconto"].ToString());
                    Conteudo.InnerHtml += "<tr class=\"Linha1\">";
                    Conteudo.InnerHtml += "<td class=\"ProdNome\"><div id=\"bordnome\"><img class=\"icos\" src=\"../../../StyleSheets/Images/book.png\" />" + item["Nome"] + "</div></td>";
                    Conteudo.InnerHtml += "<td class=\"ProdDetalhe\"><div id=\"Nada\" onclick=\"MostraDetalhe('" + item["Nome"] + "','" + item["Descricao"] + "')\">?</div></td>";
                    Conteudo.InnerHtml += "<td class=\"ProdPreco\">" + string.Format("{0:C}", valor) + "</td>";
                    Conteudo.InnerHtml += "</tr>";
                    Conteudo.InnerHtml += "<tr class=\"Linha2\">";
                    Conteudo.InnerHtml += "<td class=\"ProdQuantidade\"><input type=\"button\" id=\"plus\" value='-' onclick=\"process(-1, '" + i + "')\" /> " +
                                               "<input id=\"quant" + i + "\" name=\"quant\" class=\"text\" size=\"1\" type=\"text\" value=\"" + qtd + "\" maxlength=\"2\" disabled /> " +
                                               "<input type=\"button\" id=\"minus\" value='+' onclick=\"process(1, '" + i + "')\"></td>";
                    Conteudo.InnerHtml += "<td class=\"ProdAdd\"><a class=\"Adicionar\" href=\"javascript: Adicionar_Comanda('" + comanda.id_Comanda + "', '" + item["id_Cardapio_Item"] + "', '" + i + "', '" + item["valor"] + "');\">Adicionar</a></td>";
                    Conteudo.InnerHtml += "</tr>";
                    i++;
                }
            }

            Conteudo.InnerHtml += "</table>";
            Conteudo.InnerHtml += "<div id=\"Tipo\">Bebidas<div id=\"textinho\">Drinks, Sucos e Refrigerantes.</div></div>";
            Conteudo.InnerHtml += "<table id=\"Cardapio\" runat=\"server\">";
            foreach (DataRow item in tabela.Rows)
            {
                if (item["Tipo"].ToString() == "Bebida")
                {
                    valor = float.Parse(item["Valor"].ToString()) - float.Parse(item["vl_Desconto"].ToString());
                    Conteudo.InnerHtml += "<tr class=\"Linha1\">";
                    Conteudo.InnerHtml += "<td class=\"ProdNome\"><div id=\"bordnome\"><img class=\"icos\" src=\"../../../StyleSheets/Images/book.png\" />" + item["Nome"] + "</div></td>";
                    Conteudo.InnerHtml += "<td class=\"ProdDetalhe\"><div id=\"Nada\" onclick=\"MostraDetalhe('" + item["Nome"] + "','" + item["Descricao"] + "')\">?</div></td>";
                    Conteudo.InnerHtml += "<td class=\"ProdPreco\">" + string.Format("{0:C}", valor) + "</td>";
                    Conteudo.InnerHtml += "</tr>";
                    Conteudo.InnerHtml += "<tr class=\"Linha2\">";
                    Conteudo.InnerHtml += "<td class=\"ProdQuantidade\"><input type=\"button\" id=\"plus\" value='-' onclick=\"process(-1, '" + i + "')\" /> " +
                                               "<input id=\"quant" + i + "\" name=\"quant\" class=\"text\" size=\"1\" type=\"text\" value=\"" + qtd + "\" maxlength=\"2\" disabled /> " +
                                               "<input type=\"button\" id=\"minus\" value='+' onclick=\"process(1, '" + i + "')\"></td>";
                    Conteudo.InnerHtml += "<td class=\"ProdAdd\"><a class=\"Adicionar\" href=\"javascript: Adicionar_Comanda('" + comanda.id_Comanda + "', '" + item["id_Cardapio_Item"] + "', '" + i + "', '" + item["valor"] + "');\">Adicionar</a></td>";
                    Conteudo.InnerHtml += "</tr>";
                    i++;
                }
            }
            Conteudo.InnerHtml += "</table>";

        }

        [WebMethod]
        public static string Adicionar(string id_comanda, string id_cardapio_item, string qtd, string valor)
        {
            Comanda_Item comanda_Item = new Comanda_Item();
            BancoTools banco = new BancoTools();
            comanda_Item.id_Comanda = Convert.ToInt32(id_comanda);
            comanda_Item.id_Cardapio_Item = Convert.ToInt32(id_cardapio_item);
            comanda_Item.qtd_Cardapio_Item = Convert.ToInt32(qtd);
            comanda_Item.vl_Cardapio_Item = float.Parse(valor);
            RepComandaItem repComandaItem = new RepComandaItem();
            var resultComanda = banco.checa_existe("Comanda_Item", "id_Cardapio_Item", comanda_Item.id_Cardapio_Item + " and id_Comanda = " + comanda_Item.id_Comanda + "");
            if (resultComanda.Rows.Count > 0)
            {
                comanda_Item.id_Comanda_Item = banco.retornaId("Comanda_Item", "id_Comanda", comanda_Item.id_Comanda + " and id_Cardapio_item = " + comanda_Item.id_Cardapio_Item + "", "id_Comanda_Item");
                var resultCozinha = banco.checa_existe("Cozinha", "id_Comanda_Item", comanda_Item.id_Comanda_Item + " and id_Comanda = " + comanda_Item.id_Comanda + "");
                if (resultCozinha.Rows.Count < 1)
                    repComandaItem.Update_Comanda_Cliente(comanda_Item);
                else
                    repComandaItem.Insert(comanda_Item);
            }
            else
                repComandaItem.Insert(comanda_Item);
            return "Item inserido na comanda";
        }
    }
}