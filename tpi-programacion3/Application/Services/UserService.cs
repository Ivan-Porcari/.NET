using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ICollection<UserDto> GetAll()
        {
            var users = _userRepository.GetAllUsers();
            return users.Select(u => new UserDto { Id = u.Id, Name = u.Name, Email = u.Email, UserType = u.UserType }).ToList();
        }

        public ICollection<UserDto> GetAllCustomers()
        {
            var customers = _userRepository.GetAllCustomers();
            return customers.Select(c => new UserDto { Id = c.Id, Name = c.Name, Email = c.Email, UserType = c.UserType}).ToList();
        }

        public ICollection<UserDto> GetAllAdmins()
        {
            var admins = _userRepository.GetAllAdmins();
            return admins.Select(a => new UserDto { Id = a.Id, Name = a.Name, Email = a.Email, UserType = a.UserType}).ToList();
        }

        public User GetByName(string name)
        {
            var user = _userRepository.GetByName(name);
            return user;
        }

        public void DeleteUser(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user != null)
            {
                user.Activo = false;
                _userRepository.UpdateUser(user);
            }
            else
            {
                throw new Exception("El usuario no existe");
            }
        }

        public UserDto GetById(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user != null)
            {
                return new UserDto { Name = user.Name, Email = user.Email, UserType = user.UserType};
            }
            else
            {
                throw new Exception("El usuario no existe");
            }
        }

        public UserDto Create(UserSaveRequest user)
        {
            switch (user.UserType.ToLower())
            {
                case "admin":
                    var newAdmin = new Admin
                    {
                        Name = user.Name,
                        Email = user.Email,
                        Password = user.Password,
                        Activo = true
                    };
                    _userRepository.AddUser(newAdmin);
                    return new UserDto { Name = newAdmin.Name, Email = newAdmin.Email, UserType = newAdmin.UserType};

                case "customer":
                    var newCustomer = new Customer
                    {
                        Name = user.Name,
                        Email = user.Email,
                        Password = user.Password,
                        Activo = true
                    };
                    _userRepository.AddUser(newCustomer);
                    return new UserDto { Name = newCustomer.Name, Email = newCustomer.Email, UserType = newCustomer.UserType};

                default:
                    throw new ArgumentException("Error en Rol de User");
            }
        }



        public UserDto UpdateUser(int id, UserSaveRequest user)
        {
            var NotNullUser = _userRepository.GetUserById(id);
            if (NotNullUser == null)
            {
                throw new ArgumentException("El usuario no existe");
            }

            NotNullUser.Name = user.Name;
            NotNullUser.Email = user.Email;

            _userRepository.UpdateUser(NotNullUser);
            return new UserDto { Name = NotNullUser.Name, Email = NotNullUser.Email, UserType = NotNullUser.UserType };
        }

    }
}
