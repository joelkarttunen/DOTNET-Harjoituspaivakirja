using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        /*
        FormsAuthentication.SetAuthCookie(CreateUserWizard1.CreateUserStep.
         
          // createPersistentCookie 
            ContentTemplateContainer.FindControl("UserName").ToString(), false );

        string continueUrl = CreateUserWizard1.ContinueDestinationPageUrl;
        if (String.IsNullOrEmpty(continueUrl))
        {
            continueUrl = "~/";
        }
        TextBox FirstNameTextBox = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("FirstName");
        TextBox LastNameTextBox = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("LastName");
        TextBox UsernameTextBox = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("UserName");
        TextBox EmailTextBox = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Email");


        lblDebug.Text = "testi";
         * */
    }
    protected void FinishButtonClicked(object sender, WizardNavigationEventArgs e)
    {
        lblDebug.Text = "testi";
    }
    protected void CreatinUser(object sender, LoginCancelEventArgs e)
    {
        e.Cancel = true;

    }
    protected void NextButtonClick(object sender, WizardNavigationEventArgs e)
    {
        e.Cancel = false;
        CreateUserWizard1.ActiveStepIndex = 1;
    }
    protected void ContinueButtonClicked(object sender, EventArgs e)
    {
        
        
        /*
        string continueUrl = CreateUserWizard1.ContinueDestinationPageUrl;
        if (String.IsNullOrEmpty(continueUrl))
        {
            continueUrl = "~/";
        }
        */
        
        AutentikointiDB.ConnectionString = ConfigurationManager.ConnectionStrings["HarkkaPvk"].ConnectionString;
        if (!AutentikointiDB.isUserNameInUse(CreateUserWizard1.UserName))
        {
            AutentikointiDB.CreateNewUser(CreateUserWizard1.UserName, CreateUserWizard1.Email, CreateUserWizard1.Password, true);
            // kirjaa käyttäjän sisään.
            FormsAuthentication.SetAuthCookie(CreateUserWizard1.UserName, false /* createPersistentCookie */);

        }
        else
        {
            //Response.Redirect("~/index.aspx");

            //Kirjaa käyttäjän ulos ulos
            FormsAuthentication.SignOut();
        }
        //lblDebug.Text = CreateUserWizard1.UserName;
    }
}