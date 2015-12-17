<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chapter 2: Future Value</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 282px;
        }
        body {
            font-size: 23px;
        }
    </style>
</head>
<body>
    <img src="Images/MurachLogo.jpg" alt="Murach Logo"/>
    <h1>401K Future Value Calculator</h1>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblMonthlyInvestment" runat="server" Text="Monthly investment" Font-Size="23px"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlMonthlyInvestment" runat="server" Height="22px" Width="147px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblIntRate" runat="server" Text="Annual interest rate" Font-Size="23px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtInterestRate" runat="server" Width="118px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="*" ForeColor="Red" Display="Dynamic" ControlToValidate="txtInterestRate"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtInterestRate"
                         Display="Dynamic" ErrorMessage="Interest rate must range from 1 - 20" ForeColor="Red"
                         MaximumValue="20" MinimumValue="1" Type="Double"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblYears" runat="server" Text="Number of years" Font-Size="23px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtYears" runat="server" Width="118px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtYears" Display="Dynamic" ErrorMessage="*" 
                        ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtYears" 
                        Display="Dynamic" ErrorMessage="Years must range from 1 - 45" ForeColor="Red" 
                        MaximumValue="45" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Future value</td>
                <td>
                    <asp:Label ID="lblFutureValue" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnCalculate" runat="server" Text="Calculate" Width="160px" OnClick="btnCalculate_Click" />
                </td>
                <td>
                    <asp:Button ID="btnClear" runat="server" CausesValidation="False" Text="Clear" Width="165px" OnClick="btnClear_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
