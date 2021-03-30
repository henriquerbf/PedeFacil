<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/MasterPage/Empresa/Master_Emp.Master" AutoEventWireup="true" CodeBehind="Home_Emp.aspx.cs" Inherits="PedeFacilWebApp.WebPages.WebPage.Empresa.Home_Emp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterHeader" runat="server">
    <link href="../StyleSheets/MasterPage/MasterEmp.css" rel="stylesheet" />
    <link href="../StyleSheets/WebPage/Empresa/Home_Emp.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterBody" runat="server">
    <div id="Bolinha">
        <div id="PagNome"><img class="icoPag" src="../../../StyleSheets/Images/history.png" />Home</div>
        <img src="../../../StyleSheets/Images/menu.png" id="btnMenu" onclick="Abre()" />
    </div>
</asp:Content>