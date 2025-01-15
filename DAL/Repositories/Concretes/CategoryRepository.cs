using CORE.Models;
using DAL.Contexts;
using DAL.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Concretes
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<SelectListItem>> SelectCategoriesAsync()
        {
            return await _context.Categories.Select(c=>new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.CategoryName,
            }).ToListAsync() ?? new List<SelectListItem>();
        }
    }
}
