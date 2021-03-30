using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PedeFacilLibrary.Models;
using PedeFacilLibrary.Repository;
using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Validations;

namespace PedeFacilWebApp.WebPages.WebPage.Empresa
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        dynamic item = null;
        dynamic objentidade = null;

        BancoTools bancoTools = new BancoTools();
        Cardapio_Item cardapio_Item = new Cardapio_Item();
        Entidade entidade = new Entidade();
        RepCardapioItem repCardapioItem = new RepCardapioItem();
        Validacoes validacoes = new Validacoes();

        protected void Page_Load(object sender, EventArgs e)
        {
            objentidade = Session["Objentidade"];
            if (objentidade != null)
            {
                item = Session["Item"];
                Session["Item"] = null;
                entidade.id_Entidade = objentidade.id_Entidade;
                if (item != null)
                {
                    txtNome.Text = item.nome;
                    txtDescricao.Text = item.descricao;
                    txtValor.Text = string.Format("{0:C}", item.valor);
                    txtDesconto.Text = string.Format("{0:C}", item.desconto);
                    ddlTipo.Text = item.tipo;
                    if (item.ativo == "1")
                        chbAtivo.Checked = true;
                    if (item.destaque == "True")
                        chbDestaque.Checked = true;
                }
                else
                {
                    txtNome.Enabled = true;
                    txtDescricao.Enabled = true;
                }
            }
            else
                Response.Redirect("../Entrada.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            cardapio_Item.Nome = txtNome.Text;
            cardapio_Item.Descricao = txtDescricao.Text;
            cardapio_Item.vl_Desconto = float.Parse(txtDesconto.Text);
            cardapio_Item.Valor = float.Parse(txtValor.Text);
            if (chbDestaque.Checked)
                cardapio_Item.ic_Destaque = 1;
            else
                cardapio_Item.ic_Destaque = 0;

            if (chbAtivo.Checked)
                cardapio_Item.ic_Ativo = 1;
            else
                cardapio_Item.ic_Ativo = 0;

            if (ddlTipo.SelectedValue == "Comida")
                cardapio_Item.id_Tipo = 4;
            else
                cardapio_Item.id_Tipo = 5;

            cardapio_Item.id_Cardapio = bancoTools.retornaId("Cardapio", "id_Entidade", entidade.id_Entidade, "id_Cardapio");

            var validar = validacoes.Validar(cardapio_Item);

            if (validar == "")
            {
                var resultItem = bancoTools.checa_existe("Cardapio_Item", "Nome", "'" + cardapio_Item.Nome + "' and id_Cardapio = " + cardapio_Item.id_Cardapio + "");
                if (resultItem != null)
                    cardapio_Item.id_Cardapio_Item = bancoTools.retornaId("Cardapio_Item", "Nome", "'" + cardapio_Item.Nome + "'" + " and id_Cardapio = " + cardapio_Item.id_Cardapio, "id_Cardapio_Item");
                var result = repCardapioItem.Enviar(cardapio_Item, resultItem);
                if (result == true)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Item cadastrado com sucesso!'); window.location ='Cardapio_Emp.aspx'", true);
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Erro ao inserir item no cardapio!');", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Erro: " + validar + "');", true);
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            txtDesconto.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtValor.Text = string.Empty;
            chbAtivo.Checked = false;
            chbDestaque.Checked = false;
        }
    }
}