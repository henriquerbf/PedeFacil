<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/MasterPage/Empresa/Master_Emp.Master" AutoEventWireup="true" CodeBehind="Detalhes_RelatorioEmp.aspx.cs" Inherits="PedeFacilWebApp.Empresa.Detalhes_RelatorioEmp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterHeader" runat="server">
    <link href="../StyleSheets/MasterPage/MasterEmp.css" rel="stylesheet" />
    <link href="../StyleSheets/WebPage/Empresa/Comanda_Emp.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterBody" runat="server">
    <div id="Bolinha">
        <div id="PagNome">
            <img class="icoPag" src="../../../StyleSheets/Images/sac.png" />Relatorios - Detalhe
        </div>
        <img src="../../../StyleSheets/Images/menu.png" id="btnMenu" onclick="Abre()" />
    </div>
    <br />
    <div id="com">
        <div id="ContRelatorio" runat="server"></div>
    </div>
</asp:Content>
