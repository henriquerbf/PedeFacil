<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/MasterPage/Empresa/Master_Emp.Master" AutoEventWireup="true" CodeBehind="Relatorios_Emp.aspx.cs" Inherits="PedeFacilWebApp.WebPages.WebPage.Empresa.Relatorios_Emp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterHeader" runat="server">
    <link href="../StyleSheets/MasterPage/MasterEmp.css" rel="stylesheet" />
    <link href="../StyleSheets/WebPage/Empresa/Relatorio_emp.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterBody" runat="server">
    <div id="Bolinha">
        <div id="PagNome">
            <img class="icoPag" src="../../../StyleSheets/Images/report.png" />Relatorios
        </div>
        <img src="../../../StyleSheets/Images/menu.png" id="btnMenu" onclick="Abre()" />
    </div>
    <br />
    	<div id="lblrel">Busque relatórios por lucro, rotatividade e produtos mais vendidos.</div><br />
	<br />
    <div id="rel">
        <asp:Label ID="lblLucro" runat="server" Text="Lucro por mês"></asp:Label><br />
        <asp:DropDownList ID="ddlAnoLucro" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>2017</asp:ListItem>
            <asp:ListItem>2018</asp:ListItem>
            <asp:ListItem>2019</asp:ListItem>
            <asp:ListItem>2020</asp:ListItem>
        </asp:DropDownList><br />
        <asp:Button ID="btnLucro" class="botoes" runat="server" Text="Buscar" OnClick="btnLucro_Click" /><br />
        <div id="LucroPorMes" runat="server"></div>

        <br />
        <br />

        <asp:Label ID="lblProdutos" runat="server" Text="Produtos mais vendidos"></asp:Label><br />
        <asp:Button ID="btnProdutos" class="botoes" runat="server" Text="Buscar" OnClick="btnProdutos_Click" />
        <div id="ProdutosMaisVendidos" runat="server"></div>

        <br />
        <br />

        <asp:Label ID="lblDias" runat="server" Text="Dias de maior movimento"></asp:Label><br />
        <asp:DropDownList ID="ddlAno" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>2017</asp:ListItem>
            <asp:ListItem>2018</asp:ListItem>
            <asp:ListItem>2019</asp:ListItem>
            <asp:ListItem>2020</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlMes" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>Janeiro</asp:ListItem>
            <asp:ListItem>Fevereiro</asp:ListItem>
            <asp:ListItem>Marco</asp:ListItem>
            <asp:ListItem>Abril</asp:ListItem>
            <asp:ListItem>Maio</asp:ListItem>
            <asp:ListItem>Junho</asp:ListItem>
            <asp:ListItem>Julho</asp:ListItem>
            <asp:ListItem>Agosto</asp:ListItem>
            <asp:ListItem>Setembro</asp:ListItem>
            <asp:ListItem>Outubro</asp:ListItem>
            <asp:ListItem>Novembro</asp:ListItem>
            <asp:ListItem>Dezembro</asp:ListItem>
        </asp:DropDownList><br />
        <asp:Button ID="btnDias" class="botoes" runat="server" Text="Buscar" OnClick="btnDias_Click" />
        <div id="DiasMovimento" runat="server"></div>
    </div>
</asp:Content>
