<%@ Page Title="" Language="C#" MasterPageFile="~/harjoituspaivakirja.master" AutoEventWireup="true" CodeFile="KayttajaTiedot.aspx.cs" Inherits="KayttajaTiedot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="page-header">
            <h2>Muuta tietojasi</h2>
        </div>
        
        <div class="col-md-4">
        <div class="form-group">
            <asp:Label ID="label1" runat="server" Text="Etunimi"></asp:Label>
            <asp:TextBox ID="txtEtunimi" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text="Sukunimi"></asp:Label>
            <asp:TextBox ID="txtSukunimi" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="Label3" runat="server" Text="Sähköposti"></asp:Label>
            <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
        </div>

        <hr />
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
        </div>
            <asp:Button ID="btnPaivitaTiedot" runat="server" Text="Päivitä tiedot" />
        </div>
    </div>
</asp:Content>

