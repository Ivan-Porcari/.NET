using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {


        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ICollection<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public ICollection<Customer> GetAllCustomers()
        {
            return _context.Users.OfType<Customer>().ToList();
        }

        public ICollection<Admin> GetAllAdmins()
        {
            return _context.Users.OfType<Admin>().ToList();
        }
        public User GetByName(string name)
        {
            var userEntity = _context.Users.FirstOrDefault(u => u.Name == name);
            if (userEntity == null)
            {
                throw new ArgumentException("El usuario no existe");
            }

            return userEntity;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var userToDelete = _context.Users.Find(id);
            if (userToDelete != null)
            {
                userToDelete.Activo = false;
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("El usuario no existe");
            }
        }


        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public User GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new ArgumentException("El usuario no existe");
            }
            return user;
        }

    }
}
