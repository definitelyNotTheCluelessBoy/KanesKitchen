using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Models.Users
{
    public class Roles
    {

        [Key]
        public int Id { get; set; }
        public string Role { get; set; }
    }
}
