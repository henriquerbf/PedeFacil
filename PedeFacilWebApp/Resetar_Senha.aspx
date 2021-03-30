<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resetar_Senha.aspx.cs" Inherits="PedeFacilWebApp.WebPages.WebPage.Geral.Resetar_Senha" %>

<meta
    name='viewport'
    content='user-scalable=0' />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheets/WebPage/EsqueciSenha.css" rel="stylesheet" />
    <script>        
        function Alterar() {
            var a = document.getElementById("txtNovaSenha").value;
            PageMethods.btnConfirmar_Click(a, Redireciona);
        }

        function Redireciona(tipo) {
            if (tipo == "erro") {
                Alerta("Erro ao alterar senha");
            } else {
                Alerta(tipo);
                window.location = "Login.aspx";
            }
        }
        function Voltar() {
            window.location = "Entrada.aspx";
        }
        function Alerta(msg) {
            alert(msg);
        }
    </script>
</head>
<body>
    <div>
        <form id="FormRecuperarSenha" runat="server">
            <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"></asp:ScriptManager>
            <div id="Nos">PedeFácil</div>
            <div id="Textim">Aqui, seu pedido é uma ordem.</div>

            <div id="Formulario">

                <br />
                <asp:Label ID="lblNovaSenha" runat="server" Text="Nova senha"></asp:Label><br /><br />
                <asp:TextBox ID="txtNovaSenha" placeholder="novasenha" TextMode="Password" runat="server"></asp:TextBox>
                <br />
                <br />
            </div>
            <div id="Cadastrar"  onclick="Alterar()">Alterar</div>
		<div id="Voltar" onclick="Voltar()">Voltar</div>
        </form>
    </div>
</body>
</html>
