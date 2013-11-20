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
        IniMyStuff();
    }

    protected void IniMyStuff()
    {
        Suoritus s1 = new Suoritus(1, 1, new DateTime(2013, 11, 1, 13, 00, 00), new DateTime(2013, 11, 1, 14, 24, 00), "Testoharjoitus", "Hyvät fiilikset");
        Suoritus s2 = new Suoritus(2, 1, new DateTime(2013, 11, 2, 11, 45, 00), new DateTime(2013, 11, 2, 12, 15, 00), "Punnerrus", "Huonoa");
        Suoritus s3 = new Suoritus(3, 1, new DateTime(2013, 11, 3, 16, 00, 00), new DateTime(2013, 11, 3, 16, 30, 00), "Kävely", "Jees");

        List<Suoritus> suoritusList = new List<Suoritus>();

        suoritusList.Add(s1);
        suoritusList.Add(s2);
        suoritusList.Add(s3);

        suoritusRepeater.DataSource = suoritusList;
        suoritusRepeater.DataBind();

    }
}