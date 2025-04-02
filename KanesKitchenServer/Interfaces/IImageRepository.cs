using SharedLibrary.DTOs.EShop;
using SharedLibrary.Models.Eshop;
using SharedLibrary.Responses;

namespace KanesKitchenServer.Interfaces
{
    public interface IImageRepository
    {
        Task<GeneralResponse> AddImage(int productId, string url);
        Task<GeneralResponse> DeleteImage(int imageId);
        Task<SasDto> GetSasToken();
    }
}
