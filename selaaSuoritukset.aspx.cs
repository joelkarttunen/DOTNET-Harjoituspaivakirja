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
        if (!IsPostBack)
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
        //Session["calendarEnd"] = suoritusLoppuCalendar.SelectedDate;
        //Session["calendarStart"] = suoritusAlkuCalendar.SelectedDate;
    }
    protected void updateCalendarDate()
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
    protected void suoritusLoppuCalendar_SelectionChanged(object sender, EventArgs e)
    {

        updateCalendarDate();
        
    }
    protected void suoritusAlkuCalendar_SelectionChanged(object sender, EventArgs e)
    {

        updateCalendarDate();
    }
    protected void suoritusRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int suoritus_id = Convert.ToInt32(e.CommandArgument.ToString());

            Tietokanta tk = new Tietokanta();
            int k_id = tk.haeKayttajanID(System.Web.HttpContext.Current.User.Identity.Name);

            tk.poistaSuoritus(suoritus_id, k_id);

            List<Suoritus> suoritusList = tk.haeSuorituksetKayttajanIDnPerusteella(k_id);

            Session["suoritukset"] = suoritusList;

            suoritusRepeater.DataSource = suoritusList;
            suoritusRepeater.DataBind();
        }
    }
    protected void alkuVuosiBack_Click(object sender, EventArgs e)
    {
        suoritusAlkuCalendar.SelectedDate = suoritusAlkuCalendar.SelectedDate.AddYears(-1);
        suoritusAlkuCalendar.VisibleDate = suoritusAlkuCalendar.SelectedDate;
        updateCalendarDate();
    }
    protected void alkuVuosiForward_Click(object sender, EventArgs e)
    {
        suoritusAlkuCalendar.SelectedDate = suoritusAlkuCalendar.SelectedDate.AddYears(1);
        suoritusAlkuCalendar.VisibleDate = suoritusAlkuCalendar.SelectedDate;
        updateCalendarDate();
    }
    protected void loppuVuosiBack_Click(object sender, EventArgs e)
    {
        suoritusLoppuCalendar.SelectedDate = suoritusLoppuCalendar.SelectedDate.AddYears(-1);
        suoritusLoppuCalendar.VisibleDate = suoritusLoppuCalendar.SelectedDate;
        updateCalendarDate();
    }
    protected void loppuVuosiForward_Click(object sender, EventArgs e)
    {
        suoritusLoppuCalendar.SelectedDate = suoritusLoppuCalendar.SelectedDate.AddYears(1);
        suoritusLoppuCalendar.VisibleDate = suoritusLoppuCalendar.SelectedDate;
        updateCalendarDate();
    }
}