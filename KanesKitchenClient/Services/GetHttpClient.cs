using KanesKitchenClient.Services.Implementations;
using System.Net.Http.Headers;

namespace KanesKitchenClient.Services
{
    public class GetHttpClient
    {
        private const string _headerKey = "Authorization";
        IHttpClientFactory _clientFactory;
        LocalStorageService _localStorageService;

        public GetHttpClient(IHttpClientFactory httpClientFactory, LocalStorageService localStorageService) {
            _clientFactory = httpClientFactory;
            _localStorageService = localStorageService;
        }

        public async Task<HttpClient> GetPrivateHttpClient()
        {
            var client = _clientFactory.CreateClient("ApiClient");
            var token = await _localStorageService.GetToken();
            
            if (token == null)
            {
                return client;
            }

            var deserialized = Serialization.Deserialize<Session>(token);
            if (deserialized == null)
            {
                return client;
            }

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", deserialized.Token);
            return client;
        }

        public async Task<HttpClient> GetPublicHttpClient()
        {
            var client = _clientFactory.CreateClient("ApiClient");
            client.DefaultRequestHeaders.Remove(_headerKey);
           
            return client;
        }
    }
}
