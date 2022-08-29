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
        string passPhrase = "password";
        string data = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).";
        //var encryptionValue = new EncryptionValue(1000, 128, "~1B2c3D4e5F6g7H8", "1234567890123456");
        var encryptionValue = encryptionService.GenerateEncryptionValue();

        var response = encryptionService.Encrypt(data, encryptionValue, passPhrase);
        var result = encryptionService.Decrypt(response, encryptionValue, passPhrase);

        Assert.True(result.Equals(data));
    }
}
