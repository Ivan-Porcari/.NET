using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AdminRepository : EfRepository<Admin>, IAdminRepository
    {
        public AdminRepository(ApplicationDbContext context) : base(context)
        {
        }

        public AdminDto? GetAdminById(int id)
        {
            var admin = _context.Admins.SingleOrDefault(a => a.Id == id);
            return admin != null ? AdminDto.Create(admin) : null;
        }

        public List<AdminDto> GetAllAdmins()
        {
            var admins = _context.Admins.ToList();
            return AdminDto.CreateList(admins);
        }


    }
}
