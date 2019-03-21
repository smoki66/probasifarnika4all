<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SifarnikU.aspx.cs" Inherits="ProbaSifarnika.SifarnikU" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Table ID="Table1" runat="server" Width="329px" BorderColor="#CC66FF" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
            </asp:Table>
            <asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="&lt;" Width="100px" />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Dodaj" Width="100px" />
            <asp:Button ID="Button2" runat="server" Text="Promeni" Width="100px" OnClick="Button2_Click" />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Brisi" Width="100px" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="&gt;" Width="100px" />
        </div>
    </form>
</body>
</html>
