using System;
using PedeFacilLibrary.Models;
using PedeFacilLibrary.Repository;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using System.Web;
using PedeFacilLibrary.Data_Services;

namespace PedeFacilWebApp.WebPages.WebPage.Cliente
{
    public partial class Comanda_Cli : System.Web.UI.Page
    {
        dynamic objusuario = null;
        dynamic objcomanda = null;
        dynamic lista = null;
        float valor = 0;
        private RepComanda repComanda = new RepComanda();
        private Comanda comanda = new Comanda();

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
                objcomanda = Session["Objcomanda"];
                comanda.id_Comanda = objcomanda.id_Comanda;
                comanda.nm_Comanda = objcomanda.nm_Comanda;
                if (comanda != null)
                {
                    lista = repComanda.Select_Comanda(comanda);
                    ListarComandas(lista);
                }
                else
                {
                    Response.Redirect("../Cliente/Home_Cli.aspx");
                }
            }
            else
                Response.Redirect("../Entrada.aspx");
        }

        private void ListarComandas(DataTable tabela)
        {
            Conteudo.InnerHtml = "<div id=\"Tipo\">Comanda<div id=\"textinho\">Produtos escolhidos.</div></div>";
            Conteudo.InnerHtml += "<table id=\"Comanda\" runat=\"server\">";

            int i = 1;
            foreach (DataRow item in tabela.Rows)
            {
                Conteudo.InnerHtml += "<tr class=\"Linha1\" class=\"tr2\">";
                Conteudo.InnerHtml += "<td  class=\"ProdNome\"><div id=\"bordnome\">" + item["Nome"] + "</div></td>";
                Conteudo.InnerHtml += "<td class=\"ProdPreco\">" + string.Format("{0:C}", item["vl_Cardapio_Item"]) + "</td>";
                Conteudo.InnerHtml += "</tr>";
                Conteudo.InnerHtml += "<tr class=\"Linha2\">";
                if (verificarCozinha(Convert.ToInt32(item["id_Comanda_Item"]), Convert.ToInt32(item["id_Comanda"])) == true)
                {
                    Conteudo.InnerHtml += "<td class=\"ProdQuantidade\"><input type=\"button\" id=\"plus\" value='-' onclick=\"process(-1, '" + i + "', '" + item["id_Comanda_Item"] + "')\" /> " +
                                          "<input id=\"quant" + i + "\" name=\"quant\" class=\"text\" size=\"1\" type=\"text\" value=\"" + item["qtd_Cardapio_Item"] + "\" maxlength=\"2\" disabled /> " +
                                          "<input type=\"button\" id=\"minus\" value='+' onclick=\"process(1, '" + i + "', '" + item["id_Comanda_Item"] + "')\"></td>";
                    Conteudo.InnerHtml += "<td class=\"ProdAdd\"><a class=\"Adicionar\"  href=\"javascript: Alterar_Item('" + item["id_Comanda_Item"] + "', '" + i + "');\">Alterar</td>";
                    Conteudo.InnerHtml += "<td><a class=\"Pedir\" href=\"javascript: Fazer_Pedido('" + item["id_Comanda_Item"] + "', '" + comanda.id_Comanda + "');\">Pedir</td>";
                }
                else
                {
                    Conteudo.InnerHtml += "<td class=\"ProdQuantidade\"><input type=\"button\" id=\"plus\" value='-' onclick=\"process(-1, '" + i + "', '" + item["id_Comanda_Item"] + "')\" disabled /> " +
                                          "<input id=\"quant" + i + "\" name=\"quant\" class=\"text\" size=\"1\" type=\"text\" value=\"" + item["qtd_Cardapio_Item"] + "\" maxlength=\"2\" disabled /> " +
                                          "<input type=\"button\" id=\"minus\" value='+' onclick=\"process(1, '" + i + "', '" + item["id_Comanda_Item"] + "')\" disabled ></td>";
                    Conteudo.InnerHtml += "<td class=\"ProdAdd\"><a class=\"Adicionar\"\">Pedido</td>";
                }
                Conteudo.InnerHtml += "</tr>";
                i++;
                if (lista.Rows.Count > 0)
                    valor += float.Parse(item["vl_Cardapio_Item"].ToString()) * Convert.ToInt32(item["qtd_Cardapio_Item"]);
            }
            Conteudo.InnerHtml += "<tr class=\"Linha3\" ><td>Total: </td><td class=\"PrecoTot\">" + string.Format("{0:C}", valor) + "</td></tr>";
            Conteudo.InnerHtml += "</table>";
            Conteudo.InnerHtml += "<a class=\"FechaCo\" href=\"javascript: Fechar_Comanda('" + comanda.nm_Comanda + "');\">Fechar comanda</a>";
        }

        [WebMethod]
        public static string Alterar(string idcomandaitem, string qtd)
        {
            Comanda_Item comanda_Item = new Comanda_Item();
            comanda_Item.id_Comanda_Item = Convert.ToInt32(idcomandaitem);
            comanda_Item.qtd_Cardapio_Item = Convert.ToInt32(qtd);
            RepComandaItem repComandaItem = new RepComandaItem();
            repComandaItem.Update_Comanda(comanda_Item);
            return "";
        }

        [WebMethod]
        public static string Deletar(string id)
        {
            Comanda_Item comanda_Item = new Comanda_Item();
            comanda_Item.id_Comanda_Item = Convert.ToInt32(id);
            RepComandaItem repComandaItem = new RepComandaItem();
            repComandaItem.Delete(comanda_Item);
            return "";
        }

        [WebMethod]
        public static string Pedir(string id_comanda_item, string id_comanda, string obs)
        {
            Cozinha cozinha = new Cozinha();
            cozinha.id_Comanda_Item = Convert.ToInt32(id_comanda_item);
            cozinha.id_Comanda = Convert.ToInt32(id_comanda);
            cozinha.DataHora = DateTime.Now;
            cozinha.ic_Status = Convert.ToByte(false);
            if (obs == "")
                cozinha.ds_Observacao = "Nenhuma observação";
            else
                cozinha.ds_Observacao = obs;
            RepCozinha repCozinha = new RepCozinha();
            repCozinha.Enviar(cozinha);
            return "";
        }

        public bool verificarCozinha(int item, int comanda)
        {
            bool status;
            BancoTools banco = new BancoTools();
            var result = banco.checa_existe("Cozinha", "id_Comanda_Item", item + " and id_Comanda = " + comanda);
            if (result.Rows.Count == 0)
                status = true;
            else
                status = false;
            return status;
        }
    }
}