using SharedLibrary.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models.Eshop
{
    public class Basket
    {
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        public int? Number { get; set; }
    }
}
