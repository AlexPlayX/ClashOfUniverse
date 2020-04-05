using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class Encryption
{
    private AesCryptoServiceProvider encrypt;

    public Encryption()
    {
        encrypt = new AesCryptoServiceProvider();
        encrypt.BlockSize = 128;
        encrypt.KeySize = 128;
        encrypt.IV = Encoding.UTF8.GetBytes("shpois");
        encrypt.Key = Encoding.UTF8.GetBytes("universe");
        encrypt.Mode = CipherMode.CBC;
        encrypt.Padding = PaddingMode.PKCS7;
    }
    
    public byte[] Encrypt(string plainText)
    {
        byte[] encrypted;
        ICryptoTransform encryptor = encrypt.CreateEncryptor(encrypt.Key, encrypt.IV);
        using (MemoryStream msEncrypt = new MemoryStream())
        {
            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(plainText);
                }
                encrypted = msEncrypt.ToArray();
            }
        }
        return encrypted;
    }
    public string Decrypt(byte[] cipherText)
    {
        string plaintext;
        ICryptoTransform decryptor = encrypt.CreateDecryptor(encrypt.Key, encrypt.IV);

        using (MemoryStream msDecrypt = new MemoryStream(cipherText))
        {
            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                {
                    plaintext = srDecrypt.ReadToEnd();
                }
            }
        }
        return plaintext;
    }
}
