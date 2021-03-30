<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/MasterPage/Cliente/Master_Cli.Master" AutoEventWireup="true" CodeBehind="Historico_Cli.aspx.cs" Inherits="PedeFacilWebApp.WebPages.WebPage.Cliente.Historico_Cli" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterHeader" runat="server">
	<link href="../../../StyleSheets/MasterPage/MasterCli.css" rel="stylesheet" />
	<link href="../../../StyleSheets/WebPage/Cliente/Historico_Cli.css" rel="stylesheet" />
	<link href="../StyleSheets/MasterPage/MasterCli.css" rel="stylesheet" />
	<link href="../StyleSheets/WebPage/Cliente/Historico_Cli.css" rel="stylesheet" />
	<script type="text/javascript"></script>
	<script>
		function Detalhes_Comanda(a, b) {
			PageMethods.Detalhes(a, b, Redirecionar);
		}

		function Redirecionar(msg) {
			if (msg == "Comanda vazia")
				alert(msg);
			else
				window.location = "DetalhesHistorico_Cli.aspx";
		}
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterBody" runat="server">
	<asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"></asp:ScriptManager>
	<div id="Bolinha">
		<div id="PagNome">
			<img class="icoPag" src="../../../StyleSheets/Images/history.png" />Historico
		</div>
		<img src="../../../StyleSheets/Images/menu.png" id="btnMenu" onclick="Abre()" />
	</div>
	<div id="Conteudo" runat="server"></div>
	<div id="power">Powered by PedeFacil.©</div>
</asp:Content>
