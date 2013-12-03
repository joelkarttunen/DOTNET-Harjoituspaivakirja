<%@ Page Title="" Language="C#" MasterPageFile="~/harjoituspaivakirja.master" AutoEventWireup="true" CodeFile="KayttajaTiedot.aspx.cs" Inherits="KayttajaTiedot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="page-header">
            <h2>Tietosi</h2>
        </div>
        
        <div class="col-md-4">
            <h3>Perustietosi</h3>
            <asp:Label ID="txtPaivitysInfoText" runat="server" Text=""></asp:Label>
        <div class="form-group">
            <asp:Label ID="label1" runat="server" Text="Etunimi"></asp:Label>
            <asp:TextBox ID="txtEtunimi" class="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="FirstNameRequiredFieldValidator" runat="server" ControlToValidate="txtEtunimi"
                    Display="Dynamic" ErrorMessage="Etunimi on vaadittu" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="FirstnameRegularExpressionValidator" runat="server" ControlToValidate="txtEtunimi"
                    Display="Dynamic" ValidationExpression="\b[a-öA-Ö]{2,20}\b" ErrorMessage="Pituuden täytyy olla 2-20. Voit käyttää isoja- ja pieniä kirjaimia">
                </asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text="Sukunimi"></asp:Label>
            <asp:TextBox ID="txtSukunimi" class="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="LastNameRequiredFieldValidator" runat="server" ControlToValidate="txtSukunimi"
                    Display="Dynamic" ErrorMessage="Sukunimi on vaadittu" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSukunimi"
                    Display="Dynamic" ValidationExpression="\b[a-öA-Ö]{2,45}\b" ErrorMessage="Pituuden täytyy olla 2-45. Voit käyttää isoja- ja pieniä kirjaimia">
                </asp:RegularExpressionValidator>
        </div>

            <div class="form-group">
            <asp:Label ID="Label10" runat="server" Text="Sähköposti"></asp:Label>
            <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" ControlToValidate="txtEmail"
                    Display="Dynamic" ErrorMessage="Sähköpostiosoite vaaditaan" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="EmailRegularExpressionValidator" runat="server"
                    ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Syötä oikeaa muotoa oleva sähköpostiosoite"
                    SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
            <asp:Label ID="Label3" runat="server" Text="Ikä"></asp:Label>
            <asp:TextBox ID="txtIka" class="form-control" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="IkaReqularExpressionValidator" ControlToValidate="txtIka" runat="server" 
                    Display="Dynamic" ValidationExpression="[0-9]*" ErrorMessage="Syötä vain nunmeroita"></asp:RegularExpressionValidator>
        </div>
            <div class="form-group">
            <asp:Label ID="Label7" runat="server" Text="Henkilötunnus"></asp:Label>
            <asp:TextBox ID="txtHetu" class="form-control" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="HetuRegularExpressionValidator" ControlToValidate="txtHetu" runat="server" 
                    Display="Dynamic" ValidationExpression="^\d{6}[A+-]\d{3}[a-zA-Z0-9]$" ErrorMessage="Syötä hetu oikeassa muodossa">
            </asp:RegularExpressionValidator>
        </div>
            <div class="form-group">
            <asp:Label ID="Label9" runat="server" Text="Asuinpaikka"></asp:Label>
            <asp:TextBox ID="txtAsuinPaikka" class="form-control" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtAsuinPaikka"
                   Display="Dynamic" ValidationExpression="\b[a-öA-Ö]{0,45}\b" ErrorMessage="Pituuden täytyy olla 0-45. Voit käyttää isoja- ja pieniä kirjaimia">
                </asp:RegularExpressionValidator>
        </div>
            <div class="form-group">
            <asp:Label ID="Label8" runat="server" Text="Lisäinfo"></asp:Label>
            <asp:TextBox ID="txtInfo" class="form-control" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </div>
            <asp:Button ID="btnVaihdaTiedot" EnableViewState="false" runat="server" Text="Päivitä tiedot" OnClick="btnVaihdaTiedot_Click" />
        </div>
        <div class="col-md-4"></div>

        <div class="col-md-4">
        <h3>Vaihda salasana</h3>
        <div class="form-group">
            <asp:Label ID="Label4" runat="server" Text="Vanha salasana"></asp:Label>
            <asp:TextBox ID="txtVanhaSalasana" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="Label5" runat="server" Text="Uusi salasana"></asp:Label>
            <asp:TextBox ID="txtUusiSalasana" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="Label6" runat="server" Text="Toista uusi salasana"></asp:Label>
            <asp:TextBox ID="txtToistaUusiSalasana" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator ID="ConfirmPasswordCompareValidator" runat="server" ControlToCompare="txtUusiSalasana"
                    ControlToValidate="txtToistaUusiSalasana" Display="Dynamic" ErrorMessage="Salasanat eivät täsmää!"
                    SetFocusOnError="True"></asp:CompareValidator>
        </div>
            <asp:Button ID="btnVaihdaSalasana" runat="server" Text="Vaihda Salasana" OnClick="btnVaihdaSalasana_Click" />
            <asp:Label ID="lblErrorMessages" runat="server" Text=""></asp:Label>
            </div>
    </div>
</asp:Content>

