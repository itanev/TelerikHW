<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="_02.ValidationGroups.RegistrationForm" %>

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
                    <asp:TextBox runat="server" ID="Username" ValidationGroup="LogonInfo" /></td>
            </tr>
            <tr>
                <td>Password:</td>
                <td>
                    <asp:TextBox runat="server" ID="Pass" ValidationGroup="LogonInfo" TextMode="Password" /></td>
            </tr>
            <tr>
                <td>Repeat Password:</td>
                <td>
                    <asp:TextBox runat="server" ID="PassRepeat" ValidationGroup="LogonInfo" TextMode="Password" /></td>
            </tr>
            <tr>
                <td>First Name:</td>
                <td>
                    <asp:TextBox runat="server" ID="FirstName" ValidationGroup="PersonalInfo" /></td>
            </tr>
            <tr>
                <td>Last Name:</td>
                <td>
                    <asp:TextBox runat="server" ID="LastName" ValidationGroup="PersonalInfo" /></td>
            </tr>
            <tr>
                <td>Age:</td>
                <td>
                    <asp:TextBox runat="server" ID="Age" ValidationGroup="PersonalInfo" /></td>
            </tr>
            <tr>
                <td>Email:</td>
                <td>
                    <asp:TextBox runat="server" ID="Email" ValidationGroup="PersonalInfo" /></td>
            </tr>
            <tr>
                <td>Local Address:</td>
                <td>
                    <asp:TextBox runat="server" ID="LocalAddress" ValidationGroup="AddressInfo" /></td>
            </tr>
            <tr>
                <td>Phone:</td>
                <td>
                    <asp:TextBox runat="server" ID="Phone" ValidationGroup="AddressInfo" /></td>
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
            ControlToValidate="Email" ValidationGroup="PersonalInfo"
            ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}" />

        <asp:RegularExpressionValidator
            ID="RegularExpressionValidatorPhone"
            runat="server" ForeColor="Orange" Display="None"
            ErrorMessage="Phone is incorrect!"
            ControlToValidate="Phone" ValidationGroup="AddressInfo"
            ValidationExpression="[0-9]{4}" />

        <asp:CustomValidator runat="server" ID="CheckBoxRequired" EnableClientScript="true"
            OnServerValidate="CheckBoxRequired_ServerValidate" ForeColor="RoyalBlue"
            ErrorMessage="You must accept the terms before you proceed!" Display="Dynamic" />

        <asp:RangeValidator runat="server" ForeColor="Red" Display="None"
            ControlToValidate="Age" Type="Integer" ValidationGroup="PersonalInfo"
            MaximumValue="81" MinimumValue="18" ErrorMessage="Age must be betweent 18 and 81!" />

        <asp:CompareValidator ID="CompareValidatorPassword"
            runat="server" ControlToCompare="Pass"
            ControlToValidate="PassRepeat" ValidationGroup="LogonInfo"
            ValueToCompare="Text" ForeColor="Blue"
            ErrorMessage="Passwords doesn't match!" Display="None" />

        <asp:RequiredFieldValidator runat="server" ControlToValidate="Username" ValidationGroup="LogonInfo"
            ErrorMessage="Username cannot be empty!<br />" ForeColor="Blue" Display="None" />

        <asp:RequiredFieldValidator runat="server" ControlToValidate="Pass" ValidationGroup="LogonInfo"
            ErrorMessage="Password cannot be empty!<br />" ForeColor="Blue" Display="None" />

        <asp:RequiredFieldValidator runat="server" ControlToValidate="PassRepeat" ValidationGroup="LogonInfo"
            ErrorMessage="Repeat Password cannot be empty!<br />" ForeColor="Blue" Display="None" />

        <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName" ValidationGroup="PersonalInfo"
            ErrorMessage="First Name cannot be empty!<br />" ForeColor="Red" Display="None" />

        <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName" ValidationGroup="PersonalInfo"
            ErrorMessage="Last Name cannot be empty!<br />" ForeColor="Red" Display="None" />

        <asp:RequiredFieldValidator runat="server" ControlToValidate="Age" ValidationGroup="PersonalInfo"
            ErrorMessage="Age cannot be empty!<br />" ForeColor="Red" Display="None" />

        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" ValidationGroup="PersonalInfo"
            ErrorMessage="Email cannot be empty!<br />" ForeColor="Red" Display="None" />

        <asp:RequiredFieldValidator runat="server" ControlToValidate="LocalAddress" ValidationGroup="AddressInfo"
            ErrorMessage="Local Address cannot be empty!<br />" ForeColor="Orange" Display="None" />

        <asp:RequiredFieldValidator runat="server" ControlToValidate="Phone" ValidationGroup="AddressInfo"
            ErrorMessage="Phone cannot be empty!<br />" ForeColor="Orange" Display="None" />

        <asp:ValidationSummary runat="server" HeaderText="Some Address errors occured!"
            DisplayMode="BulletList" EnableClientScript="true" ForeColor="Orange" ValidationGroup="AddressInfo"/>

        <asp:ValidationSummary runat="server" HeaderText="Some Personal Info errors occured!"
            DisplayMode="BulletList" EnableClientScript="true" ForeColor="Red" ValidationGroup="PersonalInfo"/>
        
        <asp:ValidationSummary runat="server" HeaderText="Some Logon Info errors occured!"
            DisplayMode="BulletList" EnableClientScript="true" ForeColor="Blue" ValidationGroup="LogonInfo"/>

    </form>

</body>
</html>
