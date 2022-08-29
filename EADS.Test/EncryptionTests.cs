using EADS.Application.Services;
using EADS.Domain.Interfaces.Services;
using EADS.Domain.Models.Entities;

namespace EADS.Test;

public class EncryptionTests
{
    

    [Fact]
    public void EncryptedDataDecryptsIntoSameData()
    {
        var encryptionService = new EncryptionService();
        string passPhrase = "Banan123";
        string data = "Hej jag heter Torsten och jag har 42 stycken kossor";
        var encryptionValue = encryptionService.GenerateEncryptionValue();

        var response = encryptionService.Encrypt(data,encryptionValue, passPhrase);
        var result = encryptionService.Decrypt(response, encryptionValue, passPhrase);

        Assert.True(result.Equals(data));
    }
}
