<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Esqueci_Senha.aspx.cs" Inherits="PedeFacilWebApp.WebPages.WebPage.Geral.Esqueci_Senha" %>
<meta
	name='viewport'
	content='user-scalable=0' />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
    <link href="StyleSheets/WebPage/EsqueciSenha.css" rel="stylesheet" />
	<script>        
		function Recuperar() {
			var a = document.getElementById("txtEmail").value;
			PageMethods.btnEsqueci_Click(a, alerta);
		}
		function alerta(msg) {
			alert(msg);
			if (msg != "Usuário não cadastrado")
				window.location = "Entrada.aspx";
		}

		function Voltar() {
			window.location = "Entrada.aspx";
		}
	</script>
</head>
<body>
	<form id="form1" runat="server">
		<asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"></asp:ScriptManager>
		<div id="Nos">PedeFácil</div>
		<div id="Textim">Aqui, seu pedido é uma ordem.</div>

		<div id="Formulario">

			<br />
			<span>Email</span>
			<asp:TextBox ID="txtEmail" placeholder="e-mail" runat="server"></asp:TextBox><br />

		</div>
		<div id="Cadastrar" onclick="Recuperar()">Recuperar</div>
		<div id="Voltar" onclick="Voltar()">Voltar</div>
	</form>
</body>
</html>
