using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class suoritus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int suoritusId = int.Parse(Request.QueryString["id"]);

        lblId.Text = suoritusId.ToString();

        Suoritus sNew = new Suoritus();
        List<Suoritus> slist = (List<Suoritus>)Session["suoritukset"];

        foreach (Suoritus s in slist)
        {
            if (s.suoritusId == suoritusId)
                sNew = s;
        }

        lblLaji.Text = sNew.laji;
        lblFiilikset.Text = sNew.tuntemukset;
        lblAlkuAika.Text = sNew.alkuAika.ToString();
        lblLopetusAika.Text = sNew.loppuAika.ToString();

        //get suoritus from database by id
    }
}