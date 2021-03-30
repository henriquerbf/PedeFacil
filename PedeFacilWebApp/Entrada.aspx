<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Entrada.aspx.cs" Inherits="PedeFacilWebApp.WebPages.WebPage.Geral.Entrada" %>
<meta
	name='viewport'
	content='user-scalable=0' />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
    <link href="StyleSheets/WebPage/Entrada.css" rel="stylesheet" />
	<script>
		function Entrar() {
			window.location = "Login.aspx";
		}

		function Cadastrar() {
			window.location = "Cadastrar_Usuario.aspx";
		}
	</script>

</head>
<body>
	<div id="Nos">PedeFácil</div>
	<div id="Textim">Aqui, seu pedido é uma ordem.</div>

	<div id="Formulario"></div>

	<div id="Entrar" onclick="Entrar()">Entrar</div>
	<div id="Cadastrar" onclick="Cadastrar()">Cadastre-se!</div>
</body>
</html>
