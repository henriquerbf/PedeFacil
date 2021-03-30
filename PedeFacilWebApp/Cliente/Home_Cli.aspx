<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/MasterPage/Cliente/Master_Cli.Master" AutoEventWireup="true" CodeBehind="Home_Cli.aspx.cs" Inherits="PedeFacilWebApp.WebPages.WebPage.Cliente.Home_Cli" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterHeader" runat="server">
	<link href="../../../StyleSheets/MasterPage/MasterCli.css" rel="stylesheet" />
	<link href="../../../StyleSheets/WebPage/Cliente/Home_Cli.css" rel="stylesheet" />
    <link href="../StyleSheets/MasterPage/MasterCli.css" rel="stylesheet" />
    <link href="../StyleSheets/WebPage/Cliente/Home_Cli.css" rel="stylesheet" />
	<script type="text/javascript"></script>
	<script>
		function Criar_Comanda(a, b) {
			var mesa = prompt("Digite o nome da mesa");
			if (mesa != null) {
				PageMethods.Escolher(a, b, mesa, Refresh);
			}
		}

		function Refresh(msg) {
			if (msg == "Comanda criada")
				window.location.reload();
			else
				alert(msg);
		}

	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterBody" runat="server">
	<asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"></asp:ScriptManager>
	<div id="Bolinha">
		<div id="PagNome">
			<img class="icoPag" src="../../../StyleSheets/Images/history.png" />Home
		</div>
		<img src="../../../StyleSheets/Images/menu.png" id="btnMenu" onclick="Abre()" />
	</div>
	<br />


	<div id="Conteudo" runat="server">
		<div id="Tipo">
			Seja bem-vindo!<br />
			<div id="acesso" runat="server"></div>
		</div>
		<div id="SelecionarMesa" runat="server"></div>

		<br />
		<div id="ListaDestaque" runat="server"></div>

		<br />
		<div id="ListaPromocao" runat="server"></div>
	</div>
	<div id="power">Powered by PedeFacil.©</div>
</asp:Content>
