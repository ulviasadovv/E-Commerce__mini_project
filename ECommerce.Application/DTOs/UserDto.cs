using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public decimal Balance { get; set; }
    }

    public class UserCreateDto : UserDto
    {
        public UserType Type { get; set; }
        public string FullName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public decimal Balance { get; set; }
    }

    public class UserUpdateDto : UserDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public decimal Balance { get; set; }
    }

}
