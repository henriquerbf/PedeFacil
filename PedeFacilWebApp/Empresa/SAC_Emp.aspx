<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/MasterPage/Empresa/Master_Emp.Master" AutoEventWireup="true" CodeBehind="SAC_Emp.aspx.cs" Inherits="PedeFacilWebApp.WebPages.WebPage.Empresa.SAC_Emp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterHeader" runat="server">
    <link href="../StyleSheets/MasterPage/MasterEmp.css" rel="stylesheet" />
    <link href="../StyleSheets/WebPage/Empresa/SAC_emp.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterBody" runat="server">
    <div id="Bolinha">
        <div id="PagNome"><img class="icoPag" src="../../../StyleSheets/Images/sac.png" />SAC</div>
        <img src="../../../StyleSheets/Images/menu.png" id="btnMenu" onclick="Abre()" />
    </div>
	<div id="lblSAC">Através deste serviço você poderá tirar qualquer duvida ou algum possível problema encontrado durante o uso da aplicação.</div><br />
	<br />
	<div id="lblAssunto">Assunto:</div>
	<br />
	<asp:DropDownList ID="ddlSAC" runat="server">
		<asp:ListItem></asp:ListItem>
		<asp:ListItem>Problemas</asp:ListItem>
		<asp:ListItem>Sugestões</asp:ListItem>
		<asp:ListItem>Contato</asp:ListItem>
	</asp:DropDownList><br /><br />
	<div ID="lblMensagem">Mensagem:</div><br />
	<asp:TextBox ID="txtSAC"  TextMode="MultiLine"  Columns="50" Rows="10" runat="server"></asp:TextBox>
	<br /><br />
    <div id="botoes">
	<asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click"/>
	<asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click"/></div>
</asp:Content>