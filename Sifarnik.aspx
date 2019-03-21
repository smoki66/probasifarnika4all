<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sifarnik.aspx.cs" Inherits="ProbaSifarnika.Koverat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="Table1" runat="server" Width="473px">
            </asp:Table>
            <asp:Label ID="Label1" runat="server" Text="Unesite naziv "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Dodaj" />
        </div>
    </form>
</body>
</html>
