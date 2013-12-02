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
                <asp:RegularExpressionValidator ID="FirstnameRegularExpressionValidator" runat="server" ControlToValidate="txtFirstName"
                    Display="Dynamic" ValidationExpression="\b[a-öA-Ö]{2,20}\b" ErrorMessage="Pituuden täytyy olla 2-20. Voit käyttää isoja- ja pieniä kirjaimia">

                </asp:RegularExpressionValidator>
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
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtLastName"
                    Display="Dynamic" ValidationExpression="\b[a-öA-Ö]{2,45}\b" ErrorMessage="Pituuden täytyy olla 2-45. Voit käyttää isoja- ja pieniä kirjaimia">

                </asp:RegularExpressionValidator>
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
            <asp:RegularExpressionValidator ID="KayttajatunnusRegularExpressionValidator" runat="server" ControlToValidate="txtUsername"
                    Display="Dynamic" ValidationExpression="\b[0-9a-öA-Ö]{2,20}\b" ErrorMessage="Pituuden täytyy olla 2-20. Voit käyttää numeroita, ssekä isoja- ja pieniä kirjaimia">

                </asp:RegularExpressionValidator>
            </td>
        </tr>

        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label2" runat="server" Text="Ikä:" Width="80px"></asp:Label>
            </td>
            <td style="width: 116px">
                <asp:TextBox ID="txtIka" runat="server" ></asp:TextBox>
            </td>
            <td style="width: 100px">
                <asp:RegularExpressionValidator ID="IkaReqularExpressionValidator" ControlToValidate="txtIka" runat="server" 
                    Display="Dynamic" ValidationExpression="[0-9]*" ErrorMessage="Syötä vain nunmeroita"></asp:RegularExpressionValidator>
            </td>
        </tr>

        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label3" runat="server" Text="Asuinpaikka:" Width="80px"></asp:Label>
            </td>
            <td style="width: 116px">
                <asp:TextBox ID="txtAsuinpaikka" runat="server" ></asp:TextBox>
            </td>
            <td style="width: 100px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtAsuinpaikka"
                   Display="Dynamic" ValidationExpression="\b[a-öA-Ö]{0,45}\b" ErrorMessage="Pituuden täytyy olla 0-45. Voit käyttää isoja- ja pieniä kirjaimia">
                </asp:RegularExpressionValidator>
            </td>
        </tr>

        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label4" runat="server" Text="Hetu:" Width="80px"></asp:Label>
            </td>
            <td style="width: 116px">
                <asp:TextBox ID="txtHetu" runat="server" ></asp:TextBox>
            </td>
            <td style="width: 100px">
                <asp:RegularExpressionValidator ID="HetuRegularExpressionValidator" ControlToValidate="txtHetu" runat="server" 
                    Display="Dynamic" ValidationExpression="^\d{6}[A+-]\d{3}[a-zA-Z0-9]$" ErrorMessage="Syötä hetu oikeassa muodossa"></asp:RegularExpressionValidator>
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

