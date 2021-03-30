using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using PedeFacilLibrary.Repository;
using PedeFacilLibrary.Validations;
using System;
using System.Data;
using System.Web.Services;
using System.Web.UI;

namespace PedeFacilWebApp.WebPages.WebPage.Geral
{
    public partial class Cadastrar_Usuario : System.Web.UI.Page
    {
        private RepEntidade repEntidade = new RepEntidade();
        private RepUsuario repUsuario = new RepUsuario();
        private RepCardapio repCardapio = new RepCardapio();
        private Validacoes validacoes = new Validacoes();
        private BancoTools banco = new BancoTools();
        private Criptografia criptografia = new Criptografia();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string btnCadastrar_Click(string txtUsuario, string txtSenha, string txtNome, string txtRazao, string txtCNPJCPF, string txtEmail)
        {
            Cadastrar_Usuario CadUsuario = new Cadastrar_Usuario();
            DataTable tabela = new DataTable();
            EmailTools email = new EmailTools();

            Tipo Tipo = new Tipo();

            if (txtCNPJCPF.Length > 11)
                Tipo.Descricao = "Estabelecimento";
            //verificar nome, razao social e cnpj
            else
                Tipo.Descricao = "Cliente";

            Entidade entidade = new Entidade
            {
                id_Tipo = CadUsuario.banco.retornaId("Tipo", "Descricao", "'" + Tipo.Descricao + "'", "id_Tipo"),
                Nome = txtNome,
                RazaoSocial = txtRazao,
                CNPJ_CPF = txtCNPJCPF,
                Email = txtEmail,
                Bairro = "",
                CEP = "",
                Cidade = "",
                Complemento = "",
                Estado = "",
                Logradouro = "",
                Numero = "",
                Pais = "",
                Telefone = 0
            };

            Usuario usuario = new Usuario
            {
                Login = txtUsuario,
                Senha = CadUsuario.criptografia.Criptografar(txtSenha.ToUpper()),
                id_Tipo = entidade.id_Tipo,
                ic_Ativo = Convert.ToByte(true)
            };

            string valEntidade = CadUsuario.validacoes.Validar(entidade);
            string valUsuario = CadUsuario.validacoes.Validar(usuario);

            var resultEnt = CadUsuario.banco.checa_existe("Entidade", "CNPJ_CPF", "'" + entidade.CNPJ_CPF + "'");
            var resultUser = CadUsuario.banco.checa_existe("Usuario", "Login", "'" + usuario.Login + "'");

            if (valEntidade == "")
            {
                if (valUsuario == "")
                {
                    if (resultEnt.Rows.Count < 1)
                    {
                        if (resultUser.Rows.Count < 1)
                        {
                            var resultentidade = CadUsuario.repEntidade.Enviar(entidade, resultEnt);
                            usuario.id_Entidade = CadUsuario.banco.retornaId("Entidade", "CNPJ_CPF", "'" + entidade.CNPJ_CPF + "'", "id_Entidade");
                            if (txtCNPJCPF.Length > 11)
                                usuario.ic_Ativo = Convert.ToByte(false);
                            var resultusuario = CadUsuario.repUsuario.Enviar(usuario, resultUser);
                            if (txtCNPJCPF.Length > 11)
                            {
                                Cardapio cardapio = new Cardapio()
                                {
                                    id_Entidade = usuario.id_Entidade
                                };
                                Usuario cozinha = new Usuario()
                                {
                                    Login = txtUsuario + "_cozinha",
                                    Senha = CadUsuario.criptografia.Criptografar(txtSenha.ToUpper()),
                                    id_Entidade = usuario.id_Entidade,
                                    id_Tipo = CadUsuario.banco.retornaId("Tipo", "Descricao", "'Cozinha'", "id_Tipo"),
                                    ic_Ativo = Convert.ToByte(false)
                                };
                                CadUsuario.repUsuario.Enviar(cozinha, tabela);
                                CadUsuario.repCardapio.Enviar(cardapio, tabela);
                                email.sendEmail("pedefacil@outlook.com", entidade.Email, "Cadastro", "Olá senhor(a) " + entidade.Nome + "<br>" + "Seu cadastro foi efetuado com sucesso!!<br>Seu login é: " + usuario.Login + " e sua senha: " + txtSenha +
                                    "<br>Seu login para a cozinha é: " + usuario.Login + "_cozinha e sua senha: " + txtSenha + "<br>O acesso é permitido somente em computadores<br>Entre em contato conosco no email: pedefacil@outlook.com para ativarmos o seu cadastro");
                                return ("Seu cadastro foi realizado, verifique seu email. Você sera redirecionado para a tela de Login.");
                            }
                            if (resultentidade == true && resultentidade == true)
                            {
                                email.sendEmail("pedefacil@outlook.com", entidade.Email, "Cadastro", "Olá senhor(a) " + entidade.Nome + "<br>O acesso é permitido apenas em smartphones.<br>Seu cadastro foi efetuado com sucesso!!<br>Seu login é: " + usuario.Login + " e sua senha: " + txtSenha);
                                return ("Seu cadastro foi realizado. Você sera redirecionado para a tela de Login.");
                            }
                            else
                                return ("Erro ao criar cadastro.");
                        }
                        else
                        {
                            return ("Usuário já cadastrado(a)");
                        }
                    }
                    else
                    {
                        return ("Entidade já cadastrado(a)");
                    }
                }
                else
                {
                    return ("Erros: " + valUsuario);
                }
            }
            else
            {
                return ("Erros: " + valEntidade);
            }
        }

        protected void txtCNPJCPF_TextChanged(object sender, EventArgs e)
        {
            txtCNPJCPF.MaxLength = 14;
            if (txtCNPJCPF.Text.Length > 11)
                txtRazao.Enabled = true;
            else
                txtRazao.Enabled = false;
        }
    }
}