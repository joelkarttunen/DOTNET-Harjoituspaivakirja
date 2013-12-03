using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Kayttaja
/// </summary>
public class Kayttaja
{
    public int id { get; set; }
    public string eNimi { get; set; }
    public string sNimi { get; set; }
    public int ika { get; set; }
    public string sPosti { get; set; }
    public string asuinpaikka { get; set; }
    public string kayttajatunnus { get; set; }
    public string salasana { get; set; }
    public string lisatiedot { get; set; }
    public string hetu { get; set; }
    public DateTime rekisteroitymisPvm { get; set; }

	public Kayttaja()
	{
		//
		// TODO: Add constructor logic here
		//
        
	}

    
}