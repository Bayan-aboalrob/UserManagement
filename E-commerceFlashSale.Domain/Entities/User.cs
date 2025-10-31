namespace UserManagement.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }= String.Empty;
        public string PasswordHash { get; set; } = String.Empty;
        public string Role { get; set; } = String.Empty ;
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
