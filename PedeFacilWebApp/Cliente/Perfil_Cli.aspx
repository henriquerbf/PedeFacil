<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/MasterPage/Cliente/Master_Cli.Master" AutoEventWireup="true" CodeBehind="Perfil_Cli.aspx.cs" Inherits="PedeFacilWebApp.WebPages.WebPage.Cliente.Perfil_Cli" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterHeader" runat="server">
    <link href="../StyleSheets/MasterPage/MasterCli.css" rel="stylesheet" />
    <link href="../StyleSheets/WebPage/Cliente/Perfil_Cli.css" rel="stylesheet" />
    <script>        
        function Enviar() {
            var a = document.getElementById("MasterBody_txtNome").value;
			var b = document.getElementById("MasterBody_txtCPF").value;
			var c = document.getElementById("MasterBody_txtTelefone").value;
			var d = document.getElementById("MasterBody_txtEmail").value;
            PageMethods.btnEnviar_Click(a, b, c, d, Alerta);
        }

        function Alerta(msg) {
            alert(msg);
            if (msg == "Dados alterados com sucesso!")
                window.location = "Home_Cli.aspx";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterBody" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <div id="Bolinha">
        <div id="PagNome">
            <img class="icoPag" src="../../../StyleSheets/Images/avatar.png" />Perfil</div>
        <img src="../../../StyleSheets/Images/menu.png" id="btnMenu" onclick="Abre()" />
    </div>
    <br />
    <div id="Conteudo" runat="server">
        <div id="Tipo">Perfil<div id="textinho">Aqui voce podera ALTERAR seus dados.</div></div>
        <asp:Label ID="lblNome" runat="server" Text="Nome:"></asp:Label><br />
        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblCPF" runat="server" Text="CPF:"></asp:Label><br />
        <asp:TextBox ID="txtCPF" Enabled="false" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblTelefone" runat="server" Text="Telefone:"></asp:Label><br />
        <asp:TextBox ID="txtTelefone" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label><br />
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>

        <br />
        <br />
        <div id="Enviar" onclick="Enviar()">Alterar</div>
    </div>
    <div id="power">Powered by PedeFacil.©</div>
</asp:Content>
