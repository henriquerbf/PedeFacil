<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PedeFacilWebApp.WebPages.WebPage.Geral.Login" %>
<meta
	name='viewport'
	content='user-scalable=0' />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
    <link href="StyleSheets/WebPage/Login.css" rel="stylesheet" />
	<script>        
		function Entrar() {
			var a = document.getElementById("txtUsuario").value;
			var b = document.getElementById("txtSenha").value;
			var c = document.getElementById("ddlEstabelecimento").value;
			var w = screen.width;
			var h = screen.height;
			PageMethods.btnLogin_Click(a, b, c, w, h, Redireciona);
		}

		function Redireciona(tipo) {
			if (tipo == "cliente") {
				window.location = "../Cliente/Home_Cli.aspx";
			} else if (tipo == "empresa") {
				window.location = "../Empresa/Home_Emp.aspx";
			} else if (tipo == "cozinha") {
				window.location = "../Empresa/Comandas_Cozinha.aspx";
			} else {
				Alerta(tipo);
			}
		}

		function EsqueciSenha() {
			window.location = "Esqueci_Senha.aspx";
		}

		function Alerta(msg) {
			alert(msg);
		}
	</script>
</head>
<body>
	<form id="Form1" runat="server">
		<asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"></asp:ScriptManager>
		<div id="Nos">PedeFácil</div>
		<div id="Textim">Aqui, seu pedido é uma ordem.</div>

		<div id="Formulario">

			<asp:Label ID="Label1" runat="server" Text="Estabelecimento"></asp:Label>
			<asp:DropDownList ID="ddlEstabelecimento" runat="server"></asp:DropDownList><br />
			<br />

			<asp:Label ID="Label2" runat="server" Text="Usuario"></asp:Label>
			<asp:TextBox ID="txtUsuario" placeholder="usuario" runat="server"></asp:TextBox><br />
			<br />

			<asp:Label ID="Label3" runat="server" Text="Senha"></asp:Label>
			<asp:TextBox ID="txtSenha" placeholder="senha" TextMode="Password" runat="server"></asp:TextBox><br />

		</div>

		<div id="Entrar" onclick="Entrar()">Entrar</div>
		<div id="Esquecisenha" onclick="EsqueciSenha()">Esqueci a Senha</div>
	</form>
</body>
</html>
