using EADS.Domain.Models.DTOs;
using Microsoft.AspNetCore.Http;

namespace EADS.RazorDemo.Services
{
    public class APIService : IAPIService
    {
        private HttpClient client;
        private readonly string _baseAdress;
        public APIService(string? baseAdress = "")
        {
            _baseAdress = baseAdress!;
            client = new HttpClient();
            client.BaseAddress = new Uri(_baseAdress);
        }
        public async Task<bool> Delete(string id)
        {
            var response = await client.DeleteAsync(client.BaseAddress!.ToString() + $"/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<DemoPresentationObjectDTO> Get(string id, string passPhrase)
        {
            var request = new EADSRequestGetDTO() { Id = id, PassPhrase = passPhrase };
            var response = await client.PostAsJsonAsync(client.BaseAddress.ToString() + $"/", request);
            return null;
        }

        public Task<string> Post(DemoPresentationObjectDTO demoPresentationObjectDTO, string passPhrase)
        {
            throw new NotImplementedException();
        }
    }
    public interface IAPIService
    {
        Task<string> Post(DemoPresentationObjectDTO demoPresentationObjectDTO, string passPhrase);
        Task<DemoPresentationObjectDTO> Get(string id, string passPhrase);
        Task<bool> Delete(string id);
    }
}

