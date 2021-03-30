<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/MasterPage/Cliente/Master_Cli.Master" AutoEventWireup="true" CodeBehind="Comanda_Cli.aspx.cs" Inherits="PedeFacilWebApp.WebPages.WebPage.Cliente.Comanda_Cli" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterHeader" runat="server">
    <link href="../StyleSheets/MasterPage/MasterCli.css" rel="stylesheet" />
    <link href="../StyleSheets/WebPage/Cliente/Comanda_Cli.css" rel="stylesheet" />
	<<script type="text/javascript"></script>
	<script>
		function process(quant, i, item) {
			var value = parseInt(document.getElementById("quant" + i).value);
			value += quant;
			if (value < 1) {
				Remover_Item(item)
			} else {
				document.getElementById("quant" + i).value = value;
			}
		}

		function Alterar_Item(a, i) {
			var b = document.getElementById("quant" + i).value;
			PageMethods.Alterar(a, b, Refresh);
		}

		function Remover_Item(a) {
			PageMethods.Deletar(a, Refresh);
		}

		function Fazer_Pedido(a, b) {
			var obs = prompt("Alguma observação?");
			if (obs != null)
				PageMethods.Pedir(a, b, obs, Refresh);
		}

		function Fechar_Comanda(a) {
			alert("Apresente na saida o nome da sua comanda: " + a);
		}

		function Refresh() {
			window.location.reload();
		}
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterBody" runat="server">
	<asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"></asp:ScriptManager>

	<div id="Bolinha">
		<div id="PagNome">
			<img class="icoPag" src="../../../StyleSheets/Images/copy.png" />Comanda</div>
		<img src="../../../StyleSheets/Images/menu.png" id="btnMenu" onclick="Abre()" />
	</div>
	<div id="Conteudo" runat="server"></div>
	<div id="power">Powered by PedeFacil.©</div>
</asp:Content>
