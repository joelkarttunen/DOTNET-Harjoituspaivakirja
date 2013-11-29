using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Tietokanta
/// </summary>
public class Tietokanta
{
    private static string connString = ConfigurationManager.ConnectionStrings["HarkkaPvk"].ConnectionString;
	
    private MySqlConnection connection = new MySqlConnection(connString);
    public Tietokanta()
	{
		
	}


    public List<Suoritus> haeSuorituksetKayttajanIDnPerusteella(int kayttajanId)
    {
        try
        {
            List<Suoritus> suoritukset = new List<Suoritus>();
            connection.Open();
            string query = "SELECT * FROM Suoritus WHERE Kayttaja_ID = @userid";

            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("userid", kayttajanId);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();
            Suoritus suor;
            while (dataReader.Read())
            {
                suor = new Suoritus(Convert.ToInt32(dataReader["Suoritus_ID"]), Convert.ToInt32(dataReader["Kayttaja_ID"]),
                    Convert.ToDateTime(dataReader["Alkuaika"]), Convert.ToDateTime(dataReader["Loppuaika"]),
                    dataReader["laji"].ToString(), dataReader["tuntemukset"].ToString());
                suoritukset.Add(suor);
            }
            connection.Close();
            return suoritukset;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    // Poikkeus, jos salasana on väärä
    public Kayttaja haeKayttaja(string kayttajatunnus, string salasana)
    {
        return null;
    }
    
    public int haeKayttajanID(string kayttajatunnus)
    {
        try
        {
            int KayttajanID = 0;
            connection.Open();
            string query = "SELECT Kayttaja_ID FROM Kayttaja WHERE kayttajatunnus = @kayttajatunnus";

            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("kayttajatunnus", kayttajatunnus);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
               // object testi = dataReader["Kayttaja_ID"];
                KayttajanID = Convert.ToInt32(dataReader["Kayttaja_ID"]);
            }
            connection.Close();
            return KayttajanID;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public Kayttaja palautaKayttaja(int id){

        try
        {
            connection.Open();

            string query = "SELECT * FROM Kayttaja WHERE Kayttaja_ID = @id";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", id);

            MySqlDataReader dataReader = cmd.ExecuteReader();
            Kayttaja k = new Kayttaja();

            while (dataReader.Read())
            {
                k.id = Convert.ToInt32(dataReader["Kayttaja_ID"]);
                k.eNimi = dataReader["e_nimi"].ToString();
                k.sNimi = dataReader["s_nimi"].ToString();
                k.ika = Convert.ToInt32(dataReader["ika"]);
                k.lisatiedot = dataReader["lisatietoa"].ToString();
                k.asuinpaikka = dataReader["asuinpaikka"].ToString();
                k.hetu = dataReader["hetu"].ToString();
                k.salasana = dataReader["salasana"].ToString();
               
            }

            connection.Close();
            return k;
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public bool paivitaKayttajaTiedot(string tunnus, Kayttaja k)
    {
        bool success = false;
        try
        {
            connection.Open();
            string query = "UPDATE Kayttaja SET e_nimi=@uusi_enimi, s_nimi=@uusi_snimi, ika=@uusi_ika, lisatietoa=@uusi_tieto, asuinpaikka=@uusi_paikka, hetu=@uusi_hetu WHERE kayttajatunnus=@tunnus";
            MySqlCommand cmd = new MySqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@uusi_enimi", k.eNimi);
            cmd.Parameters.AddWithValue("@uusi_snimi", k.sNimi);
            cmd.Parameters.AddWithValue("@uusi_ika", k.ika);
            cmd.Parameters.AddWithValue("@uusi_tieto", k.lisatiedot);
            cmd.Parameters.AddWithValue("@uusi_paikka", k.asuinpaikka);
            cmd.Parameters.AddWithValue("@uusi_hetu", k.hetu);
            cmd.Parameters.AddWithValue("@tunnus", tunnus);

            cmd.ExecuteNonQuery();
            connection.Close();
            success = true;
        }
        catch (Exception)
        {
            
            throw;
            
        }
        return success;
    }
    public bool paivitaKayttajanSalasana(string tunnus, string salasanaEiHashattyna)
    {
        string uusi_salasanaHashattyna = JAMK.ICT.Security.SHA256Hash.getSHA256Hash(salasanaEiHashattyna);
        bool success = false;
        try
        {
            connection.Open();
            string query = "UPDATE Kayttaja SET salasana=@uusi_salasanaHashattyna WHERE kayttajatunnus=@tunnus";
            MySqlCommand cmd = new MySqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@uusi_salasanaHashattyna", uusi_salasanaHashattyna);
            cmd.Parameters.AddWithValue("@tunnus", tunnus);

            cmd.ExecuteNonQuery();
            connection.Close();
            success = true;
        }
        catch (Exception)
        {

            throw;

        }
        return success;
    }
    public void tallennaSuoritus(Suoritus s, int kayttajaID)
    {
        /*
         * Suoritus_ID INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  Kayttaja_ID INTEGER UNSIGNED  NOT NULL  ,
  Alkuaika DATETIME  NULL  ,
  Loppuaika DATETIME  NULL  ,
  laji VARCHAR(20)  NULL  ,
  tuntemukset VARCHAR(255)  NULL    
         * */
        connection.Open();
        //lisätään käyttäjä tietokantaan
       string query = "INSERT INTO Suoritus (Kayttaja_ID, Alkuaika, Loppuaika, laji, tuntemukset)" +
            "VALUES (@kayttajaID, @Alkuaika, @Loppuaika, @laji, @tuntemukset)";
       MySqlCommand cmd = new MySqlCommand(query, connection);
        // be aware of the possibility of the wrong implicit type conversion
        cmd.Parameters.AddWithValue("@kayttajaID", kayttajaID);
        cmd.Parameters.AddWithValue("@Alkuaika", s.alkuAika);
        cmd.Parameters.AddWithValue("@Loppuaika", s.loppuAika);
        cmd.Parameters.AddWithValue("@laji", s.laji);
        cmd.Parameters.AddWithValue("@tuntemukset", s.tuntemukset);
        cmd.ExecuteNonQuery();

        connection.Close();
    }
    // Poikkeus voidaan käsitellä käyttöliittymässä
    public void tallennaKayttaja(Kayttaja k)
    {
        connection.Open();
        string query = "SELECT kayttajatunnus FROM Kayttaja WHERE kayttajatunnus = @kayttajatunnus";

            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("kayttajatunnus", k.kayttajatunnus);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();
        // tarkistetaan onko käyttäjätunnus jo tietokannassa
            if(dataReader.Read())
            {
                connection.Close();
                throw new System.ArgumentException("Kayttajatunnus on varattu!");
            }
        /*
         *   e_nimi VARCHAR(20)  NULL  ,
  s_nimi VARCHAR(45)  NULL  ,
  ika INTEGER UNSIGNED  NULL  ,
  asuinpaikka VARCHAR(45)  NULL  ,
  kayttajatunnus VARCHAR(20)  NOT NULL  UNIQUE,
  salasana VARCHAR(20)  NOT NULL  ,
  lisatietoa VARCHAR(255)  NULL  ,
  hetu VARCHAR(20)  NULL  ,
  rekisteroitymisPvm DATE  NULL    ,
         * */
        //lisätään käyttäjä tietokantaan
        query = "INSERT INTO Kayttaja (e_nimi, s_nimi, ika, asuinpaikka, kayttajatunnus, salasana, lisatietoa, hetu, rekisteroitymisPvm)"+ 
            "VALUES (@e_nimi, @s_nimi, @ika, @asuinpaikka, @kayttajatunnus, @salasana, @lisatietoa, @hetu, @rekisteroitymisPvm)";
        cmd = new MySqlCommand(query, connection);
        // be aware of the possibility of the wrong implicit type conversion
        cmd.Parameters.AddWithValue("@e_nimi", k.eNimi);
        cmd.Parameters.AddWithValue("@s_nimi", k.sNimi);
        cmd.Parameters.AddWithValue("@ika", k.ika.ToString());
        cmd.Parameters.AddWithValue("@asuinpaikka", k.asuinpaikka);
        cmd.Parameters.AddWithValue("@kayttajatunnus", k.kayttajatunnus);
        cmd.Parameters.AddWithValue("@salasana", k.salasana); // MD5Hashays myöhemmin
        cmd.Parameters.AddWithValue("@lisatietoa", k.lisatiedot);
        cmd.Parameters.AddWithValue("@hetu", k.hetu);
        cmd.Parameters.AddWithValue("@rekisteroitymisPvm", DateTime.Now);
        cmd.ExecuteNonQuery();
        
        connection.Close();
        
    }
    public void poistaSuoritus(int suoritus_id, int kayttaja_id)
    {
        try
        {
            connection.Open();

            string query = "DELETE FROM Suoritus WHERE Kayttaja_ID=@kayttaja_id AND Suoritus_ID=@suoritus_id";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@kayttaja_id", kayttaja_id);
            cmd.Parameters.AddWithValue("@suoritus_id", suoritus_id);

            cmd.ExecuteNonQuery();

            connection.Close();
        }
        catch (Exception)
        {
            
            throw;
        }
        

    }

    public void poistaKayttajaIDnPerusteella(int id){
    }

    public void poistaKayttajaNimenPerusteella(string nimi){
    }

    public void poistaKayttaja(Kayttaja k){
    }
}