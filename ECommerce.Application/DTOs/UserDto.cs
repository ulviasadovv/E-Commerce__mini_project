using ECommerce.Domain.Entities.Enums;

namespace ECommerce.Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public decimal? Balance { get; set; } = 0;
    }

    public class UserCreateDto
    {
        public UserType? Type { get; set; } = UserType.User;
        public string FullName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public decimal? Balance { get; set; } = 0;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }

    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public decimal? Balance { get; set; }
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }

}
