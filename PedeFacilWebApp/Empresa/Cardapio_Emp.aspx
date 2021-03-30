<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/MasterPage/Empresa/Master_Emp.Master" AutoEventWireup="true" CodeBehind="Cardapio_Emp.aspx.cs" Inherits="PedeFacilWebApp.WebPages.WebPage.Empresa.Cardapio_Emp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterHeader" runat="server">
<link href="../StyleSheets/MasterPage/MasterEmp.css" rel="stylesheet" />
    <link href="../StyleSheets/WebPage/Empresa/Cardapio_Emp.css" rel="stylesheet" />
    <script type="text/javascript"></script>
    <script>
        function Editar_Item(a, b, c, d, e, f, g, h) {
            PageMethods.Alterar(a, b, c, d, e, f, g, h, Redireciona_Cadastro);
        }

        function Status_Item(a, b) {
            PageMethods.Status(a, b, Refresh);
        }

        function Refresh() {
            window.location.reload();
        }

        function Redireciona_Cadastro() {
            window.location = "Cadastrar_Item.aspx";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterBody" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <div id="Bolinha">
        <div id="PagNome">
            <img class="icoPag" src="../../../StyleSheets/Images/book.png" />Cardapio
        </div>
        <img src="../../../StyleSheets/Images/menu.png" id="btnMenu" onclick="Abre()" />
    </div>
    <div id="lblcom">Gerencie seu cardapio, podendo remover e adicionar itens, adicionar descontos e mais!</div>
    <br />
    <br />
    <div id="com">
        <div id="cardapio" runat="server"></div>
        <br />
        <asp:Button ID="btnCadastrar" class="botoes" runat="server" Text="Cadastrar item" OnClick="btnCadastrar_Click" />
    </div>
</asp:Content>
