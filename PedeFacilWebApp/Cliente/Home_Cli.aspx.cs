using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using PedeFacilLibrary.Repository;
using System;
using System.Data;
using System.Web;
using System.Web.Services;

namespace PedeFacilWebApp.WebPages.WebPage.Cliente
{
    public partial class Home_Cli : System.Web.UI.Page
    {
        dynamic objusuario = null;
        dynamic objentidade = null;
        dynamic objcomanda = null;
        dynamic objestabelecimento = null;
        dynamic lista = null;
        BancoTools bancoTools = new BancoTools();
        RepCardapio repCardapio = new RepCardapio();
        Comanda comanda = new Comanda();
        RepMesa repMesa = new RepMesa();

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
            objusuario = Session["Objusuario"];
            objestabelecimento = Session["Objestabelecimento"];
            objentidade = Session["Objentidade"];
            if (objusuario != null)
            {
                if (objcomanda != null)
                {
                    lista = repCardapio.Select_Cardapio_Destaque(objestabelecimento);
                    if (lista.Rows.Count > 0)
                        ListarDestaque(lista);

                    lista = repCardapio.Select_Cardapio_Promocao(objestabelecimento);
                    if (lista.Rows.Count > 0)
                        ListarPromocoes(lista);
                    acesso.InnerHtml = "" + objentidade.Nome + "";
                }
                else
                {
                    acesso.InnerHtml = "" + objentidade.Nome + "";
                    Selecionar_Mesa();
                }
            }
            else
                Response.Redirect("../Entrada.aspx");

        }

        private void ListarDestaque(DataTable tabela)
        {
            ListaDestaque.InnerHtml = "<div id=\"Dest\">Destaques!</div>";
            ListaDestaque.InnerHtml += "<table id=\"Destaque\" runat=\"server\">";
            foreach (DataRow item in tabela.Rows)
            {
                ListaDestaque.InnerHtml += "<tr class=\"Linha1\" class=\"tr2\">";
                ListaDestaque.InnerHtml += "<td class=\"ProdNome\"><div id=\"bordnome\">" + item["Nome"] + "</div></td>";
                ListaDestaque.InnerHtml += "<td class=\"ProdPreco\">" + string.Format("{0:C}", item["Valor"]) + "</td>";
                ListaDestaque.InnerHtml += "</tr>";
            }
            ListaDestaque.InnerHtml += "</table>";
        }

        private void ListarPromocoes(DataTable tabela)
        {
            ListaPromocao.InnerHtml = "<div id=\"Dest\">Promoções!</div>";
            ListaPromocao.InnerHtml += "<table id=\"Promocao\" runat=\"server\">";
            float valor = 0;
            foreach (DataRow item in tabela.Rows)
            {
                valor = float.Parse(item["Valor"].ToString()) - float.Parse(item["vl_Desconto"].ToString());
                ListaPromocao.InnerHtml += "<tr class=\"Linha1\" class=\"tr2\">";
                ListaPromocao.InnerHtml += "<td class=\"ProdNome\"><div id=\"bordnome\">" + item["Nome"] + "</div></td>";
                ListaPromocao.InnerHtml += "<td class=\"ProdPreco2\">" + string.Format("{0:C}", item["Valor"]) + "</td>";
                ListaPromocao.InnerHtml += "<td class=\"ProdPreco1\">" + string.Format("{0:C}", valor) + "</td>";
                ListaPromocao.InnerHtml += "</tr>";
            }
            ListaPromocao.InnerHtml += "</table>";
        }

        private void Selecionar_Mesa()
        {
            SelecionarMesa.InnerHtml = "<div id=\"Dest\"><a href=\"javascript: Criar_Comanda('" + objentidade.id_Entidade + "','" + objestabelecimento.id_Entidade + "');\">Criar comanda</div>";
        }

        [WebMethod]
        public static string Escolher(string id_Entidade, string id_Estabelecimento, string nm_Mesa)
        {
            Comanda comanda = new Comanda();
            RepComanda repComanda = new RepComanda();
            BancoTools bancoTools = new BancoTools();
            comanda.id_Entidade = Convert.ToInt32(id_Entidade);
            int mesa = bancoTools.retornaId("Mesa", "ds_Mesa", "'" + nm_Mesa + "' and id_Entidade = " + id_Estabelecimento + "", "id_Mesa");
            if (mesa != 0)
                comanda.id_Mesa = Convert.ToInt32(mesa);
            else
                return "Mesa inválida";
            var resultComanda = bancoTools.checa_existe("Comanda as C join Mesa as M on M.id_Mesa = C.id_Mesa ", "C.id_Entidade", id_Entidade + " and M.id_Entidade = " + id_Estabelecimento + " and C.ic_Status = 1");
            var resultnmComanda = repComanda.Verificar_Comanda(id_Estabelecimento);
            if (resultComanda.Rows.Count < 1)
            {
                comanda.DataHora = DateTime.Now;
                comanda.ic_Status = 1;
                if (resultnmComanda == "")
                    comanda.nm_Comanda = "A" + id_Estabelecimento + "0001";
                else
                    comanda.nm_Comanda = bancoTools.nmComanda(resultnmComanda);
                var result = repComanda.Enviar(comanda, resultComanda);
                if (result == true)
                {
                    comanda.id_Comanda = Convert.ToInt32(bancoTools.retornaCampo("id_Comanda", "Comanda", "join Mesa on Mesa.id_Mesa = Comanda.id_Mesa", " Comanda.id_Entidade = " + comanda.id_Entidade + " and Comanda.ic_Status = 1 and Mesa.id_Entidade = " + id_Estabelecimento));
                    HttpContext.Current.Session["Objcomanda"] = comanda;
                    return "Comanda criada";
                }
                else
                    return "Erro ao criar comanda";
            }
            return "";
        }
    }
}