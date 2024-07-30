using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        ICollection<UserDto> GetAll();
        ICollection<UserDto> GetAllCustomers();
        ICollection<UserDto> GetAllAdmins();
        User GetByName(string name);
        UserDto Create(UserSaveRequest user);
        void DeleteUser(int id);
        UserDto GetById(int id);
        UserDto UpdateUser(int id, UserSaveRequest user);
    }
}
