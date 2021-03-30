<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/MasterPage/Empresa/Master_Emp.Master" AutoEventWireup="true" CodeBehind="Perfil_Emp.aspx.cs" Inherits="PedeFacilWebApp.WebPages.WebPage.Empresa.Perfil_Emp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterHeader" runat="server">

    <link href="../StyleSheets/MasterPage/MasterEmp.css" rel="stylesheet" />
    <link href="../StyleSheets/WebPage/Empresa/Perfil_emp.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterBody" runat="server">
    <div id="Bolinha">
        <div id="PagNome">
            <img class="icoPag" src="../../../StyleSheets/Images/avatar.png" />Perfil
        </div>
        <img src="../../../StyleSheets/Images/menu.png" id="btnMenu" onclick="Abre()" />
    </div>
    <div id="perfil">
        <asp:Label ID="lblNome" runat="server" Text="Nome:"></asp:Label><br />
        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblRazaoSocial" runat="server" Text="Razão Social:"></asp:Label><br />
        <asp:TextBox ID="txtRazaoSocial" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblCNPJ" runat="server" Text="CNPJ:"></asp:Label><br />
        <asp:TextBox ID="txtCNPJ" Enabled="false" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblTelefone" runat="server" Text="Telefone:"></asp:Label><br />
        <asp:TextBox ID="txtTelefone" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblCEP" runat="server" Text="CEP:"></asp:Label><br />
        <asp:TextBox ID="txtCEP" runat="server" AutoPostBack="true" OnTextChanged="txtCEP_TextChanged"></asp:TextBox>
        <br />

        <asp:Label ID="lblLogradouro" runat="server" Text="Logradouro:"></asp:Label><br />
        <asp:TextBox ID="txtLogradouro" Enabled="false" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblNumero" runat="server" Text="Numero:"></asp:Label><br />
        <asp:TextBox ID="txtNumero" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblComplemento" runat="server" Text="Complemento:"></asp:Label><br />
        <asp:TextBox ID="txtComplemento" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblBairro" runat="server" Text="Bairro:"></asp:Label><br />
        <asp:TextBox ID="txtBairro" Enabled="false" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblCidade" runat="server" Text="Cidade:"></asp:Label><br />
        <asp:TextBox ID="txtCidade" Enabled="false" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblEstado" runat="server" Text="Estado:"></asp:Label><br />
        <asp:TextBox ID="txtEstado" Enabled="false" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblPais" runat="server" Text="Pais:"></asp:Label><br />
        <asp:TextBox ID="txtPais" Enabled="false" Text="Brasil" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label><br />
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <div id="botoes">
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
            <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />

        </div>
    </div>
</asp:Content>
