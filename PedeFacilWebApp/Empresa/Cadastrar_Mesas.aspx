<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/MasterPage/Empresa/Master_Emp.Master" AutoEventWireup="true" CodeBehind="Cadastrar_Mesas.aspx.cs" Inherits="PedeFacilWebApp.WebPages.WebPage.Empresa.Cadastrar_Mesas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterHeader" runat="server">
    <link href="../StyleSheets/MasterPage/MasterEmp.css" rel="stylesheet" />
    <link href="../StyleSheets/WebPage/Empresa/Cadastra_Mesa.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterBody" runat="server">
    <div id="Bolinha">
        <div id="PagNome">
            <img class="icoPag" src="../../../StyleSheets/Images/mesa.png" />Cadastrar Mesas</div>
        <img src="../../../StyleSheets/Images/menu.png" id="btnMenu" onclick="Abre()" />
    </div>
    <div id="lblSAC">Aqui você poderá adicionar e alterar as mesas disponíveis em seu estabelecimento.</div>
    <br />
    <br />
    <br />
    <div id="com">
        <asp:Label ID="lblMesa" runat="server" Text="Mesa:"></asp:Label>
        <asp:TextBox ID="txtMesa" runat="server"></asp:TextBox>

        <br />
        <asp:Label ID="lblStatus" runat="server" Text="Status:"></asp:Label>
        <asp:CheckBox ID="chbStatus" Checked="false" runat="server" />

        <br />
        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
        <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />
    </div>
</asp:Content>
