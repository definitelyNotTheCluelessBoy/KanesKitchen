using KanesKitchenServer.Data;
using KanesKitchenServer.Interfaces;
using SharedLibrary.Models.Eshop;
using SharedLibrary.Responses;

namespace KanesKitchenServer.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly AppDBContext _context;

        public ImageRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<GeneralResponse> AddImage(int productId, string url)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) { return new GeneralResponse(false, "Product not found.");}
            await _context.Images.AddAsync(new Image { ImageUrl = url, ProductId = productId });
            await _context.SaveChangesAsync();
            return new GeneralResponse(true, "Image added.");
        }

        public async Task<GeneralResponse> DeleteImage(int imageId)
        {
            var image = await _context.Images.FindAsync(imageId);
            if (image == null) { return new GeneralResponse(false, "Image not found."); }
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
            return new GeneralResponse(true, "Image removed.");
        }
    }
}
