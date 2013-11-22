using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Yksinkertainen MD5Hashin teko
/// </summary>
namespace JAMK.ICT.Security { 

public static class MD5Hash
{
//http://fi.wikipedia.org/wiki/MD5
    public static string getMd5Hash(string input)
    {
        MD5 md5Hasher = MD5.Create();
        byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }
    public static bool verifyMd5Hash(string input, string hash)
    {
        string hashOfInput = getMd5Hash(input);
        StringComparer comparer = StringComparer.OrdinalIgnoreCase;
        if (0 == comparer.Compare(hashOfInput, hash))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
public static class SHA256Hash
//http://fi.wikipedia.org/wiki/SHA
{
  public static string getSHA256Hash(string input)
  {
    SHA256 sha256Hasher = SHA256.Create();
    byte[] data = sha256Hasher.ComputeHash(Encoding.Default.GetBytes(input));
    StringBuilder sBuilder = new StringBuilder();
    for (int i = 0; i < data.Length; i++)
    {
      sBuilder.Append(data[i].ToString("x2"));
    }
    return sBuilder.ToString();
  }
  public static bool verifySHA256Hash(string input, string hash)
  {
    string hashOfInput = getSHA256Hash(input);
    StringComparer comparer = StringComparer.OrdinalIgnoreCase;
    if (0 == comparer.Compare(hashOfInput, hash))
    {
      return true;
    }
    else
    {
      return false;
    }
  }

}
}