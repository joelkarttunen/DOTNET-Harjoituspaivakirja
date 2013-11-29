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
        </div>
        <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text="Sukunimi"></asp:Label>
            <asp:TextBox ID="txtSukunimi" class="form-control" runat="server"></asp:TextBox>
        </div>
            <div class="form-group">
            <asp:Label ID="Label3" runat="server" Text="Ikä"></asp:Label>
            <asp:TextBox ID="txtIka" class="form-control" runat="server"></asp:TextBox>
        </div>
            <div class="form-group">
            <asp:Label ID="Label7" runat="server" Text="Henkilötunnus"></asp:Label>
            <asp:TextBox ID="txtHetu" class="form-control" runat="server"></asp:TextBox>
        </div>
            <div class="form-group">
            <asp:Label ID="Label9" runat="server" Text="Asuinpaikka"></asp:Label>
            <asp:TextBox ID="txtAsuinPaikka" class="form-control" runat="server"></asp:TextBox>
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

