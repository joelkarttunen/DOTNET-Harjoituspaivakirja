<%@ Page Title="" Language="C#" MasterPageFile="~/harjoituspaivakirja.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <br />
        <div class="page-header">

            
<table>
        <tr>
            <td colspan="3">
                <span style="font-size: 14pt">Täytä tiedot ja rekisteröidy</span>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="lblFirstName" runat="server" Text="Etunimi:" Width="80px"></asp:Label>
            </td>
            <td style="width: 116px">
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            </td>
            <td style="width: 100px">
                <asp:RequiredFieldValidator ID="FirstNameRequiredFieldValidator" runat="server" ControlToValidate="txtFirstName"
                    Display="Dynamic" ErrorMessage="Etunimi on vaadittu" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="lblLastName" runat="server" Text="Sukunimi:" Width="80px"></asp:Label>
            </td>
            <td style="width: 116px">
                <asp:TextBox ID="txtLastName" runat="server" ></asp:TextBox>
            </td>
            <td style="width: 100px">
                <asp:RequiredFieldValidator ID="LastNameRequiredFieldValidator" runat="server" ControlToValidate="txtLastName"
                    Display="Dynamic" ErrorMessage="Sukunimi on vaadittu" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
            
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label1" runat="server" Text="Kayttajatunnus:" Width="80px"></asp:Label>
            </td>
            <td style="width: 116px">
                <asp:TextBox ID="txtUsername" runat="server" ></asp:TextBox>
            </td>
            <td style="width: 100px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername"
                    Display="Dynamic" ErrorMessage="Käyttäjätunnus vaaditaan" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td style="width: 100px">
                <asp:Label ID="lblEmail" runat="server" Text="Sähköposti:" Width="45px"></asp:Label>
            </td>
            <td style="width: 116px">
                <asp:TextBox ID="txtEmail" runat="server" ></asp:TextBox>
            </td>
            <td style="width: 100px">
                <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" ControlToValidate="txtEmail"
                    Display="Dynamic" ErrorMessage="Sähköpostiosoite vaaditaan" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="EmailRegularExpressionValidator" runat="server"
                    ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Syötä oikeaa muotoa oleva sähköpostiosoite"
                    SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 26px;">
                <asp:Label ID="lblPassword" runat="server" Text="Salasana:" Width="71px"></asp:Label>
            </td>
            <td style="width: 116px; height: 26px;">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td style="width: 100px; height: 26px">
                <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" ControlToValidate="txtPassword"
                    Display="Dynamic" ErrorMessage="Salasana on vaadittu" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 26px;">
                <asp:Label ID="lblConfirmPassword" runat="server" Text="Toista salasana:" Width="128px"></asp:Label>
            </td>
            <td style="width: 116px; height: 26px;">
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td style="width: 100px; height: 26px">
                <asp:RequiredFieldValidator ID="ConfirmPasswordRequiredFieldValidator" runat="server"
                    ControlToValidate="txtConfirmPassword" Display="Dynamic" ErrorMessage="Salasanan vahvistus on vaadittu"
                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="ConfirmPasswordCompareValidator" runat="server" ControlToCompare="txtPassword"
                    ControlToValidate="txtConfirmPassword" Display="Dynamic" ErrorMessage="Salasanat eivät täsmää!"
                    SetFocusOnError="True">*</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 26px;">
            </td>
            <td style="width: 116px; height: 26px;">
                <asp:Button ID="btnSignup" runat="server" Text="Rekisteröidy" OnClick="btnSignup_Click"/>
            </td>
            <td style="width: 100px; height: 26px">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 26px">
                <asp:ValidationSummary ID="SigupValidationSummary" runat="server" />
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
            <asp:Label ID="lblKayttajanimiVarattu" runat="server" Text=""></asp:Label>

            </div>
        </div>
    <asp:Label ID="lblDebug" runat="server" Text="Label"></asp:Label>
</asp:Content>

