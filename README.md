# Dragon's Trap Save Tools

Encrypt or decrypt save states from the [Dragon's Curse remake by Vile1011](https://www.smspower.org/forums/10266-DragonsCurseWBIIITheDragonsTrap).

This was based on C# code extracted from the game's executable by using ILSpy.

## Download the game by Vile1011

From https://www.smspower.org/forums/10266-DragonsCurseWBIIITheDragonsTrap:

- https://www.smspower.org/forums/download.php?id=7338&sid=6519ef9bbc522111706ca01dfca584b1
- [64-bit patch](https://www.smspower.org/forums/download.php?id=7337&sid=6519ef9bbc522111706ca01dfca584b1)

## How to use the tools

**Requirements:** .NET Core SDK

Clone the repository into the game's top directory.

```sh
# takes the ../../SAVE1.decrypt.dt and encrypts it into
# SAVE1.dt
cd game-path/dragontrap-savetools/encrypt
dotnet run

# takes the ../../SAVE1.dt and decrypts it into
# SAVE1.decrypt.dt
cd game-path/dragontrap-savetools/decrypt
dotnet run
```