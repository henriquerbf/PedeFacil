using PedeFacilLibrary.Data_Services;
using PedeFacilLibrary.Models;
using PedeFacilLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedeFacilWebApp.WebPages.WebPage.Empresa
{
    public partial class Cadastrar_Mesas : System.Web.UI.Page
    {
        dynamic item = null;
        dynamic objentidade = null;

        BancoTools bancoTools = new BancoTools();
        Mesa mesa = new Mesa();
        RepMesa repMesa = new RepMesa();

        protected void Page_Load(object sender, EventArgs e)
        {
            objentidade = Session["Objentidade"];
            if (objentidade != null)
            {
                item = Session["Mesa"];
                Session["Mesa"] = null;
                mesa.id_Entidade = objentidade.id_Entidade;
                if (item != null)
                {
                    txtMesa.Text = item.nome;
                    if (item.status == "True")
                        chbStatus.Checked = true;
                }
            }
            else
                Response.Redirect("../Entrada.aspx");
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            mesa.ds_Mesa = txtMesa.Text;
            if (chbStatus.Checked)
                mesa.ic_Status = 1;
            else
                mesa.ic_Status = 0;
            var resultItem = bancoTools.checa_existe("Mesa", "ds_Mesa", "'" + mesa.ds_Mesa + "' and id_Entidade = " + mesa.id_Entidade + "");
            if (resultItem != null)
                mesa.id_Mesa = bancoTools.retornaId("Mesa", "ds_Mesa", "'" + mesa.ds_Mesa + "'" + " and id_Entidade = " + mesa.id_Entidade, "id_Mesa");
            var result = repMesa.Enviar(mesa, resultItem);
            if (result == true)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Mesa cadastrada com sucesso!'); window.location ='Mesas_Emp.aspx'", true);
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Erro ao cadastrar mesa');", true);
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            txtMesa.Text = string.Empty;
            chbStatus.Checked = false;
        }
    }
}