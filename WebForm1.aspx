<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ProbaSifarnika.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            <input id="Button1" type="button" value="button" />
            <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
        </p>
    </form>
</body>
</html>
