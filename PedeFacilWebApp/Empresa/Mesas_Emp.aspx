<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/MasterPage/Empresa/Master_Emp.Master" AutoEventWireup="true" CodeBehind="Mesas_Emp.aspx.cs" Inherits="PedeFacilWebApp.WebPages.WebPage.Empresa.Mesas_Emp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterHeader" runat="server">
<link href="../StyleSheets/MasterPage/MasterEmp.css" rel="stylesheet" />
    <link href="../StyleSheets/WebPage/Empresa/Mesa_Emp.css" rel="stylesheet" />
    <script type="text/javascript"></script>
    <script>
        function Editar(a, b, c) {
            PageMethods.Alterar(a, b, c, Redireciona_Cadastro);
        }

        function Status(a, b) {
            PageMethods.Status(a, b, Refresh);
        }

        function Refresh() {
            window.location.reload();
        }

        function Redireciona_Cadastro() {
            window.location = "Cadastrar_Mesas.aspx";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterBody" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <div id="Bolinha">
        <div id="PagNome">
            <img class="icoPag" src="../../../StyleSheets/Images/mesa.png" />Mesas</div>
        <img src="../../../StyleSheets/Images/menu.png" id="btnMenu" onclick="Abre()" />
    </div>
    <div id="lblcom">Gerencie as mesas de seu estabelecimento!</div>
    <br />
    <br />
    <div id="com">
        <div id="ListaMesas" runat="server"></div>
        <br />
        <asp:Button ID="btnCadastrar" class="botoes" runat="server" Text="Cadastrar mesa" OnClick="btnCadastrar_Click" />
    </div>
</asp:Content>
