using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Infra.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public IEnumerable<Product> GetByName(string nome)
        {
            return db.Products.Where(x => x.Title == nome);
        }

        public IEnumerable<Product> GetProductByCategory(int categoryId)
        {
            return db.Products.Include("Category").Where(x => x.CategoryId == categoryId).ToList();
        }
    }
}
