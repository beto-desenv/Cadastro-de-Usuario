<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DEV0102.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Login do Sistema</h3>
            <label>Email</label><br />
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />
            <label>Senha</label><br />
            <asp:TextBox ID="txtSenha" TextMode="Password" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <br />
            <asp:LinkButton ID="btnEsqueciSenha" runat="server" Text="Esqueci a senha" OnClick="btnEsqueciSenha_Click"></asp:LinkButton>

        </div>
    </form>
</body>
</html>
