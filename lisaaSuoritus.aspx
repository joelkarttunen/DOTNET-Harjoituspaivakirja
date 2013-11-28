<%@ Page Title="" Language="C#" MasterPageFile="~/harjoituspaivakirja.master" AutoEventWireup="true" CodeFile="lisaaSuoritus.aspx.cs" Inherits="lisaaSuoritus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <div class="container">
        <div class="page-header">
            <h1>Sivu suoritusten lisäämikseksi</h1>
        </div>
        <div>

        <div class="form form-horizontal">

            <div class="col-sm-3">
                <div class="form-group">
                <asp:Label ID="lblLaji" runat="server" Text="Mitä teit"></asp:Label>
                <asp:TextBox ID="txtSuoritusLaji" runat="server" CssClass="col-sm-10" ></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtSuoritusLaji" ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="Tarvittu tieto"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="Fiilikset"></asp:Label>
                <asp:TextBox ID="txtSuoritusFiilis" runat="server" Rows="6" TextMode="MultiLine" CssClass="col-sm-10"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtSuoritusFiilis" ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="Tarvittu tieto"></asp:RequiredFieldValidator>
                </div>
            </div>


            <div class="col-sm-3">
                    <asp:Label ID="Label1" runat="server" Text="Suoritusajankohta"></asp:Label>
                    <asp:Calendar ID="suoritusCalendar" runat="server"></asp:Calendar>
                    
            </div>

            <div class="col-sm-3">
                <div class="form-group">
                    
                    <asp:Label ID="Label3" runat="server" Text="Aloitusaika"></asp:Label>
                    <asp:TextBox ID="txtAloitusAika" runat="server" CssClass="col-sm-10"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtAloitusAika" runat="server" ForeColor="Red"  ErrorMessage="Anna aika muodossa TT:MM" ValidationExpression="([01]?[0-9]|2[0-3]):[0-5][0-9]"></asp:RegularExpressionValidator>
                </div>

                <div class="form-group">
                    <asp:Label ID="Label4" runat="server" Text="Lopetusaika"></asp:Label>
                    <asp:TextBox ID="txtLopetusAika" runat="server" CssClass="col-sm-10"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtLopetusAika" runat="server" ForeColor="Red"  ErrorMessage="Anna aika muodossa TT:MM" ValidationExpression="([01]?[0-9]|2[0-3]):[0-5][0-9]"></asp:RegularExpressionValidator>
                </div>
                
                <div class="form-group">
                    <asp:Button ID="btnLisaaSuoritus" runat="server" Text="Lisää suoritus" OnClick="btnLisaaSuoritus_Click" />
                </div>
            </div>

            <asp:Label ID="lblDebug2" runat="server" Text="Poista tämä, kun ohjelma on valmis"></asp:Label>

            <hr />
          
        </div>
       </div>

       
    </div>
</asp:Content>

