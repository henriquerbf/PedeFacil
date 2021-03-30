<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/MasterPage/Cliente/Master_Cli.Master" AutoEventWireup="true" CodeBehind="Cardapio_Cli.aspx.cs" Inherits="PedeFacilWebApp.WebPages.WebPage.Cliente.Cardapio_Cli" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterHeader" runat="server">
    <link href="../StyleSheets/MasterPage/MasterCli.css" rel="stylesheet" />
    <link href="../StyleSheets/WebPage/Cliente/Cardapio_Cli.css" rel="stylesheet" />
	<script type="text/javascript"></script>
	<script>
		function Adicionar_Comanda(a, b, i, d) {
			var c = document.getElementById("quant" + i).value;
			PageMethods.Adicionar(a, b, c, d, alerta);
		}

		function alerta(msg) {
			alert(msg);
		}

		function descricao(descricao) {
			alert(descricao);
		}

		function process(quant, i) {
			var value = parseInt(document.getElementById("quant" + i).value);
			value += quant;
			if (value < 1) {
				document.getElementById("quant" + i).value = 1;
			} else {
				document.getElementById("quant" + i).value = value;
			}
		}

		function MostraDetalhe(nome, detalhe) {
			document.getElementById("DetalhesTudo").style.visibility = "visible";
			document.getElementById("NomeProduto").innerHTML = nome;
			document.getElementById("TextoDetalhe").innerHTML = detalhe;
		}

		function EscondeDetalhe() {
			document.getElementById('DetalhesTudo').style.visibility = "hidden";
		}

	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterBody" runat="server">
	<div id="DetalhesTudo">
		<div id="Detalhe">
			<div id="NomeProduto" class="TipoDet"></div>
			<div id="TextoDetalhe"></div>
		</div>
		<div id="FechaDesc" onclick="EscondeDetalhe()" style="height: 100%; width: 100%; position: absolute; top: 0;"></div>
	</div>
	<asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"></asp:ScriptManager>
	<br />
	<div id="Bolinha">
		<div id="PagNome">
			<img class="icoPag" src="../../../StyleSheets/Images/book.png" />Cardapio
		</div>
		<img src="../../../StyleSheets/Images/menu.png" id="btnMenu" onclick="Abre()" />
	</div>

	<div id="Conteudo" runat="server">

	</div>
	<div id="power">Powered by PedeFacil.©</div>
</asp:Content>
