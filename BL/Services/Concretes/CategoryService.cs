using BL.Services.Abstractions;
using DAL.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Concretes
{
    public class CategoryService : ICategoryService
    {
        readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<ICollection<SelectListItem>> SelectCategories()
        {
            return await _repository.SelectCategoriesAsync();
        }
    }
}
