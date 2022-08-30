using EADS.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADS.Domain.Interfaces.Services
{
    public interface IEncryptionService
    {
        //Encrypts a Single String and returns it.
        public string Encrypt(string data, EncryptionValue encrValue, string passPhrase);
        //Decrypts a Single String Value and Returns it.
        public string Decrypt(string data, EncryptionValue encrValue, string passPhrase);
        //Decrypts a hashed string into a byte array.
        byte[] DecryptByteArray(string data, EncryptionValue eV, string passPhrase);
        //encrypts a byte array (from file) to a hashed string. 
        string EncryptByteArray(byte[] data, EncryptionValue eV, string passPhrase);
        EncryptionValue GenerateEncryptionValue();
    }
}
