using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models.Users
{
    public record CustomUserClaims(
        string Id = null!,
        string UserName = null!,
        string Email = null!,
        string Role = null!
    );
}
