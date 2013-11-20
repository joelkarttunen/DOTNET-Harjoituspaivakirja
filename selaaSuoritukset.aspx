<%@ Page Title="" Language="C#" MasterPageFile="~/harjoituspaivakirja.master" AutoEventWireup="true" CodeFile="selaaSuoritukset.aspx.cs" Inherits="selaaSuoritukset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Tässä listataan suorituksesi</h2>
    <p>Valitse kuukausi miltä listata</p>
    <div>
        <asp:DropDownList ID="suoritusKuukausiList" runat="server"></asp:DropDownList>
    </div>

    <div id="suoritusContent">
        <asp:Repeater ID="suoritusRepeater" runat="server">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th>Suorituslaji</th>
                        <th>Suorituksen pvm</th>
                        <th>Aloitusaika</th>
                        <th>Lopetusaika</th>
                        <th>Lisäinfo</th>
                    </tr>
                
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                <td>
                    <asp:Label runat="server" ID="Label1" Text='<%# Eval("laji") %>'></asp:Label>
                </td>
                 <td>
                    <asp:Label runat="server" ID="Label2" Text='<%# Eval("laji") %>'></asp:Label>
                </td>
                 <td>
                    <asp:Label runat="server" ID="Label3" Text='<%# Eval("alkuAika") %>'></asp:Label>
                </td>
                 <td>
                    <asp:Label runat="server" ID="Label4" Text='<%# Eval("loppuAika") %>'></asp:Label>
                </td>
                 <td>
                     <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("suoritusId", "~/suoritus.aspx?id={0}") %>'>Muuta</asp:HyperLink>
                </td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

    </div>
</asp:Content>

