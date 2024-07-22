using Application.Interfaces;
using Application.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public AdminDto GetAdminById(int id)
        {
            var admin = _adminRepository.GetById(id);
            return admin != null ? AdminDto.Create(admin) : null;
        }

        public ICollection<AdminDto> GetAllAdmins()
        {
            var admins = _adminRepository.GetAll();
            return AdminDto.CreateList(admins);
        }
    }
}
