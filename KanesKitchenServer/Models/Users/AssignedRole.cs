namespace KanesKitchenServer.Models.Users
{
    public class AssignedRoles
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
