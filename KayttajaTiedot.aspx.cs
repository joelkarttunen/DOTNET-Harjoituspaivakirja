using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class KayttajaTiedot : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Tietokanta tietokanta = new Tietokanta();
            int kayttajanID = tietokanta.haeKayttajanID(System.Web.HttpContext.Current.User.Identity.Name);

            Kayttaja k = tietokanta.palautaKayttaja(kayttajanID);

            txtEtunimi.Text = k.eNimi;
            txtSukunimi.Text = k.sNimi;
            txtIka.Text = k.ika.ToString();
            txtHetu.Text = k.hetu;
            txtAsuinPaikka.Text = k.asuinpaikka;
            txtInfo.Text = k.lisatiedot;
        }
    }
    protected void btnVaihdaTiedot_Click(object sender, EventArgs e)
    {
        Kayttaja k = new Kayttaja();
        Tietokanta tk = new Tietokanta();

        k.eNimi = txtEtunimi.Text;
        k.sNimi = txtSukunimi.Text;
        k.ika = Convert.ToInt32(txtIka.Text);
        k.hetu = txtHetu.Text;
        k.asuinpaikka = txtAsuinPaikka.Text;
        k.lisatiedot = txtInfo.Text;



        bool result = tk.paivitaKayttajaTiedot(System.Web.HttpContext.Current.User.Identity.Name, k);

        if (result)
            txtPaivitysInfoText.Text = "Käyttäjätiedot vaihdettu";
        else
            txtPaivitysInfoText.Text = "Ongelmia tietojen päivittämisessä";


    }
    protected void btnVaihdaSalasana_Click(object sender, EventArgs e)
    {
        Tietokanta tk = new Tietokanta();
        // haetaan kirjautuneen käyttäjän ID tietokannasta
        int KayttajanID = tk.haeKayttajanID(System.Web.HttpContext.Current.User.Identity.Name);
        Kayttaja k = tk.palautaKayttaja(KayttajanID);
        string hashattySalasana = JAMK.ICT.Security.SHA256Hash.getSHA256Hash(txtVanhaSalasana.Text);
        if (k.salasana.Equals(hashattySalasana))
        {
            //sallitaan salasanan vaihto
            if (tk.paivitaKayttajanSalasana(System.Web.HttpContext.Current.User.Identity.Name, txtUusiSalasana.Text))
                lblErrorMessages.Text = "Salasana vaihdettu onnistuneesti.";
            else
                lblErrorMessages.Text = "Salasanan vaihto ei onnistunut.";
        }
        else
        {
            lblErrorMessages.Text = "Vanha salasana ei kelpaa.";
        }

    }
}