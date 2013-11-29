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
    
        //lblDebug.Text = CreateUserWizard1.UserName;

    protected void btnSignup_Click(object sender, EventArgs e)
    {
        AutentikointiDB.ConnectionString = ConfigurationManager.ConnectionStrings["HarkkaPvk"].ConnectionString;
        if (!AutentikointiDB.isUserNameInUse(txtUsername.Text))
        {
            string salasana = txtPassword.Text;
            //AutentikointiDB.CreateNewUser(txtUsername.Text, txtEmail.Text, salasana, true);
            AutentikointiDB.CreateNewUser(txtFirstName.Text, txtLastName.Text, txtHetu.Text, 
                Convert.ToInt32(txtIka.Text), txtAsuinpaikka.Text, txtUsername.Text, txtEmail.Text,
                txtPassword.Text, true);
            
            //FormsAuthentication.SignOut();

            // kirjaa käyttäjän pysyvästi
            // vrt. muista minut. Voidaan ehkä toteuttaa jossain vaiheessa.
            //FormsAuthentication.SetAuthCookie(txtUsername.Text, false /* createPersistentCookie */);

            //FormsAuthentication.RedirectFromLoginPage(kayttajaTunnus, false);
            //AutentikointiDB.Login(txtUsername.Text, txtPassword.Text);
            FormsAuthentication.SetAuthCookie(txtUsername.Text, false);
            Response.Redirect("~/KayttajaTiedot.aspx");
        }
        else
        {
            lblKayttajanimiVarattu.Text = "Kayttajanimi on jo varattu.";   
            //Response.Redirect("~/index.aspx");

            //Kirjaa käyttäjän ulos ulos
            //FormsAuthentication.SignOut();
        }
    }
}