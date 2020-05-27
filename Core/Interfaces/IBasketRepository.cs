using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
  public  interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAync(string basketId);

        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);

        Task<bool> DeleteBasketAync(string basketId);
         
    
    }
}
