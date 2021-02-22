<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadUsuario.aspx.cs" Inherits="DEV0102.cadUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cadastro de Usuários</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <h1>Cadastro de Usuário</h1>
            <label>Nome:</label><br />
            <asp:TextBox ID="txtNome" runat="server"></asp:TextBox><br />
            <label>CEP:</label><br />
            <asp:TextBox ID="txtCEP" runat="server"></asp:TextBox> 
            <asp:Button ID="btnConsultaCEP" runat="server" Text="Consultar CEP" OnClick="btnConsultaCEP_Click" />
            <br />
            <label>Endereço:</label><br />
            <asp:TextBox ID="txtEndereco" runat="server"></asp:TextBox><br />
            <label>Bairro:</label><br />
            <asp:TextBox id="txtBairro" runat="server"></asp:TextBox><br />
            <label>Cidade:</label><br />
            <asp:TextBox ID="txtCidade" runat="server"></asp:TextBox><br />
            <label>UF:</label><br />
            <asp:TextBox ID="txtUF" runat="server"></asp:TextBox><br />
            <label>Email:</label><br />
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
            <label>Senha:</label><br />
            <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:FileUpload ID="fupFoto" runat="server" /><br />
            <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />
            <br />
            <h4>Usuários Cadastrados</h4>
            <asp:GridView ID="gridUsuario" OnRowCommand="gridUsuario_RowCommand" runat="server" AutoGenerateColumns="False" DataKeyNames="codigo" DataSourceID="SqlDataSourceUsuario" AllowPaging="True" AllowSorting="True">
                <Columns>
                    <asp:ImageField DataImageUrlField="caminhoFoto" ControlStyle-Height="50px" HeaderText="Foto"></asp:ImageField>
                    <asp:BoundField DataField="codigo" Visible="false" HeaderText="codigo" ReadOnly="True" InsertVisible="False" SortExpression="codigo"></asp:BoundField>
                    <asp:BoundField DataField="nome" HeaderText="Nome" SortExpression="nome"></asp:BoundField>
                    <asp:BoundField DataField="cep" HeaderText="CEP" SortExpression="cep"></asp:BoundField>
                    <asp:BoundField DataField="endereco" HeaderText="Endereço" SortExpression="endereco"></asp:BoundField>
                    <asp:BoundField DataField="bairro" HeaderText="Bairro" SortExpression="bairro"></asp:BoundField>
                    <asp:BoundField DataField="cidade" HeaderText="Cidade" SortExpression="cidade"></asp:BoundField>
                    <asp:BoundField DataField="uf" HeaderText="UF" SortExpression="uf"></asp:BoundField>
                    <asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="email"></asp:BoundField>
                    <asp:BoundField DataField="senha" Visible="false" HeaderText="senha" SortExpression="senha"></asp:BoundField>
                    <asp:BoundField DataField="nomeFoto" Visible="false" HeaderText="nomeFoto" SortExpression="nomeFoto"></asp:BoundField>
                    <asp:ButtonField ButtonType="Button" CommandName="Deletar" Text="Excluir" />
                    <asp:ButtonField ButtonType="Button" CommandName="Editar" Text="Editar" />
                </Columns>
            </asp:GridView>

            <asp:HiddenField ID="hiddenfildCodigo" runat="server" Value="0" />

            <asp:SqlDataSource runat="server" ID="SqlDataSourceUsuario" ConnectionString='<%$ ConnectionStrings:DEV0102ConnectionString %>' SelectCommand="select '~/fotoUsuario/' + nomeFoto as caminhoFoto, * from tabusuario"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
