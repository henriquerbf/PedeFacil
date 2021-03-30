using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using PedeFacilLibrary.Repository;
using PedeFacilLibrary.Validations;
using System;
using System.Web.Services;
using System.Web.UI;

namespace PedeFacilWebApp.WebPages.WebPage.Cliente
{
    public partial class Perfil_Cli : System.Web.UI.Page
    {
        dynamic objcliente = null;
        dynamic objcomanda = null;
        BancoTools bancoTools = new BancoTools();
        RepEntidade repEntidade = new RepEntidade();


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
            if (!Page.IsPostBack)
            {
                objcliente = Session["Objentidade"];
                if (objcliente != null)
                {
                    var entidade = repEntidade.Select_Entidade(objcliente);
                    txtNome.Text = entidade.Nome;
                    txtTelefone.Text = entidade.Telefone.ToString();
                    txtCPF.Text = entidade.CNPJ_CPF;
                    txtEmail.Text = entidade.Email;
                }
                else
                    Response.Redirect("../Entrada.aspx");
            }
        }

        [WebMethod]
        public static string btnEnviar_Click(string nome, string cnpj_cpf, string telefone , string email)
        {
            Validacoes validacoes = new Validacoes();
            BancoTools bancoTools = new BancoTools();
            RepEntidade repEntidade = new RepEntidade();
            Entidade entidade = new Entidade();
            entidade.Nome = nome;
            entidade.Telefone = Convert.ToInt64(telefone);
            entidade.CNPJ_CPF = cnpj_cpf;
            entidade.Email = email;
            entidade.id_Tipo = 1;

            var validar = validacoes.Validar(entidade);

            if (validar == "")
            {
                var resultItem = bancoTools.checa_existe("Entidade", "CNPJ_CPF", "'" + entidade.CNPJ_CPF + "'");
                if (resultItem.Rows.Count > 0)
                    entidade.id_Entidade = bancoTools.retornaId("Entidade", "CNPJ_CPF", "'" + entidade.CNPJ_CPF + "'", "id_Entidade");
                var result = repEntidade.updateCliente(entidade);
                if (result == true)
                    return "Dados alterados com sucesso!";
                else
                    return "Erro ao alterar os dados";
            }
            else
                return "Erro: " + validar;
        }
    }
}