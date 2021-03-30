<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/MasterPage/Empresa/Master_Emp.Master" AutoEventWireup="true" CodeBehind="Historico_Emp.aspx.cs" Inherits="PedeFacilWebApp.WebPages.WebPage.Empresa.Historico_Emp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterHeader" runat="server">
	<link href="../StyleSheets/MasterPage/MasterEmp.css" rel="stylesheet" />
	<link href="../StyleSheets/WebPage/Empresa/Historico_Emp.css" rel="stylesheet" />
	<script type="text/javascript"></script>
	<script>
		function Detalhes_Comanda(a) {
			PageMethods.Detalhes(a, Redirecionar);
		}

		function Redirecionar(msg) {
			if (msg == "")
				window.location = "DetalhesHistorico_Emp.aspx";
			else
				alert(msg);
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
	<div id="lblcom">Gerencie todo o histórico de comandas de seu estabelecimento!</div>
	<br />
	<br />
	<div id="com">
		<div id="ListaHistorico" runat="server"></div>
	</div>
</asp:Content>
