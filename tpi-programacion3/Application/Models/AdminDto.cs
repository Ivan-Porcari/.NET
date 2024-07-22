using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class AdminDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public DateTime DateCreated { get; set; }

        public static AdminDto Create(Admin admin)
        {
            return new AdminDto
            {
                Id = admin.Id,
                Name = admin.Name,
                LastName = admin.LastName,
                Password = admin.Password,
                Email = admin.Email,
                UserName = admin.UserName,
                UserType = admin.UserType,
                DateCreated = admin.DateCreated
            };
        }

        public static List<AdminDto> CreateList(IEnumerable<Admin> admins)
        {
            return admins.Select(a => Create(a)).ToList();
        }
    }
}
}
