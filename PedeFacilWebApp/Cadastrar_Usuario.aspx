<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastrar_Usuario.aspx.cs" Inherits="PedeFacilWebApp.WebPages.WebPage.Geral.Cadastrar_Usuario" %>
<meta
	name='viewport'
	content='user-scalable=0' />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
    <link href="StyleSheets/WebPage/CadastrarUsuario.css" rel="stylesheet" />
	<script>
		function Voltar() {
			window.location = "Entrada.aspx";
		}

		function Cadastrar() {
			var a = document.getElementById("txtUsuario").value;
			var b = document.getElementById("txtSenha").value;
			var c = document.getElementById("txtNome").value;
			var d = document.getElementById("txtRazao").value;
			var e = document.getElementById("txtCNPJCPF").value;
			var f = document.getElementById("txtEmail").value;
			var a = PageMethods.btnCadastrar_Click(a, b, c, d, e, f, Alerta);
		}

		function Alerta(msg) {
			alert(msg);
			if (msg == "Seu cadastro foi realizado. Você sera redirecionado para a tela de Login.")
				window.location = "Login.aspx";
			else if (msg == "Seu cadastro foi realizado, verifique seu email. Você sera redirecionado para a tela de Login.")
				window.localStorage = "Login.aspx";
		}
	</script>
</head>
<body>
	<div id="Nos">PedeFácil</div>
	<div id="Textim">Aqui, seu pedido é uma ordem.</div>

	<div id="Formulario">
		<form id="form1" runat="server">
			<asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"></asp:ScriptManager>
			<br />
			<asp:Label ID="lblCNPJCPF" runat="server" Text="CNPJ/CPF: "></asp:Label><br />
			<asp:TextBox ID="txtCNPJCPF" runat="server" MaxLength="14" placeholder="cnpj/cpf" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCNPJCPF_TextChanged"></asp:TextBox><br />

			<br />
			<asp:Label ID="lblUsuario" runat="server" Text="Usuario: "></asp:Label><br />
			<asp:TextBox ID="txtUsuario" runat="server" placeholder="usuario"></asp:TextBox><br />

			<br />
			<asp:Label ID="lblSenha" runat="server" Text="Senha: "></asp:Label><br />
			<asp:TextBox ID="txtSenha" runat="server" TextMode="Password" placeholder="senha" MaxLength="20"></asp:TextBox><br />

			<br />
			<asp:Label ID="lblNome" runat="server" Text="Nome: "></asp:Label><br />
			<asp:TextBox ID="txtNome" runat="server" placeholder="nome"></asp:TextBox><br />

			<br />
			<asp:Label ID="lblRazao" runat="server" Text="Razao Social: "></asp:Label><br />
			<asp:TextBox ID="txtRazao" runat="server" placeholder="razao social" Enabled="false"></asp:TextBox><br />			

			<br />
			<asp:Label ID="lblEmail" runat="server" Text="E-mail: "></asp:Label><br />
			<asp:TextBox ID="txtEmail" runat="server" placeholder="e-mail"></asp:TextBox><br />
		</form>
	</div>

	<div id="Cadastrar" onclick="Cadastrar()">Cadastrar</div>
	<div id="Voltar" onclick="Voltar()">Voltar</div>
</body>
</html>
