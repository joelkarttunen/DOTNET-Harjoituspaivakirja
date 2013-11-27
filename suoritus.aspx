<%@ Page Title="" Language="C#" MasterPageFile="~/harjoituspaivakirja.master" AutoEventWireup="true" CodeFile="suoritus.aspx.cs" Inherits="suoritus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="page-header">
            <h2>Tarkempaa tietoa suorituksesta </h2> <asp:Label ID="lblId" runat="server" Text="Label"></asp:Label>
        </div>
        
        <div class="row">
            <h3>Laji</h3>
            <asp:Label ID="lblLaji" runat="server" Text=""></asp:Label>
        </div>
        <div class="row">
            <h3>Aloitusaika</h3>
            <asp:Label ID="lblAlkuAika" runat="server" Text=""></asp:Label>
        </div>
        <div class="row">
            <h3>Lopetusaika</h3>
            <asp:Label ID="lblLopetusAika" runat="server" Text=""></asp:Label>
        </div>
        <div class="row">
            <h3>Fiilikset</h3>
            <asp:Label ID="lblFiilikset" runat="server" Text=""></asp:Label>
        </div>

    </div>
</asp:Content>

