using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PedeFacilLibrary.Models;
using PedeFacilLibrary.Repository;
using PedeFacilLibrary.Data_Services;
using System.Web.Services;

namespace PedeFacilWebApp.WebPages.WebPage.Geral
{
    public partial class Resetar_Senha : System.Web.UI.Page
    {
        private Criptografia criptografia = new Criptografia();
        private RepUsuario repUsuario = new RepUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string btnConfirmar_Click(string senha)
        {
            Resetar_Senha resetar_Senha = new Resetar_Senha();
            Usuario usuario = new Usuario();
            usuario.Senha = resetar_Senha.criptografia.Criptografar(senha);
            usuario.id_Usuario = Convert.ToInt32(resetar_Senha.Request.QueryString["id"]);

            var result = resetar_Senha.repUsuario.Alterar_Senha(usuario);

            if (result)
                return "Senha alterada com sucesso. Você sera redirecionado(a) para a tela de Login";
            else
                return "erro";
        }
    }
}