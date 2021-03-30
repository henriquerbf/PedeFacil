using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using PedeFacilLibrary.Repository;
using System;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedeFacilWebApp.WebPages.WebPage.Geral
{
    public partial class Esqueci_Senha : System.Web.UI.Page
    {
        private EmailTools emailTools = new EmailTools();
        private RepUsuario repUsuario = new RepUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static string btnEsqueci_Click(string email)
        {
            Esqueci_Senha esqueci_Senha = new Esqueci_Senha();
            Usuario usuario = new Usuario();
            Entidade entidade = new Entidade();
            entidade.Email = email;

            dynamic reader = esqueci_Senha.repUsuario.Select_Email(entidade);
            if (reader != null)
            {
                foreach (DataRow item in reader.Rows)
                {
                    usuario.id_Usuario = Convert.ToInt32(item["id_Usuario"]);
                    entidade.Nome = item["Nome"].ToString();
                }

                var result = esqueci_Senha.emailTools.sendEmail(null, email, null, "<html><body>Olá senhor(a) " + entidade.Nome + "<br>Crie uma nova senha no link à seguir: " +
                    "<br><br> <a href=\"http://www.pedefacil.somee.com/Resetar_Senha.aspx?id=" + usuario.id_Usuario + "\">Alterar senha</a></body></html>");
                if (result == true)
                    return "O link para criar uma nova senha foi enviado por email.";
                else
                    return "Erro ao criar link para resetar sua senha";
            }
            else
                return "Usuário não cadastrado";

        }
    }
}