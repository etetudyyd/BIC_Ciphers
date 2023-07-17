using Lr2_EncryptByTheMethodOfInhibition;
using System;

public class CaesarCipher
{
    public string plainText { get; set; }
    public string alphabet { get; set; }
    public int key { get; set; }

    public CaesarCipher(string plainText, string alphabet, int key) { 

        this.plainText = plainText;
        this.alphabet = alphabet;
        this.key = key; 
    
    }
    public static string Encryption(string plainText, int shift, string alphabet)
    {
        char[] plainTextChars = plainText.ToCharArray();
        char[] cipherTextChars = new char[plainTextChars.Length];

        for (int i = 0; i < plainTextChars.Length; i++)
        {
            char plainChar = plainTextChars[i];

            if (Char.IsLetter(plainChar))
            {
                int index = alphabet.IndexOf(plainChar);
                int shiftedIndex = (index + shift) % alphabet.Length;
                cipherTextChars[i] = alphabet[shiftedIndex];
            }
            else
            {
                cipherTextChars[i] = plainChar;
            }
        }

        return new string(cipherTextChars);
    }

    public static string Decryption(string cipherText, int shift, string alphabet)
    {
        return Encryption(cipherText, alphabet.Length - shift, alphabet);
    }
}