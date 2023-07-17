
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RSA
{
    class RSA_Encrypt
    {
        static void Main()
        {
            // Читання повідомлення з файлу message.txt
            string message = File.ReadAllText("C:\\Users\\dimar\\source\\repos\\Lr1_Caesar_Cipher\\RSA\\message.txt");

            // Генерація ключової пари RSA
            using (var rsa = new RSACryptoServiceProvider())
            {
                // Збереження приватного ключа
                string privateKey = rsa.ToXmlString(true);
                File.WriteAllText("C:\\Users\\dimar\\source\\repos\\Lr1_Caesar_Cipher\\RSA\\privateKey.xml", privateKey);

                // Збереження публічного ключа
                string publicKey = rsa.ToXmlString(false);
                File.WriteAllText("C:\\Users\\dimar\\source\\repos\\Lr1_Caesar_Cipher\\RSA\\publicKey.xml", publicKey);

                // Шифрування повідомлення
                byte[] encryptedMessage = rsa.Encrypt(Encoding.UTF8.GetBytes(message), true);
                File.WriteAllBytes("C:\\Users\\dimar\\source\\repos\\Lr1_Caesar_Cipher\\RSA\\encryptedMessage.bin", encryptedMessage);

                // Обчислення хеш-суми оригінального повідомлення
                byte[] originalMessageHash = ComputeHash(Encoding.UTF8.GetBytes(message));
                File.WriteAllBytes("C:\\Users\\dimar\\source\\repos\\Lr1_Caesar_Cipher\\RSA\\originalMessageHash.bin", originalMessageHash);
            }
        }

        static byte[] ComputeHash(byte[] data)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(data);
            }
        }
    }
}
