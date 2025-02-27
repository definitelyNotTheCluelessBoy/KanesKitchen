using SharedLibrary.DTOs.EShop;

namespace KanesKitchenClient.Services.Interfaces
{
    public interface IImageService
    {
        Task<SasDto> GetSasTokenAsync();
    }
}
