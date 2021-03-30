<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/MasterPage/Empresa/Master_Emp.Master" AutoEventWireup="true" CodeBehind="Comandas_Emp.aspx.cs" Inherits="PedeFacilWebApp.WebPages.WebPage.Empresa.Comandas_Emp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterHeader" runat="server">
	<link href="../StyleSheets/MasterPage/MasterEmp.css" rel="stylesheet" />
	<link href="../StyleSheets/WebPage/Empresa/Comanda_Emp.css" rel="stylesheet" />
	<script type="text/javascript"></script>
	<script>
		function Detalhes_Comanda(a) {
			PageMethods.Detalhes(a, Redirecionar);
		}

		function Fechar_Comanda(a, b) {
			PageMethods.Fechar(a, b, alerta);
		}

		function alerta(msg) {
			alert(msg);
			Refresh();
		}

		function Redirecionar(msg) {
			if (msg == "")
				window.location = "DetalhesHistorico_Emp.aspx";
			else
				alerta(msg);
		}

		function Refresh() {
			window.location.reload;
		}

	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterBody" runat="server">
	<asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"></asp:ScriptManager>
	<div id="Bolinha">
		<div id="PagNome">
			<img class="icoPag" src="../../../StyleSheets/Images/copy.png" />Comandas
		</div>
		<img src="../../../StyleSheets/Images/menu.png" id="btnMenu" onclick="Abre()" />
	</div>
	<div id="lblcom">Gerencie as comandas abertas em seu estabelecimento, podendo obter detalhes e fechar as mesmas!</div>
	<br />
	<br />
	<div id="com">
		<div id="ListaComandas" runat="server"></div>
	</div>
</asp:Content>
