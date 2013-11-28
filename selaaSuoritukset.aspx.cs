using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class selaaSuoritukset : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsCallback)
            IniMyStuff();
       
    }

    protected void IniMyStuff()
    {
        //Dummycontent, todo: hae tietokannasta
      /*  Suoritus s1 = new Suoritus(1, 1, new DateTime(2013, 11, 1, 13, 00, 00), new DateTime(2013, 11, 1, 14, 24, 00), "Testoharjoitus", "Hyvät fiilikset");
        Suoritus s2 = new Suoritus(2, 1, new DateTime(2013, 11, 2, 11, 45, 00), new DateTime(2013, 11, 2, 12, 15, 00), "Punnerrus", "Huonoa");
        Suoritus s3 = new Suoritus(3, 1, new DateTime(2013, 11, 3, 16, 00, 00), new DateTime(2013, 11, 3, 16, 30, 00), "Kävely", "Jees");
        */

        //asetetaan kalenterin päivämääriksi eka ja vika päivä
        suoritusLoppuCalendar.SelectedDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year,DateTime.Today.Month));
        suoritusAlkuCalendar.SelectedDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

        Tietokanta tietokanta = new Tietokanta();
        int kayttajanID = tietokanta.haeKayttajanID(System.Web.HttpContext.Current.User.Identity.Name);
        //List<Suoritus> suoritusList = new List<Suoritus>();
        List<Suoritus> suoritusList = tietokanta.haeSuorituksetKayttajanIDnPerusteella(kayttajanID);
       // suoritusList.Add(s1);
       // suoritusList.Add(s2);
       // suoritusList.Add(s3);

        suoritusRepeater.DataSource = suoritusList;
        suoritusRepeater.DataBind();

        Session["suoritukset"] = suoritusList;

    }
    
    protected void suoritusLoppuCalendar_SelectionChanged(object sender, EventArgs e)
    {
        List<Suoritus> rajattuList = new List<Suoritus>();
        List<Suoritus> suoritusList = (List<Suoritus>)Session["suoritukset"];

        foreach (Suoritus s in suoritusList)
        {
            if (s.alkuAika >= suoritusAlkuCalendar.SelectedDate && s.loppuAika <= suoritusLoppuCalendar.SelectedDate)
                rajattuList.Add(s);
        }


        suoritusRepeater.DataSource = rajattuList;
        suoritusRepeater.DataBind();
    }
    protected void suoritusAlkuCalendar_SelectionChanged(object sender, EventArgs e)
    {
        List<Suoritus> rajattuList = new List<Suoritus>();
        List<Suoritus> suoritusList = (List<Suoritus>)Session["suoritukset"];

        foreach (Suoritus s in suoritusList)
        {
            if (s.alkuAika >= suoritusAlkuCalendar.SelectedDate && s.loppuAika <= suoritusLoppuCalendar.SelectedDate)
                rajattuList.Add(s);
        }


        suoritusRepeater.DataSource = rajattuList;
        suoritusRepeater.DataBind();
    }
}