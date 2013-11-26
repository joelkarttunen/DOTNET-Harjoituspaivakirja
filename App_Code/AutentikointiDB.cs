using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AutentikointiDB
/// </summary>
public static class AutentikointiDB
{
    public static string ConnectionString;
    private static MySqlConnection myConn;
    private static bool OpenMyConnection()
    {
        try
        {
            System.Diagnostics.Debug.Print(ConnectionString);
            myConn = new MySqlConnection(AutentikointiDB.ConnectionString);
            myConn.Open();
            return true;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Print(ex.Message);
            throw new Exception(ex.Message);
            //return false;
        }
    }
    private static void CloseMyConnection()
    {
        try
        {
            // Jälkimmäistä ei suoriteta, jos ensimmäinen ehto ei ole voimassa.
            if (myConn != null & myConn.State == System.Data.ConnectionState.Open)
                myConn.Close();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Print(ex.Message);
        }
    }
    public static bool isUserNameInUse(string username)
    {
       
        try
        {
            bool loytyy = false;
              if (OpenMyConnection())
            {
                 using (MySqlCommand command = new MySqlCommand("SELECT kayttajatunnus FROM Kayttaja WHERE"
                                       + " kayttajatunnus LIKE @Parametri", myConn))
                {
                    MySqlParameter param = new MySqlParameter("Parametri", SqlDbType.VarChar);
                    param.Value = username;
                    command.Parameters.Add(param);

                    using (MySqlDataReader rdr = command.ExecuteReader())
                    {
                        if (rdr.Read())
                            loytyy = true;
                        else
                            loytyy = false;
                     }
                }
                CloseMyConnection();
                return loytyy;
            }
            else
            {
                throw new Exception("Cannot open my connection to database");
            }
        }
        catch (Exception ex)
        {
            
            throw new Exception(ex.Message);
        }
    }
    public static bool CreateNewUser(string username, string email, string password, bool hashPassword)
    {
        try
        {
            if (OpenMyConnection())
            {
                string passu = password;
                if (hashPassword)
                    passu = JAMK.ICT.Security.SHA256Hash.getSHA256Hash(passu);
                string sql = string.Format("INSERT INTO Kayttaja (kayttajatunnus, email, salasana) VALUES ('{0}','{1}','{2}')", username, email, passu);
                MySqlCommand command = new MySqlCommand(sql, myConn);
                command.ExecuteNonQuery();
                CloseMyConnection();
                return true;
            }
            else
            {
                throw new Exception("Cannot open myconnection to database");
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public static bool Login(string username, string password)
    {
        // Tarkistetaan käyttäjä ja salasana tietokannasta
        //Kannassa salasana on häshättynä
        try
        {
            
            // Varsinainen tarkistus tietokannasta
            // ensin "pöljän pojan tarkistus"
            if (username.Length * password.Length == 0)
            {
               // return false;
                throw new Exception("Salasanaa tai käyttäjätunnusta ei ollut");
            }
            else
            {
                // Häshätään käyttäjän antama password
                string hashattyPwd = JAMK.ICT.Security.SHA256Hash.getSHA256Hash(password);
                //Kokeillaan tietokannasta
                if (OpenMyConnection())
                {
                    //username += "%";
                    
                    
                    string sqlQuery = "SELECT count(*) FROM Kayttaja WHERE kayttajatunnus LIKE @Parametri AND salasana LIKE @Password";
                    MySqlCommand command = new MySqlCommand(sqlQuery, myConn);



                    command.Parameters.AddWithValue("@Parametri", username);
                    command.Parameters.AddWithValue("@Password", hashattyPwd);

                    /*
                    //Lisätään komennolle kaksi parametria
                    MySqlParameter param = new MySqlParameter("Parametri", SqlDbType.VarChar);
                    param.Value = username;
                    command.Parameters.Add(param);

                    MySqlParameter param2 = new MySqlParameter("Password", SqlDbType.VarChar);
                    //hashattyPwd += "%";
                    param2.Value = "'"+hashattyPwd+"'";
                    command.Parameters.Add(param2);
                    */
                    /*
                    string sqlQuery = "SELECT count(*) FROM Kayttaja WHERE kayttajatunnus LIKE "+username +
                        " AND salasana LIKE '"+hashattyPwd+"'";
                    MySqlCommand command = new MySqlCommand(sqlQuery, myConn);
                     * */
                    //Suoritetaan kysely kantaan
                    int i = 0;

                        try
                        {
                            object userNameObj = command.ExecuteScalar();
                            if (userNameObj == null)
                                return false;

                                i = Convert.ToInt32(userNameObj);
                            //i = (Int32)command.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            string testi = ex.Message.ToString();
                            throw;
                        }
                                        
                    if (i == 1)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            //return false;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Print(ex.Message);
            return false;
        }

    }
}