﻿
using EADS.Domain.Interfaces.Services;
using EADS.Domain.Models.Entities;
using System.Security.Cryptography;
using System.Text;

namespace EADS.Application.Services;

public class EncryptionService : IEncryptionService
{
    //This has to be generated in the future.
    private const string initVector = "~1B2c3D4e5F6g7H8"; //Has to be 16-bytes
    private const int keySize = 256; //can be 256, 192 or 128
    private const string StrHashName = "SHA1"; //can also use "MD5", "SHA1"
    private readonly HashAlgorithmName hash = HashAlgorithmName.SHA512;
    private const int min = 800;
    private const int max = 1200;

    //Decrypts a Single String Value and Returns it.
    /// <summary>
    /// Decrypts a string value with it's EncryptionValue(s) using the same passPhrase. 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="eV"></param>
    /// <param name="passPhrase"></param>
    /// <returns>Decrypted String Value</returns>
    public string Decrypt(string data, EncryptionValue eV, string passPhrase)
    {
        byte[] bytes = Encoding.ASCII.GetBytes(eV.InitVector);
        byte[] rgbSalt = Encoding.ASCII.GetBytes(eV.SaltValue);
        byte[] buffer = Convert.FromBase64String(data);
        //byte[] rgbKey = new PasswordDeriveBytes(passPhrase, rgbSalt, StrHashName, eV.PassIterations).GetBytes(eV.KeySize / 8);
        byte[] rgbKey = new Rfc2898DeriveBytes(passPhrase, rgbSalt, eV.PassIterations, hash).GetBytes(eV.KeySize / 8);

        var managed = Aes.Create("AesManaged");
        managed.Padding = PaddingMode.PKCS7;
        managed.Mode = CipherMode.CBC;
        ICryptoTransform transform = managed.CreateDecryptor(rgbKey, bytes);
        MemoryStream stream = new(buffer);
        CryptoStream stream2 = new(stream, transform, CryptoStreamMode.Read);
        byte[] buffer5 = new byte[buffer.Length];
        int count = stream2.Read(buffer5, 0, buffer5.Length);
        stream.Close();
        stream2.Close();
        return Encoding.UTF8.GetString(buffer5, 0, count);
    }

    //Encrypts a Single String and returns it.
    /// <summary>
    /// Encrypts string value "data" with the EncryptionValues generated by the API with "SHA256" Passwordderivedbytes using AES with a passPhrase from external source.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="eV"></param>
    /// <param name="passPhrase"></param>
    /// <returns>Encrypted String Value</returns>
    public string Encrypt(string data, EncryptionValue eV, string passPhrase)
    {
        byte[] bytes = Encoding.ASCII.GetBytes(eV.InitVector);
        byte[] rgbSalt = Encoding.ASCII.GetBytes(eV.SaltValue);
        byte[] buffer = Encoding.UTF8.GetBytes(data);
        //byte[] rgbKey = new PasswordDeriveBytes(passPhrase, rgbSalt, StrHashName, eV.PassIterations).GetBytes(eV.KeySize / 8);
        byte[] rgbKey = new Rfc2898DeriveBytes(passPhrase, rgbSalt, eV.PassIterations, hash).GetBytes(eV.KeySize / 8);

        var managed = Aes.Create("AesManaged");
        managed.Padding = PaddingMode.PKCS7;
        
        managed.Mode = CipherMode.CBC;
        ICryptoTransform transform = managed.CreateEncryptor(rgbKey, bytes);
        MemoryStream stream = new();
        CryptoStream stream2 = new(stream, transform, CryptoStreamMode.Write);
        stream2.Write(buffer, 0, buffer.Length);
        stream2.FlushFinalBlock();
        byte[] inArray = stream.ToArray();
        stream.Close();
        stream2.Close();
        return Convert.ToBase64String(inArray);
    }

    //Generates an associated EncryptionValue Object with Encryption values specific to the resource.
    public EncryptionValue GenerateEncryptionValue() => new(RandomNumberGenerator.GetInt32(min, max), keySize, initVector, Convert.ToBase64String(GenerateSalt(RandomNumberGenerator.GetInt32(1, 9999))));

    private byte[] GenerateSalt(int v) => Encoding.UTF8.GetBytes(v.ToString());
}                                               
