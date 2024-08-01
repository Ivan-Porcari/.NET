using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPurchasedRepository
    {
        Purchased GetPurchasedByCustomerId(int customerId);
        Purchased GetPurchasedByCustomerName(string customerName);
        bool UpdatePurchased(Purchased purchased);
        bool RemoveProductFromCart(string customerName, Guid productId);
        IEnumerable<Purchased> GetAllPurchases();


    }
}
