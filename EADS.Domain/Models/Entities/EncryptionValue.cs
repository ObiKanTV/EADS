using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EADS.Domain.Models.Entities;

public class EncryptionValue : EntityBase
{
    public EncryptionValue(int passIterations, int keySize, string initVector, string saltValue)
    {
        PassIterations = passIterations;
        KeySize = keySize;
        InitVector = initVector;
        SaltValue = saltValue;
    }
    public int PassIterations { get; set; }
    public int KeySize { get; set; }
    public string InitVector { get; set; }
    public string SaltValue { get; set; }
}

