using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class SaveToolsCore
{
    public static string[] ReadTextFile(string filename, bool fromResource, bool isEncrypted)
    {
        isEncrypted = false;
        Stream stream = null;
        StreamReader streamReader = null;
        List<string> list = new List<string>();
        try
        {
            stream = ((!fromResource) ? new FileStream(filename, FileMode.Open) : GetResourceStream(filename));
            streamReader = new StreamReader(stream);
            for (string text = streamReader.ReadLine(); text != null; text = streamReader.ReadLine())
            {
                if (StringIsEncrypted(text))
                {
                    streamReader?.Close();
                    stream?.Close();
                    return ReadTextFileEncrypted(filename, fromResource, isEncrypted: true);
                }
                list.Add(text);
            }
            return list.ToArray();
        }
        catch (IOException ex)
        {
            throw new Exception("Could not read save file");
        }
        finally
        {
            streamReader?.Close();
            stream?.Close();
        }
    }

    private static bool StringIsEncrypted(string s)
    {
        for (int i = 0; i < s.Length - 1; i++)
        {
            if (s[i] > '\u0096')
            {
                return true;
            }
        }
        return false;
    }

    public static string[] ReadTextFileEncrypted(string filename, bool fromResource, bool isEncrypted)
    {
        RijndaelManaged rijndaelManaged = new RijndaelManaged();
        Stream stream = null;
        CryptoStream cryptoStream = null;
        StreamReader streamReader = null;
        List<string> list = new List<string>();
        try
        {
            stream = ((!fromResource) ? new FileStream(filename, FileMode.Open) : GetResourceStream(filename));
            if (isEncrypted)
            {
                cryptoStream = new CryptoStream(stream, rijndaelManaged.CreateDecryptor(Fnord, Foo), CryptoStreamMode.Read);
                streamReader = new StreamReader(cryptoStream);
            }
            else
            {
                streamReader = new StreamReader(stream);
            }
            for (string text = streamReader.ReadLine(); text != null; text = streamReader.ReadLine())
            {
                list.Add(text);
            }
            return list.ToArray();
        }
        catch (IOException ex)
        {
            throw new Exception("Could not read save file");
        }
        finally
        {
            streamReader?.Close();
            cryptoStream?.Close();
            stream?.Close();
        }
    }

    public static Stream GetResourceStream(string resourceName)
    {
        return GetResourceStream(resourceName, isFullString: false);
    }

    public static Stream GetResourceStream(string resourceName, bool isFullString)
    {
        throw new Exception("GetResourceStream is unimplemented.");
    }

    public static byte[] Fnord
    {
        get
        {
            byte[] password = StringToByte("0Orb2347");
            byte[] salt = StringToByte("20713289");
            PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(password, salt);
            return passwordDeriveBytes.GetBytes(16);
        }
    }

    public static byte[] Foo
    {
        get
        {
            byte[] password = StringToByte("32144131");
            byte[] salt = StringToByte("23856482");
            PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(password, salt);
            return passwordDeriveBytes.GetBytes(16);
        }
    }

    public static byte[] StringToByte(string str)
    {
        UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
        return unicodeEncoding.GetBytes(str);
    }
}