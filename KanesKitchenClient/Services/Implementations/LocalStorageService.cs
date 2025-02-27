using Blazored.LocalStorage;

namespace KanesKitchenClient.Services.Implementations
{
    public class LocalStorageService
    {
        private const string _storageKey = "authentication-token";
        private readonly ILocalStorageService _localStorage;
        
        public LocalStorageService(ILocalStorageService localStorageService)
        {
            _localStorage = localStorageService;
        }

        public async Task SaveToken(string token)
        {
            await _localStorage.SetItemAsStringAsync(_storageKey, token);
        }

        public async Task<string> GetToken()
        {
            return await _localStorage.GetItemAsStringAsync(_storageKey);
        }

        public async Task RemoveToken()
        {
            await _localStorage.RemoveItemAsync(_storageKey);
        }
    }
}
