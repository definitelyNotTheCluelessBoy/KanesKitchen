using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KanesKitchenServer.Models
{
    public class Roles
    {
        
        [Key]
        public int Id { get; set; }
        public string Role { get; set; }
    }
}
