using Aplication.Interface;
using Domain.Interfaces.Services;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication
{
    public class ProductAppService : AppServiceBase<Product>, IProductAppService
    {
        private readonly IProductService _productService;
        public ProductAppService(IProductService productService) : base (productService)
        {
            _productService = productService;
        }
        public IEnumerable<Product> GetByName(string name)
        {
            return _productService.GetByName(name);
        }
        public IEnumerable<Product> GetProductByCategory(int categoryId)
        {
            return _productService.GetProductByCategory(categoryId);
        }
    }
}
