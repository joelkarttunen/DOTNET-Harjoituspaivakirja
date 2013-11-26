using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class harjoituspaivakirja : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // Käyttäjä on kirautuneena
        if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
        {
            loginLogout.Text = "Logout";
        }
        else
            loginLogout.Text = "Login";
    }
    // LoginLogout-nappulan tapahtumankäsittelijä.
    protected void On_Click(object sender, EventArgs e)
    {
        if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.SignOut();
            loginLogout.Text = "Login";
            //lblDebug.Text = "joopajoo";
        }
        else
        {
            try
            {
                //koetetaan autentikoitua käyttämällä AutentikointiDB luokkaa
                // lisataan config.webistä
                AutentikointiDB.ConnectionString = ConfigurationManager.ConnectionStrings["HarkkaPvk"].ConnectionString;
                string kayttajaTunnus = txtKayttajatunnus.Text;
                string salasana = txtSalasana.Text;
                if (AutentikointiDB.Login(kayttajaTunnus, salasana))    //LoginUser.UserName, LoginUser.Password))
                {
                    // lblNotes.Text = Page.User.ToString();
                    // Tämä kirjaa käyttäjän sisään!
                    FormsAuthentication.RedirectFromLoginPage(kayttajaTunnus, false);
                }
                else
                {
                    lblDebug.Text += "Autentikointi epäonnistui";
                }
            }
            catch (Exception ex)
            {
                //lblDebug.Text = ex.Message.ToString(); // HUOM! ei lopullinen, vaan koodarin testauksen ajan.
                lblDebug.Text = "Autentikointipalvelua ei voi käyttää, yritä hetken päästä uudestaan.";
                //throw;
            }
        }
    }
}
