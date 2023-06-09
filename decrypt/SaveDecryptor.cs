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

        using (StreamWriter outputFile = new StreamWriter(resultFilename))
        {
            foreach (var line in SaveToolsCore.ReadTextFile(filename, fromResource: false, isEncrypted: false))
            {
                outputFile.WriteLine(line);
            }
        }
    }
}