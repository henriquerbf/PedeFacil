<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comandas_Cozinha.aspx.cs" Inherits="PedeFacilWebApp.WebPages.WebPage.Empresa.Comandas_Cozinha" %>

<!DOCTYPE html>
<link href="../StyleSheets/MasterPage/MasterEmp.css" rel="stylesheet" />
<link href="../StyleSheets/WebPage/Empresa/Cardapio_Emp.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Comandas</title>
    <script type="text/javascript"></script>
    <script>
        function Cancelar_Item(a, b) {
            PageMethods.Cancelar(a, b, Refresh);
        }

        function Status_Comanda(a, b) {
            PageMethods.Status(a, b, Refresh);
        }

        function Refresh() {
            window.location.reload();
        }
    </script>

    <style>
        html, body {
            height: 100%;
            margin: 0px;
            padding: 0px;
            overflow: hidden;
            position: static;
            overflow-x: hidden;
            background: rgb(237, 226, 214);
        }

        #lblSAC {
            background: #540000;
            color: white;
            font-family: Helvetica;
            height: 47px;
            font-size: 21px;
            text-align: left;
            text-indent: 2em;
            width: 622px;
            padding-left: 30px;
            overflow-wrap: break-word;
            padding-top: 30px;
            text-shadow: black 3px 4px 9px;
            margin: auto;
            margin-top: -40px;
            padding-bottom: 14px;
            padding-right: 18px;
            border-radius: 11px;
        }

        #com {
            display: block;
            margin: auto;
            width: 694px;
            text-align: center;
            padding-right: 120px;
            overflow-y: auto;
            overflow-x: hidden;
            margin-top: 5px;
            height: calc( 100% - 200px );
        }

        .botoes {
            font-size: 19px;
            font-family: Helvetica;
            background: #540000;
            color: white;
            width: 176px;
            border-radius: 23px;
            height: 34px;
            margin-left: 0;
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <br />

        <div id="lblSAC">Gerencie os pedidos de seus clientes, juntamente a cozinha para melhor atendê-los e deixa-los sabendo sobre seus pedidos.</div>
        <br />
        <br />
        <div id="com">
            <div id="ListaComanda" runat="server"></div>
            <asp:Button ID="btnRefresh" class="botoes" runat="server" Text="Atualizar pedidos" OnClientClick="Refresh()" /><br />
            <asp:Button ID="btnSair" class="botoes" runat="server" Text="Sair" OnClick="btnSair_Click" />
        </div>
    </form>

</body>
</html>

