using Domain.Interfaces.Services;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Services
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        private readonly IProductRepository _produtoRepository;
        public ProductService(IProductRepository repository) : base(repository)
        {
            _produtoRepository = repository;
        }

        public IEnumerable<Product> GetByName(string name)
        {
            return _produtoRepository.GetByName(name);
        }

        public IEnumerable<Product> GetProductByCategory(int categoryId)
        {
            return _produtoRepository.GetProductByCategory(categoryId);
        }
    }
}
