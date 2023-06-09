using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class SaveEncryptor
{
    public static void Main()
    {
        var filename = Path.Combine("", "../../SAVE1.decrypt.dt");
        var resultFilename = Path.Combine("", "../../SAVE1.dt");

        RijndaelManaged rijndaelManaged = new RijndaelManaged();
        FileStream fileStream = new FileStream(resultFilename, FileMode.Create, FileAccess.Write);
        CryptoStream cryptoStream = new CryptoStream(fileStream, rijndaelManaged.CreateEncryptor(GameEngine.Fnord, GameEngine.Foo), CryptoStreamMode.Write);

        using (StreamWriter outputFile = new StreamWriter(cryptoStream))
        {
            outputFile.Write(File.ReadAllText(filename, Encoding.UTF8));
        }

        cryptoStream.Close();
        fileStream.Close();
    }
}