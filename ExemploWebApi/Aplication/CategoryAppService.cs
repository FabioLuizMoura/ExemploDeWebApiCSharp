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
    public class CategoryAppService : AppServiceBase<Category>, ICategoryAppService
    {
        private readonly ICategoryService _categoryService;
        public CategoryAppService(ICategoryService categoryService) : base(categoryService)
        {
            _categoryService = categoryService;
        }
    }
}
