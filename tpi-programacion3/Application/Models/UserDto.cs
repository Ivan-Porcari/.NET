using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string UserType { get; set; } = string.Empty;

        public static UserDto Create(User user)
        {
            var dto = new UserDto();
            dto.Id = user.Id;
            dto.Name = user.Name;
            dto.Email = user.Email;
            dto.Password = user.Password;
            dto.UserType = user.UserType;

            return dto;
        }

    }
}
