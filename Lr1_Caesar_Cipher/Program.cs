using Lr2_EncryptByTheMethodOfInhibition;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr1_Caesar_Cipher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            CaesarCipher textEng = new CaesarCipher("Ryzhkov", "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", 17);
            CaesarCipher textUA = new CaesarCipher("Мова – це не просто спосіб спілкування, а щось більш значуще. Мова – це" +
                "\r\nвсі глибинні пласти духовного життя народу, його історична пам’ять, найцінніше надбання віків. Олесь ГОНЧАР",
                "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯабвгґдеєжзиіїйклмнопрстуфхцчшщьюя", 17);

            Console.WriteLine("\nШИФР ЦЕЗАРЯ");
            

            string caesarCipherTextEng = CaesarCipher.Encryption(textEng.plainText, textEng.key, textEng.alphabet);
            string caesarDecryptedTextEng = CaesarCipher.Decryption(caesarCipherTextEng, textEng.key, textEng.alphabet);
            Console.WriteLine("\nПочатковий текст: " + textEng.plainText);
            Console.WriteLine("\nШифрований текст: " + caesarCipherTextEng);
            Console.WriteLine("\nРозшифрований текст: " + caesarDecryptedTextEng);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string caesarCipherTextUA = CaesarCipher.Encryption(textUA.plainText, textUA.key, textUA.alphabet);
             stopwatch.Stop();
            long timeduration1 = stopwatch.ElapsedTicks * 1000000000 / Stopwatch.Frequency;
            stopwatch.Start();
            string caesarDecryptedTextUA = CaesarCipher.Decryption(caesarCipherTextUA, textUA.key, textUA.alphabet);
            stopwatch.Stop();
            long timeduration2 = stopwatch.ElapsedTicks * 1000000000 / Stopwatch.Frequency;
            Console.WriteLine("\nПочатковий текст: " + textUA.plainText);
            Console.WriteLine("\nШифрований текст: " + caesarCipherTextUA);
            Console.WriteLine("Час: {0} ns. ",timeduration1);
            Console.WriteLine("\nРозшифрований текст: " + caesarDecryptedTextUA);
            Console.WriteLine("Час: {0} ns. ", timeduration2);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("\nШИФР XOR");
            stopwatch.Start();
            string inhibitionCipherText = MethodOfInhibition.Encryption(textUA.plainText, textUA.key);
            stopwatch.Stop();
            long timeduration3 = stopwatch.ElapsedTicks * 1000000000 / Stopwatch.Frequency;
            string inhibitionDecryptedText = MethodOfInhibition.Decryption(inhibitionCipherText, textUA.key);
            long timeduration4 = stopwatch.ElapsedTicks * 1000000000 / Stopwatch.Frequency;
            Console.WriteLine("\nПочатковий текст: " + textUA.plainText);
            Console.WriteLine("\nШифрований текст: " + inhibitionCipherText);
            Console.WriteLine("Час: {0} ns. ", timeduration3);
            Console.WriteLine("\nРозшифрований текст: " + inhibitionDecryptedText);
            Console.WriteLine("Час: {0} ns. ", timeduration4);
        }
    }
}
