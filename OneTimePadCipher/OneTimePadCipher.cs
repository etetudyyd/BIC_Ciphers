/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIC_Ciphers
{
    public class OneTimePadCipher
    {
        public static string Encrypt(string message, string key)
        {
            string result = string.Empty;
            var binaryMessage = ToBinaryString(message);
            var binaryKey = ToBinaryString(key);

            if (binaryMessage.Length != binaryKey.Length)
            {
                throw new ArgumentException("Length of message and key must be equal.");
            }

            for (int i = 0; i < binaryMessage.Length; i++)
            {
                var messageBit = binaryMessage[i];
                var keyBit = binaryKey[i];
                var encryptedBit = messageBit ^ keyBit;

                result += encryptedBit;
            }

            return FromBinaryString(result);
        }
        private static string ToBinaryString(string text)
        {
            var binary = new StringBuilder();
            foreach (var c in text)
            {
                var binaryChar = Convert.ToString(c, 2).PadLeft(8, '0');
                binary.Append(binaryChar);
            }
            return binary.ToString();
        }

        private static string FromBinaryString(string binary)
        {
            var result = new StringBuilder();
            for (int i = 0; i < binary.Length; i += 8)
            {
                var binaryChar = binary.Substring(i, 8);
                var c = Convert.ToChar(Convert.ToByte(binaryChar, 2));
                result.Append(c);
            }
            return result.ToString();
        }

        public static string Decrypt(string message, string key)
        {
            string result = string.Empty;

            var binaryMessage = ToBinaryString(message);
            var binaryKey = ToBinaryString(key);

            if (binaryMessage.Length != binaryKey.Length)
            {
                throw new ArgumentException("Length of message and key must be equal.");
            }

            for (int i = 0; i < binaryMessage.Length; i++)
            {
                var messageBit = binaryMessage[i];
                var keyBit = binaryKey[i];

                var decryptedBit = messageBit ^ keyBit;

                result += decryptedBit;
            }

            return FromBinaryString(result);
        }
    }

        class Program
    {
        static void Main(string[] args)
        {
            string message = "Мова – це не просто спосіб спілкування, а щось більш значуще. Мова – це всі глибинні пласти духовного життя народу, його історична пам’ять, найцінніше надбання віків. Олесь ГОНЧАР";
            string keyString = "110000 011110 010100 110010 010110 011110";


            string ciphertext = OneTimePadCipher.Encrypt(message, keyString);
            string decryptedPlaintext = OneTimePadCipher.Decrypt(ciphertext, keyString);

            Console.WriteLine("Original message: {0}", message);
            Console.WriteLine("Encrypted message: {0}", ciphertext);
            Console.WriteLine("Decrypted message: {0}", decryptedPlaintext);
        }
    }
}
*/

using System;
using System.Diagnostics;
using System.Text;

class VernamCipher
{
    static string Encrypt(string message, string key)
    {
        // перетворення повідомлення та ключа в біти
        byte[] messageBytes = Encoding.ASCII.GetBytes(message);
        string binaryMessage = "";
        foreach (byte b in messageBytes)
        {
            binaryMessage += Convert.ToString(b, 2).PadLeft(8, '0');
        }
        string[] keyBits = key.Split(' ');

        // шифрування повідомлення
        string encryptedMessage = "";
        for (int i = 0; i < binaryMessage.Length; i++)
        {
            int messageBit = int.Parse(binaryMessage[i].ToString());
            int keyBit = int.Parse(keyBits[i % keyBits.Length]);
            int encryptedBit = messageBit ^ keyBit;
            encryptedMessage += encryptedBit.ToString();
        }

        // перетворення зашифрованого повідомлення з бітів в ASCII символи
        string[] encryptedBytes = new string[messageBytes.Length];
        for (int i = 0; i < messageBytes.Length; i++)
        {
            encryptedBytes[i] = encryptedMessage.Substring(i * 8, 8);
            messageBytes[i] = Convert.ToByte(encryptedBytes[i], 2);
        }
        return Encoding.ASCII.GetString(messageBytes);
    }

    static string Decrypt(string encryptedMessage, string key)
    {
        // перетворення зашифрованого повідомлення та ключа в біти
        byte[] encryptedBytes = Encoding.ASCII.GetBytes(encryptedMessage);
        string binaryMessage = "";
        foreach (byte b in encryptedBytes)
        {
            binaryMessage += Convert.ToString(b, 2).PadLeft(8, '0');
        }
        string[] keyBits = key.Split(' ');

        // розшифрування повідомлення
        string decryptedMessage = "";
        for (int i = 0; i < binaryMessage.Length; i++)
        {
            int encryptedBit = int.Parse(binaryMessage[i].ToString());
            int keyBit = int.Parse(keyBits[i % keyBits.Length]);
            int decryptedBit = encryptedBit ^ keyBit;
            decryptedMessage += decryptedBit.ToString();
        }

        // перетворення розшифрованого повідомлення з бітів в ASCII символи
        string[] decryptedBytes = new string[encryptedBytes.Length];
        for (int i = 0; i < encryptedBytes.Length; i++)
        {
            decryptedBytes[i] = decryptedMessage.Substring(i * 8, 8);
            encryptedBytes[i] = Convert.ToByte(decryptedBytes[i], 2);
        }
        return Encoding.ASCII.GetString(encryptedBytes);
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.InputEncoding = System.Text.Encoding.Unicode;

        string message = "Мова – це не просто спосіб спілкування, а щось більш значуще. Мова – це всі глибинні пласти духовного життя народу, його історична пам’ять, найцінніше надбання віків.Олесь ГОНЧАР";
        string key = "110000 011110 010100 110010 010110 011110";

        Stopwatch stopwatch = new Stopwatch();
        Console.WriteLine("Повідомлення: " + message);
        Console.WriteLine("Ключ: " + key);
        stopwatch.Start();
        string encryptedMessage = Encrypt(message, key);
        stopwatch.Stop();
        Console.WriteLine("Зашифроване повідомлення: " + encryptedMessage);
        long timeduration1 = stopwatch.ElapsedTicks * 1000000000 / Stopwatch.Frequency;
        
        stopwatch.Start();
        string decryptedMessage = Decrypt(encryptedMessage, key);
        stopwatch.Stop();
        long timeduration2 = stopwatch.ElapsedTicks * 1000000000 / Stopwatch.Frequency;
        
        Console.WriteLine("Розшифроване повідомлення: " + decryptedMessage);
        Console.WriteLine("Зашифроване повідомлення:");
        Console.WriteLine("Час: {0} ns. ", timeduration1);
        Console.WriteLine("Розшифроване повідомлення:");
        Console.WriteLine("Час: {0} ns. ", timeduration2);
    }
}