# Dragon's Trap Save Tools

## Equip item state

- NotFound
- NotEquipped
- Equipped

## Save data

- Encryption: RIJNDAEL_256
- fnord hex. = E7E58D8C1548ECC2EFAEFC65DAED036E
- foo hex. = 2C5FD628738FE4418143946C9A8D4178

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class EncryptionKeys
{
    public static byte[] FNORD = new byte[] { 0xE7, 0xE5, 0x8D, 0x8C, 0x15, 0x48, 0xEC, 0xC2, 0xEF, 0xAE, 0xFC, 0x65, 0xDA, 0xED, 0x03, 0x6E };
    public static byte[] FOO = new byte[] { 0x2C, 0x5F, 0xD6, 0x28, 0x73, 0x8F, 0xE4, 0x41, 0x81, 0x43, 0x94, 0x6C, 0x9A, 0x8D, 0x41, 0x78 };
}
```