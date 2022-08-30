using EADS.Application.Services;
using EADS.Domain.Models.Entities;

namespace EADS.Test;

public class EncryptionTests
{


    [Fact]
    public void EncryptedDataDecryptsIntoSameData()
    {
        var encryptionService = new EncryptionService();
        string passPhrase = "bababababababababa";
        string data = "Fiddle borders mithril Legolas crowned meaning mend lasts trick wander. Begged answer woods aim size Théodred filth lets tickle cost. Weed comings room windlance offering Elfling boots dam throat skill burst. Council risen East-farthing. The dark fire will not avail you, flame of Udun! Beacon Glamdring club slopes castle. Agreed towards going recoil fishes lordly pointing. Dangers hide size heirlooms traveling Wraiths. Available new Bungo homesick crooked forced." +
                        "Break Morgoth sudden.Race Earth kitchen he'll. Inspection hearts Théoden's.Chokes fire-breathing Tilda.It's some form of Elvish. I can't read it.Swept Tom possible forward lied.Assure Shelob's feverfew sorrow? Servant boneses flatten gloom himself Pippin's quarry sitting fortress sapphire descendants. Fangorn gratitude danger fists thrown? Deluge position absurd particularly cloaks loyalty Nûmenor weapon food slowed tapestry." +
                        "That is no trinket you carry. Also leaves Khazad - dum outrunning stating liable.Doom Worrywort moves foretold arrest gone moved.Arwen held dreamed.Homely startled mouthful misplaced clot - head's yet ransom loses? Uses throat mortal path royal Thengel powerful regret? Mine that wounded jam loveliest rocks spawn opener clean dragon's Tilda penalty.Lied settlement crescent survived coneys matters water part stores crunchable comforts Isen? State enemy fails Gandalf's parapet morninged grew blade nightfall enslaved asking?" +
                        "It completely collared what's guarding gulls air till Gandalf's.Foretold depends in Greenwood rubble. Meadow choking uprooted bid pierce normal union Galadhrim. There is only one Lord of the Ring. Beacon Greenwood lucky? Searching prosperous rain Legolas marched wear black-haired anyway war. Matter machine certain fever Arwen's man within amazing carried current. Expecting smithy's respectable Defiler encouraging. He'd Helm Hammerhand deserves slay free." +
                        "Despite fulfilled rune Southrons? Defending 60 worm thick doors Ring-bearer.Fundin music doilies envelope.Affects twisted engage favorite believe Númenor. What about second breakfast? Seeps adventures Legolas surety presence false brew else uh peril determined.Adjusted summer farewell guard disturb marshes Éowyn! Child finding pigheaded alerts locking hard-won aged myth Fenmarch wisest. Tom introduce both valley." +
                        "Taking Elros net.Nor e-nGilith Númenor maids gibbet rises ran kill. Birds ancient another built joined sneak Hobbitses.All we have to decide is what to do with the time that is given to us.Halflings throttle aside oversized legend? Friendships very stays credit Fangorn glimpse pile ground goat usurpers lucky bitterness? Seen swift insist inquisitive fishes came Sauron's biding. Forced succumb magic brook Rosie? Bandy wearied remembered joking you Lindir homeland aside than began.";
        //var encryptionValue = new EncryptionValue(1000, 128, "~1B2c3D4e5F6g7H8", "1234567890123456");
        var encryptionValue = encryptionService.GenerateEncryptionValue();

        var response = encryptionService.Encrypt(data, encryptionValue, passPhrase);
        var result = encryptionService.Decrypt(response, encryptionValue, passPhrase);

        Assert.True(result.Equals(data));
    }
    [Fact]
    public void EncryptedDataWithAnObject()
    {
        //arrange
        var encryptionService = new EncryptionService();
        string passPhrase = "BabaHarMassaSvampIFickanSin";
        bool match = false;
        TestEncObject targetObject = new() {
            Message = "Fiddle borders mithril Legolas crowned meaning mend lasts trick wander. Begged answer woods aim size Théodred filth lets tickle cost. Weed comings room windlance offering Elfling boots dam throat skill burst. Council risen East-farthing. The dark fire will not avail you, flame of Udun! Beacon Glamdring club slopes castle. Agreed towards going recoil fishes lordly pointing. Dangers hide size heirlooms traveling Wraiths. Available new Bungo homesick crooked forced." +
                        "Break Morgoth sudden.Race Earth kitchen he'll. Inspection hearts Théoden's.Chokes fire-breathing Tilda.It's some form of Elvish. I can't read it.Swept Tom possible forward lied.Assure Shelob's feverfew sorrow? Servant boneses flatten gloom himself Pippin's quarry sitting fortress sapphire descendants. Fangorn gratitude danger fists thrown? Deluge position absurd particularly cloaks loyalty Nûmenor weapon food slowed tapestry." +
                        "That is no trinket you carry. Also leaves Khazad - dum outrunning stating liable.Doom Worrywort moves foretold arrest gone moved.Arwen held dreamed.Homely startled mouthful misplaced clot - head's yet ransom loses? Uses throat mortal path royal Thengel powerful regret? Mine that wounded jam loveliest rocks spawn opener clean dragon's Tilda penalty.Lied settlement crescent survived coneys matters water part stores crunchable comforts Isen? State enemy fails Gandalf's parapet morninged grew blade nightfall enslaved asking?" +
                        "It completely collared what's guarding gulls air till Gandalf's.Foretold depends in Greenwood rubble. Meadow choking uprooted bid pierce normal union Galadhrim. There is only one Lord of the Ring. Beacon Greenwood lucky? Searching prosperous rain Legolas marched wear black-haired anyway war. Matter machine certain fever Arwen's man within amazing carried current. Expecting smithy's respectable Defiler encouraging. He'd Helm Hammerhand deserves slay free." +
                        "Despite fulfilled rune Southrons? Defending 60 worm thick doors Ring-bearer.Fundin music doilies envelope.Affects twisted engage favorite believe Númenor. What about second breakfast? Seeps adventures Legolas surety presence false brew else uh peril determined.Adjusted summer farewell guard disturb marshes Éowyn! Child finding pigheaded alerts locking hard-won aged myth Fenmarch wisest. Tom introduce both valley." +
                        "Taking Elros net.Nor e-nGilith Númenor maids gibbet rises ran kill. Birds ancient another built joined sneak Hobbitses.All we have to decide is what to do with the time that is given to us.Halflings throttle aside oversized legend? Friendships very stays credit Fangorn glimpse pile ground goat usurpers lucky bitterness? Seen swift insist inquisitive fishes came Sauron's biding. Forced succumb magic brook Rosie? Bandy wearied remembered joking you Lindir homeland aside than began.",
            CustomerName = "Bilbo Baggins",
            CustomerNumber = "63",
            CustomerPassword = "JagHarEttJätteSäkertLösenordSomInteDuVetOm123!",
            CustomerPhoneNumber = "0703245443",
            EncryptionValue = encryptionService.GenerateEncryptionValue(),
        };


        //act 
        TestEncObject encryptedObject = new()
        {
            Message = encryptionService.Encrypt(targetObject.Message, targetObject.EncryptionValue, passPhrase),
            CustomerName = encryptionService.Encrypt(targetObject.CustomerName, targetObject.EncryptionValue, passPhrase),
            CustomerNumber = encryptionService.Encrypt(targetObject.CustomerNumber, targetObject.EncryptionValue, passPhrase),
            CustomerPassword = encryptionService.Encrypt(targetObject.CustomerPassword, targetObject.EncryptionValue, passPhrase),
            CustomerPhoneNumber = encryptionService.Encrypt(targetObject.CustomerPhoneNumber, targetObject.EncryptionValue, passPhrase),
            EncryptionValue = targetObject.EncryptionValue
        };

        TestEncObject resultObject = new() {
            Message = encryptionService.Decrypt(encryptedObject.Message, encryptedObject.EncryptionValue, passPhrase),
            CustomerName = encryptionService.Decrypt(encryptedObject.CustomerName, encryptedObject.EncryptionValue, passPhrase),
            CustomerNumber = encryptionService.Decrypt(encryptedObject.CustomerNumber, encryptedObject.EncryptionValue, passPhrase),
            CustomerPassword = encryptionService.Decrypt(encryptedObject.CustomerPassword, encryptedObject.EncryptionValue, passPhrase),
            CustomerPhoneNumber = encryptionService.Decrypt(encryptedObject.CustomerPhoneNumber, encryptedObject.EncryptionValue, passPhrase),
            EncryptionValue = encryptedObject.EncryptionValue
        };


        if (targetObject.Message == resultObject.Message 
            && targetObject.CustomerName == resultObject.CustomerName
            && targetObject.CustomerNumber == resultObject.CustomerNumber
            && targetObject.CustomerPassword == resultObject.CustomerPassword
            && targetObject.CustomerPhoneNumber == resultObject.CustomerPhoneNumber)
        {
            match = true;
        }




        //assert
        Assert.True(match);

    }
    [Fact]
    public void EncryptAndDecryptByteArrayToMatch()
    {
        //arrange
        var encryptionService = new EncryptionService();
        var passPhrase = "TheLordOfTheRingsRules123!";
        var originalFile = GenerateTestByteArrayFromFile();
        var eV = encryptionService.GenerateEncryptionValue();



        //act
        var tolkEnc = encryptionService.EncryptByteArray(originalFile, eV, passPhrase);
        var result = encryptionService.DecryptByteArray(tolkEnc, eV, passPhrase);

        var originalToString = originalFile.ToString();
        var resultToString = result.ToString();
        //assert
        Assert.True(originalToString.Equals(resultToString));
    }
    private byte[] GenerateTestByteArrayFromFile()
    {
        return File.ReadAllBytes($"C:\\Users\\KaiTapper\\Desktop\\EncryptTestFile\\tolkien.pdf.pdf");
    }
}
