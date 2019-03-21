<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="ProbaSifarnika.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Text1 {
            margin-bottom: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" action="upis.aspx">
        <asp:Label ID="Label1" runat="server" Text="Ime"></asp:Label>
        <asp:TextBox ID="ime" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Prezime"></asp:Label>
            <asp:TextBox ID="prezime" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="Label3" runat="server" Text="Datum rodjenja:"></asp:Label>
        <input id="datum" type="date" runat="server" /><br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="e-mail"></asp:Label>
        <asp:TextBox ID="email" runat="server"> </asp:TextBox>
       
 
        <br />
        <asp:Label ID="Label4" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="username" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label5" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        <input id="Submit1" type="submit" value="submit" />&nbsp&nbsp&nbsp<asp:Button ID="Button1" runat="server" Text="Cancel" />
    </form>
</body>
</html>
