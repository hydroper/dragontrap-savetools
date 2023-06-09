using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class SaveDecryptor
{
    public static void Main()
    {
        var filename = Path.Combine("", "../../SAVE1.dt");
        var resultFilename = Path.Combine("", "../../SAVE1.decrypt.dt");

        /*
        RijndaelManaged rijndaelManaged = new RijndaelManaged();
        // FileStream fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write);
        FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
        // CryptoStream cryptoStream = new CryptoStream(fileStream, rijndaelManaged.CreateEncryptor(Fnord, Foo), CryptoStreamMode.Write);
        CryptoStream cryptoStream = new CryptoStream(fileStream, rijndaelManaged.CreateEncryptor(Fnord, Foo), CryptoStreamMode.Read);
        // StreamWriter streamWriter = new StreamWriter(cryptoStream);
        StreamReader streamReader = new StreamReader(cryptoStream);

        string result = streamReader.ReadToEnd();

        // streamWriter.Close();
        streamReader.Close();
        cryptoStream.Close();
        fileStream.Close();

        using (StreamWriter outputFile = new StreamWriter(resultFilename))
        {
            outputFile.Write(result);
        }
        */

        using (StreamWriter outputFile = new StreamWriter(resultFilename))
        {
            foreach (var line in GameEngine.ReadTextFile(filename, fromResource: false, isEncrypted: false)[0].Split(','))
            {
                outputFile.WriteLine(line);
            }
        }
    }
}