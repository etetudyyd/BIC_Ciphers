using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr2_EncryptByTheMethodOfInhibition
{
    public class MethodOfInhibition
    {
        public static string Encryption(string plainText, int key)
        {
            char[] plainTextChars = plainText.ToCharArray();
            string ciphertext = string.Empty;

            for (int i = 0; i < plainTextChars.Length; i++)
            {
                char plainChar = plainTextChars[i];

                plainChar = (char)(plainText[i] ^ key);

                ciphertext += plainChar;
            }
            return ciphertext;
        }
        public static string Decryption(string cipherText, int key)
        {
            return Encryption(cipherText, key);
        }
    }
}










































































        /*
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            string plaintext = ("Мова – це не просто спосіб спілкування, а щось більш значуще. Мова – це всі глибинні пласти духовного життя народу, його історична пам’ять, найцінніше надбання віків. Олесь ГОНЧАР");
            string key = "ключ";
            string ciphertext = Encrypt(plaintext, key);
            string decryptedText = Decrypt(ciphertext, key);

            Console.WriteLine("Plain text: " + plaintext);
            Console.WriteLine("Encrypted text: " + ciphertext);
            Console.WriteLine("Decrypted text: " + decryptedText);
        }

        static string Encrypt(string plaintext, string key)
        {
            string alphabet = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
            int keyIndex = 0;
            StringBuilder ciphertext = new StringBuilder();

            foreach (char c in plaintext)
            {
                int index = alphabet.IndexOf(Char.ToLower(c));
                if (index >= 0)
                {
                    int keyCharIndex = alphabet.IndexOf(Char.ToLower(key[keyIndex]));
                    int newIndex = (index + keyCharIndex) % alphabet.Length;
                    char newChar = Char.IsLower(c) ? alphabet[newIndex] : Char.ToUpper(alphabet[newIndex]);
                    ciphertext.Append(newChar);
                    keyIndex = (keyIndex + 1) % key.Length;
                }
                else
                {
                    ciphertext.Append(c);
                }
            }

            return ciphertext.ToString();
        }

        static string Decrypt(string ciphertext, string key)
        {
            string alphabet = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
            int keyIndex = 0;
            StringBuilder plaintext = new StringBuilder();

            foreach (char c in ciphertext)
            {
                int index = alphabet.IndexOf(Char.ToLower(c));
                if (index >= 0)
                {
                    int keyCharIndex = alphabet.IndexOf(Char.ToLower(key[keyIndex]));
                    int newIndex = (index - keyCharIndex + alphabet.Length) % alphabet.Length;
                    char newChar = Char.IsLower(c) ? alphabet[newIndex] : Char.ToUpper(alphabet[newIndex]);
                    plaintext.Append(newChar);
                    keyIndex = (keyIndex + 1) % key.Length;
                }
                else
                {
                    plaintext.Append(c);
                }
            }

            return plaintext.ToString();
        }
    }*/
    
