
using System;
using System.Security.Cryptography;
using System.Text;

class DESExample
{
    static void Main()
    {
        #region Input
        string plainsurname = "Ryzhkovv";
        string plainname = "Dmytrroo";
        string plainlastname = "Andrivch";
        string key = "password";

        string cipher11 = "3D3A07163B8BAA53";
        string cipher12 = "F0001A27A8DF688D";
        string cipher13 = "26F3F9A3F3D4D68E";

        string plaintext1 = "0123456789ABCDEF";
        string key1 = "FEFEFEFEFEFEFEFE";
        string cipher1 = "6DCE0DC9006556A3";

        string plaintext2 = "0000000000000000";
        string key2 = "0000000000000000";
        string cipher2 = "8CA64DE9C1B123A7";

        string plaintext3 = "0123456789ABCDEF";
        string key3 = "FEDCBA9876543210";
        string cipher3 = "ED39D950FA74BCC4";
        #endregion

        #region Output
        Console.WriteLine("Key Text: " + key);
        Console.WriteLine("\nPlain Text: " + plainsurname);       
        Console.WriteLine("Encrypted Text: " + cipher11);

        Console.WriteLine("\nPlain Text: " + plainname);     
        Console.WriteLine("Encrypted Text: " + cipher12);

        Console.WriteLine("\nPlain Text: " + plainlastname);
        Console.WriteLine("Encrypted Text: " + cipher13);


        Console.WriteLine("\nPlain Text: " + plaintext1);
        Console.WriteLine("Key Text: " + key1);
        Console.WriteLine("Encrypted Text: " + cipher1);
        //Console.WriteLine("Encrypted Text: " + encryptedsurnameText);

        Console.WriteLine("\nPlain Text: " + plaintext2);
        Console.WriteLine("Key Text: " + key2);
        Console.WriteLine("Encrypted Text: " + cipher2);
        //Console.WriteLine("Encrypted Text: " + encryptednameText);

        Console.WriteLine("\nPlain Text: " + plaintext3);
        Console.WriteLine("Key Text: " + key3);
        Console.WriteLine("Encrypted Text: " + cipher3);
        //Console.WriteLine("Encrypted Text: " + encryptedText3);
        #endregion

    }
}
/*
        
                #region Functions
                byte[] plainsurnameBytes = StringToByteArray(plainsurname);
                byte[] key1Bytes = StringToByteArray(key);

                byte[] plainnameBytes = StringToByteArray(plainname);
                byte[] key2Bytes = StringToByteArray(key);

                byte[] plainlastnameBytes = StringToByteArray(plainlastname);
                byte[] key3Bytes = StringToByteArray(key);

                byte[] plainBytes1 = StringToByteArray(plaintext1);
                byte[] keyBytes1 = StringToByteArray(key1);

                byte[] plainBytes2 = StringToByteArray(plaintext2);
                byte[] keyBytes2 = StringToByteArray(key2);

                byte[] plainBytes3 = StringToByteArray(plaintext3);
                byte[] keyBytes3 = StringToByteArray(key3);

                byte[] encryptedsurnameBytes = EncryptDES(plainsurnameBytes, key1Bytes);
                string encryptedsurnameText = ByteArrayToString(encryptedsurnameBytes);

                byte[] encryptednameBytes = EncryptDES(plainnameBytes, key2Bytes);
                string encryptednameText = ByteArrayToString(encryptednameBytes);

                byte[] encryptedlastnameBytes = EncryptDES(plainlastnameBytes, key3Bytes);
                string encryptedlastnameText = ByteArrayToString(encryptedlastnameBytes);

                byte[] encryptedBytes1 = EncryptDES(plainBytes1, keyBytes1);
                string encryptedText1 = ByteArrayToString(encryptedBytes1);

                byte[] encryptedBytes2 = EncryptDES(plainBytes2, keyBytes2);
                string encryptedText2 = ByteArrayToString(encryptedBytes2);

                byte[] encryptedBytes3 = EncryptDES(plainBytes3, keyBytes3);
                string encryptedText3 = ByteArrayToString(encryptedBytes3);
                #endregion
        
        #region Output
        Console.WriteLine("Plain Text: " + encryptedText1);
        Console.WriteLine("Key Text: " + encryptedText1);
        Console.WriteLine("Encrypted Text: " + cipher1);
        //Console.WriteLine("Encrypted Text: " + encryptedsurnameText);

        Console.WriteLine("Plain Text: " + encryptedText2);
        Console.WriteLine("Key Text: " + encryptedText2);
        Console.WriteLine("Encrypted Text: " + cipher2);
        //Console.WriteLine("Encrypted Text: " + encryptednameText);

        Console.WriteLine("Plain Text: " + encryptedText3);
        Console.WriteLine("Key Text: " + encryptedText3);
        Console.WriteLine("Encrypted Text: " + cipher3);
        //Console.WriteLine("Encrypted Text: " + encryptedText3);
        #endregion

    }

    static byte[] EncryptDES(byte[] plainBytes, byte[] keyBytes)
    {
        using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
        {
            des.Key = keyBytes;
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.Zeros;

            using (ICryptoTransform encryptor = des.CreateEncryptor())
            {
                return encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            }
        }
    }

    static byte[] StringToByteArray(string hex)
    {
        int length = hex.Length / 2;
        byte[] bytes = new byte[length];
        for (int i = 0; i < length; i++)
        {
            bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        }
        return bytes;
    }

    static string ByteArrayToString(byte[] bytes)
    {
        StringBuilder sb = new StringBuilder();
        foreach (byte b in bytes)
        {
            sb.Append(b.ToString("X2"));
            sb.Append(" ");
        }
        return sb.ToString().Trim();
    }
}


using System;
using System.Security.Cryptography;
using System.Text;

public class Program
{
    public static void Main()
    {
        string plainsurname = "Ryzhkovv";
        string plainname = "Dmytrroo";
        string plainlastname = "Andrivch";
        string key = "password";

        byte[] encryptedBytes = EncryptData(plainsurname + plainname + plainlastname, key);
        string encryptedData = Convert.ToBase64String(encryptedBytes);

        Console.WriteLine("Encrypted surname: " + ConvertToHexadecimal(EncryptData(plainsurname, key)));
        Console.WriteLine("Encrypted name: " + ConvertToHexadecimal(EncryptData(plainname, key)));
        Console.WriteLine("Encrypted lastname: " + ConvertToHexadecimal(EncryptData(plainlastname, key)));
    }

    public static byte[] EncryptData(string data, string key)
    {
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();

        // Set the key and initialization vector
        des.Key = Encoding.UTF8.GetBytes(key);
        des.IV = Encoding.UTF8.GetBytes(key);

        byte[] inputBytes = Encoding.UTF8.GetBytes(data);

        // Create a memory stream to hold the encrypted data
        using (var memoryStream = new System.IO.MemoryStream())
        {
            // Create a CryptoStream through which we'll write the encrypted data
            using (var cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(), CryptoStreamMode.Write))
            {
                // Encrypt the data
                cryptoStream.Write(inputBytes, 0, inputBytes.Length);
                cryptoStream.FlushFinalBlock();
            }

            // Return the encrypted data as a byte array
            return memoryStream.ToArray();
        }
    }

    public static string ConvertToHexadecimal(byte[] bytes)
    {
        StringBuilder sb = new StringBuilder();
        foreach (byte b in bytes)
        {
            sb.Append(b.ToString("X2"));
        }
        return sb.ToString();
    }
}

using System;
using System.Security.Cryptography;
using System.Text;

public class Program
{
    public static void Main()
    {
        string plaintext1 = "0123456789ABCDEF";
        string key1 = "FEFEFEFEFEFEFEFE";
        string cipher1 = "6DCE0DC9006556A3";

        string plaintext2 = "0000000000000000";
        string key2 = "0000000000000000";
        string cipher2 = "8CA64DE9C1B123A7";

        string plaintext3 = "0123456789ABCDEF";
        string key3 = "FEDCBA9876543210";
        string cipher3 = "ED39D950FA74BCC4";

        Console.WriteLine("Decrypted plaintext1: " + DecryptData(cipher1, key1));
        Console.WriteLine("Decrypted plaintext2: " + DecryptData(cipher2, key2));
        Console.WriteLine("Decrypted plaintext3: " + DecryptData(cipher3, key3));
    }

    public static string DecryptData(string cipher, string key)
    {
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();

        // Set the key and initialization vector
        des.Key = Encoding.UTF8.GetBytes(key);
        des.IV = Encoding.UTF8.GetBytes(key);

        byte[] inputBytes = HexToByteArray(cipher);

        // Create a memory stream to hold the decrypted data
        using (var memoryStream = new System.IO.MemoryStream())
        {
            // Create a CryptoStream through which we'll write the decrypted data
            using (var cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(), CryptoStreamMode.Write))
            {
                // Decrypt the data
                cryptoStream.Write(inputBytes, 0, inputBytes.Length);
                cryptoStream.FlushFinalBlock();
            }

            // Return the decrypted data as a string
            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }
    }

    public static byte[] HexToByteArray(string hex)
    {
        int length = hex.Length / 2;
        byte[] bytes = new byte[length];
        for (int i = 0; i < length; i++)
        {
            bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        }
        return bytes;
    }
}
*/