using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        ICollection<User> GetAllUsers();
        ICollection<Customer> GetAllCustomers();
        ICollection<Admin> GetAllAdmins();
        User GetByName(string name);
        void AddUser(User user);
        void DeleteUser(int id);
        User GetUserById(int id);
        void UpdateUser(User user);
    }

}