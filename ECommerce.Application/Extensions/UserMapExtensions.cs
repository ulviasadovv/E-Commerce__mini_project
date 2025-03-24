using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities.Enums;
using ECommerce.Domain.Entities.Models;

namespace ECommerce.Application.Extensions;

public static class UserMapExtensions
{
    public static User ToUser(this UserCreateDto createDto)
    {
        return new User
        {
            Type = (UserType)createDto.Type,
            FullName = createDto.FullName,
            Balance = (decimal)createDto.Balance,
            Password = createDto.Password,
        };
    }

    public static UserDto ToUserDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            FullName = user.FullName,
            Balance = user.Balance,
        };
    }
}
