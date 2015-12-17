<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Order" %>

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
            <label>Please select a product:</label>
            <asp:DropDownList ID="ddlProducts" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ProductID" AutoPostBack="True"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [ProductID], [Name], [LongDescription], [ShortDescription], [ImageFile], [UnitPrice] FROM [Products] ORDER BY [Name]"></asp:SqlDataSource>
            <div id="productData">
                <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="lblShortDescription" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="lblLongDescription" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="lblUnitPrice" runat="server" Text=""></asp:Label>
                <br />
                <label id="lblQuantity">Quantity: </label>
                <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Quantity is a required field" ControlToValidate="txtQuantity" CssClass="validator" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Quantity must range from 1-500" ControlToValidate="txtQuantity" CssClass="validator" Display="Dynamic" ForeColor="Red" MaximumValue="500" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                <asp:Button ID="btnAdd" runat="server" Text="Add to Cart" OnClick="btnAdd_Click" />
                <asp:Button ID="btnCart" runat="server" Text="Go to Cart" PostBackUrl="~/Cart.aspx" CausesValidation="False" />
            </div>

            <asp:Image ID="imgProduct" runat="server" />
        </form>
        
    </section>
    
</body>
</html>
