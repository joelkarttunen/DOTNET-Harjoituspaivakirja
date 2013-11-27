using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Suoritus
/// </summary>
public class Suoritus
{
    public int suoritusId { get; set; }
    public int kayttajaId { get; set; }
    public DateTime alkuAika { get; set; }
    public DateTime loppuAika { get; set; }
    public string laji { get; set; }
    public string tuntemukset { get; set; }
    public DateTime pvm {get; set;}

	public Suoritus()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public Suoritus(int sid, int kid, DateTime aloitusaika, DateTime lopetusaika, string laji, string tuntemukset)
    {
        this.suoritusId = sid;
        this.kayttajaId = kid;
        this.alkuAika = aloitusaika;
        this.loppuAika = lopetusaika;
        this.laji = laji;
        this.tuntemukset = tuntemukset;
    }
}