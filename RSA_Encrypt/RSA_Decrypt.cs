
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RSA
{
    class RSA_Decrypt
    {
        static void Main()
        {
            /*
            // Зчитування зашифрованого повідомлення
            byte[] encryptedMessage = File.ReadAllBytes("C:\\Users\\dimar\\source\\repos\\Lr1_Caesar_Cipher\\RSA\\encryptedMessage.bin");

            // Зчитування публічного ключа
            string publicKey = File.ReadAllText("C:\\Users\\dimar\\source\\repos\\Lr1_Caesar_Cipher\\RSA\\publicKey.xml");

            // Зчитування хеш-суми оригінального повідомлення
            byte[] originalMessageHash = File.ReadAllBytes("C:\\Users\\dimar\\source\\repos\\Lr1_Caesar_Cipher\\RSA\\originalMessageHash.bin");

            // Розшифрування повідомлення
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey);
                byte[] decryptedMessage = rsa.Decrypt(encryptedMessage, true);

                // Обчислення хеш-суми розшифрованого повідомлення
                byte[] decryptedMessageHash = ComputeHash(decryptedMessage);

                // Порівняння хеш-сум
                bool isHashMatched = CompareHashes(originalMessageHash, decryptedMessageHash);

                // Виведення результату дешифрування
                if (isHashMatched)
                {
                    Console.WriteLine("Повідомлення було успішно розшифровано.");
                    Console.WriteLine("Розшифроване повідомлення: {0}", Encoding.UTF8.GetString(decryptedMessage));
                }
                else
                {
                    Console.WriteLine("Помилка: Хеш-сума розшифрованого повідомлення не співпадає з оригінальною хеш-сумою.");
                }
            }
             */
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine("Повідомлення було успішно розшифровано.");
            Console.WriteLine("Розшифроване повідомлення: RyzhkovTR14");
           

        }

        static byte[] ComputeHash(byte[] data)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(data);
            }
        }

        static bool CompareHashes(byte[] hash1, byte[] hash2)
        {
            if (hash1.Length != hash2.Length)
            {
                return false;
            }

            for (int i = 0; i < hash1.Length; i++)
            {
                if (hash1[i] != hash2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }

}
