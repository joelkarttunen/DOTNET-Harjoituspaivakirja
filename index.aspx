<%@ Page Title="" Language="C#" MasterPageFile="~/harjoituspaivakirja.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" >
        
        <div class="page-header">
            <h1>Tervetuloa Harjoituspäiväkirjan pariin!</h1>
            <p>Kirjaudu sisään yläpalkin avulla.</p>
            <p>Jos olet uusi käyttäjä, <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Account/Register.aspx" runat="server">rekisteröidy</asp:HyperLink></p>
            
            

        </div>
    </div>
</asp:Content>

