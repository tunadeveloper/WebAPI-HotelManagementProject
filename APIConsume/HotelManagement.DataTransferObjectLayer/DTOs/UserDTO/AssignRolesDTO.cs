namespace HotelManagement.DataTransferObjectLayer.DTOs.UserDTO
{
    public class AssignRolesDTO
    {
        public int UserId { get; set; }
        public List<string> RoleNames { get; set; } = new();
    }
}
