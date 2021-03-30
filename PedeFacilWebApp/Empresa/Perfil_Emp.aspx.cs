using System;
using PedeFacilLibrary.Models;
using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Repository;
using System.Web.UI;
using PedeFacilLibrary.Validations;

namespace PedeFacilWebApp.WebPages.WebPage.Empresa
{
    public partial class Perfil_Emp : System.Web.UI.Page
    {
        dynamic objentidade = null;
        BancoTools bancoTools = new BancoTools();
        EnderecoTools enderecoTools = new EnderecoTools();
        RepEntidade repEntidade = new RepEntidade();
        Entidade entidade = new Entidade();
        Validacoes validacoes = new Validacoes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                objentidade = Session["Objentidade"];
                if (objentidade != null)
                {
                    var entidade = repEntidade.Select_Entidade(objentidade);
                    txtNome.Text = entidade.Nome;
                    txtRazaoSocial.Text = entidade.RazaoSocial;
                    txtCNPJ.Text = entidade.CNPJ_CPF;
                    txtEmail.Text = entidade.Email;
                    txtTelefone.Text = entidade.Telefone.ToString();
                    txtLogradouro.Text = entidade.Logradouro;
                    txtNumero.Text = entidade.Numero;
                    txtComplemento.Text = entidade.Complemento;
                    txtBairro.Text = entidade.Bairro;
                    txtCidade.Text = entidade.Cidade;
                    txtCEP.Text = entidade.CEP;
                    txtPais.Text = entidade.Pais;
                    txtEstado.Text = entidade.Estado;
                }
                else
                    Response.Redirect("../Entrada.aspx");
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            entidade.Nome = txtNome.Text;
            entidade.RazaoSocial = txtRazaoSocial.Text;
            entidade.Telefone = Convert.ToInt64(txtTelefone.Text);
            entidade.Complemento = txtComplemento.Text;
            entidade.Numero = txtNumero.Text;
            entidade.Email = txtEmail.Text;
            entidade.CNPJ_CPF = txtCNPJ.Text;
            entidade.id_Tipo = 2;
            entidade.Pais = "Brasil";
            entidade.CEP = txtCEP.Text;
            entidade.Logradouro = txtLogradouro.Text;
            entidade.Bairro = txtBairro.Text;
            entidade.Cidade = txtCidade.Text;
            entidade.Estado = txtEstado.Text;

            var validar = validacoes.Validar(entidade);

            if (validar == "")
            {
                var resultItem = bancoTools.checa_existe("Entidade", "CNPJ_CPF", "'" + entidade.CNPJ_CPF + "'");
                if (resultItem.Rows.Count > 0)
                    entidade.id_Entidade = bancoTools.retornaId("Entidade", "CNPJ_CPF", "'" + entidade.CNPJ_CPF + "'", "id_Entidade");
                var result = repEntidade.Enviar(entidade, resultItem);
                if (result == true)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Dados alterados com sucesso!'); window.location ='Home_Emp.aspx'", true);
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Erro ao alterar os dados');", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Erro: " + validar + "');", true);
        }


        protected void btnLimpar_Click(object sender, EventArgs e)
        {

        }

        protected void txtCEP_TextChanged(object sender, EventArgs e)
        {
            if (txtCEP.Text.Length > 7)
            {
                entidade.CEP = txtCEP.Text;
                enderecoTools.WebCEP(entidade);
                txtLogradouro.Text = entidade.Logradouro;
                txtBairro.Text = entidade.Bairro;
                txtCidade.Text = entidade.Cidade;
                txtEstado.Text = entidade.Estado;
                txtNumero.Focus();
            }
        }
    }
}