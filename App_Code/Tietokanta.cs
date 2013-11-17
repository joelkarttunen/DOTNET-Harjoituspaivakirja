using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Tietokanta
/// </summary>
public class Tietokanta
{
	public Tietokanta()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Suoritus[] haeSuorituksetKayttajanIDnPerusteella(string kayttajanId)
    {
        return null;
    }
    public Kayttaja haeKayttaja(string kayttajatunnus, string salasana)
    {
        return null;
    }
    public Kayttaja palautaKayttaja(int id){

        return null;
    }
    public bool tallennaKayttaja(Kayttaja k)
    {
        return false;
    }
    public void poistaKayttajaIDnPerusteella(int id){
    }

    public void poistaKayttajaNimenPerusteella(string nimi){
    }

    public void poistaKayttaja(Kayttaja k){
    }
}