<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="_01.RegistrationFormaValidation.RegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="RegistrationForm" runat="server">
        <table>
            <tr>
                <td>Username:</td>
                <td>
                    <asp:TextBox runat="server" ID="Username" ValidationGroup="required" /></td>
            </tr>
            <tr>
                <td>Password:</td>
                <td>
                    <asp:TextBox runat="server" ID="Pass" ValidationGroup="required" TextMode="Password" /></td>
            </tr>
            <tr>
                <td>Repeat Password:</td>
                <td>
                    <asp:TextBox runat="server" ID="PassRepeat" ValidationGroup="required" TextMode="Password" /></td>
            </tr>
            <tr>
                <td>First Name:</td>
                <td>
                    <asp:TextBox runat="server" ID="FirstName" ValidationGroup="required" /></td>
            </tr>
            <tr>
                <td>Last Name:</td>
                <td>
                    <asp:TextBox runat="server" ID="LastName" ValidationGroup="required" /></td>
            </tr>
            <tr>
                <td>Age:</td>
                <td>
                    <asp:TextBox runat="server" ID="Age" ValidationGroup="required" /></td>
            </tr>
            <tr>
                <td>Email:</td>
                <td>
                    <asp:TextBox runat="server" ID="Email" ValidationGroup="required" /></td>
            </tr>
            <tr>
                <td>Local Address:</td>
                <td>
                    <asp:TextBox runat="server" ID="LocalAddress" ValidationGroup="required" /></td>
            </tr>
            <tr>
                <td>Phone:</td>
                <td>
                    <asp:TextBox runat="server" ID="Phone" ValidationGroup="required" /></td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox runat="server" Text="I accept the terms." ID="Accept" ValidationGroup="required" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button Text="Submit" runat="server" OnClick="OnSubmit_Click" />
                </td>
            </tr>
        </table>

        <asp:RegularExpressionValidator
            ID="RegularExpressionValidatorEmail"
            runat="server" ForeColor="Red" Display="None"
            ErrorMessage="Email address is incorrect!"
            ControlToValidate="Email"
            ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}" />

        <asp:RegularExpressionValidator
            ID="RegularExpressionValidatorPhone"
            runat="server" ForeColor="Red" Display="None"
            ErrorMessage="Phone is incorrect!"
            ControlToValidate="Phone"
            ValidationExpression="[0-9]{4}" />

        <asp:CustomValidator runat="server" ID="CheckBoxRequired" EnableClientScript="true"
            OnServerValidate="CheckBoxRequired_ServerValidate"
            ErrorMessage="You must accept the terms before you proceed!" Display="None" />

        <asp:RangeValidator runat="server" ForeColor="Red" Display="None"
            ControlToValidate="Age" Type="Integer"
            MaximumValue="81" MinimumValue="18" ErrorMessage="Age must be betweent 18 and 81!" />

        <asp:CompareValidator ID="CompareValidatorPassword"
            runat="server" ControlToCompare="Pass"
            ControlToValidate="PassRepeat"
            ValueToCompare="Text" ForeColor="Red"
            ErrorMessage="Passwords doesn't match!" Display="None" />

        <asp:RequiredFieldValidator runat="server" ControlToValidate="Username"
            ErrorMessage="Username cannot be empty!<br />" ForeColor="Red" Display="None" />

        <asp:RequiredFieldValidator runat="server" ControlToValidate="Pass"
            ErrorMessage="Password cannot be empty!<br />" ForeColor="Red" Display="None" />

        <asp:RequiredFieldValidator runat="server" ControlToValidate="PassRepeat"
            ErrorMessage="Repeat Password cannot be empty!<br />" ForeColor="Red" Display="None" />

        <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
            ErrorMessage="First Name cannot be empty!<br />" ForeColor="Red" Display="None" />

        <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName"
            ErrorMessage="Last Name cannot be empty!<br />" ForeColor="Red" Display="None" />

        <asp:RequiredFieldValidator runat="server" ControlToValidate="Age"
            ErrorMessage="Age cannot be empty!<br />" ForeColor="Red" Display="None" />

        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
            ErrorMessage="Email cannot be empty!<br />" ForeColor="Red" Display="None" />

        <asp:RequiredFieldValidator runat="server" ControlToValidate="LocalAddress"
            ErrorMessage="Local Address cannot be empty!<br />" ForeColor="Red" Display="None" />

        <asp:RequiredFieldValidator runat="server" ControlToValidate="Phone"
            ErrorMessage="Phone cannot be empty!<br />" ForeColor="Red" Display="None" />

        <asp:ValidationSummary runat="server" HeaderText="Some errors occured!"
            DisplayMode="BulletList" EnableClientScript="true" ForeColor="Red" />
    </form>
</body>
</html>
