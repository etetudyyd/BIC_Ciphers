using System;

public class TrithemiusEncryption
{
    private string key;

    public TrithemiusEncryption(string key)
    {
        this.key = key;
    }

    public bool ValidateKey()
    {
        // Валідація ключа - приклад перевірки наявності лише літер англійського алфавіту
        foreach (char c in key)
        {
            if (!Char.IsLetter(c) || !Char.IsLower(c))
            {
                return false;
            }
        }

        return true;
    }

    public string Encrypt(string plaintext)
    {
        string ciphertext = string.Empty;

        for (int i = 0; i < plaintext.Length; i++)
        {
            char plainChar = plaintext[i];
            char keyChar = key[i % key.Length];

            int shift = keyChar - 'a'; // Знаходимо зсув на основі значення символу ключа

            char encryptedChar = ShiftCharacter(plainChar, shift); // Використовуємо зсув для шифрування символу
            ciphertext += encryptedChar;
        }

        return ciphertext;
    }

    public string Decrypt(string ciphertext)
    {
        string plaintext = string.Empty;

        for (int i = 0; i < ciphertext.Length; i++)
        {
            char encryptedChar = ciphertext[i];
            char keyChar = key[i % key.Length];

            int shift = keyChar - 'a'; // Знаходимо зсув на основі значення символу ключа

            char decryptedChar = ShiftCharacter(encryptedChar, -shift); // Використовуємо зсув для розшифрування символу
            plaintext += decryptedChar;
        }

        return plaintext;
    }

    private char ShiftCharacter(char c, int shift)
    {
        const int alphabetSize = 26;
        const char baseChar = 'a';

        // Застосовуємо зсув до символу, зберігаючи його в межах латинської абетки
        int shiftedValue = ((c - baseChar + shift + alphabetSize) % alphabetSize) + baseChar;

        return (char)shiftedValue;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        string key = "secretkey";
        TrithemiusEncryption encryption = new TrithemiusEncryption(key);

        string plaintext = "ryzhkovdmytro";
        Console.WriteLine("Plain Text: " + plaintext);

        if (!encryption.ValidateKey())
        {
            Console.WriteLine("Invalid key.");
            return;
        }

        string ciphertext = encryption.Encrypt(plaintext);
        Console.WriteLine("Encrypted Text: " + ciphertext);

        string decryptedText = encryption.Decrypt(ciphertext);
        Console.WriteLine("Decrypted Text: " + decryptedText);
    }
}
