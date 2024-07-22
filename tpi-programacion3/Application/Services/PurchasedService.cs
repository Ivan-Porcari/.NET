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
    public class PurchasedService : IPurchasedService
    {
        private readonly IPurchasedRepository _purchasedRepository;

        public PurchasedService(IPurchasedRepository purchasedRepository)
        {
            _purchasedRepository = purchasedRepository;
        }

        public PurchasedDto GetPurchasedById(int id)
        {
            var purchased = _purchasedRepository.GetById(id);
            return purchased != null ? PurchasedDto.Create(purchased) : null;
        }

        public ICollection<PurchasedDto> GetAllPurchased()
        {
            var purchased = _purchasedRepository.GetAll();
            return PurchasedDto.CreateList(purchased);
        }


    }
}
