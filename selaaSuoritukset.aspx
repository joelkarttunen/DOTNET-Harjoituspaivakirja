<%@ Page Title="" Language="C#" MasterPageFile="~/harjoituspaivakirja.master" AutoEventWireup="true" CodeFile="selaaSuoritukset.aspx.cs" Inherits="selaaSuoritukset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <div class="container">
    <div class="page-header">
            <h1>Tarkastele suorituksiasi</h1>
            <p>Valitse haluamasi aika boxista</p>
        </div>
    

    <div class="col-md-3">
        <asp:Label ID="Label3" runat="server" Text="Alku"></asp:Label>
        <asp:Calendar ID="suoritusAlkuCalendar" AutoPostBack="true" runat="server" OnSelectionChanged="suoritusAlkuCalendar_SelectionChanged">
        </asp:Calendar>
        <asp:Label ID="Label4" runat="server" Text="Loppu"></asp:Label>
        <asp:Calendar ID="suoritusLoppuCalendar" AutoPostBack="true" EnableViewState="true"  runat="server" OnSelectionChanged="suoritusLoppuCalendar_SelectionChanged"></asp:Calendar>
    </div>
        
      <div class="col-md-9">
        <asp:Repeater ID="suoritusRepeater" runat="server" OnItemCommand="suoritusRepeater_ItemCommand">
            <HeaderTemplate>
                <table class="table table-striped" >
                    <tr>
                        <th>Päivämäärä</th>
                        <th>Laji</th>
                        
                        <th>Lisäinfo</th>
                        <th>Poista</th>
                    </tr>
                
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                <td>
                    <asp:Label runat="server" ID="Label1" Text='<%# Eval("alkuAika") %>'></asp:Label>
                </td>
                 <td>
                    <asp:Label runat="server" ID="Label2" Text='<%# Eval("laji") %>'></asp:Label>
                </td>
                 
                 <td>
                     <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("suoritusId", "~/suoritus.aspx?id={0}") %>'>Muuta</asp:HyperLink>
                </td>
                 <td> 
                     <asp:LinkButton ID="LinkButton1" runat="server" Text="" CommandName="Delete" CommandArgument='<%# Eval("suoritusId") %>' >X</asp:LinkButton>
                </td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
      </div>
   
  </div>
</asp:Content>

