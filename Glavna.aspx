<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Glavna.aspx.cs" Inherits="ProbaSifarnika.Glavna" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
            <asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" StaticSubMenuIndent="10px" OnMenuItemClick="Menu1_MenuItemClick">
                <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicMenuStyle BackColor="#FFFBD6" />
                <DynamicSelectedStyle BackColor="#FFCC66" />
                <Items>
                    <asp:MenuItem Text="Sifarnici" Value="Unos">
                        <asp:MenuItem Text="Adresa" Value="Adresa_U"></asp:MenuItem>
                        <asp:MenuItem Text="Koverat" Value="Koverat_U"></asp:MenuItem>
                        <asp:MenuItem Text="Vlasnik" Value="Vlasnik_U"></asp:MenuItem>
                        <asp:MenuItem Text="Svrha" Value="Svrha_U"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Stampa" Value="Stampa">
                        <asp:MenuItem Text="Pregled troskova" Value="PT"></asp:MenuItem>
                        <asp:MenuItem Text="Vlasnik" Value="Vlasnik_P"></asp:MenuItem>
                        <asp:MenuItem Text="Koverat" Value="Koverat_P"></asp:MenuItem>
                        <asp:MenuItem Text="Svrha" Value="Svrha_P"></asp:MenuItem>
                        <asp:MenuItem Text="Korisnik" Value="Korisnik_P"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Script" Value="Script">
                        <asp:MenuItem Text="Koverat" Value="Koverat_S"></asp:MenuItem>
                        <asp:MenuItem Text="Vlasnik" Value="Vlasnik_S"></asp:MenuItem>
                    </asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="#990000" ForeColor="White" />
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticSelectedStyle BackColor="#FFCC66" />
            </asp:Menu>
    </form>
</body>
</html>
