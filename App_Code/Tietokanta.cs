using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for Tietokanta
/// </summary>
public class Tietokanta
{
    private string GetMD5Hash(string input)
    {
        System.Security.Cryptography.MD5CryptoServiceProvider x =
            new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
        bs = x.ComputeHash(bs);
        System.Text.StringBuilder s = new System.Text.StringBuilder();
        foreach (byte b in bs)
        {
            s.Append(b.ToString("x2").ToLower());
        }
        string password = s.ToString();
        return password;
    }

    private static string connString =
        "Server=mysql.labranet.jamk.fi;Database=H3100_2;Uid=H3100;Pwd=RiCkbUgrASh5r9y9zpfWSAKQIxynJxZY;";
	
    private MySqlConnection connection = new MySqlConnection(connString);
    public Tietokanta()
	{
		
	}


    public List<Suoritus> haeSuorituksetKayttajanIDnPerusteella(string kayttajanId)
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
                suor = new Suoritus((int)dataReader["Suoritus_ID"], (int)dataReader["Kayttaja_ID"],
                    (DateTime)dataReader["Alkuaika"], (DateTime)dataReader["Loppuaika"],
                    dataReader["laji"].ToString(), dataReader["tuntemukset"].ToString());
                suoritukset.Add(suor);
            }
        connection.Close();
        return suoritukset;
    }
    // Poikkeus, jos salasana on väärä
    public Kayttaja haeKayttaja(string kayttajatunnus, string salasana)
    {
        return null;
    }
    public Kayttaja palautaKayttaja(int id){

        return null;
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
    public void poistaKayttajaIDnPerusteella(int id){
    }

    public void poistaKayttajaNimenPerusteella(string nimi){
    }

    public void poistaKayttaja(Kayttaja k){
    }
}