using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAdminService
    {
        AdminDto GetAdminById(int id);
        ICollection<AdminDto> GetAllAdmins();
    }
}
