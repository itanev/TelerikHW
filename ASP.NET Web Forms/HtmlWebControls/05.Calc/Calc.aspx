<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calc.aspx.cs" Inherits="_05.Calc.Calc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="calc" runat="server" onsubmit="Calculate">
        <asp:Panel runat="server" ID="containerInput">
            <asp:TextBox runat="server" ID="TextBoxInput" />
        </asp:Panel>
        <asp:Panel runat="server" ID="containerButtons">
            <div>
                <asp:Button Text="1" runat="server" ID="Button1"   OnClick="ButtonNumber_Click" />
                <asp:Button Text="2" runat="server" ID="Button2"   OnClick="ButtonNumber_Click" />
                <asp:Button Text="3" runat="server" ID="Button3"   OnClick="ButtonNumber_Click" />
                <asp:Button Text="+" runat="server" ID="ButtonPlus"   OnClick="ButtonPlus_Click" />
            </div>
            <div>
                <asp:Button Text="4" runat="server" ID="Button4"   OnClick="ButtonNumber_Click" />
                <asp:Button Text="5" runat="server" ID="Button5"   OnClick="ButtonNumber_Click" />
                <asp:Button Text="6" runat="server" ID="Button6"   OnClick="ButtonNumber_Click" />
                <asp:Button Text="-" runat="server" ID="ButtonMinus"   OnClick="ButtonMinus_Click" />
            </div>
            <div>
                <asp:Button Text="7" runat="server" ID="Button7"   OnClick="ButtonNumber_Click" />
                <asp:Button Text="8" runat="server" ID="Button8"   OnClick="ButtonNumber_Click" />
                <asp:Button Text="9" runat="server" ID="Button9"   OnClick="ButtonNumber_Click" />
                <asp:Button Text="*" runat="server" ID="ButtonMultiple"   OnClick="ButtonMultiple_Click" />
            </div>
            <div>
                <asp:Button Text="Clear" runat="server" ID="ButtonClear"   OnClick="ButtonClear_Click" />
                <asp:Button Text="0" runat="server" ID="Button0"   OnClick="ButtonNumber_Click" />
                <asp:Button Text="/" runat="server" ID="ButtonDivide"   OnClick="ButtonDivide_Click" />
                <asp:Button Text="" runat="server" ID="ButtonSqrt"   OnClick="ButtonSqrt_Click" />
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="containerResult">
            <asp:Button Width="100px" Text="=" runat="server" ID="ButtonResult" OnClick="ButtonResult_Click" />
        </asp:Panel>
        <asp:Label Text="0" runat="server" ID="LabelCurrentNumber" Visible="false" />
        <asp:Label Text="" runat="server" ID="LabelOperation" Visible="false" />
        <asp:Label Text="false" runat="server" ID="LabelNewNumber" Visible="false" />
        <asp:Label Text="false" runat="server" ID="LabelCalculate" Visible="false" />
    </form>
</body>
</html>
