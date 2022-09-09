using EADS.Domain.Models.DTOs;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;

namespace EADS.RazorDemo.Services
{
    public class APIService : IAPIService
    {
        private HttpClient client;
        private readonly string _baseAdress;
        public APIService(string? baseAdress = "https://localhost:7195/api/EADSDemoObjects/")
        {
            _baseAdress = baseAdress!;
            client = new HttpClient();
            client.BaseAddress = new Uri(_baseAdress);
        }
        public async Task<bool> Delete(string id)
        {
            var response = await client.DeleteAsync(client.BaseAddress!.ToString() + $"?id={id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<DemoPresentationObjectDTO?> Get(string id, string passPhrase)
        {
            DemoPresentationObjectDTO? response = await client.GetFromJsonAsync<DemoPresentationObjectDTO>(_baseAdress + $"?id={id}&passphrase={passPhrase}");
            if (response == null)
            {
                return null;
            }
            return response;
        }

        public async Task<string?> Post(DemoPresentationObjectDTO demoPresentationObjectDTO)
        {
            var response = await client.PostAsJsonAsync<DemoPresentationObjectDTO>(_baseAdress ,demoPresentationObjectDTO);
            var content = response.Content;
            EADSResponsePostDTO contentAsObject = await content.ReadFromJsonAsync<EADSResponsePostDTO>();
            if (response.IsSuccessStatusCode)
            {
                return contentAsObject.Id;
            }
            else
            {
                return null;
            }
        }
        public string GeneratePassPhraseAsync()
        {
            var salt = Encoding.UTF8.GetBytes(RandomNumberGenerator.GetInt32(1000, 9999).ToString());
            return Convert.ToBase64String(salt);
        }

    }
    public interface IAPIService
    {
        Task<string?> Post(DemoPresentationObjectDTO demoPresentationObjectDTO);
        Task<DemoPresentationObjectDTO?> Get(string id, string passPhrase);
        Task<bool> Delete(string id);
        string GeneratePassPhraseAsync();
    }
    
}

