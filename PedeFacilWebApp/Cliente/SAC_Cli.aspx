<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/MasterPage/Cliente/Master_Cli.Master" AutoEventWireup="true" CodeBehind="SAC_Cli.aspx.cs" Inherits="PedeFacilWebApp.WebPages.WebPage.Cliente.SAC_Cli" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterHeader" runat="server">
    <link href="../StyleSheets/MasterPage/MasterCli.css" rel="stylesheet" />
    <link href="../StyleSheets/WebPage/Cliente/SAC_cli.css" rel="stylesheet" />
	<script type="text/javascript"></script>
	<script>				
		function Enviar() {
			var a = document.getElementById("MasterBody_ddlSAC").value;
			var b = document.getElementById("MasterBody_txtSAC").value;
			PageMethods.Enviar(a, b, Alerta);
		}

		function Alerta(msg) {
			alert(msg);
			window.location = "Home_Cli.aspx";
		}
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterBody" runat="server">
	<asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"></asp:ScriptManager>
	<div id="Bolinha">
		<div id="PagNome">
			<img class="icoPag" src="../../../StyleSheets/Images/sac.png" />SAC
		</div>
		<img src="../../../StyleSheets/Images/menu.png" id="btnMenu" onclick="Abre()" />
	</div>
	<div id="Conteudo" runat="server">
		<div id="lblSAC">Através deste serviço você poderá tirar qualquer duvida ou algum possivel problema encontrado durante o uso da aplicação.</div>
		<br />
		<br />
		<asp:Label ID="lblAssunto" runat="server" Text="Assunto: "></asp:Label>
		<br />
		<asp:DropDownList ID="ddlSAC" runat="server">
			<asp:ListItem></asp:ListItem>
			<asp:ListItem Value="1" Text="Problemas">Problemas</asp:ListItem>
			<asp:ListItem Value="2" Text="Sugestões">Sugestões</asp:ListItem>
			<asp:ListItem Value="3" Text="Contato">Contato</asp:ListItem>
		</asp:DropDownList><br />
		<br />
		<asp:Label ID="lblMensagem" runat="server" Text="Mensagem:"></asp:Label><br />
		<asp:TextBox ID="txtSAC" TextMode="MultiLine" Columns="50" Rows="10" runat="server"></asp:TextBox>
		<div id="Enviar" onclick="Enviar()">Enviar</div>
	</div>
	<div id="power">Powered by PedeFacil.©</div>
</asp:Content>
