using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace KanesKitchenServer.Models.EShop
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public double ProductPrice { get; set; }
        public string ProductImage { get; set; }
    }
}
