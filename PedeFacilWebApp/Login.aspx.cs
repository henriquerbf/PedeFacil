using System;
using System.Collections.Generic;
using System.Web.UI;
using PedeFacilLibrary.Models;
using PedeFacilLibrary.Repository;
using PedeFacilLibrary.Data_Services;
using System.Data;
using System.Web.Services;
using System.Web;

namespace PedeFacilWebApp.WebPages.WebPage.Geral
{
    public partial class Login : System.Web.UI.Page
    {
        private RepUsuario repUsuario = new RepUsuario();
        private RepEntidade repEntidade = new RepEntidade();
        private BancoTools bancoTools = new BancoTools();
        private Criptografia criptografia = new Criptografia();
        private dynamic listaemp;

        protected void Page_Load(object sender, EventArgs e)
        {
            listaemp = repEntidade.Select();

            List<string> list = new List<string>();

            foreach (dynamic empresa in listaemp)
            {
                list.Add(empresa.Nome);
            }

            ddlEstabelecimento.DataSource = list;
            ddlEstabelecimento.DataBind();
        }

        [WebMethod]
        public static string btnLogin_Click(string txtLogin, string txtSenha, string ddlEstabelecimento, string w, string h)
        {
            Login paglogin = new Login();
            Usuario usuario = new Usuario();
            Entidade entidade = new Entidade();
            Entidade estabelecimento = new Entidade();
            Comanda comanda = new Comanda();

            usuario.Login = txtLogin;
            usuario.Senha = txtSenha;
            estabelecimento.Nome = ddlEstabelecimento;

            int width = Convert.ToInt32(w);
            int height = Convert.ToInt32(h);

            var result = paglogin.repUsuario.Select_Usuario(usuario);
            if (result != null)
            {
                foreach (DataRow item in result.Rows)
                {
                    usuario.id_Usuario = Convert.ToInt32(item["id_Usuario"]);
                    usuario.ic_Ativo = Convert.ToByte(item["ic_Ativo"]);
                    usuario.id_Tipo = Convert.ToInt32(item["id_Tipo"]);
                    usuario.Senha = item["Senha"].ToString();
                    entidade.Nome = item["Nome"].ToString();
                }
                var senha = paglogin.criptografia.Criptografar(txtSenha.ToUpper());

                if (usuario != null)
                {
                    if (usuario.Senha == senha && usuario.ic_Ativo == 1)
                    {
                        entidade.CNPJ_CPF = paglogin.bancoTools.retornaCampo("CNPJ_CPF", "Entidade", "join Usuario on Usuario.id_Entidade = Entidade.id_Entidade", "Usuario.Login = '" + usuario.Login + "' and Usuario.Senha = '" + senha + "'");
                        paglogin.repEntidade.Select_Entidade(entidade);
                        HttpContext.Current.Session["Objentidade"] = entidade;
                        HttpContext.Current.Session["Objusuario"] = usuario;

                        if (usuario.id_Tipo == 1)
                        {
                            if (width < 490)
                            {
                                estabelecimento.id_Entidade = paglogin.bancoTools.retornaId("Entidade", "Nome", "'" + estabelecimento.Nome + "'", "id_Entidade");
                                HttpContext.Current.Session["Objestabelecimento"] = estabelecimento;
                                //var verificaComanda = paglogin.bancoTools.checa_existe("Comanda", "id_Entidade", entidade.id_Entidade + " and and ic_Status = 1");
                                var verificaComanda = paglogin.bancoTools.checa_existe("Comanda as C join Mesa as M on M.id_Mesa = C.id_Mesa ", "C.id_Entidade", entidade.id_Entidade + " and M.id_Entidade = " + estabelecimento.id_Entidade + " and C.ic_Status = 1");
                                if (verificaComanda.Rows.Count > 0)
                                {
                                    foreach (DataRow item in verificaComanda.Rows)
                                    {
                                        comanda.id_Comanda = Convert.ToInt32(item["id_Comanda"]);
                                        comanda.id_Entidade = Convert.ToInt32(item["id_Entidade"]);
                                        comanda.id_Mesa = Convert.ToInt32(item["id_Mesa"]);
                                        comanda.nm_Comanda = item["nm_Comanda"].ToString();
                                        comanda.ic_Status = Convert.ToByte(item["ic_Status"]);
                                        comanda.DataHora = Convert.ToDateTime(item["DataHora"]);
                                    }
                                    HttpContext.Current.Session["Objcomanda"] = comanda;
                                }
                                return "cliente";
                            }
                            else
                                return "Acessivel apenas em dispositivos mobile!";
                        }
                        else if (usuario.id_Tipo == 2)
                        {
                            if (width > 490)
                            {
                                if (entidade.Nome == ddlEstabelecimento)
                                    return "empresa";
                                else
                                    return "Senha ou entidade errada.";
                            }
                            else
                                return "Acessivel somente em PCs";

                        }
                        else if (usuario.id_Tipo == 3)
                            if (width > 490)
                                return "cozinha";
                            else
                                return "Acessivel somente em PCs";
                    }
                    else
                        return "Usuário ou senha inválida.";
                }
            }
            else
                return "Usuário nao cadastrado.";
            return "";
        }
    }
}