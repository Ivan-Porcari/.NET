using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPurchasedService
    {
        PurchasedDto GetPurchasedByCustomerName(string customerName);
        PurchasedDto GetPurchasedByCustomerId(int customerId);
        bool AddProductToCart(string customerName, Guid productId);
        bool RemoveProductFromCart(string customerName, Guid productId);
    }
}
