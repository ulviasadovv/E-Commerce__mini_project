using ECommerce.Application.DTOs;
using ECommerce.Application.Extensions;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities.Models;
using ECommerce.Domain.Interfaces;
using System.Linq.Expressions;

namespace ECommerce.Application.Services
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _repository;

        public UserManager(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Add(UserCreateDto userCreateDto)
        {
            var user = userCreateDto.ToUser();

            _repository.Add(user);
        }

        public UserDto Get(Expression<Func<User, bool>> predicate)
        {
            var user = _repository.Get(predicate);

            var userDto = user.ToUserDto();

            return userDto;
        }

        public List<UserDto> GetAll(Expression<Func<User, bool>>? predicate, bool asNoTracking)
        {
            var users = _repository.GetAll(predicate, asNoTracking);

            var userDtoList = new List<UserDto>();

            foreach (var item in users)
            {
                userDtoList.Add(new UserDto
                {
                    Id = item.Id,
                    FullName = item.FullName,
                    Balance = item.Balance,
                    
                });
            }

            return userDtoList;
        }

        public UserDto GetById(int id)
        {
            var user = _repository.GetById(id);

            var userDto = new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Balance = user.Balance,
            };

            return userDto;
        }

        public void Remove(int id)
        {
            var existEntity = _repository.GetById(id);

            if (existEntity == null) throw new Exception("Not found");

            _repository.Remove(existEntity);
        }

        public void Update(UserUpdateDto userUpdateDto)
        {
            var user = new User
            {
                Id = userUpdateDto.Id,
                FullName = userUpdateDto.FullName,
                Balance = (decimal)userUpdateDto.Balance,
                UpdatedAt = (DateTime)userUpdateDto.UpdatedAt,
            };

            _repository.Update(user);
        }
    }
}
