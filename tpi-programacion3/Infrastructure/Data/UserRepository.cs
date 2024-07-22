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

        public User? GetUserByUserName(string userName)
        {
            return _context.Users.SingleOrDefault(p => p.UserName == userName);
        }


        //private readonly ApplicationContext _context;
        //public UserRepository(ApplicationContext context)
        //{
        //    _context = context;
        //}
        //public User? Get(string name) // devuelve un usuario o devuelve null

        //{
        //    return _context.Users.FirstOrDefault(u => u.Name == name);
    }
    }
}
