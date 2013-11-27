using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lisaaSuoritus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLisaaSuoritus_Click(object sender, EventArgs e)
    {
        DateTime pvm = suoritusCalendar.SelectedDate;

        String temp = txtAloitusAika.Text;
        string[] pilkottu = temp.Split(':');

        TimeSpan aloitus = new TimeSpan(int.Parse(pilkottu[0]), int.Parse(pilkottu[1]), 00);

        DateTime alkuAjanKohta = pvm + aloitus;

        temp = txtLopetusAika.Text;
        pilkottu = temp.Split(':');

        TimeSpan lopetus = new TimeSpan(int.Parse(pilkottu[0]), int.Parse(pilkottu[1]), 00);

        DateTime lopetusAjanKohta = pvm + lopetus;

        txtAloitusAika.Text = alkuAjanKohta.ToString();
        txtLopetusAika.Text = lopetusAjanKohta.ToString();


       /* txtSuoritusLaji.Text
        * txtSuoritusFiilis.Text
        * alkuAjankohta
        * lopetusAjanKohta
        */
        //Todo: lisää tietokantaan 

        // Response.Redirect("selaaSuoritukset.aspx");
    }
}