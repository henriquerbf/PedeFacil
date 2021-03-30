using System;
using PedeFacilLibrary.Models;
using PedeFacilLibrary.Repository;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using System.Web;

namespace PedeFacilWebApp.WebPages.WebPage.Empresa
{
    public partial class Mesas_Emp : System.Web.UI.Page
    {
        dynamic objentidade = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            objentidade = Session["Objentidade"];
            if (objentidade != null)
            {
                RepMesa RepMesa = new RepMesa();
                DataTable Mesas = new DataTable();

                Mesas = RepMesa.Select(objentidade);
                ListarMesas(Mesas);
            }
            else
                Response.Redirect("../Entrada.aspx");

        }
        private void ListarMesas(DataTable tabela)
        {
            ListaMesas.InnerHtml = "<table id=\"Mesas\" runat=\"server\">";
            ListaMesas.InnerHtml += "<tr id=Colunas>";
            ListaMesas.InnerHtml += "<td class=\"cabe\">Descriçao</td>";
            ListaMesas.InnerHtml += "<td class=\"cabe\">Status</td>";
            ListaMesas.InnerHtml += "<td class=\"cabe\">Editar</td>";
            ListaMesas.InnerHtml += "</tr>";
            var c = 1;
            foreach (DataRow item in tabela.Rows)
            {
                if (c == 1)
                {
                    c++;
                    ListaMesas.InnerHtml += "<tr id=\"Linha\" class=\"tr2\">";
                    ListaMesas.InnerHtml += "<td>" + item["ds_Mesa"] + "</td>";
                    if (Convert.ToByte(item["ic_Status"]) == 1)
                        ListaMesas.InnerHtml += "<td><a href=\"javascript: Status('" + item["id_Mesa"] + "', '" + item["ds_Mesa"] + "');\" class=\"info\">Ativa</td>";
                    else
                        ListaMesas.InnerHtml += "<td><a href=\"javascript: Status('" + item["id_Mesa"] + "', '" + item["ds_Mesa"] + "');\" class=\"info\">Inativa</td>";
                    ListaMesas.InnerHtml += "<td><a href=\"javascript: Editar('" + item["id_Mesa"] + "', '" + item["ds_Mesa"] + "', '" + item["ic_Status"] + "');\" class=\"info\">Editar</td>";
                    ListaMesas.InnerHtml += "</tr>";
                }
                else
                {
                    c--;
                    ListaMesas.InnerHtml += "<tr id=\"Linha\" class=\"l2\">";
                    ListaMesas.InnerHtml += "<td>" + item["ds_Mesa"] + "</td>";
                    if (Convert.ToByte(item["ic_Status"]) == 1)
                        ListaMesas.InnerHtml += "<td><a href=\"javascript: Status('" + item["id_Mesa"] + "', '" + item["ds_Mesa"] + "');\" class=\"info\">Ativa</td>";
                    else
                        ListaMesas.InnerHtml += "<td><a href=\"javascript: Status('" + item["id_Mesa"] + "', '" + item["ds_Mesa"] + "');\" class=\"info\">Inativa</td>";
                    ListaMesas.InnerHtml += "<td><a href=\"javascript: Editar('" + item["id_Mesa"] + "', '" + item["ds_Mesa"] + "', '" + item["ic_Status"] + "');\" class=\"info\">Editar</td>";
                    ListaMesas.InnerHtml += "</tr>";
                }
            }
            ListaMesas.InnerHtml += "</table>";
        }

        [WebMethod]
        public static string Alterar(string id, string nome, string status)
        {
            dynamic mesa = new
            {
                id = id,
                nome = nome,
                status = status
            };

            HttpContext.Current.Session["Mesa"] = mesa;
            return "";
        }

        [WebMethod]
        public static string Status(string id, string status)
        {
            Mesa mesa = new Mesa();
            RepMesa repMesa = new RepMesa();
            if (status == "True")
                mesa.ic_Status = 0;
            else
                mesa.ic_Status = 1;
            mesa.id_Mesa = Convert.ToInt32(id);

            repMesa.Update(mesa);
            return "";
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Empresa/Cadastrar_Mesas.aspx");
        }
    }
}