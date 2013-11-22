<%@ Page Title="" Language="C#" MasterPageFile="~/harjoituspaivakirja.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <br />
        <div class="page-header">
            <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
                OnCreatedUser="CreateUserWizard1_CreatedUser" OnContinueButtonClick="ContinueButtonClicked"
                 OnCreatingUser="CreatinUser" OnFinishButtonClick="FinishButtonClicked"
                 OnNextButtonClick="NextButtonClick" LoginCreatedUser="False">
                <WizardSteps>
                    <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                    </asp:CreateUserWizardStep>
                    <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                    </asp:CompleteWizardStep>
                </WizardSteps>
            </asp:CreateUserWizard>
            </div>
        </div>
    <asp:Label ID="lblDebug" runat="server" Text="Label"></asp:Label>
</asp:Content>

