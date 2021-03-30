<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/MasterPage/Empresa/Master_Emp.Master" AutoEventWireup="true" CodeBehind="Cadastrar_Item.aspx.cs" Inherits="PedeFacilWebApp.WebPages.WebPage.Empresa.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterHeader" runat="server">
    <link href="../StyleSheets/MasterPage/MasterEmp.css" rel="stylesheet" />
    <link href="../StyleSheets/WebPage/Empresa/Cadastra_Item.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterBody" runat="server">
    <div id="Bolinha">
        <div id="PagNome">
            <img class="icoPag" src="../../../StyleSheets/Images/book.png" />Cadastrar Item</div>
        <img src="../../../StyleSheets/Images/menu.png" id="btnMenu" onclick="Abre()" />
    </div>
    <div id="lblSAC">Aqui você pode adicionar e alterar os itens disponíveis em seu estabelecimento.</div>
    <br />
    <br />
    <br />
    <div id="com">
        <asp:Label ID="lblTipo" class="label" runat="server" Text="Tipo:"></asp:Label><br />
        <asp:DropDownList ID="ddlTipo" class="input" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>Comida</asp:ListItem>
            <asp:ListItem>Bebida</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblNome" class="label" runat="server" Text="Nome:"></asp:Label><br />
        <asp:TextBox ID="txtNome" class="input" runat="server" MaxLength="20" Enabled="false"></asp:TextBox>
        <br />
        <asp:Label ID="lblDescricao" class="label" runat="server" Text="Descricao:"></asp:Label><br />
        <asp:TextBox ID="txtDescricao" class="input" runat="server" Enabled="false"></asp:TextBox>
        <br />
        <asp:Label ID="lblValor" class="label" runat="server" Text="Valor:"></asp:Label><br />
        <asp:TextBox ID="txtValor" class="input" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblDesconto" class="label" runat="server" Text="Desconto:"></asp:Label><br />
        <asp:TextBox ID="txtDesconto" class="input" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblDestaque" class="label" runat="server" Text="Destaque:"></asp:Label><br />
        <asp:CheckBox ID="chbDestaque" class="input" Checked="false" runat="server" />
        <br />
        <asp:Label ID="lblAtivo" class="label" runat="server" Text="Ativo:"></asp:Label><br />
        <asp:CheckBox ID="chbAtivo" class="input" Checked="false" runat="server" />
        <br />
        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
        <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />
    </div>
</asp:Content>
