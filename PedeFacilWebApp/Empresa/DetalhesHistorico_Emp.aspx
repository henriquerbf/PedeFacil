<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/MasterPage/Empresa/Master_Emp.Master" AutoEventWireup="true" CodeBehind="DetalhesHistorico_Emp.aspx.cs" Inherits="PedeFacilWebApp.WebPages.WebPage.Empresa.DetalhesHistorico_Emp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterHeader" runat="server">
    <link href="../StyleSheets/MasterPage/MasterEmp.css" rel="stylesheet" />
    <link href="../StyleSheets/WebPage/Empresa/Comanda_Emp.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterBody" runat="server">
    <div id="Bolinha">
        <div id="PagNome">
            <img class="icoPag" src="../../../StyleSheets/Images/history.png" />Detalhes do Historico</div>
        <img src="../../../StyleSheets/Images/menu.png" id="btnMenu" onclick="Abre()" />
    </div>
    <br />
            <div id="lblSAC">Obtenha detalhes sobre o histórico de comandas do seu estabelecimento.</div>
        <br />
        <br />
    <div id="com">
        <div id="ListaComanda" runat="server"></div>
    </div>
</asp:Content>
