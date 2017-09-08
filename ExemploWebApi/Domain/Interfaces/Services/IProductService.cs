using Domain.Models;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IProductService : IServiceBase<Product>
    {
        IEnumerable<Product> GetByName(string name);
        IEnumerable<Product> GetProductByCategory(int categoryId);
    }
}
