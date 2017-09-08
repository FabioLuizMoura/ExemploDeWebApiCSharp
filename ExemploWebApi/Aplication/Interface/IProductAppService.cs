using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    public interface IProductAppService : IAppServiceBase<Product>
    {
        IEnumerable<Product> GetByName(string name);
        IEnumerable<Product> GetProductByCategory(int categoryId);
    }
}
