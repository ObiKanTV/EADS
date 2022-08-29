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
        EncryptionValue GenerateEncryptionValue();
    }
}
