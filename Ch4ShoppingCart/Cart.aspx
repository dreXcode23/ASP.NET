<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <header>
        <img src="Images/banner.jpg" alt="Halloween Store" />
    </header>
    <section>
        <form id="form1" runat="server">
            <asp:ListBox ID="lstCart" runat="server"></asp:ListBox>
            <div id="cartButtons">
                <asp:Button ID="btnRemove" runat="server" Text="Remove Item" CssClass="button" OnClick="btnRemove_Click" />
                <asp:Button ID="btnEmpty" runat="server" Text="Empty Cart" CssClass="button" OnClick="btnEmpty_Click" />
            </div>
            <div id="shopButtons">
                <asp:Button ID="btnContinue" runat="server" PostBackUrl="~/Order.aspx" 
                     Text="Continue Shopping" CssClass="button" OnClick="btnContinue_Click" />
                <asp:Button ID="btnCheckOut" runat="server" Text="Check Out" CssClass="button" OnClick="btnCheckOut_Click" />
            </div>
            <p id="message">
                <asp:Label ID="lblMessage" runat="server" EnableViewState="false"></asp:Label>
            </p>
        </form>
    </section>
</body>
</html>
