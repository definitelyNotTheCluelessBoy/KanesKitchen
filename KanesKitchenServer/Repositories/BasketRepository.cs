using KanesKitchenServer.Data;
using KanesKitchenServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.DTOs.EShop;
using SharedLibrary.Models.Eshop;
using SharedLibrary.Responses;

namespace KanesKitchenServer.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly AppDBContext _context;
        public BasketRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<GeneralResponse> AddProductToBasketAsync(AddProductToBasketDto addProductToBasketDto)
        {
            int amount = addProductToBasketDto.Amount;
            int productId = addProductToBasketDto.ProductId;
            int userId = addProductToBasketDto.UserId;

            var user =  await _context.Users.FindAsync(userId);
            if (user == null) { return new GeneralResponse (false,"User not found."); }
            var product = await _context.Products.FindAsync(productId);
            if (product == null) { return new GeneralResponse(false, "Product not found."); }
            
            var basket = await _context.Baskets.FirstOrDefaultAsync(b => b.UserId == userId && b.ProductId == productId);

            if (amount > product.ProductStock) { return new GeneralResponse(false, "Not enough stock."); }

            if (basket == null)
            {
                basket = new Basket { UserId = userId, ProductId = productId, Number = amount };
                await _context.Baskets.AddAsync(basket);
                product.ProductStock -= amount;
                _context.SaveChanges();
                return new GeneralResponse(true, "Product added to basket.");
            }
            else
            {
                basket.Number += amount;
                product.ProductStock -= amount;
                _context.SaveChanges();
                return new GeneralResponse(true, "Product amount updated.");
            }
            
        }

        public async  Task<GeneralResponse> ClearBasketAsync(int userId)
        {
            var basket = _context.Baskets.Where(b => b.UserId == userId);
            _context.Baskets.RemoveRange(basket);
            _context.SaveChanges();
            return new GeneralResponse(true, "Basket cleared.");

        }

        public async Task<GeneralResponse> DeleteProductFromBasketAsync(int userId, int productId)
        {
            var basket = await _context.Baskets.FirstOrDefaultAsync(b => b.UserId == userId && b.ProductId == productId);
            if (basket == null) { return new GeneralResponse(false, "Product not found in basket."); }
            _context.Baskets.Remove(basket);
            _context.SaveChanges();
            return new GeneralResponse(true, "Product removed from basket.");
        }

        public Task<List<Basket>> GetBasketAsync(int userId)
        {
            var basket = _context.Baskets.Where(b => b.UserId == userId).Include(b => b.Product).ToListAsync();
            return basket;
        }

      
    }
}
